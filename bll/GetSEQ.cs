using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using THKModel;
using System.Data;

namespace bll
{
  public  class GetSEQ
    {
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
        }// 
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

                   // Add(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }//
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
    }
}
