<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeiPay.aspx.cs" Inherits="SCJN.WeiPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>���߽ɷ�</title>
    <meta http-equiv="Content-Type" content="text/html; charset=GBK" />
    <%-- <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js" type="text/javascript"></script>
    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/lazyloadv3.js" type="text/javascript"></script>--%>
   <%--  /*border-style: none; border-color: inherit; border-width: 0px; background-color: #0099FF;
                        font-size: 20px; color: #FFFFFF; width: 99%; height: 40px; font-weight: bold;
                        cursor: pointer; font-family: @��Բ;*/--%>
    <link href="CSS/BZCSS.css" rel="stylesheet" type="text/css" />

    <script src="JS/jquery.js" type="text/javascript"></script>

    <script src="JS/lazyloadv3.js" type="text/javascript"></script>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:Button ID="btn1" runat="server" Text="Button" onclick="btn1_Click" style="display:none;"/> 
    <div>
        <table id="Tab5" border="1px solid #999999" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
            <tr>
                <td id="n2" style="padding-left: 5px; padding-top: 5px; border-top: 1px solid #999999;">
                    <label id="Label1">
                        ������</label>
                </td>
                <td id="t3" style="border: 1px solid #999999; border-left: 0px; padding-right: 5px;">
                    <asp:Label ID="Text6" runat="server" BorderStyle="None" CssClass="Text1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td id="n3" style="padding-left: 5px;">
                    <label id="Label2">
                        ֧�����</label>
                </td>
                <td id="t4">
                    <%--<input id="Text2" type="text" runat="server" />--%>
                    <asp:Label ID="Text2" runat="server" BorderStyle="None" CssClass="Text2"></asp:Label>
                </td>
            </tr>
            <tr>
                <td id="n5" style="padding-left: 5px;">
                    <label id="Label3">
                        ��Ʒ����</label>
                </td>
                <td id="t5">
                    <%--<input id="Text3" type="text" runat="server" />--%>
                    <asp:Label ID="Text3" runat="server" BorderStyle="None" CssClass="Text3"></asp:Label>
                </td>
            </tr>
            <tr style="display: none;">
                <td class="td_title">
                    <label id="Lab4">
                        �Զ��������</label>
                </td>
                <td class="td_input">
                    <asp:Label ID="lblAttach" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="display: none;">
                <td class="td_title">
                    OpenId��
                </td>
                <td class="td_input">
                    <asp:Label ID="lblOpenId" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border: 0px; text-align: center; padding-bottom: 5px;">
                    <input type="button" value="ȷ��֧��" id="getBrandWCPayRequest"  style="height: 35px;
	height: 35px;
	color: #FFF;
	font-size: 16px;
	font-weight: bold;
	width: 94%;
	/*
	letter-spacing: 30px;*/
	display: block;
	/*
	-moz-border-radius: 15px;
	-webkit-border-radius: 15px;*/
	border-radius: 15px;
	background-image: url(img/5409.jpg);
	background-repeat: no-repeat;
	background-position: center center;
	/*margin-top: 15px;
	margin-right: auto;
	margin-bottom: 15px;*/
	margin-left: 3%;
	margin-top:10px;
	border: 1px solid #016599;
 " onclick="SavePay()" />
                </td>
            </tr>
        </table>
    </div>
    <%--    <div class="WCPay">
    <h1 class="title"  id="getBrandWCPayRequest" onclick="SavePay()" >�ύ</h1>
    
<a id="getBrandWCPayRequest" href="javascript:void(0);">
            <h1 class="title" onclick="">����ύ������΢��֧��</h1>
        </a>

    </div>--%>
    </form>
</body>
</html>
<script type="text/javascript">

    function SavePay() {

     document.getElementById("<%=btn1.ClientID %>").click();
    if(<%= UseMoney %><=0){
    alert("û����Ҫ���ɵķ���!");
    };
        WeixinJSBridge.invoke('getBrandWCPayRequest', {
            "appId": "<%= bll.PayConfig.AppId %>", //���ں����ƣ����̻�����
            "timeStamp": "<%= TimeStamp %>", //ʱ���
            "nonceStr": "<%= NonceStr %>", //�����
            "package": "<%= Package %>", //��չ��
            "signType": "MD5", //΢��ǩ����ʽ:1.sha1
            "paySign": "<%= PaySign %>" //΢��ǩ��
        },
               function (res) {
                   if (res.err_msg == "get_brand_wcpay_request:ok") {
                       //                       alert("΢��֧���ɹ�!");
                   } else if (res.err_msg == "get_brand_wcpay_request:cancel") {
                       alert("�û�ȡ��֧��!");
                   } else {
                       alert(res.err_msg);
                       alert("֧��ʧ��!");
                   }
                   // ʹ�����Ϸ�ʽ�ж�ǰ�˷���,΢���Ŷ�֣����ʾ��res.err_msg�����û�֧���ɹ��󷵻�ok����������֤�����Կɿ���
                   //���΢���Ŷӽ��飬���յ�ok����ʱ�����̻���̨ѯ���Ƿ��յ����׳ɹ���֪ͨ�����յ�֪ͨ��ǰ��չʾ���׳ɹ��Ľ��棻����ʱδ�յ�֪ͨ���̻���̨�������ò�ѯ�����ӿڣ���ѯ�����ĵ�ǰ״̬����������ǰ��չʾ��Ӧ�Ľ��档
               });
    }

</script>