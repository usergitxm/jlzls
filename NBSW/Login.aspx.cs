using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bll;
namespace NBSW.BusinessManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('登录成功');location.href='WeChatApplication.aspx'</script>");
        }
        /// <summary>
        /// login 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_regester_Click(object sender, EventArgs e)
        {
            if (Txt_pwd.Text.Trim() == "" || Txt_username.Text.Trim() == "")
            {
                Response.Write("<script>alert('用户名或密码错误')</script>");
                return;

            }
            else
            {
                if (Txt_username.Text == "jl" && Txt_pwd.Text == "123456")
                {
                    Response.Write("<script>alert('登录成功');location.href='NewsUserApplication.aspx'</script>");
                    return;
                }
                else
                {

                    Response.Write("<script>alert('用户名或密码错误')</script>");
                    return;
                }
              
            }
        }
    }
}