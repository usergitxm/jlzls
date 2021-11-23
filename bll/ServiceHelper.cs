using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using bll.ThinkersoftService;

namespace bll
{
    /// <summary>
    /// 获取WEB服务对象公用类
    /// 编写人：康涛
    /// </summary>
    public class ServiceHelper
    {
        //服务连接地址
        private string ServiceURL = ConfigurationManager.AppSettings["ServiceURL"].ToString();

        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int MessageBox(int hWnd, String strMessage, String strCaption, uint uiType);


        /// <summary>
        /// 客户端获取服务对象
        /// </summary>
        /// <returns></returns>
        public Service getService()
        {
            Service service = new Service();

            //if (IniReadValue("Client", "ServiceURL").ToString() == "")
            //{
            //    IniWriteValue("Client", "ServiceURL", "http://88.88.88.80/cnpcService/Service.asmx");
            //}

            //ServiceURL = IniReadValue("Client", "ServiceURL").ToString();

            service.Credentials = System.Net.CredentialCache.DefaultCredentials;

            service.Timeout = 3600 * 1000;

            service.Url = ServiceURL;

            #region  作是否下线判断 （已注释）
            //if (IniReadValue("ISCKing", "CKINGVALUE").ToString() == "")
            //{
            //    IniWriteValue("ISCKing", "CKINGVALUE", "false");
            //}

            //string ckingvalue = IniReadValue("ISCKing", "CKINGVALUE").ToString();
            //if (ckingvalue.ToUpper() == "TRUE")
            //{
            //    //读取ini文件  PCID  与数据库的PCID进行匹配
            //    string clientPCID = IniReadValue("Client", "PCID").ToString();
            //    string clientLogonName = IniReadValue("Client", "LOGONNAME").ToString();
            //    string sql = "select * from qx_Systemuser where c_login_name = '" + clientLogonName + "'";
            //    DataTable dt = getDataTable(service.ExcuteQueryTex(sql, "", "getService", "根据用户名查询", ""));
            //    string servicePCID = "";
            //    string loginState = "";
            //    if (dt != null)
            //    {
            //        servicePCID = dt.Rows[0]["C_PCID"].ToString();
            //        loginState = dt.Rows[0]["N_ONLINE_STATE"].ToString();
            //    }
            //    //如果不相等表示 要 踢下线
            //    //if (!clientPCID.Equals(servicePCID) && !clientLogonName.ToUpper().Equals("SUPER"))
            //    //{
            //    //    MessageBox(0, "您好，当前用户在其他地方登录，您被迫下线！", "提示", 0);

            //    //    //如果是踢下线 关闭当前进程
            //    //    KillProcesses();
            //    //}
            //}


            #endregion

            return service;
        }

     

        /// <summary>
        /// 客户端获取服务对象
        /// </summary>
        /// <returns></returns>
        public Service getMesService()
        {
            Service service = new Service();

            ServiceURL = "http://61.139.124.164:9458/mesService/Service.asmx";

            service.Credentials = System.Net.CredentialCache.DefaultCredentials;

            service.Timeout = 3600 * 1000;

            service.Url = ServiceURL;

            return service;
        }

        /// <summary>
        /// 获得进程
        /// </summary>
        /// <returns></returns>
        private static List<Process> GetProcesses()
        {
            Process[] processes = Process.GetProcesses();
            List<Process> ListProcess = new List<Process>();

            foreach (Process _pr in processes)
            {
                if (_pr.ProcessName.ToUpper().Equals("THKCLIENT"))
                {
                    ListProcess.Add(_pr);
                }
            }
            return ListProcess;
        }


        /// <summary>
        /// 销毁所有客户端进程
        /// </summary>
        public static void KillProcesses()
        {
            List<Process> listProcess = GetProcesses();
            foreach (Process _pr in listProcess)
            {
                _pr.Kill();
            }
        }
        public string path = ConfigurationManager.AppSettings["CusIni"].ToString();
        //public string path = System.Windows.Forms.Application.StartupPath + @"\CustomSet.ini";
        [DllImport("kernel32")]

        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        /// <summary>
        /// 写入INI
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// 表名
        /// <PARAM name="Key"></PARAM>
        /// 字段
        /// <PARAM name="Value"></PARAM>
        /// 值


        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <PARAM name="Section">表名</PARAM>
        /// <PARAM name="Key">字段</PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, this.path);
            return temp.ToString();
        }

        public static DataTable getDataTable(byte[] data)
        {

            //将字节流数组解压缩
            //byte[] buffer = UnZipClass.Decompress(zipBuffer);

            MemoryStream ms = new MemoryStream(data);

            Stream zipStream = null;

            zipStream = new System.IO.Compression.GZipStream(ms, CompressionMode.Decompress, true);

            //实例化一个序列化对象
            IFormatter formatter = new BinaryFormatter();

            DataTable result = (DataTable)formatter.Deserialize(zipStream);

            return result;

            // 获取dataset
            //DataSet DS = ds.GetDataSet();

            //  将字节流转化为内存流，然后进行反序列化，最后强制转化为DataSetSurrogate类型
            //DataSetSurrogate dss = ser.Deserialize(new MemoryStream(buffer)) as DataSetSurrogate;
            //DataSetSurrogate转化为Dataset对象
            //DataSet dataset = dss.ConvertToDataSet();
        }
    }
}
