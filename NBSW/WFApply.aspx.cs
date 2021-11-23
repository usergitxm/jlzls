using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
namespace SCJN
{
    public partial class WFApply : System.Web.UI.Page
    {
        public string UserName;
        public string id;
        public string UserAddress;
        public string UseProperties;
        public string WaterUse;
        public string UseMoney;
        public string UseMonth;
        protected void Page_Load(object sender, EventArgs e)
        {
            //LogUtil.WriteLog(Request.QueryString["OpenId"] + "     --3");
            if (!IsPostBack)
            {
                id = Request["userid"];
                WaterUse = Request["WaterUse"];//用水量
                UseMoney = Request["UseMoney"];//需付费用
                UseMonth = Request["UseMonth"];//欠费月份
                DataTable dt1 = UserDAO.GetUser(id);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    DataRow jd = dt1.Rows[0];
                    UserName = jd["用户名称"].ToString();
                    UserAddress = jd["地址"].ToString();
                }


                //查询用户用水性质
                DataTable dt = UserDAO.GetPropertiesName(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow jd = dt.Rows[0];
                    UseProperties = jd["c_properties_name"].ToString();
                }

                string tst;
                int i = 7;
                tst = UseMonth.Substring(UseMonth.Length - i);//开始月份
                string endMonth = UseMonth.Substring(0, 6);
                string a = tst.Substring(0, 6);
                if (a.Equals(endMonth))
                {
                    UseMonth = endMonth;
                }
                else
                {
                    UseMonth = tst + endMonth;
                }
            }
        }


        protected void BtnApply_Click(object sender, EventArgs e)
        {
            //if (UserDAO.IsYHDK(Request["userid"].ToString()))
            //{
            //    Response.Write("<script>alert('您已办理代扣业务,数据正在银行中！');</script>");
            //}
            //else
            //{
            PayModel model = new PayModel();

            DataTable dtWX = UserDAO.SelectWXORDERSN();
            model.OrderSN = dtWX.Rows[0]["单号"].ToString();

            model.TotalFee = Request["UseMoney"];//int.Parse(demicl.Parse(this.Text5.Text)*100);
            model.Body = "水费";
            model.Attach = Request["userid"]; //不能有中文
            model.OpenId = Request.QueryString["OpenId"];

            //string userid = model.Attach.Split('|')[0].ToString();
            //string myf = model.Attach.Split('|')[1].ToString();
            //string maxyf = model.Attach.Split('|')[model.Attach.Split('|').Length - 2].ToString();
            //decimal money = decimal.Parse(model.TotalFee);
            //new UserDAO().Charge(userid, maxyf, myf, money);

            LogUtil.WriteLog(model.OpenId + "     --3");
            #region   判断重复缴费

            DataTable dtF = UserDAO.GetUserWaterFree(Request["userid"], "", "");
            if (dtF != null && dtF.Rows.Count > 0)
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                this.Response.Redirect(model.ToString());
            }
            else
            {
                Response.Write("<script>alert('没有需要缴纳的费用！');</script>");
                return;
            }
            #endregion
            //}

            //System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("WeiPay.aspx");
        }
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {

            //为了通过证书验证，总是返回true

            return true;

        }
    }
}