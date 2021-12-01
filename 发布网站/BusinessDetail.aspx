<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessDetail.aspx.cs" Inherits="SCJN.BusinessDetail" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>业务明细</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        * {
            font-style: normal;
            color: #04388E;
            font-size: larger;
        }

        body {
            margin: 0 2%;
        }

        p {
            font-size: larger;
            font-weight: normal;
            font-style: normal;
            font-variant: normal;
            text-decoration: blink;
        }

        #footImg {
            margin-bottom: 2%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <div>
                <h5 style="background-color: #77DFF8;">用水开户</h5>
                <hr align="center" size="1" />
                <div>
                    <h5>业务说明</h5>
                    <p>
                        ①新增用水户户主持书面申请（含姓名、住址、栋号、单元号、楼层、房号、用水范围、联系电话等）送达公司水管站；
                    </p>
                    <p>
                        ②用户与公司签定《供用水收费协议书》；
                    </p>
                    <p>
                        ③发放《用水许可证》；
                    </p>
                    <p>
                        ④公司生产科派技术人员到用户住地现场勘测，提出破头搭接和安管方案，提供用工用料费用预算表，或面谈商定工料费；
                    </p>
                    <p>
                        ⑤用户到公司财务室缴纳相关费用；
                    </p>
                    <p>
                        ⑥公司组织人员破头、搭接和管道设施安装（含表箱、水表、表前表后闸阀等）；
                    </p>
                    <p>
                        ⑦经检验合格后开阀供水；
                    </p>
                    <p>
                        ⑧公司既实行“一户一表、抄表到户”的服务，也实行开发园区总表阀管理办法（一园区一总表或一小区一总表）。
                    </p>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <div>
                <h5 style="background-color: #77DFF8;">用户过户</h5>
                <hr align="center" size="1" />
                <div>
                    <h5>业务说明</h5>
                    <p>
                        ①用水户户主发生永久性变更时，可由变更双方共同提出过户申请，送达公司水管站；；
                    </p>
                    <p>
                        ②新户主应用公司重新签定《供用水收费协议书》，原《协议书》作废；
                    </p>
                    <p>
                        ③收回原《用水许可证》，发放新《用水许可证》；
                    </p>
                    <p>
                        ④双方办清一切移交手续（含交清原用水水费等）；
                    </p>
                    <p>
                        ⑤房屋出租者不能过户。
                    </p>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Visible="False">
            <div>
                <h5 style="background-color: #77DFF8;">停用水销户</h5>
                <hr align="center" size="1" />
                <div>
                    <h5>业务说明</h5>
                    <p>
                        ①用户暂不用水，可报停水，到公司水管站备案即可；
                    </p>
                    <p>
                        ②用户离开本城区供水范围，停止用水时，可持《供用水协议书》、《用水许可证》到公司水管站办理销户手续；
                    </p>
                    <p>
                        ③销户时用户必须交清已用水水费。
                    </p>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" Visible="False">
            <div>
                <h5 style="background-color: #77DFF8;">用户违约停水</h5>
                <hr align="center" size="1" />
                <div>
                    <h5>业务说明</h5>
                    <p>
                        ①每月抄表后，10号起用户到收费门市交清水费；
                    </p>
                    <p>
                        ②超过当月20号不交费，公司即向用水户发放《追收水费通知单》，限期交费；
                    </p>
                    <p>
                        ③在规定期限内仍不交费的，从超出时限的即日起停止供水；
                    </p>
                    <p>
                        ④用户交清拖欠的水费和违约金，同时，还需交纳停、供水人工费后方可恢复供水；
                    </p>
                    <p>
                        ⑤用户因特殊情况（如因事在外地）不能按时交水费时，可在规定的期限内电话告知公司办公室或水管站，说明情况经公司许可后不算违约。
                    </p>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" Visible="False">
            <div>
                <h5 style="background-color: #77DFF8;">排水管道安装工程</h5>
                <hr align="center" size="1" />
                <div>
                    <h5>业务说明</h5>
                    <p>
                        ①由用水单位提供《供排水施工图》或书面要求；
                    </p>
                    <p>
                        ②公司生产科按定额标准向用水单位提出工程造价预算书；
                    </p>
                    <p>
                        ③公司与用水单位洽谈、签定《供排水管道安装合同》；
                    </p>
                    <p>
                        ④按国家安装规范及设计图或用水单位书面要求组织施工；
                    </p>
                    <p>
                        ⑤按国家验收标准验收交付使用；结算工程费用；用水时再按开户规定办理相关手续
                    </p>
                    <p>
                        ⑥给排水管道的保修期为半年（从交付之日起计算）；
                    </p>
                    <p>
                        ⑦给排水管道安装工程可整体工程承包，也可以分单项工程承包；
                    </p>
                    <p>
                        ⑧承包方式：包工包料或包工不包料。
                    </p>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel6" runat="server" Visible="False">
            <div>
                <h5 style="background-color: #77DFF8;">排水管道设施（室内）维修、更新及改造业务</h5>
                <hr align="center" size="1" />
                <div>
                    <h5>业务说明</h5>
                    <p>
                        ①用户电话报修：告知姓名、住址、栋号、单元号、楼层和户号及维修内容；
                    </p>
                    <p>
                        ②可到公司面谈维修事项；
                    </p>
                    <p>
                        ③接到报修信息后，30分钟内派维修工上门维修服务；
                    </p>
                    <p>
                        ④按物价部门批准的价格收取工时材料费；
                    </p>
                    <p>
                        ⑤维修业务实行24小时上门服务，随叫随到。
                    </p>
                </div>
            </div>
        </asp:Panel>
        <div id="Div1">
            <br />
        </div>
        <div id="footImg">
            <img src="Img/二维码_03.png" style="width: 8%; margin-left: 48%;" />
        </div>
    </form>
</body>
</html>
