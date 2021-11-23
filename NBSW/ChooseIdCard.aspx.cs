using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using Newtonsoft.Json;
using System.Data;
namespace NBSW
{
    public partial class ChooseIdCard : System.Web.UI.Page
    {
        public string OpenId { get; set; }
        public DataTable dt = null;
        public string Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserOpenId();
                BindBusiness();
                try
                {
                    OpenId = Session["OpenId"].ToString();

                }
                catch (Exception )
                {

                    return;
                }
            }

        }
        private void BindBusiness()
        {
            try
            {
                OpenId = Session["OpenId"].ToString();
                string sql = @"select * from wx_bz w where w.c_openid='" + OpenId + @"'";
                DataTable dt = new Sys_Command().GetDataTable(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    Drop_UserId.DataSource = dt;
                    Drop_UserId.DataTextField = "N_BUSS_ID";
                    //ddlNF.DataValueField = "N_business_id";
                    Drop_UserId.DataBind();
                    Drop_UserId.Items.Insert(0, new ListItem("---请选择---", "-1"));
                    //  UserID.SelectedValue = "0";
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('您尚未提交过报装申请，暂不能缴纳安装费！');location='NewsUserApplication.aspx'</script>");
                }
            }
            catch
            {

                return;
            }
        }
        private void GetUserOpenId()
        {
            //string str = HttpUtility.UrlDecode("http%3a%2f%2fwx.thksoft.cc");
            string code = Request.QueryString["code"];
            //LogUtil.WriteLog(code);
            if (string.IsNullOrEmpty(code))
            {
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + PayConfig.AppId + "&redirect_uri=" + PayConfig.SendUrl7 + "&response_type=code&scope=snsapi_base&state=123#wechat_redirect", PayConfig.AppId, PayConfig.SendUrl7);
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
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Next_Click(object sender, EventArgs e)
        {
            try
            {
                OpenId = Session["OpenId"].ToString();
            }
            catch (Exception )
            {
                return;
            }

            var N_Id = Drop_UserId.Text;
            if (N_Id != null && N_Id != "")
            {
                string sql = @"   select s.n_business_id 业务编号 from bz_application s where s.n_application_id='" + N_Id + @"'";
                DataTable dt = new Sys_Command().GetDataTable(sql);
                Response.Redirect("Paypartner.aspx?n_id=" + N_Id + "&OpenId=" + OpenId + "&N_BUSINESS_ID=" + dt.Rows[0]["业务编号"].ToString() + "");
            }
            else
            {
                Response.Write("<script>alert(' 编号不存在！');</script>");
                return;
            }
        }
    }
}