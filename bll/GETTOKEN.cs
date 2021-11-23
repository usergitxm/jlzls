using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading;

namespace bll
{
   public class GETTOKEN
    {
       private static GETTOKEN pushPayInfo;
        private static readonly object lockObj = new object();
        private static string token = null;
        private GETTOKEN() {      }
        public static GETTOKEN GetInstance()
        {
            if(pushPayInfo == null)
            {
                lock (lockObj)
                {
                    if(pushPayInfo == null)
                    {
                        pushPayInfo = new GETTOKEN();
                    }
                }
            }
            return pushPayInfo;
        }


        public void SetToken()
        {
                //LogUtil.WriteLog("1111111111111111456");
            token = null;
        }

          public static string GetToken() 
          {   
            if(token == null)
            {
            //    LogUtil.WriteLog("222222222222222222");
                string Url = "https://api.weixin.qq.com/cgi-bin/token";
                string RequestPara = "grant_type=client_credential&appid=" + PayConfig.AppId + "&secret=" + PayConfig.AppSecret;
                string result = HttpUtil.Send(RequestPara, Url);
             
                OpenModel modeltoken = JsonConvert.DeserializeObject<OpenModel>(result);          
                token = modeltoken.access_token;
                //new Thread(a => {
                //    Thread.Sleep(int.Parse(modeltoken.expires_in));
                //    token = null;
                //}).Start();
                return token;
            }
            return token;
        }
    }
}
