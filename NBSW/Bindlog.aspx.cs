using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bll;
using Newtonsoft.Json;

namespace SCJN
{
    public partial class Bindlog : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Submit_Click(object sender, EventArgs e)
        {

            try
            {

                if (this.UserPassword.Text == "666666")
                {
                    Response.Redirect("BindId.aspx?");
                }
                else
                {
                    Response.Write("<script>alert('请检查用户编号或初始密码是否正确！');</script>");
                    return;
                }
            }
            catch (Exception)
            {

                Response.Write("<script>alert('请检查用户编号或初始密码是否正确！');</script>");
                return;
            }


        }
    }
}