using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Collections;
using System.IO;
using THKModel;

namespace bll
{
    public  class UserDAO
    {
        /// <summary>
        /// 查询用户资料
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static DataTable GetUser(string UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select y.c_user_id 用户编号,y.c_old_user_id 老编号,y.c_user_name 用户名称, y.n_amount 余额, y.n_company_id 公司,y.c_user_address 地址 ,y.n_user_prestore_state 预存 from yx_user y where (y.c_user_id='" + UserId + @"' or y.c_old_user_id='" + UserId + "') /*and  y.n_company_id=5  in   (select c.n_company_id    from qx_company c   start with c.n_parent_company_id = 2  connect by c.n_parent_company_id = c.n_company_id)*/ ");
            string sql = string.Format(strSql.ToString(), UserId);
            // return new OracleHelp().Select(sql.ToString());
            return new Sys_Command().GetDataTable(strSql.ToString());
        }
        /// <summary>
        /// 报装申请
        /// </summary>
        /// <param name="businessmodel">业务实体</param>
        /// <param name="applimodel">报装实体</param>
        /// <param name="tranmodel1">流程实体</param>
        /// <param name="tranmodel2">流转流程实体</param>
        /// <returns></returns>
        public static int addCharge(Bz_Charge model, Bz_Detail detaileMondel, string win, string logonName)
        {
            string sql = "";
            string sql1 = string.Format(@"insert into BZ_CHARGE
  (N_CHARGE_ID,
   N_BUSINESS_ID,
   N_DETAIL_ID,
   N_CHARGE_AMOUNT,
   N_PAYMENT_WAY,
   N_CHARGE_OPERATOR_ID,
   D_CHARGE_OPERATION_TIME,
   N_STAGE_CUR,
   N_CHARGE_YEAR,
   N_CHARGE_MONTH,
   N_CHARGE_STATE,
   N_CHARGE_OVER_STATE,
   N_ZPH,N_CHARGE_FS)
values
  ('{0}',
   '{1}',
   '{2}',
   '{3}',
   '{4}',
   '{5}',
   to_date('{6}', 'yyyy-mm-dd hh24:mi:ss'), '{7}',
   '{8}',
   '{9}',
   '{10}',
   '{11}',
   '{12}','{13}')", model.N_CHARGE_ID, model.N_BUSINESS_ID, model.N_DETAIL_ID, model.N_CHARGE_AMOUNT, model.N_PAYMENT_WAY, model.N_CHARGE_OPERATOR_ID, model.D_CHARGE_OPERATION_TIME, model.N_STAGE_CUR, model.N_CHARGE_YEAR, model.N_CHARGE_MONTH, model.N_CHARGE_STATE, model.N_CHARGE_OVER_STATE, model.N_ZPH, model.N_CHARGE_FS);

            string sql2 = @"update bz_detail d set d.n_received_amount = '" + detaileMondel.N_RECEIVED_AMOUNT + "', d.n_owe_amount = '" + detaileMondel.N_OWE_AMOUNT + "'  where d.n_detail_id = '" + detaileMondel.N_DETAIL_ID + "'";

            sql = sql1 + ";" + sql2;

            return new Sys_Command().SQLSExcute(sql, win, logonName);
        }
        /// <summary>
        /// 报装序列号

        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="colname"></param>
        /// <param name="win"></param>
        /// <param name="logonName"></param>
        /// <returns></returns>
        public static decimal getNextandIdentityApp(string tablename, string colname, string win, string logonName)
        {
            decimal result = 0;
            try
            {
                YX_Sequences model = getsingleModel(tablename, colname, win, logonName);
                if (model.N_Current_Number.ToString().Substring(0, 6).Equals(System.DateTime.Now.ToString("yyyyMM")) == false)
                {
                    result = decimal.Parse(System.DateTime.Now.ToString("yyyyMMdd") + "0001");
                    model.N_Current_Number = result;
                    model.N_Next_Number = decimal.Parse(System.DateTime.Now.ToString("yyyyMMdd") + "0001") + model.N_Identitity_Value;
                }
                else
                {
                    if (model.N_Current_Number.ToString().Substring(0, 8).Equals(System.DateTime.Now.ToString("yyyyMMdd")) == false)
                    {
                        result = decimal.Parse(model.N_Next_Number.ToString().Replace(model.N_Next_Number.ToString().Substring(0, 8), System.DateTime.Now.ToString("yyyyMMdd")));
                        model.N_Current_Number = result;
                        model.N_Next_Number = result + model.N_Identitity_Value;
                    }
                    else
                    {
                        result = model.N_Next_Number;
                        model.N_Current_Number = model.N_Next_Number;
                        model.N_Next_Number = model.N_Next_Number + model.N_Identitity_Value;
                    }
                }
                Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }     /// <summary>
        /// 获取下一个序列值并自增
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="colname">列名</param>
        /// <returns></returns>
        public static decimal getNextandIdentity(string tablename, string colname)
        {
            decimal result = 0;

            
            DataTable dt = new DataTable("orasptab");
            dt.Columns.Add("pname", Type.GetType("System.String"));
            dt.Columns.Add("pvalue", Type.GetType("System.String"));
            dt.Columns.Add("dir", Type.GetType("System.String"));
            dt.Columns.Add("size", Type.GetType("System.String"));

            dt.Rows.Add(new object[] { "c_table", tablename.ToUpper(), "1", 200 });
            dt.Rows.Add(new object[] { "c_col", colname.ToUpper(), "1", 200 });
            dt.Rows.Add(new object[] { "n_Seq_ID", "0", "0", 20 });
            //myservice.ExcuteProcEXTex("Pkg_Public_Method.Proc_Get_Sequences_ID_identity", dt, "any", "getNextandIdentity", "获取下一个序列值并自增", 2, "");
            string addstate = new Sys_Command().ExepPro(dt, "Pkg_Public_Method.Proc_Get_Sequences_ID_identity", 2);
            decimal.TryParse(addstate, out result);

            return result;
        }
        public static int Update(YX_Sequences model)
        {

            int result = 0;
            try
            {
                string sql = "update YX_SEQUENCES set N_START_NUMBER={0},N_CURRENT_NUMBER={1},N_NEXT_NUMBER={2},N_IDENTITY_VALUE={3} where C_TABLE_NAME='{4}' and C_COL_NAME='{5}'";
                sql = string.Format(sql, model.N_Start_Number, model.N_Current_Number, model.N_Next_Number, model.N_Identitity_Value, model.C_Table_Name.ToUpper(), model.C_Col_Name.ToUpper());

                result = new Sys_Command().SQLExcute(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 获取指定序列
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="colname">列名</param>
        /// <returns></returns>
        public static YX_Sequences getsingleModel(string tablename, string colname, string win, string logonName)
        {
         

            YX_Sequences model = new YX_Sequences();
            try
            {
                string sql = "select * from YX_SEQUENCES where C_TABLE_NAME='" + tablename.ToUpper() + "' and C_COL_NAME='" + colname.ToUpper() + "'";
                DataTable dt = new Sys_Command().GetDataTable(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    model = new YX_Sequences();
                    foreach (DataRow dr in dt.Rows)
                    {
                        model.C_Table_Name = dr["C_TABLE_NAME"].ToString();
                        model.C_Col_Name = dr["C_COL_NAME"].ToString();
                        model.N_Start_Number = decimal.Parse(dr["N_START_NUMBER"].ToString());
                        model.N_Current_Number = decimal.Parse(dr["N_CURRENT_NUMBER"].ToString());
                        model.N_Next_Number = decimal.Parse(dr["N_NEXT_NUMBER"].ToString());
                        model.N_Identitity_Value = decimal.Parse(dr["N_IDENTITY_VALUE"].ToString());
                    }
                }
                else
                {
                    model = new YX_Sequences();

                    model.C_Table_Name = tablename.ToUpper();

                    model.C_Col_Name = colname.ToUpper();

                    model.N_Start_Number = 0;

                    model.N_Current_Number = 0;

                    model.N_Next_Number = 1;

                    model.N_Identitity_Value = 1;

                    Add(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }      /// <summary>
        /// 添加序列
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(YX_Sequences model)
        {
            string sql = "select count(*) from YX_SEQUENCES where C_TABLE_NAME='" + model.C_Table_Name + "' and C_COL_NAME='" + model.C_Col_Name + "'";
            DataTable dt=new Sys_Command().GetDataTable(sql);
            int result = 0;
            try
            {
                if (dt.Rows.Count==0)
                {
                    string sql1 = "insert into YX_SEQUENCES values('{0}','{1}',{2},{3},{4},{5})";
                    sql1 = string.Format(sql, model.C_Table_Name, model.C_Col_Name, model.N_Start_Number, model.N_Current_Number, model.N_Next_Number, model.N_Identitity_Value);
                    result = new Sys_Command().SQLExcute(sql1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public static THKModel.Yx_Accounting GetCurrentAccounting(string win, string logonName)
        {
           
            string sql = " select * from yx_accounting t where  t.N_ACCOUNTING_STATE=0";

            DataTable result = new Sys_Command().GetDataTable(sql);

            Yx_Accounting model = new Yx_Accounting();

            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    model.D_Accounting_End_Date = DateTime.Parse(dr["D_ACCOUNTING_END_DATE"].ToString());
                    model.D_Accounting_Start_Date = DateTime.Parse(dr["D_ACCOUNTING_START_DATE"].ToString());
                    model.N_Accounting_Month = decimal.Parse(dr["N_ACCOUNTING_MONTH"].ToString());
                    model.N_Accounting_State = decimal.Parse(dr["N_ACCOUNTING_STATE"].ToString());
                    model.N_Accounting_Year = decimal.Parse(dr["N_ACCOUNTING_YEAR"].ToString());
                    model.C_ACCOUNTING_MONTH = model.N_Accounting_Year.ToString() + model.N_Accounting_Month.ToString().PadLeft(2, '0');
                }
            }
            return model;
        }
        /// <summary>
        /// 根据业务编号查询费用信息
        /// </summary>
        /// <param name="businessId"></param>
        /// <param name="win"></param>
        /// <param name="logonName"></param>
        /// <returns></returns>
        public static DataTable getDetail(decimal businessId)
        {
            string sql = @"select a.n_business_id  n_business_id,
       d.n_detail_id n_detail_id,
       max(a.n_Application_Count) n_application_count, 
       sum(nvl(bm.n_material_amount, 0)) n_material_amount,
       sum(nvl(d.n_total_amount, 0)) n_total_amount,
       sum(nvl(d.n_received_amount, 0)) n_received_amount,
       sum(nvl(d.n_owe_amount, 0)) n_owe_amount
  from bz_application a, bz_detail d, (select b.n_business_id, sum(b.n_material_amount) n_material_amount
          from bz_business_material b
         group by b.n_business_id) bm
 where a.n_business_id = d.n_business_id
   and a.n_business_id = bm.n_business_id(+)";

            if (businessId > 0)
            {
                sql += @" and d.n_business_id= " + businessId;
            }


            sql += @" and d.n_cost_id=6 group by a.n_business_id, d.n_detail_id";



            return new Sys_Command().GetDataTable(sql);
        }
        public static string WxSendMsg(string OpenId,string money,string token)
        {

            string url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + token;//向此链接地址POST数据发送模板消息
            string contentmsg = "{\"touser\": \"" + OpenId + "\"," +
                                        "\"template_id\": \"T_HzydjTUBrRYIjaLpd4O3hhpx9G9dvDn-2CD0XCqbU\"," +
                                        "\"topcolor\": \"#0E90D2\"," +
                                        "\"data\": {" +
                                            "\"first\": {"
                                            +
                                                "\"value\": \"\"," +
                                                "\"color\": \"#0E90D2\"" +
                                            "}," +
                                            "\"keyword1\": {" +
                                                "\"value\": \"安装费缴纳\"," +
                                                "\"color\": \"#FF0000\"" +
                                            "}," +
                                            "\"keyword2\": {" +
                                                "\"value\": \"" + money + "\"," +
                                                 "\"color\": \"#FF0000\"" +
                                            "}," +
                                             "\"keyword3\": {" +
                                                "\"value\": \"" + DateTime.Now.ToString() + "\"," +
                                                "\"color\": \"#FF0000\"" +
                                            "}," +
                                            "\"remark\": {" +
                                                "\"value\": \"感谢您的使用！\"," +
                                                "\"color\": \"#173177\"" +
                                            "}" +
                                        "}" +
                                     "}";
            return contentmsg;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">文件实体</param>
        /// <returns></returns>
        public static THKModel.Yx_File Insert(THKModel.Yx_File model, string win, string logonName)
        {
            if (model.N_File_ID > 0)
            {

            }
            else
            {
                model.N_File_ID = getNextandIdentity("YX_FILE", "N_FILE_ID");
            }

         

            string sql = "insert into YX_FILE values(" + model.N_File_ID + ",'" + model.N_Process.N_Process_ID + "','" + model.N_Queue.N_Queue_ID + "','" + model.N_Business.N_Business_ID + "','" + model.C_File_Name + "','" + model.N_File_Path + "','107',to_date('" + model.D_File_Operation_Time + "','yyyy-mm-dd hh24:mi:ss'),'" + model.C_File_Remark + "')";

            int i = new Sys_Command().SQLExcute(sql);

            if (i > 0)
            {
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 查询用户欠费
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="startMonth"></param>
        /// <param name="endMonth"></param>
        /// <returns></returns>
        public static DataTable GetUserWaterFree(string UserId, string startMonth, string endMonth)
        {
            StringBuilder strSql = new StringBuilder();
            if (!String.IsNullOrEmpty(startMonth) && !String.IsNullOrEmpty(endMonth))
            {

                strSql.Append(@"
select b.月份,
                           case
                             when a.起度 is null then
                              c.起度
                             else
                              a.起度
                           end as 起度,
                           case
                             when a.止度 is null then
                              c.止度
                             else
                              a.止度
                           end as 止度,
                           用量,
                           调整量,
                           单价,
                           状态,
                           小计
                      from (select  s.c_situation_use_month 月份,
                                   s.n_degrees_start 起度,
                                   s.n_degrees_end 止度,
                                   s.n_dosage 用量,
                                  s.n_charge_state as 状态,
                                   (select sum(p.n_price)
                  from yx_price p
                 where p.n_properties_id = s.n_properties_id
                   and p.n_parent_price_id = 0
                   and p.n_ladder_number = 0 and N_PRICE_STATE=1 and p.n_company_id=s.n_company_id) 单价
                              from yx_situation s, yx_detail n
                             where n.n_cost_id = 1
                               and s.n_situation_id = n.n_situation_id
                                 and s.c_user_id = '" + UserId + @"'   and n.c_detail_use_month between    '" + startMonth + @"' and  '" + endMonth + @"'
                                and s.n_charge_state = 0
                               and s.n_calculation_way = 0
                               and n.n_company_id = s.n_company_id
                             group by s.c_situation_use_month,
                                      s.n_degrees_start,
                                      s.n_degrees_end,
                                      s.n_dosage,s.n_charge_state,
                                      s.n_properties_id, s.n_company_id
                                      ) a,
                           (select t.c_detail_use_month 月份,
                                   sum(t.n_detail_amount) 小计
                              from yx_detail t
                             where c_user_id = '" + UserId + @"'
                             and t.n_charge_state = 0
                               and t.c_detail_use_month  between   '" + startMonth + @"' and  '" + endMonth + @"'
                             group by t.c_detail_use_month) b,
                           (select c_situation_use_month 月份,
                                   d.n_degrees_start     起度,
                                   d.n_degrees_end       止度,
                                   d.n_real_dosage       调整量
                              from yx_situation d
                            where c_user_id = '" + UserId + @"' and d.n_charge_state = 0
                               and d.c_situation_use_month  between   '" + startMonth + @"' and  '" + endMonth + @"'
                               and n_calculation_way = 3) c
                     where b.月份 = a.月份(+)
                       and b.月份 = c.月份(+)
                      and 小计>0
                     order by b.月份 desc");
            }
            else
            {
                strSql.Append(@"select b.月份,
                           case
                             when a.起度 is null then
                              c.起度
                             else
                              a.起度
                           end as 起度,
                           case
                             when a.止度 is null then
                              c.止度
                             else
                              a.止度
                           end as 止度,
                          nvl(用量,0) 用量,
                           nvl(调整量,0) 调整量,
                           nvl(单价,0) 单价,
                            nvl(状态,0) 状态,
                           nvl(小计,0)小计, 综合单价  --,d.电子发票 电子发票
                      from (select  s.c_situation_use_month 月份,
                                   s.n_degrees_start 起度,
                                   s.n_degrees_end 止度,
                                   s.n_dosage 用量,
                                  s.n_charge_state as 状态,
                                  wm_concat (N.N_DETAIL_PRICE)
              /* (select sum(p.n_price)
                  from yx_price p
                 where p.n_properties_id = s.n_properties_id
                   and p.n_parent_price_id = 0
                   and p.n_ladder_number = n.n_detail_ladder_number
                   and N_PRICE_STATE = 1
                   and p.n_company_id = s.n_company_id)*/ 单价

                              from yx_situation s, yx_detail n
                             where n.n_cost_id = 1
                               and s.n_situation_id = n.n_situation_id
                               and s.c_user_id =  '" + UserId + @"'
                                and s.n_charge_state =0
                               and s.n_calculation_way = 0
                               and n.n_company_id = s.n_company_id
                             group by s.c_situation_use_month,
                                      s.n_degrees_start,
                                      s.n_degrees_end,
                                      s.n_dosage,s.n_charge_state,
                                      s.n_properties_id
                                      ) a,
                          (select wmsys.wm_concat(c.c_cost_name ||  rtrim(to_char(t.n_detail_total_amount,'fm99999999990.99'),'.')  || '元') 综合单价,
               t.c_detail_use_month 月份,
               sum(t.n_detail_amount) 小计
          from yx_detail t, yx_cost c
         where c_user_id = '" + UserId + @"' and t.n_cost_id=1
           and c.n_cost_id = t.n_cost_id   and t.n_charge_state=0
         group by t.c_detail_use_month) b,
                           (select c_situation_use_month 月份,
                                   d.n_degrees_start     起度,
                                   d.n_degrees_end       止度,
                                   d.n_real_dosage       调整量
                              from yx_situation d
                             where c_user_id = '" + UserId + @"'   
                                 and n_charge_state = 0 /*and d.c_situation_use_month between  201307 and  201401*/
                               and n_calculation_way = 3) c--,(select  t.pdfurl 电子发票 from gs_fp_return t,yx_situation i where i.n_invoice_id=t.sbvid and t.kpbz=1   ) d
                     where b.月份 = a.月份(+)
                       and b.月份 = c.月份(+)
                       --  and 小计 > 0 and 用量 >0
                     order by b.月份 desc");
            }
            //DataTable dtqf = new OracleHelp().Select(strSql.ToString());
            //return dtqf;
            return new Sys_Command().GetDataTable(strSql.ToString());
        }

        /// <summary>
        /// 查询用户账单
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="startMonth"></param>
        /// <param name="endMonth"></param>
        /// <returns></returns>
        public static DataTable GetUserWaterZD(string UserId, string startMonth, string endMonth)
        {
            StringBuilder strSql = new StringBuilder();
            if (!String.IsNullOrEmpty(startMonth) && !String.IsNullOrEmpty(endMonth))
            {

//                strSql.Append(@"
//select b.月份,
//                           case
//                             when a.起度 is null then
//                              c.起度
//                             else
//                              a.起度
//                           end as 起度,
//                           case
//                             when a.止度 is null then
//                              c.止度
//                             else
//                              a.止度
//                           end as 止度,
//                          nvl(用量,0) 用量,
//                           nvl(调整量,0) 调整量,
//                           nvl(单价,0) 单价,
//                            nvl(状态,0) 状态,
//                           nvl(小计,0)小计,综合单价 
//                      from (select  s.c_situation_use_month 月份,
//                                   s.n_degrees_start 起度,
//                                   s.n_degrees_end 止度,
//                                   s.n_dosage 用量,
//                                  s.n_charge_state as 状态,
//                                     (select sum(p.n_price)
//                  from yx_price p
//                 where p.n_properties_id = s.n_properties_id
//                   and p.n_parent_price_id = 0
//                   and p.n_ladder_number = 0 and N_PRICE_STATE=1 and p.n_company_id=s.n_company_id) 单价
//                              from yx_situation s, yx_detail n
//                             where n.n_cost_id = 1
//                               and s.n_situation_id = n.n_situation_id
//                                 and s.c_user_id = '" + UserId + @"'   and n.c_detail_use_month between    '" + startMonth + @"' and  '" + endMonth + @"'
//                           
//                               and s.n_calculation_way = 0
//                               and n.n_company_id = s.n_company_id
//                               and s.n_charge_state=1
//                             group by s.c_situation_use_month,
//                                      s.n_degrees_start,
//                                      s.n_degrees_end,
//                                      s.n_dosage,s.n_charge_state,
//                                      s.n_properties_id, s.n_company_id
//                                      ) a,
//                           (select decode(u.n_user_prestore_state,
//                      0,
//                      wmsys.wm_concat(decode(c.n_cost_id,
//                                             30,
//                                             '',
//                                             (c.c_cost_name ||
//                                             rtrim(to_char(t.n_detail_total_amount,
//                                                            'fm99999999990.99'),
//                                                    '.'))) || '元'),
//                      wmsys.wm_concat(c.c_cost_name ||
//                                      rtrim(to_char(t.n_detail_total_amount,
//                                                    'fm99999999990.99'),
//                                            '.') || '元')) 综合单价,
//               t.c_detail_use_month 月份,
//               sum(decode(u.n_user_prestore_state, 0,decode(c.n_cost_id,30,0, t.n_detail_amount),t.n_detail_amount)) 小计
//          from yx_detail t, yx_cost c, yx_user u
//         where t.c_user_id = '" + UserId + @"'
//           and u.c_user_id = t.c_user_id
//           and c.n_cost_id = t.n_cost_id    and t.c_detail_use_month between    '" + startMonth + @"' and  '" + endMonth + @"'
//        and t.n_charge_state=1
//         group by t.c_detail_use_month, u.n_user_prestore_state ) b,
//                           (select c_situation_use_month 月份,
//                                   d.n_degrees_start     起度,
//                                   d.n_degrees_end       止度,
//                                   d.n_real_dosage       调整量
//                              from yx_situation d
//                            where c_user_id = '" + UserId + @"'
//                               and d.c_situation_use_month  between   '" + startMonth + @"' and  '" + endMonth + @"'
//                               and n_calculation_way = 3
//                               and d.n_charge_state=1) c
//                     where b.月份 = a.月份(+)
//                       and b.月份 = c.月份(+)
//                     order by b.月份 desc");

                strSql.Append(@"select b.月份,
                           case
                             when a.起度 is null then
                              c.起度
                             else
                              a.起度
                           end as 起度,
                           case
                             when a.止度 is null then
                              c.止度
                             else
                              a.止度
                           end as 止度,
                          nvl(用量,0) 用量,
                           nvl(调整量,0) 调整量,
                           nvl(单价,0) 单价,
                            nvl(状态,0) 状态,
                           nvl(小计,0)小计,综合单价
                      from (select  s.c_situation_use_month 月份,
                                   s.n_degrees_start 起度,
                                   s.n_degrees_end 止度,
                                   s.n_dosage 用量,
                                  s.n_charge_state as 状态,
                                 wm_concat (N.N_DETAIL_PRICE)
              /* (select sum(p.n_price)
                  from yx_price p
                 where p.n_properties_id = s.n_properties_id
                   and p.n_parent_price_id = 0
                   and p.n_ladder_number = n.n_detail_ladder_number
                   and N_PRICE_STATE = 1
                   and p.n_company_id = s.n_company_id)*/ 单价
                    from yx_situation s, yx_detail n
                             where n.n_cost_id = 1
                               and s.n_situation_id = n.n_situation_id
                               and s.c_user_id =  '" + UserId + @"'
and n.c_detail_use_month between '" + startMonth + @"' and  '" + endMonth + @"'
                               and s.n_charge_state = 1 
                               and s.n_calculation_way = 0
                               and n.n_company_id = s.n_company_id
                             group by s.c_situation_use_month,
                                      s.n_degrees_start,
                                      s.n_degrees_end,
                                      s.n_dosage,s.n_charge_state,
                                      s.n_properties_id
                                      ) a,
                            (select  wmsys.wm_concat(c.c_cost_name || '('|| rtrim(to_char(t.n_detail_total_amount,'fm99999999990.99'),'.') ||'元)') 综合单价 ,t.c_detail_use_month 月份,
                                           sum(t.n_detail_amount) 小计
                                      from yx_detail t,yx_cost c
                                     where c_user_id =  '" + UserId + @"' and c.n_cost_id=t.n_cost_id and t.n_charge_state=1
                                        and t.c_detail_use_month  between   '" + startMonth + @"' and  '" + endMonth + @"'
                                     group by t.c_detail_use_month ) b,
                           (select c_situation_use_month 月份,
                                   d.n_degrees_start     起度,
                                   d.n_degrees_end       止度,
                                   d.n_real_dosage       调整量
                              from yx_situation d
                             where c_user_id = '" + UserId + @"'
and d.c_situation_use_month between '" + startMonth + @"' and  '" + endMonth + @"'
                                 and n_charge_state = 1 /*and d.c_situation_use_month between  201307 and  201401*/
                               and n_calculation_way = 3) c
                     where b.月份 = a.月份(+)
                       and b.月份 = c.月份(+)
                     order by b.月份 desc");
            }
            else
            {
                strSql.Append(@"select b.月份,
                           case
                             when a.起度 is null then
                              c.起度
                             else
                              a.起度
                           end as 起度,
                           case
                             when a.止度 is null then
                              c.止度
                             else
                              a.止度
                           end as 止度,
                          nvl(用量,0) 用量,
                           nvl(调整量,0) 调整量,
                           nvl(单价,0) 单价,
                            nvl(状态,0) 状态,
                           nvl(小计,0)小计, 综合单价  --,d.电子发票 电子发票
                      from (select  s.c_situation_use_month 月份,
                                   s.n_degrees_start 起度,
                                   s.n_degrees_end 止度,
                                   s.n_dosage 用量,
                                  s.n_charge_state as 状态,
                                  wm_concat (N.N_DETAIL_PRICE)
              /* (select sum(p.n_price)
                  from yx_price p
                 where p.n_properties_id = s.n_properties_id
                   and p.n_parent_price_id = 0
                   and p.n_ladder_number = n.n_detail_ladder_number
                   and N_PRICE_STATE = 1
                   and p.n_company_id = s.n_company_id)*/ 单价

                              from yx_situation s, yx_detail n
                             where n.n_cost_id = 1
                               and s.n_situation_id = n.n_situation_id
                               and s.c_user_id =  '" + UserId + @"'
                                and s.n_charge_state =1
                               and s.n_calculation_way = 0
                               and n.n_company_id = s.n_company_id
                             group by s.c_situation_use_month,
                                      s.n_degrees_start,
                                      s.n_degrees_end,
                                      s.n_dosage,s.n_charge_state,
                                      s.n_properties_id
                                      ) a,
                          (select wmsys.wm_concat(c.c_cost_name ||  rtrim(to_char(t.n_detail_total_amount,'fm99999999990.99'),'.')  || '元') 综合单价,
               t.c_detail_use_month 月份,
               sum(t.n_detail_amount) 小计
          from yx_detail t, yx_cost c
         where c_user_id = '" + UserId + @"'
           and c.n_cost_id = t.n_cost_id   and t.n_charge_state=1
         group by t.c_detail_use_month) b,
                           (select c_situation_use_month 月份,
                                   d.n_degrees_start     起度,
                                   d.n_degrees_end       止度,
                                   d.n_real_dosage       调整量
                              from yx_situation d
                             where c_user_id = '" + UserId + @"'
                                 and n_charge_state = 1 /*and d.c_situation_use_month between  201307 and  201401*/
                               and n_calculation_way = 3) c--,(select  t.pdfurl 电子发票 from gs_fp_return t,yx_situation i where i.n_invoice_id=t.sbvid and t.kpbz=1   ) d
                     where b.月份 = a.月份(+)
                       and b.月份 = c.月份(+)
                     order by b.月份 desc");
            }
            //DataTable dtqf = new OracleHelp().Select(strSql.ToString());
            //return dtqf;
            return new Sys_Command().GetDataTable(strSql.ToString());
        }

        /// <summary>
        /// 是否银行代扣
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static  bool IsYHDK(string UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select nvl(max(t.n_bank_tranid), -1)
      from yx_bank_transaction t, yx_bank_transaction_detail d
     where t.n_bank_tranid = d.n_bank_tranid
       and d.c_user_id  = '" + UserId + "'");
            string sql = string.Format(strSql.ToString(), UserId);
            string result = new Sys_Command().GetDataTable(strSql.ToString()).Rows[0][0].ToString();
            if (result != "-1")
            {
                string  Sql = @" select nvl(max(t.n_bank_tranid), -1)
      from yx_bank_transaction t, yx_bank_transaction_detail d
     where t.n_bank_tranid = d.n_bank_tranid
       and d.c_user_id  = '" + UserId + "'";
                string result2 = new Sys_Command().GetDataTable(strSql.ToString()).Rows[0][0].ToString();
                if (result2 == "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询用户用水性质
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static DataTable GetPropertiesName(string UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select p.c_properties_name from yx_properties  p , yx_user u where u.n_properties_id=p.n_properties_id  and (u.c_user_id = '" + UserId + "' and 1=1)");
            string sql = string.Format(strSql.ToString(), UserId);
            //return new OracleHelp().Select(sql.ToString());
            return new Sys_Command().GetDataTable(strSql.ToString());
        }

        /// <summary>
        /// 改变缴费状态
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool ChangeState(string userId, string startMonth, string endMonth)
        {
            string sql = "";
            if (!String.IsNullOrEmpty(startMonth) && !String.IsNullOrEmpty(endMonth))
            {

                sql=@"update yx_detail d set d.n_charge_state=6 where d.n_situation_id in (
select distinct s.n_situation_id from yx_detail s where s.n_charge_state=0
                                 and s.c_user_id = '" + userId + @"'   and n.c_detail_use_month between    '" + startMonth + @"' and  '" + endMonth + @"'
                                   );
update yx_situation d set d.n_charge_state=6 where d.n_situation_id in ( select distinct s.n_situation_id from yx_detail s where s.n_charge_state=0
                                 and s.c_user_id = '" + userId + @"'   and n.c_detail_use_month between    '" + startMonth + @"' and  '" + endMonth + @"'
                                   )";
            }
            else
            {
                sql=@"update yx_detail d set d.n_charge_state=6 where d.n_situation_id in ( select distinct s.n_situation_id from yx_detail s where s.n_charge_state=0  and s.c_user_id = '" + userId+@"') ;
              update yx_situation d set d.n_charge_state=6 where d.n_situation_id in ( select distinct s.n_situation_id from yx_detail s where s.n_charge_state=0  and s.c_user_id = '" + userId + @"' ) ";
            }
            int i = new Sys_Command().SQLSExcute(sql, "微信支付", "改变收费状态");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Object chargeTran = new Object();

        /// <summary>
        /// 缴费
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="minyf"></param>
        /// <param name="maxyf"></param>
        /// <param name="jfje"></param>
        public void Charge(string userid)
        {

            string sqlqf =  @"select b.月份,
                           case
                             when a.起度 is null then
                              c.起度
                             else
                              a.起度
                           end as 起度,
                           case
                             when a.止度 is null then
                              c.止度
                             else
                              a.止度
                           end as 止度,
                           用量,
                           调整量,
                           单价,
                           小计
                      from (select s.c_situation_use_month 月份,
                                   s.n_degrees_start 起度,
                                   s.n_degrees_end 止度,
                                   s.n_dosage 用量,
                                   sum(n.n_detail_price) 单价
                              from yx_situation s, yx_detail n
                             where n.n_cost_id = 1
                               and s.n_situation_id = n.n_situation_id
                               and s.c_user_id = '" + userid + @"' 
                               and s.n_charge_state = 0
                               and s.n_calculation_way = 0
                               and n.n_company_id = s.n_company_id
                             group by s.c_situation_use_month,
                                      s.n_degrees_start,
                                      s.n_degrees_end,
                                      s.n_dosage) a,
                           (select t.c_detail_use_month 月份,
                                   sum(t.n_detail_amount) 小计
                              from yx_detail t
                             where c_user_id = '" + userid + @"'
                               and n_charge_state = 0
                           
                             group by t.c_detail_use_month) b,
                           (select c_situation_use_month 月份,
                                   d.n_degrees_start     起度,
                                   d.n_degrees_end       止度,
                                   d.n_real_dosage       调整量
                              from yx_situation d
                             where c_user_id = '" + userid + @"'
                               and n_charge_state = 0
                               and n_calculation_way = 3) c
                     where b.月份 = a.月份(+)
                       and b.月份 = c.月份(+)
                     order by b.月份" ;
            DataTable dtqf = new Sys_Command().GetDataTable(sqlqf);

            LogUtil.WriteLog(sqlqf);

              if (dtqf != null && dtqf.Rows.Count > 0)
            {
                
          
                for (int i = 0; i < dtqf.Rows.Count; i++)
		    	{
                    decimal ysje = 0;
                    decimal lastye = 0;
                    decimal nowye = 0;
                    decimal fpjef = 0;
                    decimal yhye = decimal.Parse(new Sys_Command().GetDataTable("select  N_AMOUNT from yx_user t where t.c_user_id='" + userid + "' ").Rows[0][0].ToString());
                    fpjef = decimal.Parse(dtqf.Rows[i]["小计"].ToString());
                    nowye = lastye = yhye;
                    ysje = decimal.Parse(dtqf.Rows[i]["小计"].ToString());
                    if (yhye < ysje)//余额<小计
                    {
                        fpjef = ysje - nowye;//缴费金额=小计-当前余额
                        nowye = 0;
                    }
                    else //余额>=小计
                    {
                        fpjef = 0;
                        nowye = yhye - ysje;
                    }
                    string[] str = this.GetSituationIdsByUserIdAndMonth(userid, dtqf.Rows[i]["月份"].ToString(), "微信支付", "微信");

                    DataTable dt = new DataTable("orasptab");
                    dt.Columns.Add("pname", Type.GetType("System.String"));
                    dt.Columns.Add("pvalue", Type.GetType("System.String"));
                    dt.Columns.Add("dir", Type.GetType("System.String"));
                    dt.Columns.Add("size", Type.GetType("System.String"));
                    object[] parm = new object[4];
                    //参数名字 参数值 参数方向(in,out) 参数长度
                    //3.参数 第一个参数是费用情况的Id用，连接
                    //构造费用情况Id
                    //支付方式
                    string returnMsg = "";
                    //第一个参数  流水号 用水情况的年+月+用水情况的id
                    dt.Rows.Add(new object[] { "N_SWIFT_NUM", str[1], "1", 200 });
                    dt.Rows.Add(new object[] { "C_SITUATION_ID", str[0], "1", 2000 });
                    dt.Rows.Add(new object[] { "C_userId", userid, "1", 20 });
                    dt.Rows.Add(new object[] { "N_PAYMENTWAY", "0", "1", 1 });
                    dt.Rows.Add(new object[] { "C_INVOICE_VERSION_NUM", "0000", "1", 20 });
                    dt.Rows.Add(new object[] { "C_INVOICE_NUM", "0", "1", 20 });
                    //应收金额
                    dt.Rows.Add(new object[] { "n_invoice_totalAmount", ysje, "1", 12 });
                    //发票金额

                    dt.Rows.Add(new object[] { "n_invoicAmount", fpjef, "1", 12 });

                    dt.Rows.Add(new object[] { "n_lastBalance", lastye, "1", 12 });

                    dt.Rows.Add(new object[] { "n_nowBalance", nowye, "1", 12 });

                    dt.Rows.Add(new object[] { "n_cashierId", PayConfig.CASHIER, "1", 5 });
                    dt.Rows.Add(new object[] { "c_Err", returnMsg, "0", 200 });

                    LogUtil.WriteLog(str[1]+"|"+str[0]+"|"+userid+"|0|"+ysje+"|"+fpjef+"|"+lastye+"|"+nowye+"|"+PayConfig.CASHIER+"|"+returnMsg+"|");

                    string msg = new Sys_Command().ExepPro(dt, "pkg_charge.Proc_Charge", 11);

                    LogUtil.WriteLog(returnMsg);

                    if (msg.Substring(0, 1) != "1")
                    {
                        break;
                    }
                    LogUtil.WriteLog(msg);
                }
            }

        }

        public string[] GetSituationIdsByUserIdAndMonth(string userId, string month, string win, string logonName)
        {
            string sql = string.Format(@"select c_detail_use_month,
                                  n_situation_id ,
                                  n_calculation_way 
                            from yx_detail 
                            where c_user_id = '{0}'
                            and n_charge_state = 0
                            --and n_calculation_way <> 2
                            and c_detail_use_month='{1}' ", userId, month);

            DataTable dt = new Sys_Command().GetDataTable(sql);

            string situationIds = "";
            string swiftSituationId = "";
            string roundSituationId = "";
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    roundSituationId = dt.Rows[i]["n_situation_id"].ToString();

                    if (!dic.Keys.Contains(dt.Rows[i]["n_situation_id"].ToString()))
                    {
                        dic.Add(dt.Rows[i]["n_situation_id"].ToString(), "");
                    }
                    if (dt.Rows[i]["n_calculation_way"].ToString() == "0")
                    {
                        swiftSituationId = dt.Rows[i]["n_situation_id"].ToString();
                    }
                }
            }


            if (dic != null && dic.Count > 0)
            {
                foreach (var item in dic)
                {
                    if (situationIds == "")
                    {
                        situationIds += item.Key.ToString();
                    }
                    else
                    {
                        situationIds += "," + item.Key.ToString();
                    }
                }
            }

            string swiftNumber = "";
            if (swiftSituationId != "")
            {
                swiftNumber = month + swiftSituationId;
            }
            else
            {
                swiftNumber = month + roundSituationId;
            }

            string[] arr = new string[] { situationIds, swiftNumber };

            return arr;
        }


        public void writeLog(string sql)
        {
            string str = sql.Trim();
            string isSelect = str.Substring(0, 6);

            //1.创建第一个大的文件夹  名字叫：ORA_LOG
            string firstFoler = "ORA_LOGWX";
            string secondFoler = DateTime.Now.ToString("yyyy-MM-dd");
            if (!Directory.Exists("D:" + "\\" + firstFoler))
            {
                //创建该文件夹
                Directory.CreateDirectory("D:" + "\\" + firstFoler);

                //创建二级文件夹
                Directory.CreateDirectory("D:" + "\\" + firstFoler + "\\" + secondFoler);
            }
            else
            {
                //2.创建第二级文件夹  以当天的日期命名
                if (!Directory.Exists("D:" + "\\" + firstFoler + "\\" + secondFoler))
                {
                    //创建
                    Directory.CreateDirectory("D:" + "\\" + firstFoler + "\\" + secondFoler);
                }
            }


            string url = "D:" + "\\" + firstFoler + "\\" + secondFoler;

            string filename = url + "\\微信支付_" + DateTime.Now.ToString("yyyyMMdd") + " ";
            //  string filename = System.Configuration.ConfigurationSettings.AppSettings["PayLogPath "] + TradeTime.Substring(0, 8) + ".txt ";

            File.AppendAllText(filename, sql + ";\r\n");
        }

        /// <summary>
        /// 绑定用户
        /// </summary>
        /// <param name="sql"></param>
        public static bool  BindId(string userid,string openid,string  userpassword)
        {
            string sql = @" insert into wx_bind_id
                            (c_user_id, c_opendid, n_bind_state, c_password)
                          values
                            ('" + userid + @"', '" + openid + @"', '1' ,'" + userpassword +@"') ";
            int i = new Sys_Command().SQLExcute(sql);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取消用户
        /// </summary>
        /// <param name="sql"></param>
        public static bool BindCancelId(string userid,string opendid)
        {
            string sql = @"update wx_bind_id
   set  n_bind_state = 0
 where  c_user_id='" + userid + @"' and c_opendid='" + opendid + "'";
       //and C_password='" + UserPassword + "'
            int i = new Sys_Command().SQLExcute(sql);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="sql"></param>
        public static DataTable SelectBindId1(string userid)
        {
           // string sql = @"select c_user_id,  n_bind_state,c_password  from wx_bind_id   where c_opendid='" + openid + "' and n_bind_state=1";
            string sql = @"select c_user_id,  n_bind_state,c_password  from wx_bind_id   where c_user_id='" + userid + "' and n_bind_state=1";
            return new Sys_Command().GetDataTable(sql);
        }
        public static DataTable SelectBindId(string openid)
        {
            string sql = @"select c_user_id,  n_bind_state,c_password  from wx_bind_id   where c_opendid='" + openid + "' and n_bind_state=1";
            // string sql = @"select c_user_id,  n_bind_state,c_password  from wx_bind_id   where c_user_id='" + userid + "' and n_bind_state=1";
            return new Sys_Command().GetDataTable(sql);
        }
        /// <summary>
        /// 查询用户订单号
        /// </summary>
        /// <param name="sql"></param>
        public static DataTable SelectWXORDERSN()
        {
            string sql = @"select to_char(WXORDERSN.NEXTVAL) 单号 from dual";

            return new Sys_Command().GetDataTable(sql);

        }

        /// <summary>
        /// 绑定用户订单号
        /// </summary>
        /// <param name="sql"></param>
        public static bool NumCall(string userid)
        {
            string sql = @" insert into WX_NumCall
                            (C_USER_OPEN)
                          values
                            ('" + userid + @"') ";
            int i = new Sys_Command().SQLExcute(sql);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询用户订单号是否存在
        /// </summary>
        /// <param name="sql"></param>
        public static DataTable numcall(string openid)
        {
            string sql = @"select * from wx_numcall t where t.c_user_open='" + openid + "'";
            return new Sys_Command().GetDataTable(sql);
        }
    }
}
