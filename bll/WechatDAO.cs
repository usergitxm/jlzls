using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bll
{
   public class WechatDAO
    {
        private class ReturnMsg
        {
            public string errcode { get; set; }
            public string errmsg { get; set; }
            public string msgid { get; set; }
        }
     
        public static bool CheckPhoneIsAble(string input)
        {
            if (input.Length < 11)
            {
                return false;
            }
            //电信手机号码正则
            string dianxin = @"^1[3578][01379]\d{8}$";
            Regex regexDX = new Regex(dianxin);
            //联通手机号码正则
            string liantong = @"^1[34578][01256]\d{8}";
            Regex regexLT = new Regex(liantong);
            //移动手机号码正则
            string yidong = @"^(1[012345678]\d{8}|1[345678][012356789]\d{8})$";
            Regex regexYD = new Regex(yidong);
            if (regexDX.IsMatch(input) || regexLT.IsMatch(input) || regexYD.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string WxSendMsg(string OpenId, string name,string state,string token,string id)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + token;//向此链接地址POST数据发送模板消息
            string contentmsg = "{\"touser\": \"" + OpenId + "\"," +
                                        "\"template_id\": \"LygpUfNNLDEk0HP9nZ3AzOSrfRXHXMVEeCxdbiLUGKg\"," +
                                        "\"topcolor\": \"#0E90D2\"," +
                                        "\"data\": {" +
                                            "\"first\": {"
                                            +
                                                "\"value\": \"\"," +
                                                "\"color\": \"#0E90D2\"" +
                                            "}," +
                                            "\"keyword1\": {" +
                                                "\"value\": \"" + DateTime.Now.ToString() + "\"," +
                                                "\"color\": \"#FF0000\"" +
                                            "}," +
                                            "\"keyword2\": {" +
                                                "\"value\": \"" + name + "\"," +
                                                 "\"color\": \"#FF0000\"" +
                                            "}," +
                                             "\"keyword3\": {" +
                                                "\"value\": \"" + state + "\"," +
                                                "\"color\": \"#FF0000\"" +
                                            "}," +
                                            "\"remark\": {" +
                                                "\"value\": \"您当前的业务办理编号为："+id+"，请您留意微信公众号业务办理通知情况，我们会尽快给您处理。\"," +
                                                "\"color\": \"#173177\"" +
                                            "}" +
                                        "}" +
                                     "}";
            return WeChatPushNotice(token, contentmsg);
        }
        public static string WeChatPushNotice(string accessToken, string contentMsg)
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
