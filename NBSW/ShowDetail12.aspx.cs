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
    public partial class ShowDetail12 : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenId = Request.QueryString["OpenId"];
            LogUtil.WriteLog(OpenId + "     --2");
            //if (!IsPostBack)
            // {
            id = Request["id"];
            //id = "003053130104114";
            string SumMonth = Request["Month"];
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
            string time = DateTime.Now.Year.ToString() + (DateTime.Now.Month.ToString().Length <= 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString());

            if (SumMonth.Equals("0"))
            {
                //当月
                dt = UserDAO.GetUserWaterZD(id, time, time);
                SumMonths = "本月的用水信息";
                Fun_ApplyPra();

            }
            else if (SumMonth.Equals("3"))
            {
                //最近三个月

                string nowmonth = DateTime.Now.AddMonths(-2).Year.ToString() + (DateTime.Now.AddMonths(-2).Month.ToString().Length <= 1 ? "0" + DateTime.Now.AddMonths(-2).Month.ToString() : DateTime.Now.AddMonths(-2).Month.ToString());

                dt = UserDAO.GetUserWaterZD(id, nowmonth, time);
                SumMonths = "最近三个月的用水信息";

                Fun_ApplyPra();
            }
            else if (SumMonth.Equals("6"))
            {
                //半年
                string nowmonth = DateTime.Now.AddMonths(-5).Year.ToString() + (DateTime.Now.AddMonths(-5).Month.ToString().Length <= 1 ? "0" + DateTime.Now.AddMonths(-5).Month.ToString() : DateTime.Now.AddMonths(-5).Month.ToString());

                dt = UserDAO.GetUserWaterZD(id, nowmonth, time);
                SumMonths = "最近半年的用水信息";
                Fun_ApplyPra();

            }
            else if (SumMonth.Equals("22"))
            {
                //全部
                SumMonths = "全部用水信息";
                dt = UserDAO.GetUserWaterZD(id, "", "");
                Fun_ApplyPra();

            }
            allMoney = UseMoney.ToString();
            // }
        }

        private void Fun_ApplyPra()
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr["状态"]) == 0)
                    {
                        WaterUse = WaterUse + Convert.ToDouble(dr["用量"]);
                        UseMoney = UseMoney + Convert.ToDouble(dr["小计"]);
                        UseMonth += dr["月份"] + "|";
                    }
                }
            }
        }

        //protected void Submit_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(allMoney) || allMoney=="0")
        //    {
        //        Response.Write("<script>alert('没有需要缴纳的费用！');</script>");
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        LogUtil.WriteLog(OpenId + "     --2");
        //        Response.Redirect("WFApply.aspx?userid=" + id + "&&WaterUse=" + WaterUse + "&&UseMoney=" + allMoney + "&&UseMonth=" + UseMonth + "&&OpenId=" + OpenId); 
        //    }
        //}
    }
}