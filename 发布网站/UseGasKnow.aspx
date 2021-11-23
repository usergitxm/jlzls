<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UseGasKnow.aspx.cs" Inherits="SCJN.UserWaterKnow" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>公司经营服务</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        *
        {
            margin: 0 2%;
            font-size: larger;
        }
        .btn-big
        {
            padding: 1% 25;
        }
        .btn
        {
            margin-top: 2%;
        }
        .dark-blue-bordered-btn
        {
            background: none;
            border: 1px solid #98EBFB;
            color: #006699;
        }
        .btn
        {
            text-align: left;
            width: 98%;
            color: White;
            padding: 2% 4%;
            margin-top: 2%;
            font-size: larger;
            margin-right: 2%;
        }
        a
        {
            margin: 0 0;
        }
    </style>
</head>
<%--#006699--%>
<body style="background-image: url('Img/back.jpg')">
    <div>
                <a href="DetailInf.aspx?type=4">
                    <button class="btn btn-big dark-blue-bordered-btn">
                       服务程序
                    </button>
                </a>
        <a href="DetailInf.aspx?type=1">
            <button class="btn btn-big dark-blue-bordered-btn">
                经营服务范围</button></a> 
                <a href="DetailInf.aspx?type=2">
                    <button class="btn btn-big dark-blue-bordered-btn">
                       经营服务项目
                    </button>
                </a>
                <a href="DetailInf.aspx?type=3">
                    <button class="btn btn-big dark-blue-bordered-btn">
                       公司机构设置及其服务职责
                    </button>
                </a>
    </div>
</body>
</html>
