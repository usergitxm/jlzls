using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;

namespace bll
{
    public class Sys_Command
    {
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime getServiceTime()
        {
            bll.ThinkersoftService.Service myservice = new ServiceHelper().getService();

            string sql = @"select sysdate from dual";

            DataTable dt = ServiceHelper.getDataTable(myservice.ExcuteQueryTex(sql, "", "getServiceTime", "获取服务器时间", ""));

            DateTime result = DateTime.Parse(dt.Rows[0][0].ToString());

            return result;
        }

      
        /// <summary>
        /// 创建更新目录
        /// </summary>
        /// <param name="version">版本</param>
        /// <param name="xmlStr">说明信息</param>
        /// <returns></returns>
        public string CreateUpdateFolder(string version, string xmlStr)
        {
            bll.ThinkersoftService.Service myservice = new ServiceHelper().getService();

            return myservice.CreateUpdateFolder(version, xmlStr);
        }
        

        /// <summary>
        /// 获取预查询HASHcode
        /// </summary>
        /// <returns></returns>
        public long getServiceHashCode()
        {
            bll.ThinkersoftService.Service myservice = new ServiceHelper().getService();

            return myservice.getHashcode();
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public  ThinkersoftService.Tcp_Models UPLOADFILE(byte [] bytes,string sqe)
        {
            bll.ThinkersoftService.Service myservice = new ServiceHelper().getService();

            return myservice.UPLOADFILE(bytes, sqe);
        }

        /// <summary>
        /// 复合SQL语句执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="win"></param>
        /// <param name="logonName"></param>
        /// <returns></returns>
        public int SQLSExcute(string sql, string win, string logonName)
        {
            bll.ThinkersoftService.Service myservice = new ServiceHelper().getService();

            return myservice.SQLSExcute(sql, win, "SQLSExcute", "复合SQL语句", logonName);
        }
        /// <summary>
        /// 动态UPDATE语句
        /// </summary>
        /// <param name="tabname">表名</param>
        /// <param name="colsname">要更新的列名</param>
        /// <param name="val">要更新的值</param>
        /// <param name="type">要更新的列字段类型 1 数字 2 字符串 3 日期</param>
        /// <param name="conditioncol">唯一条件列</param>
        /// <param name="conditionval">唯一条件值</param>
        /// <param name="conditiontype">唯一条件类型 1 数字 2 字符串 3 日期</param>
        /// <param name="win">执行窗体</param>
        /// <param name="logonName">执行人</param>
        /// <returns></returns>
        public int SQLExcute(string tabname, string colsname, string val, int type, string conditioncol, string conditionval, int conditiontype, string win, string logonName)
        {
            bll.ThinkersoftService.Service myservice = new ServiceHelper().getService();
            string myval = "";
            switch (type)
            {
                case 1:
                    myval = val;
                    break;
                case 2:
                    myval = "'" + val + "'";
                    break;
                case 3:
                    myval = "to_date('" + val + "','yyyy-mm-dd hh24:mi:ss')";
                    break;
            }
            string mycval = "";
            switch (conditiontype)
            {
                case 1:
                    mycval = conditionval;
                    break;
                case 2:
                    mycval = "'" + conditionval + "'";
                    break;
                case 3:
                    mycval = "to_date('" + conditionval + "','yyyy-mm-dd hh24:mi:ss')";
                    break;
            }
            string sql = "update " + tabname + " set " + colsname + "=" + myval + " where " + conditioncol + "=" + mycval;

            return myservice.ExcuteOperationTex(sql, win, "SQLExcute", "动态UPDATE语句", logonName);
        }

        public int SQLExcute(string sql)
        {
            bll.ThinkersoftService.Service myservice = new ServiceHelper().getService();
            return myservice.ExcuteOperationTex(sql, "微信支付", "SQLExcute", "", "微信");
        }

        /// <summary>
        /// 日志内容格式化
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string getLogVal(string val)
        {
            string result = "";

            if (val.Length == 0)
            {
                result = "空";
            }
            else
            {
                result = val;
            }

            return result;
        }

        public DataTable GetDataTable(string sql)
        {
            bll.ThinkersoftService.Service myservice = new ServiceHelper().getService();


            DataTable dt = ServiceHelper.getDataTable(myservice.ExcuteQueryTex(sql, "WXZF", "GetDataTable", "获取数据", "微信支付"));
            return dt;
        }

        public string ExepPro(DataTable dt, string proName, int outindex)
        {
            bll.ThinkersoftService.Service myservice = new ServiceHelper().getService();

            string addstate = myservice.ExcuteProcEXTex(proName, dt, "微信支付", "收费", "微信支付", outindex, "微信支付");

            return addstate;
        }
    }
}
