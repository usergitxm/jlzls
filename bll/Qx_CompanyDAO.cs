using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace bll
{
   public class Qx_CompanyDAO
   {      /// <summary>
       /// 查询公司
       /// </summary>
       /// <returns></returns>
       public  DataTable getCompany(string companyID, string win, string logonName)
       {

           string sql = @"select N_COMPANY_ID,
       N_PARENT_COMPANY_ID,
       C_COMPANY_NAME,
       C_COMPANY_ADDRESS,
       N_COMPANY_PHONE,
       C_COMPANY_REMARK,
       C_COMPANY_OPERATOR,
       D_COMPANY_OPERATION_TIME,
       N_COMPANY_STATE
  from qx_company
 where N_COMPANY_STATE = 1 and N_COMPANY_ID in (select N_COMPANY_ID from qx_company start with N_COMPANY_ID = " + companyID + @" connect by prior N_COMPANY_ID = N_PARENT_COMPANY_ID)";

           DataTable result = new Sys_Command().GetDataTable(sql);

           return result;
       }
    }
}
