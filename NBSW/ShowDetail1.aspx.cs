using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bll;
namespace SCJN
{
    public partial class ShowDetail1 : System.Web.UI.Page
    {
        public string id;
        public DataTable dt = null;
        public string UserName;
        public string UserAddress;
        public double WaterUse;
        public double UseMoney;
        public string UseMonth;
        public string UserAmount;
        public string SumMonths;
        public string allMoney;
        public string OpenId;
        public double userAmount;
        protected void Page_Load(object sender, EventArgs e)
        {
            //  OpenId = "oeSS50irwqBp4yp1RryxGA4LcjNM";
            OpenId = Request.QueryString["OpenId"];
            LogUtil.WriteLog(OpenId + "     --2");
            //if (!IsPostBack)
            // {
           id = Request["id"];
            // id = "0530100402527";
            string SumMonth =  Request["Month"];
            //查询用户信息
            DataTable dt1 = UserDAO.GetUser(id);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                DataRow jd = dt1.Rows[0];
                id = jd["用户编号"].ToString();
                UserName = jd["用户名称"].ToString();
                UserAddress = jd["地址"].ToString();
                UserAmount = jd["余额"].ToString();
            }
            SumMonths = "全部用水信息";
            dt = UserDAO.GetUserWaterFree(id, "", "");
            Fun_ApplyPra();
            if (dt.Rows.Count > 1)
            {

                allMoney = UseMoney.ToString();

            }
            else
            {
                if (dt.Rows.Count > 0)
                {

                    if (double.Parse(dt.Rows[0]["小计"].ToString()) > double.Parse(UserAmount))
                    {
                        allMoney = UseMoney.ToString("0.00");
                    }
                    else
                    {
                        allMoney = "0";
                    }
                }
                else
                {
                    allMoney = "0";
                }
            }
            // }
        }

        private void Fun_ApplyPra()
        {
            userAmount = Convert.ToDouble(UserDAO.GetUser(id).Rows[0]["余额"].ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr["状态"]) == 0)
                    {
                        WaterUse = WaterUse + Convert.ToDouble(dr["用量"]);
                        UseMoney = UseMoney + Convert.ToDouble(dr["小计"]) - userAmount;
                        UseMonth += dr["月份"] + "|";
                        userAmount = 0;
                    }
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(allMoney) || allMoney == "0")
            {
                Response.Write("<script>alert('没有需要缴纳的费用！');</script>");
                return;
            }
            if (!string.IsNullOrEmpty(id))
            {
                LogUtil.WriteLog(OpenId + "     --2");
                Response.Redirect("WFApply.aspx?userid=" + id + "&&WaterUse=" + WaterUse + "&&UseMoney=" + allMoney + "&&UseMonth=" + UseMonth + "&&OpenId=" + OpenId);
            }
        }
    }
}