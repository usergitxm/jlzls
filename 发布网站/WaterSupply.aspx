<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaterSupply.aspx.cs" Inherits="NBSW.WaterSupply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--
<html lang="zh-CN">
<head>
    <title>停水公告</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <link href="CSS/news.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="JS/index.js" type="text/javascript"></script>
    <style type="text/css"> 
    .back{ background-color:White;}
    .line{ border-bottom:1px solid #bebebe;}
    .line1{ border-bottom:1px solid #bebebe;}
    .bottom{ margin-top:68%;}
    </style>
</head>
<body class="back">
   <div>
   <img src="Img/watersupply.jpg" style=" width:100%; height:200px;"/>
   <div>   <p class="line1"></p>
   <p style=" height:30px; margin-top:20px; margin-bottom:20px;">&ensp;&ensp;暂无公告</p>
   <p class="line"></p>
   </div>
   </div>
    <div style=" height:40px; width:100%; background-color:#009afe; position:fixed; bottom:0px;">
   <p style=" text-align:center; color:White;">&nbsp;</p>
       <p style=" text-align:center; color:White; margin-top:-10px;">筠连县自来水公司</p>
   </div>
</body>
</html>--%>

<!--停水发布网页-->
<html lang="zh-CN">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>停水公告</title>
    <meta http-equiv="X-UA-Compatible" content="IE=Edge, chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <link href="./bind_files/normalize.css" rel="stylesheet" />
    <link href="./bind_files/bootstrap.min.css" rel="stylesheet" />
    <link href="./bind_files/font-awesome.min.css" rel="stylesheet" />
    <link href="./bind_files/function.css" rel="stylesheet" />
    <link href="./bind_files/base.css" rel="stylesheet" />
    <link href="./bind_files/main.css" rel="stylesheet" />
    <link href="./bind_files/form.css" rel="stylesheet" />
    <link href="./bind_files/list.css" rel="stylesheet" />
    <link href="./bind_files/article.css" rel="stylesheet" />
    <link href="./bind_files/mytooltip.css" rel="stylesheet" />
    <link href="./bind_files/comment.css" rel="stylesheet" />
    <link href="./bind_files/layui.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="./bind_files/sandbeach-oldPage.css" rel="stylesheet" />
    <link href="./bind_files/mydialog.css" rel="stylesheet" type="text/css" media="screen" />
    <style type="text/css">
        .mydialog-content {
            max-height: 500px;
            overflow-y: auto;
        }
    </style>
</head>
<body id="page-xxbd" class="page-color-card-form">
    <div class="container">
        <div style="text-align: center; font-size: 28px;">
            <p>停水公告</p>
        </div>
        <br />
        <div class="mytooltip-container"></div>
        <form id="fanuserform" class="color-card-form" data-parsley-trigger="focusout" novalidate="" runat="server">
            <div class="form-row">
                <div class="input-row">
                    <label>停水类型：</label>
                    <asp:TextBox ID="fTitle" placeholder="请输入停水类型" required="" data-parsley-id="4" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="input-row">
                    <label>停水时间：</label>
                    <asp:TextBox ID="start_time" runat="server" placeholder="请输入停水开始时间" required="" data-parsley-id="6"></asp:TextBox><br />
                    <br />
                    <asp:TextBox ID="end_time" runat="server" placeholder="请输入停水结束时间" required="" data-parsley-id="6"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="input-row">
                    <label>停水区域：</label>
                    <asp:TextBox ID="fContent" runat="server" placeholder="请输入停水区域"
                        required="" data-parsley-id="8" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="handler-group">
                <div class="cell">
                    <asp:Button ID="Button1" runat="server" Text="确认提交" class="btn btn-lg btn-base col-xs-10 f-cb" />
                </div>
                <div class="cell">
                    <asp:Button ID="Button2" runat="server" Text="取消返回" class="btn btn-lg btn-base col-xs-10 f-cb" />
                </div>
            </div>
    </div>
    <div class="second-bg">
    </div>
    <script src="./bind_files/jquery.min.js"></script>
    <script src="./bind_files/parsley.min.js"></script>
    <script src="./bind_files/jquery.mytooltip.js"></script>
    <script src="./bind_files/layui.js"></script>
    <script src="./bind_files/jquery.mydialog.js"></script>
    </form>
</body>
</html>
