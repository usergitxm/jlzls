<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SCJN.Index" %>

<html lang="zh-CN">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>缴纳水费</title>
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
    <link href="./bind_files/sandbeach-oldPage.css" rel="stylesheet">
    <link href="./bind_files/mydialog.css" rel="stylesheet" type="text/css" media="screen">
    <style type="text/css">
        .mydialog-content {
            max-height: 500px;
            overflow-y: auto;
        }
    </style>
</head>
<body id="page-xxbd" class="page-color-card-form">
    <br />
    <div style="text-align: center; font-size: 23px;"><span>缴纳水费</span></div>
    <div class="container">
        <form id="fanuserform" class="color-card-form" action="Index.aspx?action=up" data-parsley-trigger="focusout" novalidate="" runat="server">
            <div class="mytooltip-container"></div>
            <div class="form-row">
                <div class="input-row">
                    <label>单位名称：</label>
                    <asp:TextBox ID="TextBox1" runat="server" name="UserID" Text="筠连县自来水公司" required="" data-parsley-id="4" ReadOnly="True">筠连县自来水公司</asp:TextBox>
                </div>
            </div>
            <br />
            <div class="form-row">
                <div class="input-row">
                    <label>用户编号：</label>
                    &ensp;<asp:DropDownList ID="UserID" CssClass="lblName" runat="server" name="DropDownList1" Width="125" Height="30">
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="form-row">
                <div class="input-row">
                    <label>初始密码：</label>
                    <asp:TextBox ID="UserPassword" runat="server" name="UserPassword" placeholder="请输入初始密码" required="" data-parsley-id="4"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="form-row">
                <div class="input-row">
                    <label>选择月份：</label>
                    &ensp;
                    <asp:DropDownList ID="DropDownList1" runat="server" name="DropDownList1"
                        Width="125px" Height="30">
                        <asp:ListItem Value="22">全部</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <div>
                <p style="color: #FF0000; line-height: 28px;">温馨提示：用户输入用户编号设置初始密码后可登录进行绑定信息、查询信息、缴纳水费，在输入编号时切记于自己编号后面加数字“1”。</p>
            </div>
            <br />
            <div class="handler-group">
                <div class="cell">
                    <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Submit_Click" class="btn btn-lg btn-base col-xs-10 f-cb" /><br />
                </div>
            </div>
    </div>
    <div class="second-bg"></div>
    <footer>
        <div class="copyright" id="footerContent">
        </div>
        <script src="./bind_files/jquery.min.js"></script>
        <script type="text/javascript">

            var token = '03dde854475342b8940a505e4ea5c7fb';

            $.ajax({
                url: '/zsy_mobile/m/findMpByTokenJson.do',
                dataType: 'json',
                async: false,
                data: {
                    'token': token
                },
                type: 'get',   //请求方式
                contentType: 'application/x-www-form-urlencoded; charset=utf-8',
                beforeSend: function () {
                    //请求前的处理
                },
                success: function (msg) {
                    if (msg.customizationLogoStatus == 0) {
                        $('#footerContent').show();
                        if (msg.customizationLogoUrl != null && msg.customizationLogoUrl.length > 0) {
                            $('#footBaselogoUrl').attr("href", msg.customizationLogoUrl);
                        } else {
                            $('#footBaselogoUrl').removeAttr("href", "http://nhgs.wisewater.cn/zsy_mobile/m/zsy/about-zsy.html");
                        }
                        $('#footBaseImg').attr("src", "http://zsybackend.wisewater.cn:8082/zsy_backend/resources/attached/03dde854475342b8940a505e4ea5c7fb/" + msg.customizationLogoImg);
                    } else if (msg.customizationLogoStatus == 1) {
                        $('#footBaselogoUrl').attr("href", "http://nhgs.wisewater.cn/zsy_mobile/m/zsy/about-zsy.html");
                        $('#footBaseImg').attr("src", "/zsy_mobile/resources/img/zsy-logo.png");
                    } else if (msg.customizationLogoStatus == 2) {
                        $('#footerContent').hide();
                    } else {
                        $('#footerContent').show();
                        $('#footBaselogoUrl').attr("href", "http://nhgs.wisewater.cn/zsy_mobile/m/zsy/about-zsy.html");
                        $('#footBaseImg').attr("src", "/zsy_mobile/resources/img/zsy-logo.png");
                    }
                },
                error: function (msg) {
                    $('#footerContent').hide();
                    //请求出错处理
                }
            }); //ajax结束
	</script>
    </footer>
    </form>
</body>
</html>
