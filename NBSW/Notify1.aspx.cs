using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;
using THKModel;

namespace NBSW
{
    public partial class Notify1 : System.Web.UI.Page
    {
        private class ReturnMsg
        {
            public string errcode { get; set; }
            public string errmsg { get; set; }
            public string msgid { get; set; }
        }
        public string OpenId;
        public string acc;
        public DataTable dt = null;
        public DateTime Time = DateTime.Now;
        string strReturn = string.Empty;
        private static Object _lockObj3 = new Object();
        protected void Page_Load(object sender, EventArgs e)
        {



            LogUtil.WriteLog("notify1加载。。。。");
            //创建ResponseHandler实例
            ResponseHandler resHandler = new ResponseHandler(Context);
            resHandler.setKey(PayConfig.AppKey);

            string error = "";
            if (resHandler.isWXsign(out error))
            {
                #region 协议参数=====================================

                //--------------协议参数--------------------------------------------------------
                //SUCCESS/FAIL此字段是通信标识，非交易标识，交易是否成功需要查
                string return_code = resHandler.getParameter("return_code");
                //返回信息，如非空，为错误原因签名失败参数格式校验错误
                string return_msg = resHandler.getParameter("return_msg");
                //微信分配的公众账号 ID
                string appid = resHandler.getParameter("appid");

                //以下字段在 return_code 为 SUCCESS 的时候有返回--------------------------------
                //微信支付分配的商户号
                string mch_id = resHandler.getParameter("mch_id");
                //微信支付分配的终端设备号
                string device_info = resHandler.getParameter("device_info");
                //微信分配的公众账号 ID
                string nonce_str = resHandler.getParameter("nonce_str");
                //业务结果 SUCCESS/FAIL
                string result_code = resHandler.getParameter("result_code");
                //错误代码
                string err_code = resHandler.getParameter("err_code");
                //结果信息描述
                string err_code_des = resHandler.getParameter("err_code_des");

                //以下字段在 return_code 和 result_code 都为 SUCCESS 的时候有返回---------------
                //-------------业务参数---------------------------------------------------------
                //用户在商户 appid 下的唯一标识
                string openid = resHandler.getParameter("openid");
                //用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
                string is_subscribe = resHandler.getParameter("is_subscribe");
                //JSAPI、NATIVE、MICROPAY、APP
                string trade_type = resHandler.getParameter("trade_type");
                //银行类型，采用字符串类型的银行标识
                string bank_type = resHandler.getParameter("bank_type");
                //订单总金额，单位为分
                string total_fee = resHandler.getParameter("total_fee");
                //货币类型，符合 ISO 4217 标准的三位字母代码，默认人民币：CNY
                string fee_type = resHandler.getParameter("fee_type");
                //微信支付订单号
                string transaction_id = resHandler.getParameter("transaction_id");
                //商户系统的订单号，与请求一致。
                string out_trade_no = resHandler.getParameter("out_trade_no");
                //商家数据包，原样返回
                string attach = resHandler.getParameter("attach");
                //支 付 完 成 时 间 ， 格 式 为yyyyMMddhhmmss，如 2009 年12 月27日 9点 10分 10 秒表示为 20091227091010。时区为 GMT+8 beijing。该时间取自微信支付服务器
                string time_end = resHandler.getParameter("time_end");

                #endregion 协议参数=====================================

                //支付成功
                if (!out_trade_no.Equals("") && return_code.Equals("SUCCESS") && result_code.Equals("SUCCESS"))
                {
                    lock (_lockObj3)
                    {
                        try
                        {
                            #region 业务处理
                            // attach = "49|5384";
                            var N_BUSINESS_ID = attach.Split('|')[0].ToString();
                            var PayMoney = attach.Split('|')[1].ToString();
                            decimal businessid = decimal.Parse(N_BUSINESS_ID);
                            int paymentWay = 0;
                            //string sql22 = @"select  a.n_business_id 业务编号 from bz_application a  where a.n_application_id='" + N_BUSINESS_ID + @"'";
                            //DataTable dt2 = new Sys_Command().GetDataTable(sql22);
                            string sql2 = "select* from bz_detail d where d.n_business_id='" + N_BUSINESS_ID + @"'";
                            DataTable dtdetail = new Sys_Command().GetDataTable(sql2);
                            decimal jineAmount = decimal.Parse(PayMoney);

                            Bz_Charge chargeMonde = new Bz_Charge(); //报装收费实体类
                            //N_CHARGE_ID
                            chargeMonde.N_CHARGE_ID = UserDAO.getNextandIdentity("BZ_CHARGE", "N_CHARGE_ID");
                            chargeMonde.N_BUSINESS_ID = businessid;//业务编号
                            chargeMonde.N_DETAIL_ID = decimal.Parse(dtdetail.Rows[0]["N_DETAIL_ID"].ToString());//费用ID
                            chargeMonde.N_CHARGE_AMOUNT = jineAmount;//本次缴费金额。
                            chargeMonde.N_PAYMENT_WAY = paymentWay;//支付方式
                            chargeMonde.N_CHARGE_OPERATOR_ID = decimal.Parse(PayConfig.CASHIER);
                            chargeMonde.D_CHARGE_OPERATION_TIME = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            string sql = @"select count(*) countNumber from bz_charge b where b.n_business_id = '" + businessid + "' and b.n_Charge_State = 1";
                            DataTable dt = new Sys_Command().GetDataTable(sql);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                chargeMonde.N_STAGE_CUR = decimal.Parse(dt.Rows[0]["countNumber"].ToString()) + 1;
                            }
                            else
                            {
                                chargeMonde.N_STAGE_CUR = 1;//分期数
                            }
                            Yx_Accounting aMondel = UserDAO.GetCurrentAccounting("", "");//会计月份
                            if (aMondel != null)
                            {
                                chargeMonde.N_CHARGE_YEAR = decimal.Parse(aMondel.N_Accounting_Year.ToString());//收费年
                                chargeMonde.N_CHARGE_MONTH = decimal.Parse(aMondel.N_Accounting_Month.ToString());//收费月
                            }
                            else
                            {
                                chargeMonde.N_CHARGE_YEAR = decimal.Parse(DateTime.Now.ToString("yyyy"));//收费年
                                chargeMonde.N_CHARGE_MONTH = decimal.Parse(DateTime.Now.ToString("MM"));//收费月
                            }
                            chargeMonde.N_CHARGE_STATE = 1;//已收
                            chargeMonde.N_CHARGE_OVER_STATE = 0;//扎帐状态
                            chargeMonde.N_CHARGE_FS = 2;//收费方式结算


                            Bz_Detail detailMondel = new Bz_Detail();//费用明细实体类
                            detailMondel.N_DETAIL_ID = decimal.Parse(dtdetail.Rows[0]["N_DETAIL_ID"].ToString());
                            detailMondel.N_RECEIVED_AMOUNT = decimal.Parse(dtdetail.Rows[0]["n_received_amount"].ToString()) + decimal.Parse(PayMoney);
                            detailMondel.N_OWE_AMOUNT = decimal.Parse(dtdetail.Rows[0]["n_total_amount"].ToString()) - decimal.Parse((detailMondel.N_RECEIVED_AMOUNT.ToString()));

                            int rowid = UserDAO.addCharge(chargeMonde, detailMondel, "", "");
                            if (rowid > 0)
                            {
                                GETTOKEN t = GETTOKEN.GetInstance();
                                var token = GETTOKEN.GetToken();
                                string msg = UserDAO.WxSendMsg(OpenId, PayMoney, token);
                                string result = WeChatPushNotice(token, msg);
                                //缴费成功
                                string sql1 = @"update bz_detail d set d.d_charge_date=to_date('" + DateTime.Now.ToString() + @"','yyyy-mm-dd hh24 mi:ss') where d.n_business_id='" + N_BUSINESS_ID + @"'";
                                new Sys_Command().SQLExcute(sql1);
                            }
                            else
                            {
                                //缴费失败
                            }
                            Response.Write(" <xml><return_code><![CDATA[SUCCESS]]></return_code> <return_msg><![CDATA[OK]]></return_msg></xml>");
                            #endregion

                        }
                        catch (Exception ex)
                        {
                            LogUtil.WriteLog("业务处理错误：" + ex.Message);
                        }

                    }
                }
                else
                {
                    LogUtil.WriteLog("Notify1 页面  支付失败，支付信息   total_fee= " + total_fee + "、err_code_des=" + err_code_des + "、result_code=" + result_code);
                }
            }
            else
            {
                LogUtil.WriteLog("Notify1 页面  isWXsign= false ，错误信息：" + error);
            }

            Response.End();
        }
        private OpenModel GetAccess_token(string appid, string secret)
        {
            string strUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret;//获取appid及secret
            OpenModel mode = new OpenModel();
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(strUrl);
            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();//在这里对Access_token 赋值  //如错误需添加白名单以刷新Access_Token
                OpenModel token = new OpenModel();
                token = JsonConvert.DeserializeObject<OpenModel>(content);
                mode.access_token = token.access_token;
                mode.expires_in = token.expires_in;
            }
            return mode;
        }
        public string WeChatPushNotice(string accessToken, string contentMsg)
        {
            string promat = "";
            //需要提交的数据
            byte[] bs = Encoding.UTF8.GetBytes(contentMsg);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + accessToken + "");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            HttpWebResponse respon = (HttpWebResponse)req.GetResponse();
            Stream stream = respon.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                promat = reader.ReadToEnd();
            }
            ReturnMsg y = JsonConvert.DeserializeObject<ReturnMsg>(promat);
            promat = y.errmsg;

            return promat;
        }
    }
}