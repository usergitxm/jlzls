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
    public partial class BindId : System.Web.UI.Page
    {

        public string OpenId;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetUserOpenId();
            }
            OpenId = Session["OpenId"].ToString();




            //OpenId = "o1rxwwlYv5eZy8naxU-7Aq6kjLpM";
            DataTable dt = UserDAO.SelectBindId(this.UserID.Text);
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    this.Cancel.Visible = true;
            //    this.Submit.Visible = false;
            //    this.UserID.Text = dt.Rows[0]["c_user_id"].ToString();

            //}
            //else
            //{
            //    this.Cancel.Visible = false;
            //    this.Submit.Visible = true;
            //}
            #region
            //if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString().Equals("up"))
            //{
            //    //initDataTable();
            //    ///提交了数据 取值
            //    string USerID = Request.Form["userID"].ToString();
            //    string UserMonth = this.DropDownList1.SelectedValue;
            //    if (!String.IsNullOrEmpty(USerID))
            //    {
            //        //判断该userid是否存在
            //        DataTable dt = QueryFree.GetUser(USerID);
            //        if (dt != null && dt.Rows.Count > 0)
            //        {
            //            Response.Redirect("ShowDetail1.aspx?id=" + USerID + "&&Month=" + UserMonth);
            //        }
            //        else
            //        {
            //            //请输入用户编号
            //            Response.Write("<script>alert('该用户不存在！');</script>");
            //            return;
            //        }

            //    }
            //    else
            //    {
            //        Response.Write("<script>alert('请输入用户编号！');</script>");
            //        return;
            //    }

            //}
            //else
            //{
            //    initDataTable();

            //}
            #endregion
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
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + PayConfig.AppId + "&redirect_uri=" + PayConfig.SendUrl2 + "&response_type=code&scope=snsapi_base&state=123#wechat_redirect", PayConfig.AppId, PayConfig.SendUrl2);
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
            // OpenId = Session["OpenId"].ToString();
            //OpenId = "o1rxwwlYv5eZy8naxU-7Aq6kjLpM";
            string USerID = Request.Form["userID"].ToString();
            string USerPassword = this.UserPassword.Text;
            string s = this.UserID.Text;
            if (!String.IsNullOrEmpty(USerID))
            {
                DataTable dt3 = UserDAO.SelectBindId1(s);
                if (dt3.Rows.Count < 1)
                {
                    //判断该userid是否存在
                    DataTable dt = UserDAO.GetUser(USerID);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (UserDAO.BindId(USerID, OpenId, USerPassword))
                        {
                            Response.Write("<script>alert('绑定成功！');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('绑定失败！');</script>");
                            UserID.Text = "";
                            UserPassword.Text = "";
                        }
                        //LogUtil.WriteLog(OpenId + "     --1");
                        //Response.Redirect("ShowDetail1.aspx?id=" + USerID + "&&OpenId=" + OpenId);
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
                    Response.Write("<script>alert('该用户已绑定！');</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script>alert('请输入用户编号！');</script>");
                return;
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            string USerID = Request.Form["userID"].ToString();

            if (!String.IsNullOrEmpty(USerID))
            {

                //判断该userid是否存在
                DataTable dt = UserDAO.GetUser(USerID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string USerPassword = this.UserPassword.Text;
                    if (UserDAO.BindCancelId(USerID, OpenId))
                    {
                        Response.Write("<script>alert('取消绑定成功！');</script>");
                        UserID.Text = "";
                        UserPassword.Text = "";
                    }
                    else
                    {
                        Response.Write("<script>alert('取消绑定失败！');</script>");
                    }
                    //LogUtil.WriteLog(OpenId + "     --1");
                    //Response.Redirect("ShowDetail1.aspx?id=" + USerID + "&&OpenId=" + OpenId);
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
                Response.Write("<script>alert('请输入用户编号！');</script>");
                return;
            }
        }
    }
}