<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDetail12.aspx.cs" Inherits="SCJN.ShowDetail12" %>

<!DOCTYPE html>
<html >
<head runat="server">
    <title></title>
    <meta name="referrer" content="always" /><meta charset='utf-8' /><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no"/>
    <style type="text/css">
        *
        {
            font-size: 15px;
            line-height: 200%;
            padding: 0px;
        }
        body
        {
            width: 96%;
            height: 100%;
            background-color: #f7f8f8;
            margin: 0px 2% 0px 2%;
            min-width: 230px;
        }
        form table
        {
            width: 100%;
            min-width: 230px;
        }
        #DivHead
        {
            background-color: #005ca1;
            text-align: left;
            font-size: x-large;
            color: White;
        }
        #DivHead img
        {
            width: 25px;
            border: none;
            vertical-align: middle;
        }
        #DivHead div:first
        {
            border-bottom: 1px solid red;
        }
        #DivMonth
        {
            text-align: right;
            font-size: larger;
            color: #787878;
        }
        table img
        {
            width: 35px;
            vertical-align: middle;
        }
        table
        {
            border-bottom: 1px solid #787878;
            border-top: 1px solid #787878;
            background-color: White;
        }
        table tr td
        {
            font-size: small;
            color: #787878;
        }
        table tr td:first
        {
            cellspacing: 25px;
        }
        #DivBottom
        {
            width: 100%;
            margin-top: 40px;
            min-width: 250px;
        }
        #AllMoney
        {
            width: 70%;
            height: 35px;
            border: 1px solid #EEE;
        }
        #Submit
        {
            height: 35px;
	color: #FFF;
	font-size: 16px;
	font-weight: bold;
background-image:img/5409.jpg;
	width: 80%;
	letter-spacing: 30px;
	display: block;
	-moz-border-radius: 15px;
	-webkit-border-radius: 15px;
	border-radius: 15px;
	background-image: url(img/5409.jpg);
	background-repeat: no-repeat;
	background-position: center center;
	margin-top: 15px;
	margin-right: auto;
	margin-bottom: 15px;
	margin-left: auto;
	border: 1px solid #016599;
        }
        #Img1
        {
            margin-left: 65%;
        }
        #noInfo{text-align:center;
                 margin-bottom:20px;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div id="DivHead">
        <div>
            <img src="Img/kehu2.png" /><%=UserName%>><%=id%></div>
        <div>
            <img src="Img/zuobiao1.png" /><%=UserAddress%></div>
             <div>
            用户余额:<%=UserAmount%><br />
        </div>
    </div>
    <div id="DivMonth">
        <%=SumMonths%></div>
    <div>
        <%if (dt != null && dt.Rows.Count != 0)
          {
              foreach (System.Data.DataRow dr in dt.Rows)
              {
        %>
        <table>
            <tr>
                <td>
                    <img src="Img/rili2.png" /><label ForeColor="#005CA1"><%=dr["月份"] %></label> 
                </td>
                <td>
                    <%if (Convert.ToInt32(dr["状态"]) == 0)
                      {  %>
                    <img src="Img/weiF_05.png" id="Img1" name="Img1" />
                    <% }
                      else
                      {  %>
                    <img src="Img/Yf.png" id="Img1" name="Img1" /><%}%>
                </td>
            </tr>
            <tr>
                <td>
                    起度：<%=dr["起度"] %>
                </td>
                <td>
                    止度：<%=dr["止度"] %>
                </td>
            </tr>
            <tr>
                <td>
                    水量：<%=dr["用量"] %>
                </td>
                <td>
                    单价：<%= dr["单价"]%>元/立方
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    综合单价：<%=dr["综合单价"]%>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    综合费用：<%=dr["小计"]%>元
                </td>
            </tr>
        </table>
        <% 	  }
          }
          else
          {     %>
       <div id="noInfo">没有查询到信息</div> 
        <%  }
        %>
    </div>
   <%-- <div id="DivBottom">
        <input type="text" id="AllMoney" value="<%=allMoney %>" style="color: #FF0000"  ruant="server"/><asp:Button
            ID="Submit" runat="server" Text="缴费" onclick="Submit_Click" /></div>--%>
    </form>
</body>
</html>
