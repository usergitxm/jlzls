using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using Newtonsoft.Json;

namespace SCJN
{
    public partial class Index : System.Web.UI.Page
    {

        public string OpenId;


        protected void Page_Load(object sender, EventArgs e)
        {





            if (!IsPostBack)
            {
                GetUserOpenId();
                OpenId = Session["OpenId"].ToString();
                BindBusiness();
            }
        }
        private void BindBusiness()
        {
            try
            {
                OpenId = Session["OpenId"].ToString();
                DataTable dt = UserDAO.SelectBindId(OpenId);

                UserID.DataSource = dt;
                UserID.DataTextField = "c_user_id";
                //ddlNF.DataValueField = "N_business_id";
                UserID.DataBind();
                UserID.Items.Insert(0, new ListItem("---请选择---", "-1"));
                //  UserID.SelectedValue = "0";
            }
            catch
            {

                return;
            }
        }
        /// <summary>
        /// 获取当前用户的微信 OpenId，如果知道用户的OpenId请不要使用该函数
        /// </summary>
        private void GetUserOpenId()
        {
            //string str = HttpUtility.UrlDecode("http%3a%2f%2fwx.thksoft.cc");
            string code = Request.QueryString["code"];
            //LogUtil.WriteLog(code);
            if (string.IsNullOrEmpty(code))
            {
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + PayConfig.AppId + "&redirect_uri=" + PayConfig.SendUrl + "&response_type=code&scope=snsapi_base&state=123#wechat_redirect", PayConfig.AppId, PayConfig.SendUrl);
                LogUtil.WriteLog(" ============ 开始获取code =====================");
                LogUtil.WriteLog(code_url);
                LogUtil.WriteLog(" ============ 结束获取dode =====================");
                Response.Redirect(code_url);
            }
            else
            {
                LogUtil.WriteLog(" ============ 通过code换取网页授权access_token =====================");
                //Response.Write(code);
                #region 获取支付用户 OpenID================
                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", PayConfig.AppId, PayConfig.AppSecret, code);

                LogUtil.WriteLog(url);
                string returnStr = HttpUtil.Send("", url);
                //LogUtil.WriteLog("Send 页面  returnStr 第一个：" + returnStr);

                var obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

                url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", PayConfig.AppId, obj.refresh_token);
                returnStr = HttpUtil.Send("", url);
                obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

                LogUtil.WriteLog("Send 页面  access_token：" + obj.access_token);
                LogUtil.WriteLog("Send 页面  openid=" + obj.openid);

                url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", obj.access_token, obj.openid);
                returnStr = HttpUtil.Send("", url);
                //LogUtil.WriteLog("Send 页面  returnStr：" + returnStr);


                OpenId = obj.openid;
                Session["OpenId"] = OpenId;
                LogUtil.WriteLog(OpenId + " ============ 结束 获取微信用户相关信息 =====================");
                #endregion
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);

            if (DateTime.Now.Hour >= 23 || DateTime.Now.Hour < 2 || DateTime.Now.Day == 25)
            {
                Response.Write("<script>alert('微信每日23：00-2：00，每月25号扎帐，在此期间暂停微信缴费，如有给您带来不便，敬请谅解！');</script>");
                return;
            }
            try
            {
                OpenId = Session["OpenId"].ToString();

                string USerID = Request.Form["userID"].ToString();
                // string USerID = "0530100700200";
                //OpenId = "odgWA1Ny7O_q6vXMAStLoaFkOPPw";

                //string USerID = "010109581";
                // string UserMonth = this.DropDownList1.SelectedValue;
                string UserMonth = "22";

                if (!String.IsNullOrEmpty(USerID))
                {

                    DataTable dt2 = UserDAO.SelectBindId1(USerID);
                    if (this.UserPassword.Text.Trim() == dt2.Rows[0]["C_PASSWORD"].ToString().Trim())
                    {
                        //判断该userid是否存在
                        DataTable dt = UserDAO.GetUser(USerID);
                        string a = DateTime.Now.Day.ToString();
                        int b = int.Parse(DateTime.Now.Hour.ToString());
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //DataTable dt1 = UserDAO.SelectBindId(OpenId);
                            //if (dt1 != null && dt1.Rows.Count > 0)
                            //{

                            //}
                            //else
                            //{
                            //  //  UserDAO.BindId(USerID, OpenId);
                            //}
                            Response.Redirect("ShowDetail1.aspx?id=" + USerID + "&&Month=" + UserMonth + "&&OpenId=" + OpenId);
                        }
                        else
                        {
                            //请输入用户编号
                            Response.Write("<script>alert('该用户不存在！');</script>");
                            return;
                        }
                    }
                    else
                    {
                        //请输入用户编号
                        Response.Write("<script>alert(' 密码错误！');</script>");
                        return;
                    }
                }
                else
                {
                    Response.Write("<script>alert('请输入用户编号！');</script>");
                    return;
                }
            }
            catch (Exception)
            {

                Response.Write("<script>alert('该用户未绑定！');</script>");
                return;
            }

        }

    }
}