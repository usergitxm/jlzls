<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsUserApplication.aspx.cs"
    Inherits="NBSW.NewsUserApplication" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0">
    <title>报装申请</title>
    <link href="./投诉_files/webuploader.css" rel="stylesheet">
    <link href="./投诉_files/css.css" rel="stylesheet">
    <link href="./投诉_files/cf_zhsw.css" rel="stylesheet">
    <script src="./投诉_files/jquery-3.3.1.min.js.下载"></script>
    <script src="./投诉_files/layer.js.下载"></script>
    <link rel="stylesheet" href="./投诉_files/layer.css" id="layui_layer_skinlayercss"
        style="">
    <script src="./投诉_files/webuploader.js.下载"></script>

    <style type="text/css">
        .cf_tsjy1cont02 {
            padding: 15px 10px;
        }
    </style>
    <style>
        .myd-txCont {
            margin-top: 0;
            border: none;
            width: 94%;
            margin: 0 auto;
            border-radius: 4px;
            background: #fff;
            margin-top: 1rem;
            padding: 1rem 0;
        }

            .myd-txCont h3 {
                font-size: 16px;
                padding-left: 15px;
                margin-bottom: 1.3rem;
                margin-top: .7rem;
            }

            .myd-txCont p {
                height: 50px;
                line-height: 50px;
                border: 0;
            }

        .cf_tsjy1cont02 {
            background: #fff;
            width: 94%;
            margin: 0 auto;
            padding: 1rem 0;
            border-radius: 4px;
            overflow: hidden;
        }

        .cf_tsjy1cont {
            margin-top: 0;
        }

        .myd-txCont p i {
            color: #ff0000;
            background: none;
            margin-right: .5rem;
        }

        .cf_tsjy1cont02 h3 {
            font-size: 16px;
            margin-bottom: 2rem;
            margin-left: 15px;
            margin-top: .7rem;
        }

            .cf_tsjy1cont02 h3 i {
                color: #ff0000;
                background: none;
                margin-right: .5rem;
            }

        .webuploader-pick {
            background: #eee;
            padding: 30px 35px;
        }

        .cf_tsjy1cont {
            padding-bottom: 2rem;
        }

            .cf_tsjy1cont p {
                color: #ff0000;
            }

        .myd-txCont p {
            background: none;
            padding-left: 15px;
        }

            .myd-txCont p label {
                color: #000;
                width: 100px;
            }

            .myd-txCont p input {
                color: #000;
            }

        .s_ts {
            width: 92%;
            margin: 0 auto;
            overflow: hidden;
        }

        .s_list {
            font-size: 15px;
            float: left;
            width: 46%;
            text-align: center;
            border: 1px solid #eee;
            border-radius: 4px;
            padding: .5rem 0;
            margin-right: .8rem;
            margin-bottom: 1rem;
            color: #999;
        }

        .onsel {
            border: 1px solid #2b2f77;
            color: #2b2f77;
            background: url(/content/20190117/images/su.png) no-repeat right top;
            background-size: 28px;
        }

        .select_s {
        }

        .myd-txCont p input[type="text"] {
            margin-left: 0;
        }

        .myd-txCont p input[type="text"] {
            width: 67%;
        }

        .myd-txCont p input[disabled], input:disabled, input.disabled {
            color: #999 !important;
            -webkit-text-fill-color: #999;
            -webkit-opacity: 1;
            opacity: 1;
        }

        .myd-txCont {
            height: 750px;
        }

        .delimg1 {
            position: absolute;
            top: 0;
            right: 0;
        }

            .delimg1 img {
                width: 18px;
            }

        .add_tu {
            position: relative;
            float: left;
            width: 30%;
            margin-right: 1%;
        }

        .new_style {
            width: 100%;
            overflow: hidden;
            margin: 0 auto;
            padding: 15px 0px;
        }

        .new_style_l {
            float: left;
            width: 100px;
            font-size: 16px;
            padding-left: 15px;
        }

        .new_style_r {
            float: left;
            line-height: 22px;
            color: #999;
            font-size: 15px;
            width: 60%;
        }
    </style>
    <style>
        .myd-txCont p input[disabled], input:disabled, input.disabled {
            color: #999 !important;
            -webkit-text-fill-color: #999;
            -webkit-opacity: 1;
            opacity: 1;
        }

        .cf_tsjy1cont {
            padding: 15px 10px;
        }

        .ka_add {
            width: 100%;
            margin: 0 auto;
            overflow: hidden;
            padding: 15px 0;
        }

        .ka_add_l {
            float: left;
            font-size: 15px;
            padding-left: 15px;
            width: 100px;
        }

        .ka_add_r {
            float: left;
            font-size: 15px;
        }

            .ka_add_r input {
                font-size: 15px;
            }



            .ka_add_r label {
                margin-right: 10px;
            }

        .new_style_r input[type="text"] {
            width: 100%;
        }
    </style>
    <style class="mpa-style-fix ImageGatherer">
        .FotorFrame {
            position: fixed !important;
        }
    </style>
    <style class="mpa-style-fix SideFunctionPanel">
        .weui-desktop-online-faq__wrp {
            top: 304px !important;
            bottom: unset !important;
        }

            .weui-desktop-online-faq__wrp .weui-desktop-online-faq__switch {
                width: 38px !important;
            }
    </style>

</head>
<body class="cf_tsjy1body" mpa-version="7.16.11" mpa-extension-id="ibefaeehajgcpooopoegkifhgecigeeg">
    <form id="form1" runat="server">
        <div class="myd-txCont" style="margin-bottom: 15px;">
            <h3>基本信息<i style="color: #f40">*</i></h3>
            <p>
                <label>
                    报装编号<i style="color: #f40">*</i></label>
                <asp:TextBox ID="Txt_BZBH" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            <p>
                <label>
                    水表类型<i style="color: #f40">*</i></label>
                <asp:DropDownList Style="font-size: 16px" ID="cboMeterType" runat="server">
                    <asp:ListItem>普通水表</asp:ListItem>
                    <asp:ListItem>智能水表</asp:ListItem>
                    <asp:ListItem>远程表</asp:ListItem>
                    <asp:ListItem>其他表</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <label>
                    安装类型<i style="color: #f40">*</i></label>
                <asp:DropDownList Style="font-size: 16px" ID="cbxInstallType" runat="server">
                </asp:DropDownList>
            </p>
            <p>
                <label>
                    用水性质<i style="color: #f40">*</i></label>
                <asp:DropDownList Style="font-size: 16px" ID="cbxProperties" runat="server">
                </asp:DropDownList>
            </p>
            <p>
                <label>
                    申请名称<i style="color: #f40">*</i></label>
                <asp:TextBox ID="Txt_AppName" placeholder="请输入申请名称" runat="server">
                </asp:TextBox>
            </p>
            <p>
                <label>
                    经&ensp;办&ensp;人<i style="color: #f40">*</i></label>
                <asp:TextBox ID="Txt_UserName" placeholder="请输入经办人" runat="server">
                </asp:TextBox>
            </p>
            <p>
                <label>
                    水表只数<i style="color: #f40">*</i></label>
                <asp:TextBox ID="Txt_UseCount" placeholder="请输入水表只数" runat="server">
                </asp:TextBox>
            </p>
            <p>
                <label>
                    联系地址<i style="color: #f40">*</i></label>
                <asp:TextBox ID="Txt_UserAddress" placeholder="请输入地址" runat="server">
                </asp:TextBox>
            </p>
            <p>
                <label>
                    联系电话<i style="color: #f40">*</i></label>
                <asp:TextBox ID="Txt_UserPhone" placeholder="请输入联系电话" runat="server">
                </asp:TextBox>
            </p>

            <p>
                <label>
                    上传附件<i style="color: #f40">*</i></label><br />
                <asp:FileUpload Style="font-size: 16px" ID="FileUpload1" AllowMultiple="true" runat="server" /><br />
                <asp:FileUpload Style="font-size: 16px" ID="FileUpload2" AllowMultiple="true" runat="server" /><br />
                <asp:FileUpload Style="font-size: 16px" ID="FileUpload3" AllowMultiple="true" runat="server" /><br />
                <asp:FileUpload Style="font-size: 16px" ID="FileUpload4" AllowMultiple="true" runat="server" /><br />
            </p>


        </div>
        <div class="cf_tsjy1cont02" id="imgList">
            <h3>用水原因<i style="color: #f40">*</i></h3>
            <div class="cf_tsjy1cont">
                <textarea id="content" placeholder="请输入用水原因" name="content" cols="100" rows="4" style="width: 100%; font-size: 15px; background-attachment: fixed; background-repeat: no-repeat; border: 1px solid #eee; text-indent: 10px; padding: 1rem 0;"></textarea>
            </div>
        </div>
        <div style="margin-top: 2rem;">

            <asp:Button ID="Button1" runat="server" class="cf_tsjy1abtn" Style="background: #2b2f77; color: #fff; text-align: center; line-height: 3em; height: 3em; font-size: 18px; border-radius: 4px; margin: 0 auto; width: 94%; margin: 0 auto; margin-top: 2rem;"
                Text="提交" OnClick="Button1_Click" />
        </div>
        <br />
        <br />
        <div class="mpa-sc mpa-plugin-article-gatherer mpa-new mpa-rootsc" data-z="100" style="display: block;"
            id="mpa-rootsc-article-gatherer">
        </div>
        <div class="mpa-sc mpa-plugin-image-gatherer mpa-new mpa-rootsc" data-z="100" style="display: block;"
            id="mpa-rootsc-image-gatherer">
        </div>
        <div class="mpa-sc mpa-plugin-page-clipper mpa-new mpa-rootsc" data-z="100" style="display: block;"
            id="mpa-rootsc-page-clipper">
        </div>
        <div class="mpa-sc mpa-plugin-text-gatherer mpa-new mpa-rootsc" data-z="100" style="display: block;"
            id="mpa-rootsc-text-gatherer">
        </div>
        <div class="mpa-sc mpa-plugin-video-gatherer mpa-new mpa-rootsc" data-z="100" style="display: block;"
            id="mpa-rootsc-video-gatherer">
        </div>
        <div class="mpa-sc mpa-plugin-side-function-panel mpa-new mpa-rootsc" data-z="110"
            style="display: block;" id="mpa-rootsc-side-function-panel">
        </div>
        <div class="mpa-sc mpa-plugin-notifier mpa-new mpa-rootsc" data-z="120" style="display: block;"
            id="mpa-rootsc-notifier">
        </div>
        <div class="mpa-sc mpa-plugin-notification-manager mpa-new mpa-rootsc" data-z="130"
            style="display: block;" id="mpa-rootsc-notification-manager">
        </div>
    </form>
</body>
</html>
