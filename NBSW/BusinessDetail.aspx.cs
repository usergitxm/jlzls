using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCJN
{
    public partial class BusinessDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string type = Request.QueryString["site"].ToString();
                if (type.Equals("1"))
                {
                    Panel1.Visible = true;
                }
                else if (type.Equals("2"))
                {
                    Panel2.Visible = true;
                }
                else if (type.Equals("3"))
                {
                    Panel3.Visible = true;
                }
                else if (type.Equals("4"))
                {
                    Panel4.Visible = true;
                }
                else if (type.Equals("5"))
                {
                    Panel5.Visible = true;
                }
                else if (type.Equals("6"))
                {
                    Panel6.Visible = true;
                }

            }
        }
    }
}