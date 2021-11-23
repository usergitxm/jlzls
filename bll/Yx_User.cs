using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THKModel
{
    /// <summary>
    /// 用户资料明细表

    /// </summary>
    [Serializable]
    public class Yx_User
    {
        #region Model
        private string _c_user_id;
        private string _c_card_number;
        private string _c_application_id;
        private string _c_user_name;
        private string _c_user_address;
        private decimal _n_amount;
        private string _c_identity_card;
        private string _c_user_phone;
        private string _c_house_property_card;
        private decimal _n_housing_area;
        private string _c_uses_card_number;
        private string _c_contract_number;
        private DateTime _d_contract_date;
        private decimal _n_user_operator_id;
        private DateTime _d_user_operation_date;
        private decimal _n_user_state;
        private decimal _n_user_prestore_state;
        private decimal _n_company_id;
        private decimal _n_area_id;
        private decimal _n_regulator_id;
        private decimal _n_book_id;
        private decimal _n_order_num1;
        private decimal _n_order_num2;
        private string _c_parent_user_id;
        private string _c_old_user_id;
        private string _c_check_meter_id;
        private decimal _n_model_id;
        private decimal _n_manufacturers_id;
        private string _c_meter_number;
        private decimal _n_meter_degrees = 0M;
        private string _c_meter_address;
        private decimal _n_properties_id;
        private DateTime _d_meter_production_date;
        private DateTime _d_meter_install_date;
        private DateTime _d_meter_opened_date;
        private string _c_meter_validity_time;
        private decimal _n_user_count;
        private string _c_house;
        private string _c_unit;
        private string _c_floor;
        private string _c_opened_operator;
        private decimal _n_install_init_degrees;
        private decimal _n_opened_init_degrees;
        private string _c_opened_remark;
        private decimal _n_remission = 0M;
        private decimal _n_change_meter = 0M;
        private decimal _n_minimum = 0M;
        private decimal _n_mix_state;
        private decimal _n_tax_state;
        private decimal _n_enter_type;
        private decimal _n_enter_state;
        private decimal _n_user_meter_reader_id;
        private decimal _n_meter_type;
        private decimal _n_station_id;
        private decimal _n_valve_id;
        private string _c_security_card;
        private decimal _n_group_id = 0M;
        private decimal _n_check_state;
        private string _c_user_remark;
        private decimal _n_BUY_COUNT;

        private string c_USER_TEL;
        private decimal n_USER_INSTAL_AMOUNT;
        private string c_USER_BANK_ACCOUNT;
        private decimal n_BANK_ID;
        private decimal n_METER_DIRECTION;
        private long c_User_Syn;

        private int _n_Version;

        public int N_Version
        {
            get { return _n_Version; }
            set { _n_Version = value; }
        }

        
        /// <summary>
        /// 座机
        /// </summary>
        public string C_USER_TEL
        {
            get { return c_USER_TEL; }
            set { c_USER_TEL = value; }
        }

        /// <summary>
        /// 银行帐号
        /// </summary>
        public string C_USER_BANK_ACCOUNT
        {
            get { return c_USER_BANK_ACCOUNT; }
            set { c_USER_BANK_ACCOUNT = value; }
        }

        /// <summary>
        /// 银行编号
        /// </summary>
        public decimal N_BANK_ID
        {
            get { return n_BANK_ID; }
            set { n_BANK_ID = value; }
        }
        /// <summary>
        /// 0 无 1 左进右出 2 右进左出
        /// </summary>
        public decimal N_METER_DIRECTION
        {
            get { return n_METER_DIRECTION; }
            set { n_METER_DIRECTION = value; }
        }

        /// <summary>
        /// 安装费

        /// </summary>
        public decimal N_USER_INSTAL_AMOUNT
        {
            get { return n_USER_INSTAL_AMOUNT; }
            set { n_USER_INSTAL_AMOUNT = value; }
        }






        /// <summary>
        /// 当前购买次数
        /// </summary>
        public decimal N_BUY_COUNT
        {
            get { return _n_BUY_COUNT; }
            set { _n_BUY_COUNT = value; }
        }
        private decimal _n_BUY_SUM_COUNT;
        /// <summary>
        /// 总购买次数

        /// </summary>
        public decimal N_BUY_SUM_COUNT
        {
            get { return _n_BUY_SUM_COUNT; }
            set { _n_BUY_SUM_COUNT = value; }
        }
        private decimal _n_BUY_SUM_DOSAGE;
        /// <summary>
        /// 总购买量
        /// </summary>
        public decimal N_BUY_SUM_DOSAGE
        {
            get { return _n_BUY_SUM_DOSAGE; }
            set { _n_BUY_SUM_DOSAGE = value; }
        }


        private string _c_PRESSURE_REGULATOR;
        /// <summary>
        /// 调压器编号

        /// </summary>
        public string C_PRESSURE_REGULATOR
        {
            get { return _c_PRESSURE_REGULATOR; }
            set { _c_PRESSURE_REGULATOR = value; }
        }


        /// <summary>
        /// 用户编号
        /// </summary>
        public string C_User_Id
        {
            set { _c_user_id = value; }
            get { return _c_user_id; }
        }
        /// <summary>
        /// 磁卡号


        /// </summary>
        public string C_Card_Number
        {
            set { _c_card_number = value; }
            get { return _c_card_number; }
        }
        /// <summary>
        /// 报装申请号


        /// </summary>
        public string C_Application_Id
        {
            set { _c_application_id = value; }
            get { return _c_application_id; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string C_User_Name
        {
            set { _c_user_name = value; }
            get { return _c_user_name; }
        }
        /// <summary>
        /// 用户住址
        /// </summary>
        public string C_User_Address
        {
            set { _c_user_address = value; }
            get { return _c_user_address; }
        }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal N_Amount
        {
            set { _n_amount = value; }
            get { return _n_amount; }
        }
        /// <summary>
        /// 身份证


        /// </summary>
        public string C_Identity_Card
        {
            set { _c_identity_card = value; }
            get { return _c_identity_card; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string C_User_Phone
        {
            set { _c_user_phone = value; }
            get { return _c_user_phone; }
        }
        /// <summary>
        /// 房产证号
        /// </summary>
        public string C_House_Property_Card
        {
            set { _c_house_property_card = value; }
            get { return _c_house_property_card; }
        }
        /// <summary>
        /// 住房面积
        /// </summary>
        public decimal N_Housing_Area
        {
            set { _n_housing_area = value; }
            get { return _n_housing_area; }
        }
        /// <summary>
        /// 使用证号
        /// </summary>
        public string C_Uses_Card_Number
        {
            set { _c_uses_card_number = value; }
            get { return _c_uses_card_number; }
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string C_Contract_Number
        {
            set { _c_contract_number = value; }
            get { return _c_contract_number; }
        }
        /// <summary>
        /// 合同日期
        /// </summary>
        public DateTime D_Contract_Date
        {
            set { _d_contract_date = value; }
            get { return _d_contract_date; }
        }
        /// <summary>
        /// 操作员Id
        /// </summary>
        public decimal N_User_Operator_Id
        {
            set { _n_user_operator_id = value; }
            get { return _n_user_operator_id; }
        }
        /// <summary>
        /// 操作日期
        /// </summary>
        public DateTime D_User_Operation_Date
        {
            set { _d_user_operation_date = value; }
            get { return _d_user_operation_date; }
        }
        /// <summary>
        /// 用户状态(0停表1正常9销户)
        /// </summary>
        public decimal N_User_State
        {
            set { _n_user_state = value; }
            get { return _n_user_state; }
        }
        /// <summary>
        /// 用户预存状态(0不预存1预存)
        /// </summary>
        public decimal N_User_Perstore_State
        {
            set { _n_user_prestore_state = value; }
            get { return _n_user_prestore_state; }
        }
        /// <summary>
        /// 公司Id
        /// </summary>
        public decimal N_Company_Id
        {
            set { _n_company_id = value; }
            get { return _n_company_id; }
        }
        /// <summary>
        /// 分区Id
        /// </summary>
        public decimal N_Area_Id
        {
            set { _n_area_id = value; }
            get { return _n_area_id; }
        }
        /// <summary>
        /// 调压器Id
        /// </summary>
        public decimal N_Regulator_Id
        {
            set { _n_regulator_id = value; }
            get { return _n_regulator_id; }
        }
        /// <summary>
        /// 抄表本Id
        /// </summary>
        public decimal N_Book_Id
        {
            set { _n_book_id = value; }
            get { return _n_book_id; }
        }
        /// <summary>
        /// 抄表本顺序号1
        /// </summary>
        public decimal N_Order_Num1
        {
            set { _n_order_num1 = value; }
            get { return _n_order_num1; }
        }
        /// <summary>
        /// 抄表本顺序号2
        /// </summary>
        public decimal N_Order_Num2
        {
            set { _n_order_num2 = value; }
            get { return _n_order_num2; }
        }
        /// <summary>
        /// 父级用户编号
        /// </summary>
        public string C_Parent_User_Id
        {
            set { _c_parent_user_id = value; }
            get { return _c_parent_user_id; }
        }
        /// <summary>
        /// 老用户编号


        /// </summary>
        public string C_Old_User_Id
        {
            set { _c_old_user_id = value; }
            get { return _c_old_user_id; }
        }
        /// <summary>
        /// 考核表Id
        /// </summary>
        public string C_Check_Meter_Id
        {
            set { _c_check_meter_id = value; }
            get { return _c_check_meter_id; }
        }
        /// <summary>
        /// 计量器型号


        /// </summary>
        public decimal N_Model_Id
        {
            set { _n_model_id = value; }
            get { return _n_model_id; }
        }
        /// <summary>
        /// 计量器生产厂家


        /// </summary>
        public decimal N_Manufacturers_Id
        {
            set { _n_manufacturers_id = value; }
            get { return _n_manufacturers_id; }
        }
        /// <summary>
        /// 计量器编号


        /// </summary>
        public string C_Meter_Number
        {
            set { _c_meter_number = value; }
            get { return _c_meter_number; }
        }
        /// <summary>
        /// 计量器读数


        /// </summary>
        public decimal N_Meter_Degrees
        {
            set { _n_meter_degrees = value; }
            get { return _n_meter_degrees; }
        }
        /// <summary>
        /// 计量器位置


        /// </summary>
        public string C_Meter_Address
        {
            set { _c_meter_address = value; }
            get { return _c_meter_address; }
        }
        /// <summary>
        /// 性质Id
        /// </summary>
        public decimal N_Properties_Id
        {
            set { _n_properties_id = value; }
            get { return _n_properties_id; }
        }
        /// <summary>
        /// 计量器生产日期


        /// </summary>
        public DateTime D_Meter_Production_Date
        {
            set { _d_meter_production_date = value; }
            get { return _d_meter_production_date; }
        }
        /// <summary>
        /// 计量器安装日期


        /// </summary>
        public DateTime D_Meter_Install_Date
        {
            set { _d_meter_install_date = value; }
            get { return _d_meter_install_date; }
        }
        /// <summary>
        /// 计量器启用日期


        /// </summary>
        public DateTime D_Meter_Opened_Date
        {
            set { _d_meter_opened_date = value; }
            get { return _d_meter_opened_date; }
        }
        /// <summary>
        /// 计量器有效期
        /// </summary>
        public string C_Meter_Validity_Time
        {
            set { _c_meter_validity_time = value; }
            get { return _c_meter_validity_time; }
        }
        /// <summary>
        /// 计量器使用人数


        /// </summary>
        public decimal N_User_Count
        {
            set { _n_user_count = value; }
            get { return _n_user_count; }
        }
        /// <summary>
        /// 楼栋号


        /// </summary>
        public string C_House
        {
            set { _c_house = value; }
            get { return _c_house; }
        }
        /// <summary>
        /// 单元号


        /// </summary>
        public string C_Unit
        {
            set { _c_unit = value; }
            get { return _c_unit; }
        }
        /// <summary>
        /// 门牌号


        /// </summary>
        public string C_Floor
        {
            set { _c_floor = value; }
            get { return _c_floor; }
        }
        /// <summary>
        /// 启用人


        /// </summary>
        public string C_Opened_Operator
        {
            set { _c_opened_operator = value; }
            get { return _c_opened_operator; }
        }
        /// <summary>
        /// 安装初始读数
        /// </summary>
        public decimal N_Install_Init_Degress
        {
            set { _n_install_init_degrees = value; }
            get { return _n_install_init_degrees; }
        }
        /// <summary>
        /// 启用初始读数
        /// </summary>
        public decimal N_Opened_Init_Degrees
        {
            set { _n_opened_init_degrees = value; }
            get { return _n_opened_init_degrees; }
        }
        /// <summary>
        /// 启用说明
        /// </summary>
        public string C_Opened_Remark
        {
            set { _c_opened_remark = value; }
            get { return _c_opened_remark; }
        }
        /// <summary>
        /// 加减量


        /// </summary>
        public decimal N_Remission
        {
            set { _n_remission = value; }
            get { return _n_remission; }
        }
        /// <summary>
        /// 计量器更换量
        /// </summary>
        public decimal N_Change_Meter
        {
            set { _n_change_meter = value; }
            get { return _n_change_meter; }
        }
        /// <summary>
        /// 启用量


        /// </summary>
        public decimal N_Minimum
        {
            set { _n_minimum = value; }
            get { return _n_minimum; }
        }
        /// <summary>
        /// 混合使用状态(0正常1混合)
        /// </summary>
        public decimal N_Mix_State
        {
            set { _n_mix_state = value; }
            get { return _n_mix_state; }
        }
        /// <summary>
        /// 增值税状态(0正常1增值税)
        /// </summary>
        public decimal N_Tax_State
        {
            set { _n_tax_state = value; }
            get { return _n_tax_state; }
        }
        /// <summary>
        /// 录入类型(0半月1每月2单月3双月4季度5半年6全年)
        /// </summary>
        public decimal N_Entre_Type
        {
            set { _n_enter_type = value; }
            get { return _n_enter_type; }
        }
        /// <summary>
        /// 录入状态(0不能录入1可以录入)
        /// </summary>
        public decimal N_Enter_State
        {
            set { _n_enter_state = value; }
            get { return _n_enter_state; }
        }
        /// <summary>
        /// 抄表员Id
        /// </summary>
        public decimal N_User_Meter_Reader_Id
        {
            set { _n_user_meter_reader_id = value; }
            get { return _n_user_meter_reader_id; }
        }
        /// <summary>
        /// 计量器类型(0普通表1智能表2远传表3远程表)
        /// </summary>
        public decimal N_Meter_Type
        {
            set { _n_meter_type = value; }
            get { return _n_meter_type; }
        }
        /// <summary>
        /// 供应站Id
        /// </summary>
        public decimal N_Station_Id
        {
            set { _n_station_id = value; }
            get { return _n_station_id; }
        }
        /// <summary>
        /// 阀门Id
        /// </summary>
        public decimal N_Valve_Id
        {
            set { _n_valve_id = value; }
            get { return _n_valve_id; }
        }
        /// <summary>
        /// 防盗卡序列号
        /// </summary>
        public string C_Security_Card
        {
            set { _c_security_card = value; }
            get { return _c_security_card; }
        }
        /// <summary>
        /// 团缴Id
        /// </summary>
        public decimal N_Group_Id
        {
            set { _n_group_id = value; }
            get { return _n_group_id; }
        }
        /// <summary>
        /// 安全检查状态


        /// </summary>
        public decimal N_Check_State
        {
            set { _n_check_state = value; }
            get { return _n_check_state; }
        }
        /// <summary>
        /// 用户备注
        /// </summary>
        public string C_User_Remark
        {
            set { _c_user_remark = value; }
            get { return _c_user_remark; }
        }

        /// <summary>
        /// 同步值

        /// </summary>
        public long C_User_Syn
        {
            get { return c_User_Syn; }
            set { c_User_Syn = value; }
        }

        private decimal _N_COMMUNITY_ID;
        /// <summary>
        /// 小区ID
        /// </summary>
        public decimal N_COMMUNITY_ID
        {
            get { return _N_COMMUNITY_ID; }
            set { _N_COMMUNITY_ID = value; }
        }

        private decimal _N_BANK_STATE;
        /// <summary>
        /// 银行代扣状态 0 不代扣 1 代扣
        /// </summary>
        public decimal N_BANK_STATE
        {
            get { return _N_BANK_STATE; }
            set { _N_BANK_STATE = value; }
        }

        private decimal _N_CHANGE_NUMBER;

        /// <summary>
        /// 修改正系数 0 不代扣 1 代扣
        /// </summary>
        public decimal N_CHANGE_NUMBER
        {
            get { return _N_CHANGE_NUMBER; }
            set { _N_CHANGE_NUMBER = value; }
        }
        public int N_SERIES_ID { get; set; }
        #endregion Model
    }
}
