using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bll;
using THKModel;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
namespace NBSW
{
    public partial class Pay_partner : System.Web.UI.Page
    {
        public static string N_BUSINESS_ID { get; set; }
        public string OpenId { get; set; }
        public DataTable dt = null;
        public static string UseCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                N_BUSINESS_ID = Request.QueryString["N_BUSINESS_ID"].ToString();
                OpenId = Request.QueryString["OpenId"].ToString();
                dt = UserDAO.getDetail(decimal.Parse(N_BUSINESS_ID));
                if (dt != null && dt.Rows.Count > 0)
                {
                    UseCount = dt.Rows[0]["n_application_count"].ToString();
                    PayMoney.Text = dt.Rows[0]["n_owe_amount"].ToString();
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('暂无需缴纳材料费！');location='ChooseIdCard.aspx'</script>");
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
            if (PayMoney.Text == "0")
            {
                Response.Write("<script language='javascript'>alert('您暂无需缴纳安装费！')</script>");
                return;

            }
            PayModel1 model = new PayModel1();

            DataTable dtWX = UserDAO.SelectWXORDERSN();
            model.OrderSN = dtWX.Rows[0]["单号"].ToString();

            model.TotalFee = PayMoney.Text.Trim();
            model.Body = "安装费";
            model.Attach = N_BUSINESS_ID + "|" + model.TotalFee;
            model.OpenId = Request.QueryString["OpenId"];

            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            this.Response.Redirect(model.ToString());
        }
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {

            //为了通过证书验证，总是返回true

            return true;

        }
    }
}