using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using Newtonsoft.Json;

namespace NBSW
{
    public partial class InstallationPay : System.Web.UI.Page
    {
        public string OpenId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserOpenId();
                try
                {
                    OpenId = Session["OpenId"].ToString();
                }
                catch (Exception)
                {

                    return;
                }

            }
        }
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenId = Session["OpenId"].ToString();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('获取信息超时，请稍后再试！');</script>");
                return;
            }

        }
        private void GetUserOpenId()
        {
            string code = Request.QueryString["code"];
            if (string.IsNullOrEmpty(code))
            {
                LogUtil.WriteLog(" ============ Code不存在获取 =====================");
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + PayConfig.AppId + "&redirect_uri=" + PayConfig.SendUrl6 + "&response_type=code&scope=snsapi_base&state=123#wechat_redirect", PayConfig.AppId, PayConfig.SendUrl6);

                Response.Redirect(code_url);
            }
            else
            {
                LogUtil.WriteLog(" ============ 通过code换取网页授权access_token =====================");
                LogUtil.WriteLog("开始获取OPENID======================================================");
                #region 获取支付用户 OpenID================

                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", PayConfig.AppId, PayConfig.AppSecret, code);

                string returnStr = HttpUtil.Send("", url);

                var obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

                url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", PayConfig.AppId, obj.refresh_token);
                returnStr = HttpUtil.Send("", url);
                obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);



                url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", obj.access_token, obj.openid);
                returnStr = HttpUtil.Send("", url);


                OpenId = obj.openid;
                Session["OpenId"] = OpenId;
                LogUtil.WriteLog(OpenId + " ============ 获取OPENID ==========" + OpenId + "===========");

                #endregion 获取支付用户 OpenID================

            }
        }
    }
}