<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFApply.aspx.cs" Inherits="SCJN.WFApply" %>

<!DOCTYPE html>
<html>
<head runat="server">
<meta name="referrer" content="always" /><meta charset='utf-8' /><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no"/>
    <title></title>
    <style type="text/css">
        *
        {
            font-size: 15px;
            line-height: 200%;
            padding: 0px;
        }
        body
        {
            width: 96%;
            height: 100%;
           background-color:#f7f8f8;
            margin: 0px 2% 0px 2%;
        }
        #DivHead
        {
            background-color: #005ca1;
            text-align: left;
            font-size: x-large;
            color: White;
            margin-top:10px
        }
        #DivHead img
        {
            width: 30px;
            border: none;
        }
        #DivHead div:first
        {
            border-bottom: 4px solid black;
        }
        table
        {
            color: #005ca1;
            font-size: x-large;
            text-align: center;
            width: 100%;
            font-weight: bold;
            margin: 10px 0 auto 0;
        }
        table tr td{ border:1px solid gray;}
        #BtnApply{ /*font-size:large; background-color:#005ca1; width:96%; margin-left:2%; margin-right:2%;  color:White; height:40px;*/
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
	margin-top:15px;
	margin-left: 3%;
	border: 1px solid #016599;

		}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="DivHead">
        <div>
            <img src="Img/kehu2.png" /><%=UserName%> <%=id%></div>
        <div>
            <img src="Img/zuobiao1.png" /><%=UserAddress%></div>
    </div>
    <div>
        <table>
            <tr>
                <td>
                    用水月份
                </td>
                <td>
                   <%=UseMonth%>
                </td>
            </tr>
            <tr>
                <td>
                    用水量
                </td>
                <td>
                    <%=WaterUse%>立方
                </td>
            </tr>
            <tr>
                <td>
                    用水性质
                </td>
                <td>
                    <%=UseProperties%>
                </td>
            </tr>
            <tr>
                <td>
                    应缴金额
                </td>
                <td>
                   <%=UseMoney%>元
                </td>
            </tr>
            <tr>
                <td>
                    缴费金额
                </td>
                <td>
                      <%=UseMoney%>元
                </td>
            </tr>
        </table>
    </div>
    <div >
    <asp:Button
            ID="BtnApply" runat="server" Text="支付" onclick="BtnApply_Click"  /></div>
    </form>
</body>
</html>
