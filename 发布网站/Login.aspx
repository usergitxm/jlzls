<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NBSW.BusinessManagement.Login" %>

<!DOCTYPE >

<html class="no-js">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="format-detection" content="telephone=no">
    <title></title>
    <!-- Set render engine for 360 browser -->
    <meta name="renderer" content="webkit">
    <!-- No Baidu Siteapp-->
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <!-- <link rel="icon" type="image/png" href="assets/i/favicon.png"> -->
    <!-- Add to homescreen for Chrome on Android -->
    <meta name="mobile-web-app-capable" content="yes">
    <!-- <link rel="icon" sizes="192x192" href="assets/i/app-icon72x72@2x.png"> -->
    <!-- Add to homescreen for Safari on iOS -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="apple-mobile-web-app-title" content="Amaze UI" />
    <!--  <link rel="apple-touch-icon-precomposed" href="assets/i/app-icon72x72@2x.png"> -->
    <!-- Tile icon for Win8 (144x144 + tile color) -->
    <!-- <meta name="msapplication-TileImage" content="assets/i/app-icon72x72@2x.png"> -->
    <meta name="msapplication-TileColor" content="#0e90d2">
   
    <link rel="stylesheet" href="css/amazeui.min.css" >
    <style>
        html
        {
            font-size: 10px;
        }
        html, body
        {
            background-color: #f0eff4;
        }
        body
        {
            padding-bottom: 0;
            margin: 0;
            padding-top: 49px;
        }
        *
        {
            padding: 0;
            margin: 0;
        }
        header
        {
            position: fixed;
            top: 0;
            left: 0;
            z-index: 999;
            width: 100%;
            height: 49px;
            background-color: #333;
            color: #fff;
        }
        header .back
        {
            position: absolute;
            top: 0;
            left: 0;
            display: inline-block;
            padding-left: 5px;
            font-size: 30px;
        }
        header p
        {
            margin: 0;
            line-height: 49px;
            font-size: 16px;
            text-align: center;
        }
        .register
        {
            padding: 8px 6px;
            font-size: 14px;
        }
        .res-item
        {
            position: relative;
            width: 100%;
            border-radius: 4px;
            margin-bottom: 8px;
            background-color: #fff;
        }
        .res-icon
        {
            position: absolute;
            left: 8px;
            top: 5px;
            z-index: 100;
            display: inline-block;
            font-size: 18px;
            color: #9c9c9c;
        }
        .res-item .input-item
        {
            display: inline-block;
            width: 100%;
            padding-left: 31px;
            height: 40px;
            border: none;
            font-size: inherit;
        }
        .res-item .input-item:focus
        {
            outline-offset: 0;
            outline: -webkit-focus-ring-color auto -2px;
            background-color: #fefffe;
            border: 1px solid #e21945;
            outline: 0;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 5px rgba(226,25,69,.3);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 5px rgba(226,25,69,0.3);
        }
        .res-item .input-item:focus + .res-icon
        {
            color: #e21945;
        }
        .yanzhengma
        {
            position: absolute;
            right: 10px;
            top: 5px;
            z-index: 100;
            display: inline-block;
            padding: 0.5rem 0.8rem;
            font-size: 14px;
            border: none;
            background-color: #e21945;
            color: #fff;
            border-radius: 8px;
        }
        .yanzhengma:disabled
        {
            background-color: #ddd;
        }
        .res-btn
        {
            margin-top: 10px;
            padding: 0 5px;
        }
        .res-btn button
        {
            background-color: #e21945;
            font-size: 14px;
            color: #fff;
            border-radius: 8px;
        }
        .res-btn button:focus
        {
            color: #fff;
        }
    </style>
</head>
<body style="font-family: 黑体; left: 0px;">
    <form id="form1" runat="server">
    <header>
        <p style=" background-color:#2B2F77;">管理员登录</p>
    </header>
    <div class="register">
        <div class="res-item" style="text-align: center;">
            <asp:TextBox ID="Txt_username" runat="server" placeholder="请输入登录账号" class="input-item mobile"></asp:TextBox>
            <%--  <i class="res-icon am-icon-phone"></i>--%>
        </div>
        <div class="res-item">
            <asp:TextBox ID="Txt_pwd" runat="server" placeholder="请输入登录密码" 
                class="input-item mobile" TextMode="Password"></asp:TextBox>
            <%--  <i class="res-icon am-icon-phone"></i>--%>
        </div>
        
      
       
      
        <div class="res-btn">
            <asp:Button ID="Btn_regester" runat="server" Text="登录" class="am-btn am-btn-block"
                Style="color: White; background-color: #2B2F77; border-radius: 4px;" OnClick="Btn_regester_Click" />
        </div>
    </div>
    <script src="js/jquery-3.2.1.min.js"></script>
    </form>
</body>
</html>

