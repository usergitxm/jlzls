<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseIdCard.aspx.cs" Inherits="NBSW.ChooseIdCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html lang="en">
<head>
    <meta charset="UTF-8">
    <title></title>
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
    <link rel="stylesheet" type="text/css" href="themes/css/picker-extend.css">
</head>
<body>
<form id="form1" runat="server">
    <section class="aui-flexView">
	<header class="aui-navBar aui-navBar-fixed b-line">
   
		<a href="javascript:;" onClick="javascript :history.back(-1);" class="aui-navBar-item">
			<i class="icon icon-return"></i>
		</a>
		<div class="aui-center">
			<span class="aui-center-title">编号选择</span>
		</div>
		<a href="javascript:;" class="aui-navBar-item">
			<i class="icon icon-news"></i>
		</a>
      
	</header>
	<section class="aui-scrollView">
		<div class="aui-white">
			<div class="aui-ad">
				<img src="img/1111.jpg" alt=""  style=" width:100%;">
			</div>
			<div class="aui-listing">
				<a href="javascript:;" class="aui-flex b-line">
					<div class="aui-listing-title">
						<span>编号选择</span>
					</div>
					<div class="aui-flex-box aui-arrow" id="cityPicker">
						<%--<p>--请选择用户编号--</p>--%>
                        <p><asp:DropDownList ID="Drop_UserId" runat="server"></asp:DropDownList></p>
					</div>
				</a>
			
			</div>
        <div id="div-btn" style=" margin-top:50px;"><asp:Button runat="server" 
                ID="Btn_Next" Text="下一步"  
                style=" width:90%; margin-left:5%; background-color:#FD8050; height:40px; border:0px solid; border-radius:100px; color:White;" 
                onclick="Btn_Next_Click"></asp:Button></div>
		</div>
	</section>
</section>
    <script src="themes/js/jquery.min.js"></script>
    <script src="themes/js/picker-extend.js" type="text/javascript"></script>
</form>
</body>
</html>
