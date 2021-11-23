using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using THKModel;
using bll;
using System.Drawing;
using System.Drawing.Imaging;

namespace NBSW
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static string file = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileExrensio = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写
            string FileType = FileUpload1.PostedFile.ContentType;
            string UploadURL = Server.MapPath("~/upload/");//上传的目录
            string fullPath =FileUpload1.PostedFile.FileName;
            //FileUpload1.FileBytes;
            //byte[] file = File.ReadAllBytes(fullPath);
          
       
            //string file_str = Convert.ToBase64String(FileUpload1.FileBytes);
         
            //byte[] bytes = Convert.FromBase64String(file_str);
            bll.ThinkersoftService.Tcp_Models model= new Sys_Command().UPLOADFILE(FileUpload1.FileBytes, "");
            if (FileType == "image/bmp" || FileType == "image/gif" || FileType == "image/jpeg" || FileType == "image/jpg" || FileType == "image/png")//判断文件类型
            {

                try
                {
                    if (!System.IO.Directory.Exists(UploadURL))//判断文件夹是否已经存在
                    {
                        System.IO.Directory.CreateDirectory(UploadURL);//创建文件夹
                    }

                    FileUpload1.PostedFile.SaveAs(UploadURL + FileUpload1.FileName);


                    FileUpload1.PostedFile.SaveAs("http://125.64.213.53:9458/JLService/FileProgram/ProcessFile/" + FileUpload1.FileName);


                }
                catch (Exception )
                {
                    Response.Write("失败");
                }
            }
            else
            {
                Response.Write("格式错误");
            }
        }
      
    }
}