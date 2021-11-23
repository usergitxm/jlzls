using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;
using bll;
using System.Xml;

namespace NBSW
{
    public partial class WeiPay1 : System.Web.UI.Page
    {
        public double userAmount;
        public DataTable dtFee;
        public string WaterUse;
        public double UseMoney;
        public string UserAmount;
        public string UseMonth;

        #region 页面输出 不用操作

        public static string Code = "";     //微信端传来的code

        public static string PrepayId = ""; //预支付ID
        public static string Sign = "";     //为了获取预支付ID的签名
        public static string PaySign = "";  //进行支付需要的签名
        public static string Package = "";  //进行支付需要的包
        public static string TimeStamp = ""; //时间戳 程序生成 无需填写
        public static string NonceStr = ""; //随机字符串  程序生成 无需填写

        #endregion

        #region 支付相关参数 ，以下参数请从需要支付的页面通过get方式传递过来

        protected string OrderSN = ""; //商户自己订单号

        protected string Body = ""; //商品描述
        protected string TotalFee = "";  //总支付金额，单位为：分，不能有小数
        protected string Attach = ""; //用户自定义参数，原样返回
        protected string UserOpenId = "";//微信用户openid

        #endregion
        public void Fun_ApplyPra()
        {
            LogUtil.WriteLog("Fun_ApplyPra 已经进入");
            this.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>SavePay1();</script>", false);
        }
        /// <summary>
        /// 获取传递的支付参数，并绑定页面上
        /// </summary>
        private void BindData()
        {
            this.OrderSN = this.Request.QueryString["OrderSN"];
            this.Attach = this.Request.QueryString["Attach"];
            //  Fun_ApplyPra();
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
            BindData();
            Fun_ApplyPra();
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            this.BindData();
            LogUtil.WriteLog("============ 单次支付开始 ===============");
            LogUtil.WriteLog(string.Format("传递支付参数：OrderSN={0}、Body={1}、TotalFee={2}、Attach={3}、UserOpenId={4}",
           this.OrderSN, this.Body, this.TotalFee, this.Attach, this.UserOpenId));
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

            packageReqHandler.setParameter("appid", PayConfig.AppId);
            packageReqHandler.setParameter("body", this.Body); //商品信息 127字符
            packageReqHandler.setParameter("mch_id", PayConfig.MchId);
            //packageReqHandler.setParameter("device_info", "WEB");//终端设备号(门店号或收银设备ID)，注意：PC网页或公众号内支付请传"WEB"
            packageReqHandler.setParameter("nonce_str", NonceStr);//随机字符串 不长于32位
                                                                  //packageReqHandler.setParameter("sign", Sign);//签名
            packageReqHandler.setParameter("notify_url", PayConfig.NotifyUrl1);
            packageReqHandler.setParameter("openid", this.UserOpenId);
            packageReqHandler.setParameter("out_trade_no", this.OrderSN); //商家订单号
            packageReqHandler.setParameter("spbill_create_ip", Page.Request.UserHostAddress); //用户的公网ip，不是商户服务器IP
            packageReqHandler.setParameter("trade_type", "JSAPI");
            packageReqHandler.setParameter("total_fee", Math.Ceiling((decimal.Parse(this.TotalFee) * 100)).ToString()); //商品金额,以分为单位(money * 100).ToString()
            if (!string.IsNullOrEmpty(this.Attach))
                packageReqHandler.setParameter("attach", this.Attach);//自定义参数 127字符

            #endregion 基本参数===========================

            #region sign===============================

            Sign = packageReqHandler.CreateMd5Sign("key", PayConfig.AppKey);
            LogUtil.WriteLog("WeiPay 页面  sign：" + Sign);

            #endregion sign===============================

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

            #endregion 获取package包======================

            #region 设置支付参数 输出页面  该部分参数请勿随意修改 ==============
            if (this.Attach.Length < 127)
            {
                var paySignReqHandler = new RequestHandler(Context);
                paySignReqHandler.setParameter("appId", PayConfig.AppId);
                paySignReqHandler.setParameter("timeStamp", TimeStamp);
                paySignReqHandler.setParameter("nonceStr", NonceStr);
                paySignReqHandler.setParameter("package", Package);
                paySignReqHandler.setParameter("signType", "MD5");
                PaySign = paySignReqHandler.CreateMd5Sign("key", PayConfig.AppKey);

                HiddenField1.Value = PayConfig.AppId;
                HiddenField2.Value = TimeStamp;
                HiddenField3.Value = NonceStr;
                HiddenField4.Value = Package;
                HiddenField5.Value = PaySign;
                LogUtil.WriteLog("签名:" + PayConfig.AppKey);
            }
            else
            {
                Response.Write("<script>alert('【系统提示】该用户由于欠费月份过多，咱不能微信缴费，如需缴费请前往营业大厅缴纳水费！')</script>");
            }
            LogUtil.WriteLog("WeiPay 页面  paySign：" + PaySign);

            #endregion 设置支付参数 输出页面  该部分参数请勿随意修改 ==============

            #endregion 支付操作============================

        }
        static Dictionary<string, object> JsonToDictionary(string JsonData)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Deserialize<Dictionary<string, object>>(JsonData);
            }
            catch (Exception )
            {
                return null;
            }

        }
    }
}