<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailInf.aspx.cs" Inherits="SCJN.DetailInf" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>公司机构设置及其服务职责</title>
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        *
        {
            margin: 0 1%;
            font-style: normal;
            color: white;
            font-size: larger;
        }
        #BODY-Detail
        {
            border: 1px solid #033A94;
            margin: 0 2%;
            background-color: #1675AB;
        }
    </style>
</head>
<body lang="en">
    <div id="Div2">
        <br />
    </div>
    <div id="head">
        <div id="BODY-Detail">
            
           <asp:Panel runat="server" ID="Panel1" Visible="False">
                <div id="first">
                    <div id="Div3">
                    <h5> 公司机构设置及其服务职责</h5>
                        <br />
                    </div>
                        <p>
                            1、经理（1人）：全面负责公司供水经营服务的管理和城区管网建设；
                        </p>
                        <p>
                            2、办公室（2人）：对内负责公司各部门的工作协议、监督及文书、资料和档案的管理；对外负责用户来信来访的接待，处理用户报修、投诉等事务；
                        </p>
                        <p>
                           3、生产技术科（1人）：负责管道安装及管网维修工作的安排、施工技术与质量和工程费的预决算。
                        </p>
                        <p>
                            4、安全治保科（5人）：负责生产安全管理及单位内部治安综合治理工作；
                        </p>
                        <p>
                           5、财务科（6人）：负责帐务往来及现金收支及门市收费管理；
                        </p>
                        <p>
                           6、材料门市和库房（1人）：负责管材管件的采购、销售和保管；
                        </p>
                        <p>
                           7、水政管理站（11人）：负责上门抄表、办理供水业务和巡查管网运行状况；
                        </p>
                        <p>
                           8、管道安装维修服务队（9人）：负责城市管网铺设、室内外给排水管道安装及管爆管漏的抢修工作；
                        </p>
                       
                </div>
            </asp:Panel><asp:Panel runat="server" ID="Panel2" Visible="False">
                <div id="first">
                    <div id="Div3">
                    <h5> 经营服务范围</h5>
                        <br />
                    </div>
                        <p>
                           1、自来水销售及供水业务承办；
                        </p>
                        <p>
                           2、给排水管道安装；
                        </p>
                        <p>
                           3、给排水管道设施维修、更换及改造；
                        </p>
                        <p>
                           4、给排水管道、管件器材零售；
                        </p>
                        <p>
                          5、管网漏损及突发事故的抢修。
                        </p>
                       
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="Panel3" Visible="False">
                <div id="first">
                    <div id="Div3">
                    <h5> 经营服务项目</h5>
                        <br />
                    </div>
                        <p>
                           1、抄表计量；
                        </p>
                        <p>
                           2、收取水费；
                        </p>
                        <p>
                           3、办理供水业务；
                        </p>
                        <p>
                           4、给排水管道工程安装；
                        </p>
                        <p>
                         5、给排水管道设施维修、更新及改造；
                        </p>
                        <p>
                          6、用水开户；
                        </p>
                        <p>
                           7、用户过户；
                        </p>
                        <p>
                           8、停用水销户；
                        </p>
                        <p>
                           9、用户搬迁用水户头的变更；
                        </p>
                        <p>
                          10、用水类别变更；
                        </p>
                        <p>
                          11、违约停水；
                        </p>
                        <p>
                           12、零售管材、管件及配件。
                        </p>
                       
                </div>
            </asp:Panel>

            </asp:Panel><asp:Panel runat="server" ID="Panel4" Visible="False">
                <div id="first">
                    <div id="Div3">
                    <h5> 经营服务范围</h5>
                        <br />
                    </div>
                    <h1>抄表计量</h1>
                        <p>
                          ①每月6日～8日为定时上门抄表日；
                        </p>
                        <p>
                         ②以用户水表为准按月类计量；
                        </p>
                        <h2>水费收缴方式</h2>
                        <p>
                           ①用户自行到公司收费处缴纳水费。
                        </p>
                        <p>
                          ②银行转帐：由用户通知到所在银行办理转帐手续；
                        </p>
                       
                </div>
            </asp:Panel>
        </div>
        <div id="Div10">
            <hr align="center" size="1" />
        </div>
        <div id="footImg">
            <div id="Div6">
                <br />
            </div>
            <div>
                <img src="Img/二维码_03.png" style="width: 8%; border-radius: 10px; height: 8%; text-align: center;
                    margin-right: 48%; margin-left: 48%;" /></div>
        </div>
    </div>
</body>
</html>
