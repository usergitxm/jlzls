<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="NBSW.News" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="zh-CN">
<head>
    <title>新闻公告</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <link href="CSS/news.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="JS/index.js" type="text/javascript"></script>
    <style type="text/css">
    .back{ background-color:White;}
    .line{  border-bottom:1px solid #bebebe;}
    .lineheight{ line-height:28px;}
    a{ color:Black;}
    </style>
</head>
<body class="back">
    <div class="MainContent">
        <div id="main-list">
            <div class="FisrtList">
                <div class="ListRow">
                    <div class="ListCover">
                        <a href="News1.aspx?site=1">
                            <div class="CoverWrap" style="background-image: url(Img/ShowComany6.jpg);">
                            </div>
                        </a>
                    </div>
                    <a href="News1.aspx?site=1">
                    </a>
                </div>
            </div>
            <a href="News1.aspx?site=1">
           <div>
           <p class="lineheight" style=" margin:10px;">"副县长郭创峰带队考察供排水PPP项目"安全优质供水，用心服务大众</p>
           <p style=" margin:5px;">&ensp;2018-03-08</p>
           <p class="line"></p>
           </div></a>
        </div>
    </div>
      <div style=" height:40px; width:100%; background-color:#009afe; position:fixed; bottom:0px;">
   <p style=" text-align:center; color:White;">&nbsp;</p>
       <p style=" text-align:center; color:White; margin-top:-10px;">筠连县自来水公司</p>
   </div>
</body>
</html>
