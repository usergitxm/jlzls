<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paypartner.aspx.cs" Inherits="NBSW.Pay_partner" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>订单支付</title>
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=0"
        name="viewport" />
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="black" name="apple-mobile-web-app-status-bar-style" />
    <meta content="telephone=no" name="format-detection" />
    <link rel="stylesheet" type="text/css" href="themes/css/base.css">
    <link rel="stylesheet" type="text/css" href="themes/css/home.css">
    <link rel="stylesheet" type="text/css" href="themes/css/icon.css">
    <link rel="icon" type="image/x-icon" href="favicon.ico">
    <link href="iTunesArtwork@2x.png" sizes="114x114" rel="apple-touch-icon-precomposed">
</head>
<body>
    <form id="form1" runat="server">
        <section class="aui-flexView">
	<header class="aui-navBar aui-navBar-fixed ">
		<a href="javascript:;" onClick="javascript :history.back(-1);" class="aui-navBar-item">
			<i class="icon icon-return"></i>
		</a>
		<div class="aui-center">
			<span class="aui-center-title">订单支付</span>
		</div>
		<a href="javascript:;" class="aui-navBar-item">
			<i class="icon icon-news"></i>
		</a>
	</header>
	<section class="aui-scrollView">
		<div class="aui-white" style="padding-bottom:0">
			<div class="divHeight"></div>
			<div class="aui-listing aui-pay-partner">
               <a href="#" class="aui-flex ">
					<div class="aui-listing-title">
						<span>业务编号</span>
					</div>
					<div class="aui-flex-box aui-arrow" id="Div3">
						<p><%=N_BUSINESS_ID%></p>
					</div>
				</a>
				<a href="#" class="aui-flex b-line">
					<div class="aui-listing-title">
						<span>费用名称</span>
					</div>
					<div class="aui-flex-box">
					<%--	<input type="text" value="测试">--%>
                    材料安装费
					</div>
				</a>
				<a href="#" class="aui-flex b-line">
					<div class="aui-listing-title">
						<span>申请户数</span>
					</div>
					<div class="aui-flex-box">
					<%--	<input type="text" value="测试">--%>
                    <%=UseCount%>
					</div>
				</a>
				<a href="#" class="aui-flex b-line">
					<div class="aui-listing-title">
						<span>未缴金额</span>
					</div>
					<div class="aui-flex-box">
						<%--<input type="text" value="测试">--%>
                       <asp:TextBox ID="PayMoney" runat="server" ReadOnly="true"></asp:TextBox> 
					</div>
				</a>
			</div>
		</div>	
        <div style=" background-color:White;">	
        	<div class="aui-flex b-line">
			<div class="aui-flex-box">
				<p>订单完成后若有延迟未销账，请勿重复支付</p>
			</div>
			<div class="aui-arrow"></div>
		</div>
		<div class="aui-flex">
			
			<div class="aui-pay-mar" style=" width:100%;">
				<%--<a href="javascript:;" class="aui-btn">确认支付</a>--%>
<asp:Button ID="Button1"  class="aui-btn" runat="server"  Text="确认支付" onclick="Button1_Click"></asp:Button>
			</div>
		</div>
        </div>
	</section>
</section>
    </form>
</body>
</html>
