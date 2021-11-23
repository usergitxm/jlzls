using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;

namespace bll
{
    /**
     * 
     * 作用：微信支付公用参数，微信支付版本V3.3.7
     * 备注：请正确填写相关参数
     * 
     * */
    public class PayConfig
    {
        /// <summary>
        /// 人民币
        /// </summary>
        public static string Tenpay = "1";

        /// <summary>
        /// mchid ， 微信支付商户号
        /// </summary>
        public static string MchId = "1490264042"; //

        /// <summary>
        /// appid，应用ID， 在微信公众平台中 “开发者中心”栏目可以查看到
        /// </summary>
        public static string AppId = "wx4be520d456c36843";

        /// <summary>
        /// appsecret ，应用密钥， 在微信公众平台中 “开发者中心”栏目可以查看到
        /// </summary>
        public static string AppSecret = "41b272270fb573ad31b3f028c715af8f";

        /// <summary>
        /// paysignkey，API密钥，在微信商户平台中“账户设置”--“账户安全”--“设置API密钥”，只能修改不能查看
        /// </summary>
        public static string AppKey = "chongqingqianjiangjulianshuisi12";

        /// <summary>
        /// 支付起点页面地址，也就是send.aspx页面完整地址
        /// 用于获取用户OpenId，支付的时候必须有用户OpenId，如果已知可以不用设置
        /// </summary>
        public static string  wxurl = ConfigurationManager.AppSettings["Sendurl"].ToString();
      //  public static string SendUrl = "http" + HttpUtility.UrlEncode("://").ToUpper() +wxurl;
        public static string SendUrl = "http"+ HttpUtility.UrlEncode("://").ToUpper()+ wxurl;

        /// <summary>
        /// 绑定用户编号时
        /// 用于获取用户OpenId，支付的时候必须有用户OpenId，如果已知可以不用设置
        /// </summary>
        public static string wxurl2 = ConfigurationManager.AppSettings["Sendurl2"].ToString();
        //  public static string SendUrl = "http" + HttpUtility.UrlEncode("://").ToUpper() +wxurl;
        public static string SendUrl2 = "http" + HttpUtility.UrlEncode("://").ToUpper() + wxurl2;

        /// <summary>
        /// 绑定用户查询时
        /// 用于获取用户OpenId，支付的时候必须有用户OpenId，如果已知可以不用设置
        /// </summary>
        public static string wxurl3 = ConfigurationManager.AppSettings["Sendurl3"].ToString();
        //  public static string SendUrl = "http" + HttpUtility.UrlEncode("://").ToUpper() +wxurl;
        public static string SendUrl3= "http" + HttpUtility.UrlEncode("://").ToUpper() + wxurl3;

        /// <summary>
        /// 绑定用户查询时
        /// 用于获取用户OpenId，支付的时候必须有用户OpenId，如果已知可以不用设置
        /// </summary>
        public static string wxurl4 = ConfigurationManager.AppSettings["Sendurl4"].ToString();
        //  public static string SendUrl = "http" + HttpUtility.UrlEncode("://").ToUpper() +wxurl;
        public static string SendUrl4 = "http" + HttpUtility.UrlEncode("://").ToUpper() + wxurl4;

        public static string wxurl5 = ConfigurationManager.AppSettings["Sendurl5"].ToString();
        //  public static string SendUrl = "http" + HttpUtility.UrlEncode("://").ToUpper() +wxurl;
        public static string SendUrl5 = "http" + HttpUtility.UrlEncode("://").ToUpper() + wxurl5;

        public static string wxurl6 = ConfigurationManager.AppSettings["Sendurl6"].ToString();
        //  public static string SendUrl = "http" + HttpUtility.UrlEncode("://").ToUpper() +wxurl;
        public static string SendUrl6 = "http" + HttpUtility.UrlEncode("://").ToUpper() + wxurl6;

        public static string wxurl7 = ConfigurationManager.AppSettings["Sendurl7"].ToString();
        //  public static string SendUrl = "http" + HttpUtility.UrlEncode("://").ToUpper() +wxurl;
        public static string SendUrl7 = "http" + HttpUtility.UrlEncode("://").ToUpper() + wxurl7;





        /// <summary>
        /// 支付页面，请注意测试阶段设置授权目录，在微信公众平台中“微信支付”---“开发配置”--修改测试目录   
        /// 注意目录的层次，比如我的：http://zousky.com/WXPay/
        /// </summary>
        public static string PayUrls = ConfigurationManager.AppSettings["PayUrls"].ToString();
        public static string PayUrl = "http://" + PayUrls;

        /// <summary>
        ///  支付通知页面，请注意测试阶段设置授权目录，在微信公众平台中“微信支付”---“开发配置”--修改测试目录   
        /// 支付完成后的回调处理页面,替换成notify_url.asp所在路径
        /// </summary>
        public static string ReulstUrl = ConfigurationManager.AppSettings["ReulstUrl"].ToString();
        public static string NotifyUrl = "http://"+ ReulstUrl;

        public static string CASHIER = ConfigurationManager.AppSettings["CASHIER"].ToString();

        public static string ReulstUrl1 = ConfigurationManager.AppSettings["ReulstUrl1"].ToString();
        public static string NotifyUrl1 = "http://" + ReulstUrl1;
    }
}
