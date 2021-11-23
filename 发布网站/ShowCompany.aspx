<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCompany.aspx.cs" Inherits="SCJN.ShowCompany" %>
<html lang="zh-CN"><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>官网首页</title>
	
	
	<meta http-equiv="X-UA-Compatible" content="IE=Edge, chrome=1">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
	<meta name="format-detection" content="telephone=no">
	
	
	<link href="./CompanyShow_/normalize.css" rel="stylesheet">
	<link href="./CompanyShow_/bootstrap.min.css" rel="stylesheet">
	<link href="./CompanyShow_/font-awesome.min.css" rel="stylesheet">
	<link href="./CompanyShow_/function.css" rel="stylesheet">
	<link href="./CompanyShow_/base.css" rel="stylesheet">
	<link href="./CompanyShow_/main.css" rel="stylesheet">
	<link href="./CompanyShow_/form.css" rel="stylesheet">
	<link href="./CompanyShow_/list.css" rel="stylesheet">
	<link href="./CompanyShow_/article.css" rel="stylesheet">
	<link href="./CompanyShow_/mytooltip.css" rel="stylesheet">
	<link href="./CompanyShow_/comment.css" rel="stylesheet">
	
	<link href="./CompanyShow_/layui.css" rel="stylesheet" type="text/css" media="screen">

   		<link href="./CompanyShow_/sandbeach-oldPage.css" rel="stylesheet">
	
</head>
<body id="page-wgw" style=" background-color:White;">
<form id="form2" runat="server">
	<div class="container">
		<div class="slider-wrapper">
			<div class="main_visual">
				<div class="main_image" style="height: 316.35px;">
					<ul style="width: 1920px; overflow: visible;">
						
                            <li style="float: none; display: block; position: absolute; top: 0px; left: -1032.06px; width: 461px;">
								<span style="background-image: url(img/xwjj.jpg); height: 316.35px;"></span>
							</li>
							<li style="float: none; display: block; position: absolute; top: 0px; left: -571.064px; width: 461px;">
								<span style="background-image: url(img/ShowComany2.jpg); height: 316.35px;"></span>
							</li>
						
							<li style="float: none; display: block; position: absolute; top: 0px; left: -110.064px; width: 461px;">
								<span style="background-image: url(img/ShowComany3.jpg); height: 316.35px;"></span>
							</li>
						
							<li style="float: none; display: block; position: absolute; top: 0px; left: 350.936px; width: 461px;">
								<span style="background-image: url(img/xwjj.jpg); height: 316.35px;"></span>
							</li>
					</ul>
					<a href="javascript:;" id="btn_prev" style="width: 1920px; overflow: visible; display: none;"></a>
					<a href="javascript:;" id="btn_next" style="width: 1920px; overflow: visible; display: none;"></a>
				</div>
			</div>
		</div>
		<div class="main-menu-wrapper">
			<table class="main-menu">
				<tbody>
					<tr>
                    <td class="menu-cell" id="7c8304d5-f655-11e5-8792-00163e0c01cf">
							<a href="log.aspx">
                             <asp:ImageButton ID="ImageButton2" runat="server" class="menu-icons" 
                                src="./CompanyShow_/icon2.png" alt="" onclick="ImageButton2_Click" />
                            </a>
						<a href="log.aspx">	<label>公司简介</label></a>
						</td>
                    
                        
						<td class="menu-cell" id="7c5e091a-f655-11e5-8792-00163e0c01cf">
							<a href="zzjg.aspx">
                                    <asp:ImageButton ID="ImageButton1" runat="server"  class="menu-icons" 
                                src="./CompanyShow_/icon3.png" alt="" onclick="ImageButton1_Click" />      
                            </a>
							<a href="zzjg.aspx"><label>组织机构</label></a>
						</td>
						<td class="menu-cell" id="7c9e119b-f655-11e5-8792-00163e0c01cf">
							<a href="ShutdownPoint.aspx">               
                                    <asp:ImageButton ID="ImageButton5" runat="server" class="menu-icons" 
                                src="./CompanyShow_/icon9.png" alt="" onclick="ImageButton5_Click" />
                            </a>
						<a href="ShutdownPoint.aspx">	<label>营业网点</label></a>
						</td>	
					</tr>
				</tbody>
			</table>
		</div>
	</div>
<footer>
	<div class="copyright" id="footerContent">
		<a id="footBaselogoUrl">
			<%--<img class="f-cb" src="img/log.png" id="footBaseImg" style="width: 90px;height: 27px;">--%>
		</a>
	</div>
<script src="./CompanyShow_/jquery.min.js"></script>
<script type="text/javascript">

var token ='03dde854475342b8940a505e4ea5c7fb';

$.ajax({
	url: '/zsy_mobile/m/findMpByTokenJson.do',
	dataType:'json',
	async:false,
	data:{
		'token':token
	},
    type: 'get',   //����ʽ
    contentType: 'application/x-www-form-urlencoded; charset=utf-8',
    beforeSend: function() {
        //����ǰ�Ĵ���
    },
    success: function(msg) {
        if(msg.customizationLogoStatus==0){
        	$('#footerContent').show();
        	if(msg.customizationLogoUrl!=null && msg.customizationLogoUrl.length > 0){
	        	$('#footBaselogoUrl').attr("href",msg.customizationLogoUrl);
        	}else{
        		$('#footBaselogoUrl').removeAttr("href","http://nhgs.wisewater.cn/zsy_mobile/m/zsy/about-zsy.html");
        	}
        	$('#footBaseImg').attr("src","http://zsybackend.wisewater.cn:8082/zsy_backend/resources/attached/03dde854475342b8940a505e4ea5c7fb/"+msg.customizationLogoImg);
        }else if(msg.customizationLogoStatus==1){
        	$('#footBaselogoUrl').attr("href","http://nhgs.wisewater.cn/zsy_mobile/m/zsy/about-zsy.html");
        	$('#footBaseImg').attr("src","/zsy_mobile/resources/img/zsy-logo.png");
        }else if(msg.customizationLogoStatus==2){
        	$('#footerContent').hide();
        }else{
        	$('#footerContent').show();
        	$('#footBaselogoUrl').attr("href","http://nhgs.wisewater.cn/zsy_mobile/m/zsy/about-zsy.html");
        	$('#footBaseImg').attr("src","/zsy_mobile/resources/img/zsy-logo.png");
        }
	</script> 
</footer>

	<script src="./CompanyShow_/jquery.min.js"></script>
<script src="./CompanyShow_/parsley.min.js"></script>
<script src="./CompanyShow_/jquery.mytooltip.js"></script>
<script src="./CompanyShow_/layui.js"></script>
	<script src="./CompanyShow_/jquery.event.drag.js"></script>
	<script src="./CompanyShow_/jquery.touchslider.js"></script>
	<script>
	    $(document).ready(function () {
	        /* �����ֲ� */
	        $('.main_visual').hover(function () {
	            $('#btn_prev, #btn_next').fadeIn();
	        }, function () {
	            $('#btn_prev, #btn_next').fadeOut();
	        });

	        $dragBln = false;

	        $('.main_image').touchSlider({
	            flexible: true,
	            speed: 200,
	            btn_prev: $('#btn_prev'),
	            btn_next: $('#btn_next')
	        });

	        $('.main_image').on('mousedown', function () {
	            $dragBln = false;
	        });

	        $('.main_image').on('dragstart', function () {
	            $dragBln = true;
	        });

	        $('.main_image a').click(function () {
	            if ($dragBln) {
	                return false;
	            }
	        });

	        timer = setInterval(function () {
	            $('#btn_next').click();
	        }, 3000);

	        $('.main_visual').hover(function () {
	            clearInterval(timer);
	        }, function () {
	            timer = setInterval(function () {
	                $('#btn_next').click();
	            }, 3000);
	        });

	        $('.main_image').on('touchstart', function () {
	            clearInterval(timer);
	        }).on('touchend', function () {
	            timer = setInterval(function () {
	                $('#btn_next').click();
	            }, 3000);
	        });

	        var wInnerH = window.innerHeight; // �豸����߶�
	        $('.slider-wrapper .main_image, .slider-wrapper .main_image li span').css({
	            'height': wInnerH * 0.333 + 'px'
	        });
	    });


	    /* ��ʾ΢����ģ������ */
	    $('.main-menu').on('click', '.menu-cell', function () {
	        var id = $(this).attr('id');
	        window.location.href = '/zsy_mobile/m/cmsView.do?token=03dde854475342b8940a505e4ea5c7fb&id=' + id;
	    });
		
	</script>

</form>
</body></html>