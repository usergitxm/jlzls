using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using THKModel;

namespace bll
{
  public  class Businiss
    {

        /// <summary>
        /// 查询全部申请类型
        /// </summary>
        /// <returns></returns>
      public static DataTable Select(string C_INSTALL_TYPE_NAME, string win, string logonName)
        {
          string sql="";
          if (C_INSTALL_TYPE_NAME == "")
          {

              sql = "select N_INSTALL_TYPE_ID,C_INSTALL_TYPE_NAME,C_INSTALL_TYPE_REMARK,qx_systemuser.c_user_name,D_INSTALL_TYPE_OPERATION_TIME from  BZ_INSTALL_TYPE ,qx_systemuser where BZ_INSTALL_TYPE.N_INSTALL_TYPE_OPERATOR_ID=qx_systemuser.n_systemuser_id ";
          }
          else
          {
              sql = "select N_INSTALL_TYPE_ID,C_INSTALL_TYPE_NAME,C_INSTALL_TYPE_REMARK,qx_systemuser.c_user_name,D_INSTALL_TYPE_OPERATION_TIME from  BZ_INSTALL_TYPE ,qx_systemuser where BZ_INSTALL_TYPE.N_INSTALL_TYPE_OPERATOR_ID=qx_systemuser.n_systemuser_id and C_INSTALL_TYPE_NAME='" + C_INSTALL_TYPE_NAME + @"'";
          
          }
            DataTable dt = new  Sys_Command().GetDataTable(sql);
            return dt;
        }
      public static System.Data.DataTable GetPropertiesList(decimal state, decimal companyid, string win, string logonName, string C_PROPERTIES_NAME)
        {
          string sql="";
          if (C_PROPERTIES_NAME == "")
          {
              sql = "select distinct p.* from YX_PROPERTIES p,yx_price pr where p.N_PROPERTIES_STATE =" + state + " and pr.n_properties_id=p.n_properties_id and pr.n_company_id in(select N_COMPANY_ID from qx_company start with N_COMPANY_ID = " + companyid + " connect by prior N_COMPANY_ID = N_PARENT_COMPANY_ID)";
          }
          else
          {
              sql = "select distinct p.* from YX_PROPERTIES p,yx_price pr where p.N_PROPERTIES_STATE =" + state + " and pr.n_properties_id=p.n_properties_id and pr.n_company_id in(select N_COMPANY_ID from qx_company start with N_COMPANY_ID = " + companyid + " connect by prior N_COMPANY_ID = N_PARENT_COMPANY_ID) and C_PROPERTIES_NAME='" + C_PROPERTIES_NAME + @"'";
          }
             

            DataTable dt = new Sys_Command().GetDataTable(sql);

            return dt;
        }

      /// <summary>
      /// 查询所有项目类型

      /// </summary>
      /// <returns></returns>
      public System.Data.DataTable ProJectSelect(string win, string logonName)
      {
         

          string sql = @"select t.n_project_type_id,
			 t.c_project_type_name,
			 t.c_project_type_remark,
			 t.n_project_type_operator_id,
			 t.d_project_type_operation_time
	from BZ_PROJECT_TYPE t";

          return new Sys_Command().GetDataTable(sql);
      }
        /// <summary>
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

           // string addstate = myservice.ExcuteProcEXTex("Pkg_Public_Method.Proc_Get_Sequences_ID_identity", dt, "any", "getNextandIdentity", "获取下一个序列值并自增", 2, "");

            string addstate = new Sys_Command().ExepPro(dt, "Pkg_Public_Method.Proc_Get_Sequences_ID_identity", 2);
             decimal.TryParse(addstate, out result);

            return result;
        }
        /// <summary>
        /// 根据KEY值取有效流程
        /// </summary>
        /// <param name="keyCom"></param>
        /// <returns></returns>
        public static THKModel.Yx_Process SelectByKeyCom(string keyCom, string win, string logonName)
        {
         
            string sql = "select * from YX_PROCESS where C_PROCESS_REQUESTION_COM='" + keyCom + "' and N_PROCESS_STATE=1";

            DataTable dt = new Sys_Command().GetDataTable(sql);
            THKModel.Yx_Process model = new THKModel.Yx_Process();
            foreach (DataRow dr in dt.Rows)
            {
                model.N_Process_ID = decimal.Parse(dr["N_PROCESS_ID"].ToString());
                model.C_Process_Name = dr["C_PROCESS_NAME"].ToString();
                model.N_Process_State = decimal.Parse(dr["N_PROCESS_STATE"].ToString());
                model.Process_operator = getSysUserById(decimal.Parse(dr["N_PROCESS_OPERATOR_ID"].ToString()), win, logonName);
                model.D_Process_Operatoin_Time = DateTime.Parse(dr["D_PROCESS_OPERATOIN_TIME"].ToString());
                model.C_PROCESS_REQUESTION_COM = dr["C_PROCESS_REQUESTION_COM"].ToString();
            }
            return model;
        }

        /// <summary>
        /// 查询公司
        /// </summary>
        /// <param name="cid">公司ID</param>
        /// <returns></returns>
        public static Qx_Company getCompany(int cid, string win, string logonName)
        {
          

            string sql = @"select N_COMPANY_ID,N_PARENT_COMPANY_ID,C_COMPANY_NAME,C_COMPANY_ADDRESS,N_COMPANY_PHONE,C_COMPANY_REMARK,C_COMPANY_OPERATOR,D_COMPANY_OPERATION_TIME,N_COMPANY_STATE from qx_company where N_COMPANY_STATE=1 and N_COMPANY_ID=" + cid;

            DataTable dt = new Sys_Command().GetDataTable(sql);
            Qx_Company model = new Qx_Company();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model.N_Company_Id = decimal.Parse(dr["N_COMPANY_ID"].ToString());
                    model.N_Parent_Company_Id = decimal.Parse(dr["N_PARENT_COMPANY_ID"].ToString());
                    model.C_Company_Name = dr["C_COMPANY_NAME"].ToString();
                    model.C_Company_Address = dr["C_COMPANY_ADDRESS"].ToString();
                    model.N_Company_Phone = decimal.Parse(dr["N_COMPANY_PHONE"].ToString());
                    model.C_Company_Remark = dr["C_COMPANY_REMARK"].ToString();
                    model.C_Company_Operator = dr["C_COMPANY_OPERATOR"].ToString();
                    model.D_Company_Operation_Time = DateTime.Parse(dr["D_COMPANY_OPERATION_TIME"].ToString());
                    model.N_Company_State = decimal.Parse(dr["N_COMPANY_STATE"].ToString());
                }
            }
            else
            {
                model = null;
            }
            return model;
        }

        /// <summary>
        /// 根据用户ID获取用户
        /// </summary>
        /// <param name="sysUserId"></param>
        /// <returns></returns>
        public static THKModel.Qx_SystemUser getSysUserById(decimal sysUserId, string win, string logonName)
        {
            string sql = "select * from Qx_Systemuser t where t.n_systemuser_id=" + sysUserId + "";



            DataTable dt = new Sys_Command().GetDataTable(sql);

            THKModel.Qx_SystemUser model = new THKModel.Qx_SystemUser();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model.N_SystemUser_Id = decimal.Parse(dr["N_SYSTEMUSER_ID"].ToString());
                    model.C_Login_Name = dr["C_LOGIN_NAME"].ToString();
                    model.C_Login_Password = dr["C_LOGIN_PASSWORD"].ToString();
                    model.C_User_Name = dr["C_USER_NAME"].ToString();
                    model.CompanyId = int.Parse(dr["N_COMPANY_ID"].ToString());
                  //  model.ComPanyModel =Businiss.getCompany(1, win, logonName);
                    model.DeparementId = int.Parse(dr["N_DEPARTMENT_ID"].ToString());
                    model.DeparementModel = getDepartment(model.DeparementId, win, logonName);
                    model.Position = getPosition(int.Parse(dr["N_POSITION_ID"].ToString()), win, logonName);
                    model.N_Job_State = decimal.Parse(dr["N_JOB_STATE"].ToString());
                    model.C_Role_Id = dr["C_ROLE_ID"].ToString();
                    model.C_Sex = dr["C_SEX"].ToString();
                    model.D_Birthday = DateTime.Parse(dr["D_BIRTHDAY"].ToString());
                    model.C_Political_Face = dr["C_POLITICAL_FACE"].ToString();
                    model.C_Education = dr["C_EDUCATION"].ToString();
                    model.C_Phone = dr["C_PHONE"].ToString();
                    model.C_Address = dr["C_ADDRESS"].ToString();
                    model.N_Postcode = dr["C_POSTCODE"].ToString();
                    model.C_Fax = dr["C_FAX"].ToString();
                    model.C_Oicq = dr["C_OICQ"].ToString();
                    model.C_Email = dr["C_EMAIL"].ToString();
                    model.C_User_Remark = dr["C_USER_REMARK"].ToString();
                    model.N_User_State = decimal.Parse(dr["N_USER_STATE"].ToString());
                    model.N_Show_Message = decimal.Parse(dr["N_SHOW_MESSAGE"].ToString());
                    model.N_Msg_Timeinterval = decimal.Parse(dr["N_MSG_TIMEINTERVAL"].ToString());
                    model.C_User_Operator = dr["C_SYSTEMUSER_OPERATOR"].ToString();
                    model.D_User_Operation_Time = DateTime.Parse(dr["D_SYSTEMUSER_OPERATION_TIME"].ToString());
                    model.N_Signature_IsUse = decimal.Parse(dr["N_SIGNATURE_USE_STATE"].ToString());
                    model.N_Online_State = Convert.ToDecimal(dr["N_ONLINE_STATE"].ToString() == "" ? "0" : dr["N_ONLINE_STATE"].ToString());
                    if (dr["D_LOGIN_TIME"].ToString() != "")
                    {
                        model.D_Logon_Time = Convert.ToDateTime(dr["D_LOGIN_TIME"].ToString());
                    }
                    model.C_PCID = dr["C_PCID"].ToString();
                }
            }
            else
            {
                model = null;
            }
            return model;
        }//
 

        /// <summary>
        /// 得到下一队列
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="firstQueue"></param>
        /// <returns></returns>
        public static string GetNextNum(string processId, string firstQueue, string win, string logonName)
        {
            string nextNum = string.Empty;
            string sql = "select t.n_queue_id_right from yx_condition t where  t.n_process_id=" + processId + " and t.n_queue_id_left=" + firstQueue;



            DataTable dt = new Sys_Command().GetDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                nextNum = dr["n_queue_id_right"].ToString();
            }

            return nextNum;
        }


        /// <summary>
        /// 报装申请
        /// </summary>
        /// <param name="businessmodel">业务实体</param>
        /// <param name="applimodel">报装实体</param>
        /// <param name="tranmodel1">流程实体</param>
        /// <param name="tranmodel2">流转流程实体</param>
        /// <returns></returns>
        public static int AddApplication(THKModel.Yx_Business businessmodel, THKModel.Bz_Application applimodel, THKModel.Yx_Transation tranmodel1, THKModel.Yx_Transation tranmodel2, string win, string logonName)
        {
            string sql = "";

            string sql1 = "insert into YX_BUSINESS(N_BUSINESS_ID,C_BUSINESS_NAME,N_PROCESS_ID,N_BUSINESS_STATE,N_BUSINESS_OPERATOR_ID,D_BUSINESS_OPERATION_TIME) values('" + businessmodel.N_Business_ID + "','" + businessmodel.C_Business_Name + "','" + businessmodel.N_Process.N_Process_ID + "','" + businessmodel.N_Business_State + "','" + businessmodel.N_Business_Operator.N_SystemUser_Id + "',to_date('" + businessmodel.D_Business_Operation_Time + "','yyyy-mm-dd hh24:mi:ss'))";

            string sql2 = string.Format(@" insert into BZ_APPLICATION(N_APPLICATION_ID, N_INSTALL_TYPE_ID, N_PROJECT_TYPE_ID,N_PROPERTIES_ID,C_APPLICATION_NAME,N_APPLICATION_COUNT,D_APPLICATION_OPERATION_TIME,
   N_APPLICATION_OPERATOR_ID,C_APPLICATION_PHONE, C_AGENT_NAME, C_AGENT_PHONE, C_AGENT_IDENTITY_CARD,N_PLAN_QUANTITY,C_RESIDENTIAL_NAME, C_DEVELOPERS_NAME, C_RESIDENTIAL_ADDRESS, C_USER_IDENTITY_CARD,
   N_HOUSING_AREA, C_EQUIPMENT_PRESSURE,  C_LEGAL_PERSON_NAME, C_LEGAL_PERSON_IDENTITY_CARD,  C_HOUSE, C_UNIT,  C_FLOOR,  C_APPLICATION_REMARK, N_BUSINESS_ID,  C_USER_ID, N_THE_OPENING_BANK,
   N_BANK_ACCOUNT, N_ELEVATION,  N_METER_TYPE, N_PAYMENT_WAY, N_USER_STATE, N_INSTALL_MODE,  C_AGENT_PHONE_SJ)values ( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', to_date('{6}','yyyy-mm-dd hh24:mi:ss'), '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}',
  '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}')", applimodel.N_Application_ID, applimodel.N_install_Type.N_Install_Type_ID, applimodel.N_Project_Type.N_Project_Type_ID,
 applimodel.N_Properties.N_Properties_Id, applimodel.C_Application_Name, applimodel.N_Application_Count, applimodel.D_Application_Operator_Time, applimodel.N_Application_Operator.N_SystemUser_Id, applimodel.C_Application_Phone,
 applimodel.C_Agent_Name, applimodel.C_Agent_Phone, applimodel.C_Agent_Identity_Card, applimodel.N_Plan_Quantity, applimodel.C_Residential_Name, applimodel.C_Developers_Name, applimodel.C_Residential_Address,
 applimodel.C_User_Identity_Card, applimodel.N_Housing_Area, applimodel.C_Equipment_Pressure, applimodel.C_Legal_Person_Name, applimodel.C_Legal_Person_Identity_Card, applimodel.C_House, applimodel.C_Unit,
 applimodel.C_Floor, applimodel.C_Application_Remark, applimodel.N_Business.N_Business_ID, applimodel.C_User_ID, applimodel.N_THE_OPENING_BANK, applimodel.N_BANK_ACCOUNT, applimodel.N_ELEVATION, applimodel.N_METER_TYPE,
applimodel.N_PAYMENT_WAY, applimodel.N_USER_STATE, applimodel.N_INSTALL_MODE, applimodel.C_AGENT_PHONE_SJ);

            string sql3 = "insert into YX_TRANSACTION values('" + tranmodel1.N_Transaction_ID + "','" + tranmodel1.N_Process.N_Process_ID + "','" + tranmodel1.N_Queue.N_Queue_ID + "','" + tranmodel1.N_Business.N_Business_ID + "','" + tranmodel1.N_Transaction_State + "','" + tranmodel1.N_Transaction_Comment + "','" + tranmodel1.C_Transactor_ID + "',to_date('" + tranmodel1.D_Transaction_Time_Begin + "','yyyy-mm-dd hh24:mi:ss'),to_date('" + tranmodel1.D_Transaction_Time_End + "','yyyy-mm-dd hh24:mi:ss'),to_date('" + tranmodel1.D_Transaction_Time_due + "','yyyy-mm-dd hh24:mi:ss'),'" + tranmodel1.N_Transaction_Due_State + "','" + tranmodel1.C_TRANSACTOR_SIGNATURE + "','" + tranmodel1.N_LAST_BACE_TRANSACTION_ID + "')";

            string sql4 = "insert into YX_TRANSACTION values('" + tranmodel2.N_Transaction_ID + "','" + tranmodel2.N_Process.N_Process_ID + "','" + tranmodel2.N_Queue.N_Queue_ID + "','" + tranmodel2.N_Business.N_Business_ID + "','" + tranmodel2.N_Transaction_State + "','" + tranmodel2.N_Transaction_Comment + "','" + tranmodel2.C_Transactor_ID + "',to_date('" + tranmodel2.D_Transaction_Time_Begin + "','yyyy-mm-dd hh24:mi:ss'),to_date('" + tranmodel2.D_Transaction_Time_End + "','yyyy-mm-dd hh24:mi:ss'),to_date('" + tranmodel2.D_Transaction_Time_due + "','yyyy-mm-dd hh24:mi:ss'),'" + tranmodel2.N_Transaction_Due_State + "','" + tranmodel2.C_TRANSACTOR_SIGNATURE + "','" + tranmodel2.N_LAST_BACE_TRANSACTION_ID + "')";

            sql = sql1 + ";" + sql2 + ";" + sql3 + ";" + sql4;
            if (applimodel.D_WATER_PERIOD_TIME.ToString().Length > 0)
            {
                string sql5 = " update bz_application a set a.d_water_period_time = to_date('" + applimodel.D_WATER_PERIOD_TIME.ToString() + "','yyyy-mm-dd hh24:mi:ss')  where a.n_application_id ='" + applimodel.N_Application_ID + "'";
                sql = sql1 + ";" + sql2 + ";" + sql3 + ";" + sql4 + ";" + sql5;
            }


            if (applimodel.C_User_ID != "")
            {
                string sql6 = "update yx_user set N_USER_STATE=8 where C_USER_ID='" + applimodel.C_User_ID + "'";
                string sql7 = "update yx_user set C_USER_SYN=" + applimodel.N_USER_STATE + " where C_USER_ID='" + applimodel.C_User_ID + "'";

                sql = sql + ";" + sql6 + ";" + sql7;
            }

            return new Sys_Command().SQLSExcute(sql, win, logonName);
        }


        /// <summary>
        /// 计算出特定流程的特定办理节点的到期时间

        /// </summary>
        /// <param name="queue">流程队列</param>
        /// <param name="startTime">开始时间</param>
        /// <returns></returns>
        public static DateTime getTransactionTimeDue(THKModel.Yx_Queue queue, DateTime startTime, string win, string logonName)
        {
            string transactors = queue.C_Queue_Transaction_ID;

            #region 解决周末问题（遇到周末直接将节点办理的开始时间后移可以避免周末和节假日的交叉作用）

            if (startTime.DayOfWeek == DayOfWeek.Sunday)
            {
                startTime = startTime.AddDays(1);
            }
            else if (startTime.DayOfWeek == DayOfWeek.Saturday)
            {
                startTime = startTime.AddDays(2);
            }
            {
                if (((int)startTime.DayOfWeek + (int)queue.N_Node.N_Transaction_Time) > 5)
                {
                    startTime = startTime.AddDays(2);
                }
            }
            #endregion

            DateTime finishTime = startTime.AddDays(Convert.ToDouble(queue.N_Node.N_Transaction_Time));

            string sql = @"select h.d_holiday_start_date, h.d_holiday_end_date
  from yx_holiday h
 where h.n_company_id in
       (select distinct t.n_company_id
          from qx_systemuser t
         where t.n_systemuser_id in (" + transactors + "))";

            //ServiceHelper shelper = new ServiceHelper();
            //THKDAO.ThinkerService.Service myservice = null;
            //myservice = shelper.getService();

            DataTable dt = new Sys_Command().GetDataTable(sql);// ServiceHelper.getDataTable(myservice.ExcuteQueryTex(sql, win, "getTransactionTimeDue", "计算出特定流程的特定办理节点的到期时间", logonName));
            List<int> timeInterval = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {
                //除“办理开始时间在节假日结束之后”或“预期到期时间在节假日开始之前”之外节假日均可能对“到期时间”产生影响

                if (!(startTime > DateTime.Parse(dr["D_HOLIDAY_END_DATE"].ToString()) || finishTime < DateTime.Parse(dr["D_HOLIDAY_START_DATE"].ToString())))
                {
                    //若开始时间在节假日开始之前则到期时间向后推移节假日的长度
                    if (startTime <= DateTime.Parse(dr["D_HOLIDAY_START_DATE"].ToString()))
                    {
                        timeInterval.Add((DateTime.Parse(dr["D_HOLIDAY_END_DATE"].ToString()) - DateTime.Parse(dr["D_HOLIDAY_START_DATE"].ToString())).Days);
                    }
                    else //若开始时间在节假日开始之后则到期时间向后推移开始时间到节假日结束时间之间的时间间隔的长度
                    {
                        timeInterval.Add((DateTime.Parse(dr["D_HOLIDAY_END_DATE"].ToString()) - startTime).Days);
                    }

                }
            }
            //若节假日对“到期时间”没有产生影响则到期时间就不用向后推移（即推移0天）防止timeInterval的Count为0而报错

            if (timeInterval.Count <= 0)
            {
                timeInterval.Add(0);
            }
            finishTime = finishTime.AddDays(timeInterval.Max());

            return finishTime;
        }

        public static THKModel.Yx_Queue SelectStart(decimal processid, string win, string logonName)
        {
        //    Yx_NodeDAO nodedao = new Yx_NodeDAO();
         //  Yx_ProcessDAO processdao = new Yx_ProcessDAO();
  

            string sql = "select * from YX_QUEUE where N_PROCESS_ID=" + processid.ToString() + " and N_QUEUE_NUMBER=1";

            DataTable dt = new Sys_Command().GetDataTable(sql);

            THKModel.Yx_Queue model = new THKModel.Yx_Queue();

            foreach (DataRow dr in dt.Rows)
            {
                model.N_Queue_ID = decimal.Parse(dr["N_QUEUE_ID"].ToString());
                model.N_Process = SelectByIDProcessID(decimal.Parse(dr["N_PROCESS_ID"].ToString()), win, logonName);
                model.N_Node = SelectByIDnodeID(decimal.Parse(dr["N_NODE_ID"].ToString()), win, logonName);
                model.N_Queue_Number = decimal.Parse(dr["N_QUEUE_NUMBER"].ToString());
                model.C_Queue_Transaction_ID = dr["C_QUEUE_TRANSACTOR_ID"].ToString();
                model.N_Audit_Type = decimal.Parse(dr["N_AUDIT_TYPE"].ToString());
                model.C_QUEUE_BLOCK = dr["C_QUEUE_BLOCK"].ToString();
                model.C_SPICAL_TABLE = dr["C_SPICAL_TABLE"].ToString();
                model.C_SPICAL_COL = dr["C_SPICAL_COL"].ToString();
            }

            return model;
        }

        /// <summary>
        /// 根据编号取实体

        /// </summary>
        /// <param name="ProcessID">流程编号</param>
        /// <returns></returns>
        public static THKModel.Yx_Process SelectByIDProcessID(decimal ProcessID, string win, string logonName)
        {
          //  Qx_SystemUserDAO userdao = new Qx_SystemUserDAO();
           
            string sql = "select * from YX_PROCESS where N_PROCESS_ID=" + ProcessID;

            DataTable dt = new Sys_Command().GetDataTable(sql);

            THKModel.Yx_Process model = new THKModel.Yx_Process();
            foreach (DataRow dr in dt.Rows)
            {
                THKModel.Qx_SystemUser y = new THKModel.Qx_SystemUser();
                y.C_User_Operator = "107";
                model.N_Process_ID = decimal.Parse(dr["N_PROCESS_ID"].ToString());
                model.C_Process_Name = dr["C_PROCESS_NAME"].ToString();
                model.N_Process_State = decimal.Parse(dr["N_PROCESS_STATE"].ToString());
                model.Process_operator = y;// getSysUserById(decimal.Parse(dr["N_PROCESS_OPERATOR_ID"].ToString()), win, logonName);
                model.D_Process_Operatoin_Time = DateTime.Parse(dr["D_PROCESS_OPERATOIN_TIME"].ToString());
                model.C_PROCESS_REQUESTION_COM = dr["C_PROCESS_REQUESTION_COM"].ToString();
            }
            return model;
        }

        /// <summary>
        /// 根据ID查询方法
        /// </summary>
        /// <param name="nodeID">节点编号</param>
        /// <returns></returns>
        public static THKModel.Yx_Node SelectByIDnodeID(decimal nodeID, string win, string logonName)
        {
          //  Qx_SystemUserDAO userdao = new Qx_SystemUserDAO();
          
            string sql = "select * from YX_NODE where N_NODE_ID=" + nodeID;
            DataTable dt = new Sys_Command().GetDataTable(sql);
            THKModel.Yx_Node model = new THKModel.Yx_Node();
            foreach (DataRow dr in dt.Rows)
            {
                model.N_Node_ID = decimal.Parse(dr["N_NODE_ID"].ToString());
                model.C_Node_Name = dr["C_NODE_NAME"].ToString();
                model.C_Template_Path = dr["C_TEMPLATE_PATH"].ToString();
                model.C_Node_State = decimal.Parse(dr["N_NODE_STATE"].ToString());
                model.N_Transaction_Time = decimal.Parse(dr["N_TRANSACTION_TIME"].ToString());
                model.N_Node_Type = decimal.Parse(dr["N_NODE_TYPE"].ToString());
                model.Node_operator = getSysUserById(decimal.Parse(dr["N_NODE_OPERATOR_ID"].ToString()), win, logonName);
                model.D_Node_Operation_Time = DateTime.Parse(dr["D_NODE_OPERATION_TIME"].ToString());
            }
            return model;
        }



        /// <summary>
        /// 查询职位
        /// </summary>
        /// <param name="pid">职位ID</param>
        /// <returns>职位实体类</returns>
        public static  THKModel.Qx_Position getPosition(int pid, string win, string logonName)
        {
           

            string sql = @"SELECT N_POSITION_ID,N_DEPARTMENT_ID, C_POSITION_NAME, C_POSITION_REMARK, 
                           C_POSITION_OPERATOR, D_POSITION_OPERATION_TIME,N_POSITION_STATE FROM QX_POSITION WHERE N_POSITION_ID=" + pid;

            DataTable dt = new Sys_Command().GetDataTable(sql);

            THKModel.Qx_Position model = new THKModel.Qx_Position();
            if (dt != null && dt.Rows.Count > 0)
            {
              //  Qx_DepartmentDAO dep = new Qx_DepartmentDAO();

                foreach (DataRow dr in dt.Rows)
                {
                    model.N_Position_Id = decimal.Parse(dr["N_POSITION_ID"].ToString());
                    model.N_Department_Id = decimal.Parse(dr["N_DEPARTMENT_ID"].ToString());
                    model.Department = getDepartment(int.Parse(dr["N_DEPARTMENT_ID"].ToString()), win, logonName);
                    model.C_Position_Name = dr["C_POSITION_NAME"].ToString();
                    model.C_Position_Remark = dr["C_POSITION_REMARK"].ToString();
                    model.C_Position_Operator = dr["C_POSITION_OPERATOR"].ToString();
                    model.D_Position_Operation_Time = DateTime.Parse(dr["D_POSITION_OPERATION_TIME"].ToString());
                    model.N_Position_State = decimal.Parse(dr["N_POSITION_STATE"].ToString());
                }
            }
            else
            {
                model = null;
            }
            return model;
        }

       
        /// <summary>
        /// 查询部门
        /// </summary>
        /// <param name="model">部门ID</param>
        /// <returns>部门实体类</returns>
        public static THKModel.Qx_Department getDepartment(int did, string win, string logonName)
        {
           
            string sql = @"SELECT N_DEPARTMENT_ID, N_COMPANY_ID, N_PARENT_DEPARTMENT_ID,C_DEPARTMENT_NAME, N_DEPARTMENT_PHONE, C_DEPARTMENT_REMARK, 
                           C_DEPARTMENT_OPERATOR, D_DEPARTMENT_OPERATION_TIME,N_DEPARTMENT_STATE FROM QX_DEPARTMENT WHERE N_DEPARTMENT_ID=" + did;

            DataTable dt = new Sys_Command().GetDataTable(sql);

            THKModel.Qx_Department model = new THKModel.Qx_Department();

            if (dt != null && dt.Rows.Count > 0)
            {
                Qx_CompanyDAO company = new Qx_CompanyDAO();
                foreach (DataRow dr in dt.Rows)
                {
                    model.N_Department_Id = decimal.Parse(dr["N_DEPARTMENT_ID"].ToString());
                    model.N_ComPany_Id = int.Parse(dr["N_COMPANY_ID"].ToString());

                  //  model.Company = Businiss.getCompany(int.Parse(dr["N_COMPANY_ID"].ToString()), "", "");
                    model.N_Parent_Department_Id = decimal.Parse(dr["N_PARENT_DEPARTMENT_ID"].ToString());
                    model.C_Department_Name = dr["C_DEPARTMENT_NAME"].ToString();
                    model.N_Department_Phone = decimal.Parse(dr["N_DEPARTMENT_PHONE"].ToString());
                    model.C_Department_Remark = dr["C_DEPARTMENT_REMARK"].ToString();
                    model.C_Department_Operator = dr["C_DEPARTMENT_OPERATOR"].ToString();
                    model.D_Department_Operation_Time = DateTime.Parse(dr["D_DEPARTMENT_OPERATION_TIME"].ToString());
                    model.N_Department_State = decimal.Parse(dr["N_DEPARTMENT_STATE"].ToString());
                }
            }
            else
            {
                model = null;
            }
            return model;
        }

  
    }
}
