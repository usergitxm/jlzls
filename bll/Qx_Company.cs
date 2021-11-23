using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bll
{
    /// <summary>
    /// 公司实体类
    /// </summary>
    [Serializable]
    public class Qx_Company
    {

        private decimal _n_Company_Id;
        /// <summary>
        /// 公司Id
        /// </summary>
        public decimal N_Company_Id
        {
            get { return _n_Company_Id; }
            set { _n_Company_Id = value; }
        }


        private decimal _n_Parent_Company_Id;
        /// <summary>
        /// 父级公司id
        /// </summary>
        public decimal N_Parent_Company_Id
        {
            get { return _n_Parent_Company_Id; }
            set { _n_Parent_Company_Id = value; }
        }


        private string _c_Company_Name;
        /// <summary>
        /// 公司名称
        /// </summary>
        public string C_Company_Name
        {
            get { return _c_Company_Name; }
            set { _c_Company_Name = value; }
        }


        private string _c_Company_Address;
        /// <summary>
        /// 公司地址
        /// </summary>
        public string C_Company_Address
        {
            get { return _c_Company_Address; }
            set { _c_Company_Address = value; }
        }


        private decimal _n_Company_Phone;
        /// <summary>
        /// 公司电话
        /// </summary>
        public decimal N_Company_Phone
        {
            get { return _n_Company_Phone; }
            set { _n_Company_Phone = value; }
        }


        private string _c_Company_Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string C_Company_Remark
        {
            get { return _c_Company_Remark; }
            set { _c_Company_Remark = value; }
        }

        private string _c_Company_Operator;

        /// <summary>
        /// 操作人
        /// </summary>
        public string C_Company_Operator
        {
            get { return _c_Company_Operator; }
            set { _c_Company_Operator = value; }
        }


        private DateTime _d_Company_Operation_Time;
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime D_Company_Operation_Time
        {
            get { return _d_Company_Operation_Time; }
            set { _d_Company_Operation_Time = value; }
        }


        private decimal _n_Company_State;
        /// <summary>
        /// 状态
        /// </summary>
        public decimal N_Company_State
        {
            get { return _n_Company_State; }
            set { _n_Company_State = value; }
        }
    }
}
