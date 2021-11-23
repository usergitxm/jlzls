<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenDoorList.aspx.cs" Inherits="SCJN.OpenDoorList" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>业务指南</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        *
        {
            font-size: larger;
            margin:2% 0;
        }
        body
        {
            margin:0 2% 2% 2% ;
            background-attachment: fixed;
            background-image: url('Img/2016-06-22_140808.jpg');
            background-repeat: no-repeat;
            background-position: center center; 
        }
        .divdemo
        {
         
            margin: auto left;
            border: 1px solid #A7EDF7;
            background-color: White;
            height: 5%;
            text-align: left left;
        }
        a
        {
            text-decoration: none;
            color: #04388E;
        }
        #footImg
        {
            margin-bottom: 2%;
        }
    </style>
</head>
<body lang="en">
    <div>
        <br />
    </div>
    <div>
        <a href="BusinessDetail.aspx?site=1">
            <div class="divdemo">
                <p>
                    用水开户</p>
            </div>
        </a>
    </div>
    <div class="divft">
        <a href="BusinessDetail.aspx?site=2">
            <div class="divdemo">
                <p>
                    用户过户</p>
            </div>
        </a>
    </div>
    <div>
        <a href="BusinessDetail.aspx?site=3">
            <div class="divdemo">
                <p>
                    用户销户</p>
            </div>
        </a>
    </div>
    <div>
        <a href="BusinessDetail.aspx?site=4">
            <div class="divdemo">
                <p>
                    用户违约停水</p>
            </div>
        </a>
    </div>
    <div>
        <a href="BusinessDetail.aspx?site=5">
            <div class="divdemo">
                <p>
                    给排水管道安装工程</p>
            </div>
        </a>
    </div>
    <div>
        <a href="BusinessDetail.aspx?site=6">
            <div class="divdemo">
                <p>
                    给排水管道设施（室内）维修、更新及改造业务</p>
            </div>
        </a>
    </div>
    <hr align="center" size="1" />
    <div>
        <br />
    </div>
    <div id="footImg">
        <img src="Img/二维码_03.png" style="width: 6%; margin-left: 48%;" /></div>
</body>
</html>
