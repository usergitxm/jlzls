<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeiPay1.aspx.cs" Inherits="NBSW.WeiPay1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>在线缴费</title>
    <meta http-equiv="Content-Type" content="text/html; charset=GBK" />
    <link href="CSS/BZCSS.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery.js" type="text/javascript"></script>
    <script src="JS/lazyloadv3.js" type="text/javascript"></script>
    <script type="text/javascript">
        function SavePay1() {
            if (typeof WeixinJSBridge == "undefined") {
                if (document.addEventListener) {
                    document.addEventListener('WeixinJSBridgeReady', SavePay2, false);
                }
                else if (document.attachEvent) {
                    document.attachEvent('WeixinJSBridgeReady', SavePay2);
                    document.attachEvent('onWeixinJSBridgeReady', SavePay2);
                }
            }
            else {
                SavePay2();
            }
        }
        function SavePay2() {
            var obj = {
                "appId": document.getElementById("<%=HiddenField1.ClientID %>").value, //公众号名称，由商户传入
                "timeStamp": document.getElementById("<%=HiddenField2.ClientID %>").value, //时间戳
                "nonceStr": document.getElementById("<%=HiddenField3.ClientID %>").value, //随机串
                "package": document.getElementById("<%=HiddenField4.ClientID %>").value, //扩展包
                "signType": "MD5", //微信签名方式:1.sha1
                "paySign": document.getElementById("<%=HiddenField5.ClientID %>").value //微信签名
            };
            try {
                WeixinJSBridge.invoke(
                    'getBrandWCPayRequest',
                    obj,
                    function (res) {
                        if (res.err_msg == "get_brand_wcpay_request:ok") {
                            alert("微信支付成功!");
                            WeixinJSBridge.call('closeWindow');
                        } else if (res.err_msg == "get_brand_wcpay_request:cancel") {
                            alert("用户取消支付!");
                            WeixinJSBridge.call('closeWindow');
                        } else {
                            alert(res.err_msg);
                            alert("支付失败!");
                            window.history.back(-1);
                        }
                        // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
                        //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
                    });
            }
            catch (e) {
                alert(e);
            }

        }
        function SavePay() {

            document.getElementById("<%=btn1.ClientID %>").click();
            return;

        }

    </script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:HiddenField ID="HiddenField4" runat="server" />
        <asp:HiddenField ID="HiddenField5" runat="server" />
        <asp:Button ID="btn1" runat="server" Text="Button" OnClick="btn1_Click" Style="display: none;" />
        <div>
            <table id="Tab5" border="1px solid #999999" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                <tr>
                    <td id="n2" style="padding-left: 5px; padding-top: 5px; border-top: 1px solid #999999;">
                        <label id="Label1" style="color: #FD8050;">
                            订单号</label>

                    </td>
                    <td id="t3" style="border: 1px solid #999999; border-left: 0px; padding-right: 5px;">
                        <asp:Label ID="Text6" runat="server" BorderStyle="None" CssClass="Text1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="n3" style="padding-left: 5px;">
                        <label id="Label2" style="color: #FD8050;">
                            支付金额</label>
                    </td>
                    <td id="t4">
                        <asp:Label ID="Text2" runat="server" BorderStyle="None" CssClass="Text2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="n5" style="padding-left: 5px;">
                        <label id="Label3" style="color: #FD8050;">
                            商品描述</label>
                    </td>
                    <td id="t5">
                        <asp:Label ID="Text3" runat="server" BorderStyle="None" CssClass="Text3"></asp:Label>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td class="td_title">
                        <label id="Lab4" style="color: #FD8050;">
                            自定义参数：</label>
                    </td>
                    <td class="td_input">
                        <asp:Label ID="lblAttach" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td class="td_title" style="color: #FD8050;">OpenId：
                    </td>
                    <td class="td_input">
                        <asp:Label ID="lblOpenId" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="border: 0px; text-align: center; padding-bottom: 5px;">
                        <input type="button" value="确认支付" id="getBrandWCPayRequest" style="border-radius: 8px; background-color: #FD8050;"
                            onclick="SavePay()" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
