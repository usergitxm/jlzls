using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;

using Newtonsoft.Json;
using System.IO;
using System.Text;
using bll;

namespace SCJN
{
    /**
     * 
     * 作用：微信支付核心页面，该页面获取用户的支付信息显示网页上。
     *          通过其它配置参数和支付参数调用微信支付Api获取相关其它数据。
     *          通过点击页面“确认支付”按钮来发起支付操作
     * 作者：邹学典
     * 编写日期：2014-12-25
     * 备注：请注意相关支付数据、配置信息的正确
     * 
     * */
    public partial class WeiPay : System.Web.UI.Page
    {

        public double userAmount;
        public DataTable dtFee;
        public string WaterUse;
        public double UseMoney;
        public string UserAmount;
        public string UseMonth;

        //页面输出 不用操作
        public static string Code = "";     //微信端传来的code
        public static string PrepayId = ""; //预支付ID
        public static string Sign = "";     //为了获取预支付ID的签名
        public static string PaySign = "";  //进行支付需要的签名
        public static string Package = "";  //进行支付需要的包
        public static string TimeStamp = ""; //时间戳 程序生成 无需填写
        public static string NonceStr = ""; //随机字符串  程序生成 无需填写


        //支付相关参数 ，以下参数请从需要支付的页面通过get方式传递过来
        protected string OrderSN = ""; //商户自己订单号
        protected string Body = ""; //商品描述
        protected string TotalFee = "";  //总支付金额，单位为：分，不能有小数
        protected string Attach = ""; //用户自定义参数，原样返回
        protected string UserOpenId = "";//微信用户openid

        protected void Page_Load(object sender, EventArgs e)
        {

            this.BindData();

            LogUtil.WriteLog("============ 单次支付开始 ===============");
            LogUtil.WriteLog(string.Format("传递支付参数：OrderSN={0}、Body={1}、TotalFee={2}、Attach={3}、UserOpenId={4}",
           this.OrderSN, this.Body, this.TotalFee, this.Attach, this.UserOpenId));

            DataTable dt = UserDAO.numcall(OrderSN);
            if (dt.Rows.Count == 0)
            {
                #region 支付操作============================


                #region 基本参数===========================
                //时间戳 
                TimeStamp = TenpayUtil.getTimestamp();
                //随机字符串 
                NonceStr = TenpayUtil.getNoncestr();

                //创建支付应答对象
                var packageReqHandler = new RequestHandler(Context);
                //初始化
                packageReqHandler.init();

                //设置package订单参数  具体参数列表请参考官方pdf文档，请勿随意设置
                //            <appid>wx2421b1c4370ec43b</appid>
                //<attach>支付测试</attach>
                //<body>JSAPI支付测试</body>
                //<mch_id>10000100</mch_id>
                //<nonce_str>1add1a30ac87aa2db72f57a2375d8fec</nonce_str>
                //<notify_url>http://wxpay.weixin.qq.com/pub_v2/pay/notify.v2.php</notify_url>
                //<openid>oUpF8uMuAJO_M2pxb1Q9zNjWeS6o</openid>
                //<out_trade_no>1415659990</out_trade_no>
                //<spbill_create_ip>14.23.150.211</spbill_create_ip>
                //<total_fee>1</total_fee>
                //<trade_type>JSAPI</trade_type>
                //<sign>0CB01533B8C1EF103065174F50BCA001</sign>

                // 
                packageReqHandler.setParameter("appid", PayConfig.AppId);
                packageReqHandler.setParameter("body", this.Body); //商品信息 127字符
                packageReqHandler.setParameter("mch_id", PayConfig.MchId);
                //packageReqHandler.setParameter("device_info", "WEB");//终端设备号(门店号或收银设备ID)，注意：PC网页或公众号内支付请传"WEB"
                packageReqHandler.setParameter("nonce_str", NonceStr);//随机字符串 不长于32位
                                                                      //packageReqHandler.setParameter("sign", Sign);//签名
                packageReqHandler.setParameter("notify_url", PayConfig.NotifyUrl);
                packageReqHandler.setParameter("openid", this.UserOpenId);
                packageReqHandler.setParameter("out_trade_no", this.OrderSN); //商家订单号
                packageReqHandler.setParameter("spbill_create_ip", Page.Request.UserHostAddress); //用户的公网ip，不是商户服务器IP
                packageReqHandler.setParameter("trade_type", "JSAPI");
                packageReqHandler.setParameter("total_fee", Math.Ceiling((decimal.Parse(this.TotalFee) * 100)).ToString()); //商品金额,以分为单位(money * 100).ToString()
                if (!string.IsNullOrEmpty(this.Attach))
                    packageReqHandler.setParameter("attach", this.Attach);//自定义参数 127字符

                #endregion

                #region sign===============================
                Sign = packageReqHandler.CreateMd5Sign("key", PayConfig.AppKey);
                LogUtil.WriteLog("WeiPay 页面  sign：" + Sign);
                #endregion

                #region 获取package包======================
                packageReqHandler.setParameter("sign", Sign);

                string data = packageReqHandler.parseXML();
                LogUtil.WriteLog("WeiPay 页面  package（XML）：" + data);

                string prepayXml = HttpUtil.Send(data, "https://api.mch.weixin.qq.com/pay/unifiedorder");
                LogUtil.WriteLog("WeiPay 页面  package（Back_XML）：" + prepayXml);

                //获取预支付ID
                var xdoc = new XmlDocument();
                xdoc.LoadXml(prepayXml);
                XmlNode xn = xdoc.SelectSingleNode("xml");
                XmlNodeList xnl = xn.ChildNodes;
                if (xnl.Count > 7)
                {
                    PrepayId = xnl[7].InnerText;
                    Package = string.Format("prepay_id={0}", PrepayId);
                    LogUtil.WriteLog("WeiPay 页面  package：" + Package);
                }
                #endregion

                #region 设置支付参数 输出页面  该部分参数请勿随意修改 ==============
                var paySignReqHandler = new RequestHandler(Context);
                paySignReqHandler.setParameter("appId", PayConfig.AppId);
                paySignReqHandler.setParameter("timeStamp", TimeStamp);
                paySignReqHandler.setParameter("nonceStr", NonceStr);
                paySignReqHandler.setParameter("package", Package);
                paySignReqHandler.setParameter("signType", "MD5");
                PaySign = paySignReqHandler.CreateMd5Sign("key", PayConfig.AppKey);

                LogUtil.WriteLog("WeiPay 页面  paySign：" + PaySign);
                #endregion
                #endregion
            }
            else
            {
                Response.Write("<script>alert('已支付！');</script>");
                return;
            }
        }

        public void Fun_ApplyPra()
        {
            UseMoney = 0;
            dtFee = UserDAO.GetUserWaterFree(Attach.Substring(0, 13), "", "");
            userAmount = Convert.ToDouble(UserDAO.GetUser(Attach.Substring(0, 13)).Rows[0]["余额"].ToString());
            if (dtFee != null && dtFee.Rows.Count > 0)
            {
                foreach (DataRow dr in dtFee.Rows)
                {
                    if (Convert.ToInt32(dr["状态"]) == 0)
                    {
                        WaterUse = WaterUse + Convert.ToDouble(dr["用量"]);
                        if (Convert.ToDouble(dr["小计"]) > 0)
                        {
                            UseMoney = UseMoney + Convert.ToDouble(dr["小计"]) - userAmount;
                        }
                        else
                        {
                            UseMoney = UseMoney + Convert.ToDouble(dr["小计"]);
                        }
                        UseMonth += dr["月份"] + "|";
                        userAmount = 0;
                    }
                }
            }

            if (UseMoney <= 0)
            {
                Response.Write("<script>alert('没有需要缴纳的费用！');</script>");
                return;
            }
        }

        /// <summary>
        /// 获取传递的支付参数，并绑定页面上
        /// </summary>
        private void BindData()
        {
            this.OrderSN = this.Request.QueryString["OrderSN"];
            this.Attach = this.Request.QueryString["Attach"];
            Fun_ApplyPra();
            this.Body = this.Request.QueryString["Body"];
            //this.TotalFee =Math.Ceiling( decimal.Parse( this.Request.QueryString["TotalFee"].ToString())).ToString();
            this.TotalFee = this.Request.QueryString["TotalFee"].ToString();

            this.UserOpenId = this.Request.QueryString["UserOpenId"];
            this.Text2.Text = this.TotalFee;
            this.Text3.Text = this.Body;
            this.Text6.Text = this.OrderSN;
            this.lblAttach.Text = this.Attach;
            this.lblOpenId.Text = this.UserOpenId;
        }
        protected void btn1_Click(object sender, EventArgs e)
        {
            Fun_ApplyPra();
        }

    }



}
