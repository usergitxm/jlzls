using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll;
using THKModel;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace NBSW
{
    public partial class NewsUserApplication : System.Web.UI.Page
    {
        public string OpenId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
               // GetUserOpenId();
                try
                {

                 //   OpenId = Session["OpenId"].ToString();

                    Txt_BZBH.Text = GetSEQ.getNextandIdentityApp("BZ_APPLICATION", "N_APPLICATION_ID", "", "").ToString();
                    //安装类型  
                    this.cbxInstallType.DataSource = Businiss.Select("", "", "");
                    cbxInstallType.DataTextField = "C_INSTALL_TYPE_NAME";
                    //ddlNF.DataValueField = "N_business_id";
                    cbxInstallType.DataBind();
                    cbxInstallType.Items.Insert(0, new ListItem("---请选择---", "-1"));

                    //性质
                    this.cbxProperties.DataSource = Businiss.GetPropertiesList(1, 1, "", "", "");
                    cbxProperties.DataTextField = "C_PROPERTIES_NAME";
                    //ddlNF.DataValueField = "N_business_id";
                    cbxProperties.DataBind();
                    cbxProperties.Items.Insert(0, new ListItem("---请选择---", "-1"));
                }
                catch (Exception )
                {
                    return;
                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (cbxInstallType.Text == "-1")
            {


                WebMessageBox(this.Page, "请选择安装类型");
                return;
            }
            if (cbxProperties.Text == "-1")
            {
                WebMessageBox(this.Page, "请选择用水性质");
                return;
            }
            try
            {
                // LogUtil.WriteLog(Session["OpenId"].ToString());
                OpenId = Session["OpenId"].ToString();

                if (Txt_AppName.Text == "" || Txt_UseCount.Text == "" || Txt_UserAddress.Text == "" || Txt_UserName.Text == "" || Txt_UserPhone.Text == "")
                {
                    WebMessageBox(this.Page, "必填项不能为空");

                    // Response.Write("<script>alert('必填项不能为空！')</script>");
                    return;
                }
                if (Txt_UserPhone.Text.Length != 11)
                {
                    WebMessageBox(this.Page, "电话号码格式错误");

                    //Response.Write("<script>alert('电话号码格式错误！')</script>");
                    return;
                }
                //推送信息给用户
                //    string msgSend = WechatDAO.WxSendMsg(OpenId, "预受理新装申请", "已提交，待受理", token);



                #region 新增流程

                DataTable dta = Businiss.GetPropertiesList(1, 1, "", "", cbxProperties.Text);
                string a = dta.Rows[0]["N_PROPERTIES_ID"].ToString();
                DataTable dtb = Businiss.Select(cbxInstallType.Text, "", "");
                string b = dtb.Rows[0]["N_INSTALL_TYPE_ID"].ToString();
                //业务实体
                decimal businessid = Businiss.getNextandIdentity("YX_BUSINESS", "N_BUSINESS_ID");
                Bz_Application application = new Bz_Application();
                Yx_Business business = new Yx_Business();
                business.N_Business_ID = businessid;
                if (cbxInstallType.Text.IndexOf("一户一表") >= 0)
                {
                    business.C_Business_Name = Txt_AppName.Text.Trim();
                    application.C_Application_Name = Txt_AppName.Text.Trim();
                }
                else
                {
                    business.C_Business_Name = Txt_UserName.Text;
                    application.C_Application_Name = Txt_UserName.Text;
                }
                Bz_Project_Type aa = new Bz_Project_Type();

                business.N_Process = Businiss.SelectByKeyCom("BZ_APPLICATION", "", "");
                business.N_Business_State = 1;
                Qx_SystemUser u = new Qx_SystemUser();
                u.N_SystemUser_Id = 107;
                business.N_Business_Operator = u;
                business.D_Business_Operation_Time = System.DateTime.Now;

                //报装实体

                application.N_Application_ID = decimal.Parse(Txt_BZBH.Text.Trim()); //seqBLL.getNextandIdentityApp("BZ_APPLICATION", "N_APPLICATION_ID", this.Name, THKClient.CodeBin.StaticData.Curopuser.C_User_Name);
                Bz_Install_Type installtypemodel = new Bz_Install_Type();
                installtypemodel.N_Install_Type_ID = decimal.Parse(b);
                installtypemodel.C_Install_Type_Name = this.cbxInstallType.Text;
                application.N_install_Type = installtypemodel;
                Bz_Project_Type protypemodel = new Bz_Project_Type();
                protypemodel.N_Project_Type_ID = decimal.Parse(a);
                aa.C_Project_Type_Name = "住房高层";
                aa.N_Project_Type_ID = 1;
                protypemodel.C_Project_Type_Name = aa.ToString();

                application.N_Project_Type = aa;
                Yx_Properties propertiesmodel = new Yx_Properties();
                propertiesmodel.N_Properties_Id = decimal.Parse(a);
                propertiesmodel.C_Properties_Name = this.cbxProperties.Text;
                application.N_Properties = propertiesmodel;

                application.N_Application_Count = decimal.Parse(Txt_UseCount.Text);
                application.D_Application_Operator_Time = DateTime.Now;

                application.N_Application_Operator = u;
                application.C_Application_Phone = Txt_UserPhone.Text;
                application.C_Agent_Name = Txt_UserName.Text;
                application.C_Agent_Phone = Txt_UserPhone.Text;
                application.C_Agent_Identity_Card = "";// this.txtAgentCard.Text.Trim();
                application.N_Plan_Quantity = 0;// decimal.Parse(this.txtPlanQuantity.Text.Trim() == "" ? "0" : this.txtPlanQuantity.Text.Trim());
                application.C_Residential_Name = Txt_UserAddress.Text;
                application.C_Residential_Address = Txt_UserAddress.Text;
                application.C_Developers_Name = Txt_UserName.Text;
                application.C_User_Identity_Card = "";
                application.N_Housing_Area = decimal.Parse("" == "" ? "0" : "");
                application.C_Equipment_Pressure = "";
                application.C_Legal_Person_Name = Txt_UserName.Text;
                application.C_Legal_Person_Identity_Card = "";
                application.C_House = Txt_UserAddress.Text;
                application.C_Unit = "";// this.txtUnit.Text.Trim();
                application.C_Floor = "";// this.txtFloor.Text.Trim();
                application.C_Application_Remark = Request.Form["content"].ToString();// this.txtRemark.Text.Trim();
                application.N_Business = business;
                application.C_User_ID = cbxInstallType.Text.IndexOf("一户一表") >= 0 ? "" : "";
                application.N_THE_OPENING_BANK = decimal.Parse("0");//开户银行
                application.N_BANK_ACCOUNT = "";// textBox5.Text;//银行账号
                application.N_ELEVATION = 0;//标高
                if (cboMeterType.Text == "普通水表")//水表类型
                {
                    application.N_METER_TYPE = 0;
                }
                else if (cboMeterType.Text == "智能水表")
                {
                    application.N_METER_TYPE = 1;
                }
                else if (cboMeterType.Text == "远程表")
                {
                    application.N_METER_TYPE = 3;
                }
                else if (cboMeterType.Text == "其他表")
                {
                    application.N_METER_TYPE = 2;
                }
                application.N_PAYMENT_WAY = 1;

                application.N_USER_STATE = 1;

                application.N_INSTALL_MODE = 1;
                application.C_AGENT_PHONE_SJ = Txt_UserPhone.Text;//手机


                //申请流程
                Yx_Transation tranmodel = new Yx_Transation();

                tranmodel.D_Transaction_Time_Begin = DateTime.Now;
                tranmodel.N_Transaction_ID = Businiss.getNextandIdentity("YX_TRANSACTION", "N_TRANSACTION_ID");
                tranmodel.N_Process = Businiss.SelectByKeyCom("BZ_APPLICATION", "", "");

                Yx_Queue qumodel = Businiss.SelectStart(tranmodel.N_Process.N_Process_ID, "", "");
                tranmodel.N_Queue = qumodel;
                tranmodel.N_Business = business;
                tranmodel.N_Transaction_State = 1;
                tranmodel.N_Transaction_Comment = "报装申请";
                tranmodel.C_Transactor_ID = "107";
                tranmodel.D_Transaction_Time_End = System.DateTime.Now;
                tranmodel.D_Transaction_Time_due = Businiss.getTransactionTimeDue(qumodel, DateTime.Now, "", "");
                tranmodel.N_Transaction_Due_State = decimal.Parse(tranmodel.D_Transaction_Time_End > tranmodel.D_Transaction_Time_due ? "1" : "0");
                tranmodel.C_TRANSACTOR_SIGNATURE = "";

                //审核流程
                Yx_Transation transacmodel = new Yx_Transation();
                transacmodel.D_Transaction_Time_Begin = System.DateTime.Now;
                transacmodel.N_Transaction_ID = Businiss.getNextandIdentity("YX_TRANSACTION", "N_TRANSACTION_ID");
                transacmodel.N_Process = Businiss.SelectByKeyCom("BZ_APPLICATION", "", "");
                Yx_Queue quemodel = new Yx_Queue();
                quemodel.N_Queue_ID = decimal.Parse(Businiss.GetNextNum(transacmodel.N_Process.N_Process_ID.ToString(), tranmodel.N_Queue.N_Queue_ID.ToString(), "", ""));
                transacmodel.N_Queue = quemodel;
                transacmodel.N_Business = business;
                transacmodel.N_Transaction_State = 0;
                transacmodel.N_Transaction_Comment = "报装审核";
                transacmodel.C_Transactor_ID = "";
                transacmodel.D_Transaction_Time_End = DateTime.Parse("1900 - 1 - 1");
                transacmodel.D_Transaction_Time_due = Businiss.getTransactionTimeDue(qumodel, DateTime.Now, "", "");
                transacmodel.N_Transaction_Due_State = 0;
                transacmodel.C_TRANSACTOR_SIGNATURE = "";
                try
                {
                    upload(FileUpload1, transacmodel);
                    upload(FileUpload2, transacmodel);
                    upload(FileUpload3, transacmodel);
                    upload(FileUpload4, transacmodel);
                }
                catch (Exception)
                {
                    return;
                }

                int appi = Businiss.AddApplication(business, application, tranmodel, transacmodel, "", "");

                if (appi > 0)
                {


                    string sql = @"insert into wx_bz(C_OPENID,N_BUSS_ID,D_TIME,N_STATE)values('" + OpenId + @"','" + Txt_BZBH.Text + @"',to_Date('" + DateTime.Now.ToString() + @"','yyyy-mm-dd hh24 mi:ss'),'0')";
                    new Sys_Command().SQLExcute(sql);
                    var token = GETTOKEN.GetToken();
                    WechatDAO.WxSendMsg(OpenId, "报装申请", "已提交，待受理", token, Txt_BZBH.Text.Trim());
                    WebMessageBox(this.Page, "操作成功!");
                    //Response.Write("<script>alert('操作成功！');</script>");
                    return;
                    //  MessageBox.Show("报装申请成功", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    WebMessageBox(this.Page, "操作失败");

                    //Response.Write("<script>alert('操作失败！');</script>");
                    return;
                }
                #endregion



            }
            catch (Exception ex)
            {
                WebMessageBox(this.Page, "操作失败，失败原因：" + ex.Message + @",请联系自来水工作人员核实处理，给您带来的不便，敬请谅解！");

                // Response.Write("<script>alert('操作失败，失败原因：" + ex.Message + @",请联系自来水工作人员核实处理，给您带来的不便，敬请谅解！');</script>");
                return;
            }
        }
        #region 获取令牌token

        public static void WebMessageBox(System.Web.UI.Page page, string values)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script language=javascript>alert('" + values + "')</script>");
        }
        public void upload(FileUpload fileUpload, Yx_Transation transacmodel)
        {
            string saveFile = "";
            if (fileUpload.HasFile)
            {


                string fileFormat = fileUpload.FileName.Split('.')[fileUpload.FileName.Split('.').Length - 1]; // 以“.”截取，获取“.”后面的文件后缀
                Regex imageFormat = new Regex(@"^(bmp)|(png)|(gif)|(jpg)|(jpeg)"); // 验证文件后缀的表达式（自己写的，不规范别介意哈）
                if (string.IsNullOrEmpty(fileUpload.FileName) || !imageFormat.IsMatch(fileFormat)) // 验证后缀，判断文件是否是所要上传的格式
                {
                    Response.Write("<script>alert('【系统提示】上传失败！')</script>");
                    return;
                }
                else
                {
                    string firstFileName = "C_" + System.Guid.NewGuid().ToString("N");// DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + "BZ" + "-" + DateTime.Now.ToString("yyyyMMdd");
                    string imageStr = "ImgSave_/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";
                    if (Directory.Exists(Server.MapPath("~/ImgSave_/" + DateTime.Now.ToString("yyyy-MM-dd") + "/")) == false)
                    {
                        Directory.CreateDirectory(Server.MapPath("~/ImgSave_/" + DateTime.Now.ToString("yyyy-MM-dd") + "/"));
                    }
                    string uploadPath = Server.MapPath("~/" + imageStr); // 将项目路径与文件夹合并
                    string pictureFormat = fileUpload.FileName.Split('.')[fileUpload.FileName.Split('.').Length - 1];// 设置文件格式

                    string fileName = firstFileName + "." + fileFormat;// 设置完整（文件名+文件格式）
                    saveFile = uploadPath + fileName;//文件路径
                    fileUpload.SaveAs(saveFile);// 保存文件;// 保存文件
                                                // 如果单单是上传，不用保存路径的话，下面这行代码就不需要写了！
                    string image = imageStr + fileName;// 设置数据库保存的路径
                    try
                    {
                        #region 上传附件
                        Yx_File model = new Yx_File();
                        model.N_Business = transacmodel.N_Business;
                        model.N_Process = transacmodel.N_Process;
                        model.N_Queue = transacmodel.N_Queue;
                        string filepath = saveFile;// Server.MapPath(FileUpload1.PostedFile.FileName);
                        string type = filepath.Substring(filepath.LastIndexOf('.') + 1);
                        if (File.Exists(filepath))
                        {
                            // fileServerPath = THKTCPCom.TCPClient.UploadFile(filepath, @"\ProcessFile\", type);


                            string Path_dwgz = "http://www.thksoft.net/jlzls/";
                            string p_dwgz = "D:\\wx\\jlzls\\" + image;
                            LogUtil.WriteLog("图片上传路径：" + uploadPath + fileName);
                            //fileUpload.SaveAs(Path_dwgz);//确定上传文件

                            model.C_File_Name = DateTime.Now.ToString("yyyyMMddhh24miss") + "." + type;
                            //model.N_File_Path = fileServerPath.Substring(1, fileServerPath.Length - 1);
                            model.N_File_Path = Path_dwgz + image;
                            Qx_SystemUser q = new Qx_SystemUser();
                            q.C_User_Operator = "107";
                            model.N_File_Operator = q;
                            model.D_File_Operation_Time = DateTime.Now;
                            model.C_File_Remark = "微信";
                            Yx_File con2 = UserDAO.Insert(model, "", "");
                            //string con1 = fileServerPath.Substring(0, 1);

                            //if (con1.Equals("1") && con2 != null)
                            //{
                            //    //上传成功
                            //    fileServerPath = fileServerPath.Substring(1, fileServerPath.Length - 1);//路径
                            //}
                        }
                        else
                        {
                            Response.Write("<script>alert('本地不存在当前所选文件！');</script>"); return;

                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        LogUtil.WriteLog("失败：" + ex.Message);
                        return;
                    }
                }



            }
        }

        private void GetUserOpenId()
        {
            string code = Request.QueryString["code"];
            if (string.IsNullOrEmpty(code))
            {
                LogUtil.WriteLog(" ============ Code不存在获取 =====================");
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + PayConfig.AppId + "&redirect_uri=" + PayConfig.SendUrl5 + "&response_type=code&scope=snsapi_base&state=123#wechat_redirect", PayConfig.AppId, PayConfig.SendUrl5);

                Response.Redirect(code_url);
            }
            else
            {
                LogUtil.WriteLog(" ============ 通过code换取网页授权access_token =====================");
                LogUtil.WriteLog("开始获取OPENID======================================================");
                #region 获取支付用户 OpenID================

                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", PayConfig.AppId, PayConfig.AppSecret, code);

                string returnStr = HttpUtil.Send("", url);

                var obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

                url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", PayConfig.AppId, obj.refresh_token);
                returnStr = HttpUtil.Send("", url);
                obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);



                url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", obj.access_token, obj.openid);
                returnStr = HttpUtil.Send("", url);


                OpenId = obj.openid;
                Session["OpenId"] = OpenId;
                LogUtil.WriteLog(OpenId + " ============ 获取OPENID ==========" + OpenId + "===========");

                #endregion 获取支付用户 OpenID================

            }
        }
        #endregion



    }
}