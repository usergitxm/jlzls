!(function(e) {
	var t = {
		id: "95ac7ac0c58a5c41c705a58e3f5ded60",
		filename: "serverHost.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		window.$serverHost = {
			ip: "",
			companyid: ""
		};
		!$serverHost.ip && ($serverHost.ip = "ws://121.42.160.128:8102");
		!$serverHost.companyid && ($serverHost.companyid = "a39c5ab2f69a445c9862eba7d02ea028")
	}(t.exports, t, e);
	e.____MODULES["95ac7ac0c58a5c41c705a58e3f5ded60"] = t.exports
})(this);
var KEY="todo";
var Store={
    save:function(items){
       return window.sessionStorage.setItem(KEY,JSON.stringify(items));
    },
    fetch:function(){
       return JSON.parse(window.sessionStorage.getItem(KEY)||'[]');
    }
};
var Through = (function() {
	var elems = [],
		eName, parent;

	function init(eventName, parentNode) {
		eName = eventName;
		parent = parentNode;
		bindEvents(eName, callback)
	}

	function bindEvents(eventName, callback) {
		var node = parent || document.body;
		if (document.addEventListener) {
			node.addEventListener(eventName, callback, false);
		} else if (document.attachEvent) {
			node.attachEvent("on" + eventName.callback);
		}
	}

	function recurFind(x, y) {
		var ele = document.elementFromPoint(x, y),
			nodeName = ele.tagName.toLowerCase();
		if (nodeName === 'body' || nodeName === 'html') {
			return;
		}
		elems.push(ele);
		ele.style.display = 'none';
		if (document.elementFromPoint(x, y).tagName.toLowerCase != 'body' && ele.tagName.toLowerCase !== 'html') {
			recurFind(x, y)
		}
	}

	function callback() {
		var x = event.clientX,
			y = event.clientY,
			elems = [];
		recurFind(x, y);
		elems.map(function(node) {
			node.style.display = 'block';
		});
		elems.map(function(node, i) {
			if (i === 0) return;
			node[eName]();
		});
	}
	return {
		init: init
	}
})();

(function(e) {
	var t = {
		id: "adfa223e3b3c91013ec7b435c28d4f91",
		filename: "cashierObj.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var SwitchTool = {
			confirm: function(e, t, n, r, i) {
				var s = this._buildConfirm(e, t, n, r);
				s.show();
				var o = s.find(".info");
				o.animate({
					opacity: 1
				});
				o.on("click", ".btn", function(e) {
					if (e.target.className == "okBtn") {
						i && i()
					}
					s.hide()
					o.unbind("click")
				});
				this._disableDocumentMove()
			},
			_buildConfirm: function(e, t, n, r) {
				var i = '<div class="qn_alert qn_confirm">                            <div class="mask"></div>                            <div class="info">                                <div class="qn_close"><i></i> <i></i></div>                                <div class="title"></div>                                <div class="content"></div>                                <div class="btn"><a class="okBtn" href="javascript:void(0)"></a><a class="cancelBtn" style="color:gray" href="javascript:void(0)"></a></div>                            </div>                        </div>';
				var s = $(".qn_confirm");
				if (s.length <= 0) {
					s = $(i);
					$(".zhbd").append(s)
				}
				var o = s.find(".info");
				o.find(".title").text(e);
				o.find(".content").html(t);
				o.find(".btn .okBtn").text(n);
				o.find(".btn .cancelBtn").text(r);
				return s
			},
			_hideConfirmForm: function(e) {
				var t = e.find(".info");
				t.animate({
					opacity: 0
				}, 500, "ease-in-out", function() {
					e.hide()
				});
				this._enableDocumentMove()
			},
			alert: function(e, t, n, r) {
				var i = this._buildAlert(e, t, n);
				i.show();
				var s = i.find(".info");
				s.animate({
					opacity: 1
				});
				var o = this;
				s.on("click", ".btn", function() {
					r && r();
					i.hide();
					s.unbind("click")
				});
				this._disableDocumentMove()
			},
			_buildAlert: function(e, t, n) {
				var r = '<div class="qn_alert qn_alert_base">                            <div class="mask"></div>                            <div class="info">                                <div class="qn_close"><i></i> <i></i></div>                                <div class="title"></div>                                <div class="content"></div>                                <div class="btn"><a href="javascript:void(0)"></a></div>                            </div>                        </div>';
				var i = $(".qn_alert_base");
				if (i.length <= 0) {
					i = $(r);
					$(".zhbd").append(i)
				}
				var s = i.find(".info");
				s.find(".title").text(e);
				s.find(".content").html(t);
				s.find(".btn a").text(n);
				return i
			},
			_hideAlertForm: function(e) {
				var t = e.find(".info");
				console.log(t);
				t.animate({
					opacity: 0
				}, 500, "ease-in-out", function() {
					e.hide()
				});
				t.hide()
				this._enableDocumentMove()
			},
			_enableDocumentMove: function() {
				document.ontouchmove = null
			},
			_disableDocumentMove: function() {
				document.ontouchmove = function(e) {
					e.preventDefault()
				}
			},
			mask: {
				show: function() {
					$(".qn_mask .mask").height($("body").scrollTop() + $(window).height());
					$(".qn_mask .info").css("top", $("body").scrollTop() + $(window).height() / 2);
					$(".qn_mask").show().on("touchmove", function(e) {
						e.preventDefault()
					})
				},
				hide: function() {
					$(".qn_mask").hide()
				}
			}
		};
		n.exports = SwitchTool
	}(t.exports, t, e);
	e.____MODULES["adfa223e3b3c91013ec7b435c28d4f91"] = t.exports
})(this);
var markEvent={
	readyEvent:function(fn){
       if(fn==null){
       	   fn=document;
       }
       var oldonload=window.oldonload;
       if(typeof window.onload!='function'){
       	  window.onload=fn;
       }else{
       	  window.onload=function(){
       	  	 oldonload();
       	  	 fn();
       	  }
       }
	},
	addEvent:function(element,type,handler){
         if(element.addEventListener){
         	 element.addEventListener(type,handler,false);
         }else if(element.attachEvent){
              element.attachEvent('on'+type,function(){
              	  handler.call(element);
              });
         }else{
               element['on'+type]=handler;
         }
	},
	removeEvent:function(element,type,handler){
		if(element.removeEventListener){
			element.removeEventListener(type,handler,false);
		}else if(element.datachEvent){
			element.datachEvent('on'+type,handler);
		}else{
			element['on'+type]=null;
		}
	},
	stopPropagation:function(event){
		if(event.stopPropagation){
			event.stopPropagation();
		}else{
			event.cancelBubble=true;
		}
	},
	preventDefault:function(event){
        if(event.preventDefault){
        	event.preventDefault();
        }else{
        	event.returnValue=false;
        }
	},
	getTarget:function(event){
		return event.target||event.srcElement;
	},
	getEvent:function(e){
        var ev=e||window.event;
        if(!ev){
        	var c=this.getEvent.caller;
        	while(c){
        		ev=c.arguments[0];
        		if(ev && Event==ev.constructor){
        			break;
        		}
        		c=c.caller;
        	}
        }
        return ev;
	}
}
var util = (function() {
	function isValidVal(value) {
		return typeof value == 'undefined' || value == null ? false : true;
	}
	function tab() {
		$('.zhbd_nav ul li').bind('click', function() {
			$(this).addClass('zhbd_nav_select');
			$(this).siblings().removeClass('zhbd_nav_select');
			$('.zbdd_d1').hide();
			$('.zbdd_d1').eq($(this).index()).show();
		});
	}
	function telRelpace(str, obj) {
		var newStr = str.replace(/{{[\w\.]*}}/g, function(str, key) {
			var keys = key.split('.'),
				value = obj[keys.shift()];
			if (!isValidVal(value)) {
				return "";
			}
			for (var i = 0, max = keys.length; i < max; i++) {
				value = value[keys[i]];
				if (!isValidVal(value)) {
					return "";
				}
			}
			return value.toString();
		});
		return newStr;
	}
	function is_Object(e) {
		var obj = Object.create($CONFIG);
		if (Object.getPrototypeOf(obj) === $CONFIG && obj.__proto__ === Object.getPrototypeOf(obj)) {
			return $CONFIG instanceof Object == true && $CONFIG.openid != "" && $CONFIG.openid != "undefined" && $CONFIG.openid != null ? e.a() : e.b();
		}
	}
	function $import(path, type, title) {
		var s, i;
		if (!type) type = path.substr(path.lastIndexOf(".") + 1);
		if (type == "js") {
			var ss = document.getElementsByTagName("script");
			for (i = 0; i < ss.length; i++) {
				if (ss[i].src && ss[i].src.indexOf(path) != -1 || ss[i].title == title) return ss[i];
			}
			s = document.createElement("script");
			s.type = "text/javascript";
			s.src = convertURL(path);
			if (title) s.title = title;
		}
		var head = document.getElementsByTagName("head")[0];
		head.appendChild(s);
		return s;
	}

	function convertURL(url) {
		var timestamp = Date.parse(new Date());
		if (url.indexOf("?") >= 0) {
			url = url + "&version=" + timestamp;
		} else {
			url = url + "?version=" + timestamp;
		}
		return url;
	}

	function _isNull(n, fn) {
		if (n != "undefined" && n != '' && n != null) {
			return fn();
		} else {
			return false;
		}
	}

	function _isCache(obj, n) {
		n = sessionStorage.getItem('openid');
		return obj instanceof Object == true && n != "undefined" && n != "" && n != null
	}

	function _checkData(e) {
		return e instanceof Array == true && e.length > 0;
	}

	function _templete(eve, tplid, id) {
		var data = {
				list: eve
			},
			html = template(tplid, data);
		return document.getElementById(id).innerHTML = html;
	}
	function tp(event,el,obj){
		if(event instanceof Array == true && event.length > 0){
		    document.getElementById(el).innerHTML=obj;
		    console.log(obj);
		}
	}
	function tp_v1(event,el,obj){
		document.getElementById(el).innerHTML=obj;
	}

	function _$(id) {
		return domReady(function() {
			document.getElementById(id);
		})
	}

	function _alert(a, b) {
		layer.alert(a, {
			icon: 0
		}, function(index) {
			domReady(function() {
				document.getElementById(b).focus();
			});
			layer.close(index);
		})
	}

	function GetQueryString(name) {
		var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
		var r = window.location.search.substr(1).match(reg);
		if (r != null) return (r[2]);
		return null;
	}

	function _show() {
		return domReady(function() {
			document.getElementById('loading').style.display = 'block';
		})
	}

	function _hide() {
		return domReady(function() {
			document.getElementById('loading').style.display = 'none';
		})
	}

	function domReady(fn) {
		if (document.addEventListener) {
			document.addEventListener('DOMContentLoaded', fn, false)
		} else {
			IEContentLoaded(fn);
		}

		function IEContentLoaded(fn) {
			var done = false;
			var d = window.document;
			var init = function() {
				if (!none) {
					done = true;
					fn();
				}
			};
			(function() {
				try {
					d.documentElement.doScroll('left');
				} catch (e) {
					setTimeout(arguments.callee(), 50);
					return;
				}
			}());
			d.onreadystatechange = function() {
				if (d.readyState == 'complete') {
					d.onreadystatechange = null;
					init();
				}
			}
		}
	}

	function _empty(e) {
		if ($(e).is_empty) {
			return $(e).is_empty()
		} else {
			return $.trim($(e).val()) == ""
		}
	}

	function DATE(e) {
		var t = /^([12]\d{3})(\d{2})(\d{2})$/,
			n = t.exec(e);
		if (!n) {
			return false
		}
		var r = n[1] | 0,
			i = n[2] | 0,
			s = n[3] | 0;
		if (i > 12 || i < 1 || s < 1 || s > 31) {
			return false
		}
		return (new Date(r, i - 1, s)).getDate() === s
	}

	function parseParams(e) {
		e = e || window.location.search;
		var t = /([^?=&]+)=([^?=&]+)/g,
			n = null,
			r = {};
		while ((n = t.exec(e)) != null) {
			r[n[1]] = n[2]
		}
		return r
	}

	function parseDate(e) {
		var t = e.match(/\d+/g).map(function(e, t) {
			return parseInt(e, 10)
		});
		return new Date(t[0], t[1] - 1, t[2]);
	}

	function GetQueryObject(e) {
		var t = {};
		var n = /([^?&=]+)=([^?&=]+)/g,
			e = e || window.location.href,
			r = null;
		while (r = n.exec(e)) {
			t[r[1]] = r[2]
		}
		return t
	};
	function code(fn){
		setTimeout(function(){
			    return fn;
		},500);
	}

	function closeWindows() {
		var browserName = navigator.appName;
		var browerVer = parseInt(navigator.appVersion);
		if(browserName == "Microsoft Internet Explorer") {
			var ie7 = (document.all && !window.opera && window.XMLHttpRequest) ? true : false;
			if (ie7) {
				window.open('', '_parent', '');
				window.close();
			} else {
				this.focus();
				self.opener = this;
				self.close();
			}
		} else {
			try {
				this.focus();
				self.opener = this;
				self.close();
			} catch (e) {}
			try {
				window.open('', '_self', '');
				window.close();
			} catch (e) {

			}
		}
	};
	return {
		domReady: domReady,
		_show: _show,
		_hide: _hide,
		isValidVal: isValidVal,
		$import: $import,
		convertURL: convertURL,
		_isNull: _isNull,
		_isCache: _isCache,
		_checkData: _checkData,
		_$: _$,
		_alert: _alert,
		GetQueryString: GetQueryString,
		_empty: _empty,
		DATE: DATE,
		parseParams: parseParams,
		parseDate: parseDate,
		GetQueryObject: GetQueryObject,
		_templete: _templete,
		is_Object: is_Object,
		tab: tab,
		tp:tp,
		code:code,
		tp_v1:tp_v1
	}
})();
util.tab();
(function(e) {
	var t = {
		id: "b74d01a7cd1f6e55582e21bbb149bbgh",
		filename: "pro.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var protot = {};
		protot.getpro = function(separator) {
			var obj = new Object();
			obj.result = [];
			for (var i = 0; i < arguments.length; i++) {
				obj.result.push(arguments[i])
			}
			obj.agr_900002 = '{"code":"' + obj.result[0] + '","companyid":"' + $serverHost.companyid + '","servCode":"900002"}';
			obj.agr_900001 = '{"openid":"' + obj.result[0] + '","companyid":"' + $serverHost.companyid + '","servCode":"900001"}';
			obj.agr_200004 = '{"ciid":"' + obj.result[0] + '","ciname":"' + obj.result[1] + '","companyid":"' + $serverHost.companyid + '","openid":"' + obj.result[2] + '","servCode":"200004"}';
			obj.agr_900003 = '{"uid":"' + obj.result[0] + '","companyid":"' + $serverHost.companyid + '","openid":"' + obj.result[1] + '","servCode":"900003"}';
			obj.agr_900004 = '{"url":"' + obj.result[0] + '","companyid":"' + $serverHost.companyid + '","servCode":"900004"}',
			obj.agr_200005 = '{"openid":"' + obj.result[0] + '","companyid":"' + $serverHost.companyid + '","ciid":"' + obj.result[1] + '","servCode":"200005"}';
			obj.agr_200039 = '{"openid":"' + obj.result[0] + '","companyid":"' + $serverHost.companyid + '","ciid":"' + obj.result[1] + '","servCode":"200039"}';
			obj.agr_500012 = '{"companyid":"' + $serverHost.companyid + '","servCode":"500012"}';
			obj.agr_5000120 = '{"companyid":"' + $serverHost.companyid + '","latitude":"' + obj.result[0] + '","longitude":"' + obj.result[1] + '","speed":"' + obj.result[2] + '","accuracy":"' + obj.result[3] + '","servCode":"5000120"}';
			obj.agr_500003 = '{"type":"' + obj.result[0] + '","address":"' + obj.result[1] + '","serverId":"' + obj.result[2] + '","content":"' + obj.result[3] + '","phone":"' + obj.result[4] + '","companyid":"' + $serverHost.companyid + '","openid":"' + obj.result[5] + '","servCode":"500015","cxbh":"' + obj.result[6] + '"}';
			obj.agr_500004 = '{"uid":"' + obj.result[0] + '","companyid":"' + $serverHost.companyid + '","openid":"' + obj.result[1] + '","servCode":"500004"}';
			obj.agr_500013 = '{"companyid":"' + $serverHost.companyid + '","servCode":"500013"}';
			obj.agr_5000130 = '{"uid":"' + obj.result[0] + '","companyid":"' + $serverHost.companyid + '","servCode":"5000130"}';
			obj.agr_5000140 = '{"uid":"' + obj.result[0] + '","type":"' + obj.result[1] + '","companyid":"' + $serverHost.companyid + '","servCode":"5000140"}';
			obj.agr_500014 = '{"companyid":"' + $serverHost.companyid + '","type":"' + obj.result[0] + '","servCode":"500014"}';
			return obj
		};
		n.exports = protot;
	}(t.exports, t, e);
	e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbgh"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "b74d01a7cd1f6e55582e21bbb149bbec",
		filename: "WX.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		(function(e) {
			var t = {};
			!e.WX && (e.WX = {});
			WX.IE = /msie/i.test(navigator.userAgent);
			WX.IE6 = /msie 6/i.test(navigator.userAgent);
			WX.page = {
				add: function(e) {
					!t.pageLoadFunc && (t.pageLoadFunc = []);
					$.isFunction(e) && t.pageLoadFunc.push(e)
				}
			};
			var n = {
				load: function(e) {
					$(t.pageLoadFunc).each(function(e, t) {
						t.call(null, WX)
					})
				},
				unload: function(e) {
					var n;
					var r = window["____MODULES"] || [];
					for (var i in r) {
						n = r[i];
						try {
							n.destroy && n.destroy.call(n)
						} catch (e) {}
					}
					n = null;
					t.pageLoadFunc = null;
					t = null
				}
			};
			$(document).ready(n.load);
			$(window).unload(n.unload);
			return WX
		})(window)
	}(t.exports, t, e);
	e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbec"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "dd622e58c9a123bbf70a159c8b3b0f10",
		filename: "template.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		! function() {
			function n(e) {
				return e.replace(E, "").replace(S, ",").replace(x, "").replace(T, "").replace(N, "").split(C)
			}

			function r(e) {
				return "'" + e.replace(/('|\\)/g, "\\$1").replace(/\r/g, "\\r").replace(/\n/g, "\\n") + "'"
			}

			function i(e, t) {
				function i(e) {
					return h += e.split(/\n/).length - 1, l && (e = e.replace(/\s+/g, " ").replace(/<!--[\w\W]*?-->/g, "")), e && (e = g[1] + r(e) + g[2] + "\n"), e
				}

				function s(e) {
					var r = h;
					if (f ? e = f(e, t) : o && (e = e.replace(/\n/g, function() {
							return h++, "$line=" + h + ";"
						})), 0 === e.indexOf("=")) {
						var i = c && !/^=[=#]/.test(e);
						if (e = e.replace(/^=[=#]?|[\s;]*$/g, ""), i) {
							var s = e.replace(/\s*\([^\)]+\)/, "");
							v[s] || /^(include|print)$/.test(s) || (e = "$escape(" + e + ")")
						} else e = "$string(" + e + ")";
						e = g[1] + e + g[2]
					}
					return o && (e = "$line=" + r + ";" + e), b(n(e), function(e) {
						if (e && !p[e]) {
							var t;
							t = "print" === e ? w : "include" === e ? E : v[e] ? "$utils." + e : m[e] ? "$helpers." + e : "$data." + e, S += e + "=" + t + ",", p[e] = !0
						}
					}), e + "\n"
				}
				var o = t.debug,
					u = t.openTag,
					a = t.closeTag,
					f = t.parser,
					l = t.compress,
					c = t.escape,
					h = 1,
					p = {
						$data: 1,
						$filename: 1,
						$utils: 1,
						$helpers: 1,
						$out: 1,
						$line: 1
					},
					d = "".trim,
					g = d ? ["$out='';", "$out+=", ";", "$out"] : ["$out=[];", "$out.push(", ");", "$out.join('')"],
					y = d ? "$out+=text;return $out;" : "$out.push(text);",
					w = "function(){var text=''.concat.apply('',arguments);" + y + "}",
					E = "function(filename,data){data=data||$data;var text=$utils.$include(filename,data,$filename);" + y + "}",
					S = "'use strict';var $utils=this,$helpers=$utils.$helpers," + (o ? "$line=0," : ""),
					x = g[0],
					T = "return new String(" + g[3] + ");";
				b(e.split(u), function(e) {
					e = e.split(a);
					var t = e[0],
						n = e[1];
					1 === e.length ? x += i(t) : (x += s(t), n && (x += i(n)))
				});
				var N = S + x + T;
				o && (N = "try{" + N + "}catch(e){throw {filename:$filename,name:'Render Error',message:e.message,line:$line,source:" + r(e) + ".split(/\\n/)[$line-1].replace(/^\\s+/,'')};}");
				try {
					var C = new Function("$data", "$filename", N);
					return C.prototype = v, C
				} catch (k) {
					throw k.temp = "function anonymous($data,$filename) {" + N + "}", k
				}
			}
			var s = function(e, t) {
				return "string" == typeof t ? y(t, {
					filename: e
				}) : a(e, t)
			};
			s.version = "3.0.0", s.config = function(e, t) {
				o[e] = t
			};
			var o = s.defaults = {
					openTag: "<%",
					closeTag: "%>",
					escape: !0,
					cache: !0,
					compress: !1,
					parser: null
				},
				u = s.cache = {};
			s.render = function(e, t) {
				return y(e, t)
			};
			var a = s.renderFile = function(e, t) {
				var n = s.get(e) || g({
					filename: e,
					name: "Render Error",
					message: "Template not found"
				});
				return t ? n(t) : n
			};
			s.get = function(e) {
				var t;
				if (u[e]) t = u[e];
				else if ("object" == typeof document) {
					var n = document.getElementById(e);
					if (n) {
						var r = (n.value || n.innerHTML).replace(/^\s*|\s*$/g, "");
						t = y(r, {
							filename: e
						})
					}
				}
				return t
			};
			var f = function(e, t) {
					return "string" != typeof e && (t = typeof e, "number" === t ? e += "" : e = "function" === t ? f(e.call(e)) : ""), e
				},
				l = {
					"<": "&#60;",
					">": "&#62;",
					'"': "&#34;",
					"'": "&#39;",
					"&": "&#38;"
				},
				c = function(e) {
					return l[e]
				},
				h = function(e) {
					return f(e).replace(/&(?![\w#]+;)|[<>"']/g, c)
				},
				p = Array.isArray || function(e) {
					return "[object Array]" === {}.toString.call(e)
				},
				d = function(e, t) {
					var n, r;
					if (p(e))
						for (n = 0, r = e.length; r > n; n++) t.call(e, e[n], n, e);
					else
						for (n in e) t.call(e, e[n], n)
				},
				v = s.utils = {
					$helpers: {},
					$include: a,
					$string: f,
					$escape: h,
					$each: d
				};
			s.helper = function(e, t) {
				m[e] = t
			};
			var m = s.helpers = v.$helpers;
			s.onerror = function(e) {
				var t = "Template Error\n\n";
				for (var n in e) t += "<" + n + ">\n" + e[n] + "\n\n";
				"object" == typeof console && console.error(t)
			};
			var g = function(e) {
					return s.onerror(e),
						function() {
							return "{Template Error}"
						}
				},
				y = s.compile = function(e, t) {
					function n(n) {
						try {
							return new a(n, s) + ""
						} catch (r) {
							return t.debug ? g(r)() : (t.debug = !0, y(e, t)(n))
						}
					}
					t = t || {};
					for (var r in o) void 0 === t[r] && (t[r] = o[r]);
					var s = t.filename;
					try {
						var a = i(e, t)
					} catch (f) {
						return f.filename = s || "anonymous", f.name = "Syntax Error", g(f)
					}
					return n.prototype = a.prototype, n.toString = function() {
						return a.toString()
					}, s && t.cache && (u[s] = n), n
				},
				b = v.$each,
				w = "break,case,catch,continue,debugger,default,delete,do,else,false,finally,for,function,if,in,instanceof,new,null,return,switch,this,throw,true,try,typeof,var,void,while,with,abstract,boolean,byte,char,class,const,double,enum,export,extends,final,float,goto,implements,import,int,interface,long,native,package,private,protected,public,short,static,super,synchronized,throws,transient,volatile,arguments,let,yield,undefined",
				E = /\/\*[\w\W]*?\*\/|\/\/[^\n]*\n|\/\/[^\n]*$|"(?:[^"\\]|\\[\w\W])*"|'(?:[^'\\]|\\[\w\W])*'|\s*\.\s*[$\w\.]+/g,
				S = /[^\w$]+/g,
				x = new RegExp(["\\b" + w.replace(/,/g, "\\b|\\b") + "\\b"].join("|"), "g"),
				T = /^\d[^,]*|,\d[^,]*/g,
				N = /^,+|,+$/g,
				C = /^$|,+/;
			o.openTag = "{{", o.closeTag = "}}";
			var k = function(e, t) {
				var n = t.split(":"),
					r = n.shift(),
					i = n.join(":") || "";
				return i && (i = ", " + i), "$helpers." + r + "(" + e + i + ")"
			};
			o.parser = function(e) {
				e = e.replace(/^\s/, "");
				var t = e.split(" "),
					n = t.shift(),
					r = t.join(" ");
				switch (n) {
					case "if":
						e = "if(" + r + "){";
						break;
					case "else":
						t = "if" === t.shift() ? " if(" + t.join(" ") + ")" : "", e = "}else" + t + "{";
						break;
					case "/if":
						e = "}";
						break;
					case "each":
						var i = t[0] || "$data",
							o = t[1] || "as",
							u = t[2] || "$value",
							a = t[3] || "$index",
							f = u + "," + a;
						"as" !== o && (i = "[]"), e = "$each(" + i + ",function(" + f + "){";
						break;
					case "/each":
						e = "});";
						break;
					case "echo":
						e = "print(" + r + ");";
						break;
					case "print":
					case "include":
						e = n + "(" + t.join(",") + ");";
						break;
					default:
						if (/^\s*\|\s*[\w\$]/.test(r)) {
							var l = !0;
							0 === e.indexOf("#") && (e = e.substr(1), l = !1);
							for (var c = 0, h = e.split("|"), p = h.length, d = h[c++]; p > c; c++) d = k(d, h[c]);
							e = (l ? "=" : "=#") + d
						} else e = s.helpers[n] ? "=#" + n + "(" + t.join(",") + ");" : "=" + e
				}
				return e
			}, "function" == typeof define ? define(function() {
				return s
			}) : "undefined" != typeof e ? t.exports = s : this.template = s
		}()
	}(t.exports, t, e);
	e.____MODULES["dd622e58c9a123bbf70a159c8b3b0f10"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "0037d5e33d391dca5f2949ee2705d6b0",
		filename: "template.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var i = e.____MODULES["dd622e58c9a123bbf70a159c8b3b0f10"];
		n.exports = window.WX.template = function(e) {
			return i.compile(e || "")
		}
	}(t.exports, t, e);
	e.____MODULES["0037d5e33d391dca5f2949ee2705d6b0"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "6db902d07fab1711c8fbb4610d74bd8a",
		filename: "buildDom.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = function(e) {
			var t = $("[node-type]", e);
			var n, r = {};
			var i;
			t.each(function(e, t) {
				n = t.getAttribute("node-type");
				if (!r[n]) {
					r[n] = t
				} else if ($.isArray(r[n])) {
					r[n].push(t)
				} else {
					r[n] = [r[n]];
					r[n].push(t)
				}
			});
			r["parentNode"] = e;
			return r
		}
	}(t.exports, t, e);
	e.____MODULES["6db902d07fab1711c8fbb4610d74bd8a"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "19b40508fb74aa89c2d7ac3e36a4a1cd",
		filename: 'storage.js',
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = function() {
			var e = window.sessionStorage;
			if (e) {
				return {
					get: function(t) {
						t = escape(t);
						var n = e.getItem(t);
						n ? n = unescape(n) : null;
						try {
							n = JSON.parse(n)
						} catch (r) {}
						if (n == "null") {
							return ""
						}
						return n
					},
					set: function(t, n, r) {
						t = escape(t);
						e.setItem(t, escape(JSON.stringify(n)));
					},
					del: function(t) {
						t = escape(t);
						e.removeItem(t)
					},
					clear: function() {
						e.clear()
					},
					getAll: function() {
						var t = e.length,
							n = null,
							r = [];
						for (var i = 0; i < t; i++) {
							n = e.key(i),
								r.push(unescape(n) + "=" + this.getKey(n))
						}
						return r.join("; ")
					}
				}
			} else if (window.ActiveXObject) {
				store = document.documentElement;
				STORE_NAME = "sessionStorage";
				try {
					store.addBehavior("#default#userdata");
					store.save("sessionStorage")
				} catch (t) {}
				return {
					set: function(e, t) {
						store.setAttribute(e, t);
						store.save(STORE_NAME)
					},
					get: function(e) {
						store.load(STORE_NAME);
						return store.getAttribute(e)
					},
					del: function(e) {
						store.removeAttribute(e);
						store.save(STORE_NAME)
					}
				}
			}
		}()
	}(t.exports, t, e);
	e.____MODULES["19b40508fb74aa89c2d7ac3e36a4a1cd"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "6e603fa71c85f508c7a67a11f2d20ea6",
		filename: "store.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		function l() {}
		var r = {
			concatSign: "_"
		}
		var i = window.sessionStorage,
			s = true;
		if (i) {
			try {
				var o = "wx_test";
				i.setItem(o, "1");
				i.removeItem(o);
			} catch (u) {
				i = null
			}
		}
		if (!i) {
			s = false;
			i = {
				_store: {},
				setItem: function(e, t) {
					i._store[e] = t;
				},
				getItem: function(e) {
					return i._store[e]
				},
				removeItem: function(e) {
					delete i._store(e)
				},
				clear: function() {
					i._store()
				}
			}
		}
		var a = function(e) {
			this.name = e
		}
		a.prototype.setItem = function(e, t) {
			t.encodeURIComponent(JSON.stringify(t));
			i.setItem(this.name + r.concatSign + e, t)
		}
		a.prototype.getItem = function(e) {
			var t = i.getItem(this.name + r.concatSign + e)
			try {
				t = JSON.parse(decodeURIComponent(t));
			} catch (n) {}
			return t
		}
		a.prototype.removeItem = function(e) {
			i.removeItem(this.name + r.concatSign + e)
		}
		a.prototype.clear = function() {
			var e = this.name + r.concatSign;
			if (!s) {
				var t = i._store;
				for (var n in t) {
					if (t.hasOwnProperty(n)) {
						if (n.indexOf(e) == 0) {
							delete t[n]
						}
					}
				}
			} else {
				for (var n = i.length; n >= 0; n--) {
					var o = i.key(n);
					if (o && o.indexOf(e) == 0) {
						i.removeItem(o);
					}
				}
			}
		}
		a.clear = function() {
			i.clear();
		}
		var f = {
			CLASS: a
		}
		l.prototype.createInstance = function(e) {
			if (!f[e]) {
				f[e] = new a(e);
			}
			return f[e];
		}
		
		var c = new l;
		t.exports = c;
	}(t.exports, t, e);
	e.____MODULES["6e603fa71c85f508c7a67a11f2d20ea6"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "66693d8fcc23da1741c4bde8ee79b109",
		filename: "parseParam.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = function(e, t, n) {
			var r, i = {};
			t = t || {};
			for (r in e) {
				i[r] = e[r];
				if (t[r] != null) {
					if (n) {
						if (e.hasOwnProperty[r]) {
							i[r] = t[r];
						}
					} else {
						i[r] = t[r]
					}
				}
			}
			return i
		}
	}(t.exports, t, e)
	e.____MODULES["66693d8fcc23da1741c4bde8ee79b109"] = t.exports;
});
(function(e) {
	var t = {
		id: "1d74141e4dbe52ce44af47c4e9fe3203",
		filename: "bfCache.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		var r = function(e, t) {
			$(window).bind("pageshow", function(n) {
				if (n.persisted) {
					if (typeof e == "function") {
						e(n)
					}
				} else {
					if (typeof t == "function") {
						t(n)
					}
				}
			})
		};
		var i = function() {
			r(function() {
				window.location.reload()
			})
		};
		t.exports = {
			bindBFCache: function(e, t) {
				r(e, t)
			},
			reloadForbfCache: i
		}
	}(t.exports, t, e);
	e.____MODULES["1d74141e4dbe52ce44af47c4e9fe3203"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "5913ba6d6114d928040c1f1531dfcd6e",
		filename: "eventUtil.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = {
			addEvent: function(e, t, n, r) {
				if (e.attachEvent) {
					e.attachEvent("on" + t, n)
				} else if (e.addEventListener) {
					e.addEventListener(t, n, r || false)
				} else {
					e["on" + t] = n
				}
			},
			removeEvent: function(e, t, n, r) {
				if (e.removeEventListener) {
					e.removeEventListener(t, n, r)
				} else if (e.detachEvent) {
					e.detachEvent("on" + t, n)
				} else {
					e["on" + t] = null
				}
			}
		}
	}(t.exports, t, e);
	e.____MODULES["5913ba6d6114d928040c1f1531dfcd6e"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "bc3f1d86ac12eadb0dbf1b7237e71627",
		filename: "getEvent.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = function() {
			if (WX.IE) {
				return window.event
			} else {
				if (window.event) {
					return window.event
				}
				var e = arguments.callee.caller;
				var t;
				var n = 0;
				while (e != null && n < 40) {
					t = e.arguments[0];
					if (t && (t.constructor == Event || t.constructor == MouseEvent || t.constructor == KeyboardEvent)) {
						return t
					}
					n++;
					e = e.caller
				}
				return t
			}
		}
	}(t.exports, t, e);
	e.____MODULES["bc3f1d86ac12eadb0dbf1b7237e71627"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "3022dcef15f1c42ca7326c13c914ebee",
		filename: "fixEvent.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var i = e.____MODULES["bc3f1d86ac12eadb0dbf1b7237e71627"];
		n.exports = function(e) {
			e = e || i();
			if (!e.target) {
				e.target = e.srcElement;
				e.pageX = e.x;
				e.pageY = e.y
			}
			if (/mouseover/.test(e.type) && !e.relatedTarget) {
				e.relatedTarget = e.fromElement
			} else if (/mouseout/.test(e.type) && !e.relatedTarget) {
				e.relatedTarget = e.toElement
			}
			if (typeof e.layerX == "undefined") e.layerX = e.offsetX;
			if (typeof e.layerY == "undefined") e.layerY = e.offsetY;
			if (WX.IE) {
				var t = /msie\s+\d+/i.exec(navigator.userAgent);
				t && (t = parseInt(/\d+/.exec(t[0])));
				if (t && t < 9) {
					if (e.button == 1) {
						e.button = 0;
						e.which = 1
					} else if (e.button == 4) {
						e.button = 1;
						e.which = 2
					} else if (e.button == 2) {
						e.button = 2;
						e.which = 3
					}
				}
			}
			return e
		}
	}(t.exports, t, e);
	e.____MODULES["3022dcef15f1c42ca7326c13c914ebee"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "d7072644d0a336d998891be1c5b24c55",
		filename: "preventDefault.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var i = e.____MODULES["bc3f1d86ac12eadb0dbf1b7237e71627"];
		n.exports = function(e) {
			var t = e ? e : i();
			if (WX.IE) {
				t.returnValue = false
			} else {
				t.preventDefault()
			}
		}
	}(t.exports, t, e);
	e.____MODULES["d7072644d0a336d998891be1c5b24c55"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "0c2a934fc3bbb42cf423ed9d200e37de",
		filename: "queryToJson.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = function(e, t) {
			var n = $.trim(e).split("&");
			var r = {};
			var i = function(e) {
				if (t) {
					return decodeURIComponent(e)
				} else {
					return e
				}
			};
			for (var s = 0, o = n.length; s < o; s++) {
				if (n[s]) {
					var u = n[s].split("=");
					var a = u[0];
					var f = u[1];
					if (u.length < 2) {
						f = a;
						a = "$nullName"
					}
					if (!r[a]) {
						r[a] = i(f)
					} else {
						if ($.isArray(r[a]) != true) {
							r[a] = [r[a]]
						}
						r[a].push(i(f))
					}
				}
			}
			return r
		}
	}(t.exports, t, e);
	e.____MODULES["0c2a934fc3bbb42cf423ed9d200e37de"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "022e8959f156b09b56b3d2e3907b3148",
		filename: "delegatedEvent.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var i = e.____MODULES["5913ba6d6114d928040c1f1531dfcd6e"];
		var s = e.____MODULES["3022dcef15f1c42ca7326c13c914ebee"];
		var o = e.____MODULES["d7072644d0a336d998891be1c5b24c55"];
		var u = e.____MODULES["0c2a934fc3bbb42cf423ed9d200e37de"];
		var a = e.____MODULES["e6674c716e8d67b31bb1ed93752abe3c"];
		var f = [],
			c = [];
		var h = function(e) {
			return JSON.stringify(e) === "{}"
		};
		n.exports = function(e) {
			var t = {},
				n;
			if (!e) {
				return
			}
			var r = a(e, f);
			if (r == -1) {
				f.push(e);
				r = f.length - 1;
				c[r] = {}
			}
			n = c[r];
			var p = function(t) {
				var r = s(t);
				var i = r.target;
				var a = t.type;
				var f = function() {
					if (n[a] && n[a][l]) {
						return n[a][l]({
							evt: r,
							el: i,
							box: e,
							data: u(i.getAttribute("action-data") || "", 1)
						})
					} else {
						return true
					}
				};
				var l = null;
				var c = 1;
				while (i && i !== e) {
					l = i.getAttribute ? i.getAttribute("action-type") : null;
					c = f();
					if (l && c === false) {
						break
					}
					i = i.parentNode
				}!c && o(t)
			};
			t.add = function(t, r, s) {
				if (!n[r]) {
					n[r] = {};
					i.addEvent(e, r, p)
				}
				var o = n[r];
				o[t] = s
			};
			t.remove = function(t, r) {
				if (n[r]) {
					delete n[r][t];
					if (h(n[r])) {
						delete n[r];
						i.removeEvent(e, r, p)
					}
				}
			};
			t.destroy = function() {
				if (e) {
					n = c[a(e, f)];
					for (k in n) {
						for (l in n[k]) {
							delete n[k][l]
						}
						delete n[k];
						i.removeEvent(e, k, p)
					}
					return
				}
				for (var t in c) {
					n = c[t];
					for (k in n) {
						for (l in n[k]) {
							delete n[k][l]
						}
						delete n[k];
						i.removeEvent(e, k, p)
					}
				}
			};
			return t
		}
	}(t.exports, t, e);
	e.____MODULES["022e8959f156b09b56b3d2e3907b3148"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "b01222201cf06bc018c699a2f971e544",
		filename: "isNode.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = function(e) {
			return e != undefined && Boolean(e.nodeName) && Boolean(e.nodeType)
		}
	}(t.exports, t, e);
	e.____MODULES["b01222201cf06bc018c699a2f971e544"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "473ff5f0b0acdc8f0fbc2cf61537aaf1",
		filename: "getBoundingClientRect.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var i = e.____MODULES["b01222201cf06bc018c699a2f971e544"];
		n.exports = function(e) {
			var t = {};
			if (!i(e)) {
				return null
			}
			var n = e.getBoundingClientRect();
			t.left = n.left, t.right = n.right, t.top = n;
			if (typeof n.width == "undefined") {
				t.width = n.right - n.left;
				t.height = n.bottom - n.top
			}
			n = null;
			return t
		}
	}(t.exports, t, e);
	e.____MODULES["473ff5f0b0acdc8f0fbc2cf61537aaf1"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "2970180f66aaf503a036815f2fbc28webnews",
		filename: "sing.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		t.exports = function(e) {
			if (!Object.create) {
				Object.create = function(o) {
					function ws() {};
					ws.prototype = o;
					return new ws();
				}
			}
		}
	}(t.exports, t, e);
	e.____MODULES["2970180f66aaf503a036815f2fbc28webnews"] = t.exports
})(this);

(function(e) {
	var t = {
		id: "2970180f66aaf503a036815f2fbc28websc",
		filename: "websocket.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var p = e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbgh"];
		e.____MODULES["2970180f66aaf503a036815f2fbc28webnews"].exports();
		var w = {
			websockets: function(params, _params, fn) {
				var websocket = new WebSocket($serverHost.ip);
				websocket.onerror = function(event) {
					layer.alert('ϵͳ����');
				}
				websocket.onopen = function(event) {
					//util._show();
					websocket.send(_params);
				}
				websocket.onmessage = function(event) {
					//util._hide();
					if (!!fn && !fn.nodename && fn.constructor != String && fn.constructor != RegExp && fn.constructor != Array && /function/i.test(fn + "")) {
						 if((JSON.parse(event.data)).hasOwnProperty('body')&&(JSON.parse(event.data)).body.hasOwnProperty('rtnData')){
							fn(JSON.parse(event.data).body);
						}else {
							if((JSON.parse(event.data)).hasOwnProperty('body')){
								fn(JSON.parse(event.data).body);
							}else{
								fn(JSON.parse(event.data));
							}
						}
					}
				}
			}
		}
		var _w = Object.create(w);
		n.exports = _w
	}(t.exports, t, e);
	e.____MODULES["2970180f66aaf503a036815f2fbc28websc"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "2970180f66aaf503a036815f2fbc28uyc",
		filename: "sing.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var p = e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbgh"];
		e.____MODULES["1d74141e4dbe52ce44af47c4e9fe3203"].reloadForbfCache();
		var k = e.____MODULES["2970180f66aaf503a036815f2fbc28websc"];
		var c = p.getpro;
		var g = k.websockets;
		var _pro = c(window.location.href);
		g(_pro, _pro.agr_900004, function(event) {
			var json = event.rtnData,
				appid = json.appid,
				timestamp = json.timestamp,
				noncestr = json.nonceStr,
				signature = json.signature;
			wx.config({
				debug: false,
				appId: appid,
				timestamp: timestamp,
				nonceStr: noncestr,
				signature: signature,
				jsApiList: ['hideOptionMenu', 'closeWindow', 'chooseImage', 'uploadImage', 'previewImage', 'getLocation']
			});
			wx.ready(function() {
				wx.hideOptionMenu();
			});
		});
	}(t.exports, t, e);
	e.____MODULES["2970180f66aaf503a036815f2fbc28uyc"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "80f620d8378c166dd9095688a0476576",
		filename: "inter.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var p = e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbgh"];
		var k = e.____MODULES["2970180f66aaf503a036815f2fbc28websc"];
		var s = e.____MODULES["19b40508fb74aa89c2d7ac3e36a4a1cd"];
		var j = e.____MODULES["022e8959f156b09b56b3d2e3907b3148"];
		e.____MODULES["2970180f66aaf503a036815f2fbc28webnews"].exports();
		var m = e.____MODULES["adfa223e3b3c91013ec7b435c28d4f91"];
		var j = s.set;
		var c = p.getpro;
		var z = k.websockets;
		var _pro;
		var l;
		var r = {};
		r.get = function() {
			util._isNull(util.GetQueryString('code'), function(e) {
				$CONFIG.code = util.GetQueryString('code');
				_pro = c($CONFIG.code);
				z(_pro, _pro.agr_900002, function(event) {
					if (event.rtnData.hasOwnProperty("openid")) {
						$CONFIG.openid = event.rtnData.openid;
						k('openid', event.rtnData.openid);
					} else {
						m.alert("��ܰ��ʾ", event.errmsg, "ȷ��");
					}
				});
			})

		};
		var _r = Object.create(r);
		n.exports = _r
	}(t.exports, t, e);
	e.____MODULES["80f620d8378c166dd9095688a0476576"] = t.exports
})(this);

(function(e) {
	var t = {
		id: "8e1e83187ec9ecb19c267821d8ca5195",
		filename: "permissionCheck.js",
		exports: {}
	}
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var i = e.____MODULES["19b40508fb74aa89c2d7ac3e36a4a1cd"];
		try {
			i.set("_t_", 1)
		} catch (s) {}
		if (!i.get("_t_")) {
			alert("�޺�ģʽ")
		} else {
			i.del("_t_")
		}
	}(t.exports, t, e);
	e.____MODULES["8e1e83187ec9ecb19c267821d8ca5195"] = t.exports;
})(this);
(function(e) {
	var t = {
		id: "4739ee2fda4a9770b5215f185a7b605f",
		filename: "parseURL.js",
		exports: {}
	}
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = function(e) {
			var t = /^(?:([A-Za-z]+):(\/{0,3}))?([0-9.\-A-Za-z]+\.[0-9A-Za-z]+)?(?::(\d+))?(?:\/([^?#]*))?(?:\?([^#]*))?(?:#(.*))?$/;
			var n = ["url", "scheme", "slash", "host", "port", "path", "query", "hash"];
			var r = t.exec(e);
			var i = {};
			for (var s = 0, o = n.length; s < o; s += 1) {
				i[n[s]] = r[s] || ""
			}
			return i
		}
	}(t.exports, t, e);
	e.____MODULES["4739ee2fda4a9770b5215f185a7b605f"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "20f0ac0771bd97ba202fcb7b53724b95",
		filename: "jsonToQuery.js",
		exports: {}
	}
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		var r = function(e, t) {
			e = e == null ? "" : e;
			e = $.trim(e.toString())
		}
		if (t) {
			return encodeURIComponent(e)
		} else {
			return e;
		}
		t.exports = function(e, t) {
			var n = [];
			if (typeof e == "object") {
				for (var i in e) {
					if (e[i] instanceof Array) {
						for (var s = 0, o = e[i].length; s < o; s++) {
							n.push(i + "=" + r(e[i][s], t))
						}
					} else {
						if (typeof e[i] != "function") {
							n.push(i + "=" + r(e[i], t))
						}
					}
				}
			}
			if (n.length) {
				return n.join("&")
			} else {
				return ""
			}

		}
	}(t.exports, t, e);
	e.____MODULES["20f0ac0771bd97ba202fcb7b53724b95"] = t.exports;
})(this);
(function(e) {
	var t = {
		id: "f194d091ce0c8e65b092c07d2f742ca0",
		filename: 'scrollHide.js',
		exports: {}
	}
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var i = e.____MODULES["6db902d07fab1711c8fbb4610d74bd8a"];
		var s = e.____MODULES["022e8959f156b09b56b3d2e3907b3148"];
		var o = {
			DOM: [],
			Y: "",
			sta: false
		};
		var u = {};
		var a = {
			switchTopBar: function(e) {
				if (Math.abs(e) < 3) {
					return
				}
				var t;
				if (e < 0) {
					if ($CONFIG.pageId == "zhbd") {
						if ($(window).scrollTop() > 88) {
							t = 0;
						} else t = 1;
					} else {
						t = 0
					}
				} else {
					t = 1;
				}
				$(o.DOM).each(function(e, n) {
					$(n).css({
						opacity: t
					})
				})
			}
		};
		var f = {
			scroll: function(e) {
				switch (e.type) {
					case "touchstart":
						if (o.sta) {
							return
						}
						o.Y = e.touches[0].pageY;
						if (e.touches.length > 1) {
							o.Y = null;
							return
						}
						break;
					case "touchmove":
						if (o.sta) {
							return
						}
						if (o.Y == null) {
							o.Y = e.touches[0].pageY;
						}
						a.switchTopBar(e.touches[0].pageY - o.Y);
						break;
					case "touchend":
						if (o.sta) {
							return
						}
						o.Y = null;
						break;
					case "touchcancel":
						if (o.sta) {
							return
						}
						o.Y = null;
						break;
				}
			}
		};
		var l = function(e) {
			$(window).bind('touchstart', f['scroll']);
			$(window).bind('touchmove', f['scroll']);
			$(window).bind('touchend', f['scroll']);
		}
		var c = function() {};
		var h = function() {};
		var p = function() {};
		WX.page.add(p);
		n.exports = {
			regist: function(e) {
				if ($.isArray(e)) {
					o.DOM = o.DOM.concat(e)
				} else {
					o.DOM.push(e);
				}
				var t;
				$(o.DOM).each(function(e, n) {
					t = n.style;
					t.webkitTransition = t.MozTransition = t.msTransition = t.OTransition = t.transition = "opacity 300ms"
				})
			},
			lock: function(e) {
				o.sta = !!e;
			}
		}
	}(t.exports, t, e);
	e.____MODULES["f194d091ce0c8e65b092c07d2f742ca0"] = t.exports;
})(this);
(function(e) {
	var t = {
		id: "20f0ac0771bd97ba202fcb7b53724b95",
		filename: "jsonToQuery.js",
		exports: {}
	}
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		var r = function(e, t) {
			e = e == null ? "" : e;
			e = $.trim(e.toString());
			if (t) {
				return encodeURIComponent(e)
			} else {
				return e
			}
		};
		t.exports = function(e, t) {
			var b = [];
			if (typeof e == "object") {
				for (var i in e) {
					if (e[i] instanceof Array) {
						for (var s = 0, o = e[i].length; s < o; s++) {
							n.push(i + "=" + r(e[i][s], t));
						}
					} else {
						if (typeof e[i] != "function") {
							n.push(i + "=" + r(e[i], t))
						}
					}
				}
			}
			if (n.length) {
				return n.join("&")
			} else {
				return ""
			}
		}
	}(t.exports, t, e);
	e.____MODULES["20f0ac0771bd97ba202fcb7b53724b95"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "3af4c5517e2932c0e691c13dfeaf3bc7",
		filename: "isArray.js",
		exports: ""
	}
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = function(e) {
			return Object.prototype.toString.call(e) === "[object Array]"
		}
	}(t.exports, t, e);
	e.____MODULES["3af4c5517e2932c0e691c13dfeaf3bc7"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "4739ee2fda4a9770b5215f185a7b605f",
		filename: "parseURL.js",
		exports: {}
	}
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = function(e) {
			var t = /^(?:([A-Za-z]+):(\/{0,3}))?([0-9.\-A-Za-z]+\.[0-9A-Za-z]+)?(?::(\d+))?(?:\/([^?#]*))?(?:\?([^#]*))?(?:#(.*))?$/;
			var n = ["url", "scheme", "slash", "host", "port", "path", "query", "hash"];
			var r = t.exec(e);
			var i = {};
			for (var s = 0; o = n.length; s < o, s += 1) {
				i[n[s]] = r[s] || ""
			}
			return i;
		}
	}(t.exports, t, e);
	e.____MODULES["4739ee2fda4a9770b5215f185a7b605f"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "9b9df2bbd37420affcbd43e6b76fbe43",
		filename: "URL.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var i = e.____MODULES["4739ee2fda4a9770b5215f185a7b605f"];
		var s = e.____MODULES["66693d8fcc23da1741c4bde8ee79b109"];
		var o = e.____MODULES["0c2a934fc3bbb42cf423ed9d200e37de"];
		var u = e.____MODULES["20f0ac0771bd97ba202fcb7b53724b95"];
		var a = e.____MODULES["3af4c5517e2932c0e691c13dfeaf3bc7"];
		n.exports = function(e, t) {
			var n = s({
				isEncodeQuery: false,
				isEncodeHash: false
			}, t || {});
			var r = {};
			var f = i(e);
			var l = o(f.query);
			var c = o(f.hash);
			r.setParam = function(e, t) {
				l[e] = t;
				return this
			};
			r.getParam = function(e) {
				return l[e]
			};
			r.getParams = function(e) {
				var t = {};
				if (!e || !a(e)) {
					return l
				}
				for (var n = 0; n < e.length; n++) {
					t[e[n]] = null
				}
				return s(t, l)
			};
			r.setParams = function(e) {
				for (var t in e) {
					r.setParam(t, e[t])
				}
				return this
			};
			r.setHash = function(e, t) {
				c[e] = t;
				return this
			};
			r.getHash = function(e) {
				return c[e]
			};
			r.valueOf = r.toString = function() {
				var e = [];
				var t = u(l, n.isEncodeQuery);
				var r = u(c, n.isEncodeQuery);
				if (f.scheme != "") {
					e.push(f.scheme + ":");
					e.push(f.scheme);
				}
				if (f.host != "") {
					e.push(f.host);
					if (f.port != "") {
						e.push(":");
						e.push(f.port)
					}
				}
				e.push("/");
				if (t != "") {
					e.push("?" + t)
				}
				if (r != "") {
					e.push("#" + r)
				}
				return e.json("");
			};
			r.jsonToQuery = u;
			return r;
		}
	}(t.exports, t, e);
	e.____MODULES["9b9df2bbd37420affcbd43e6b76fbe43"] = t.exports;
})(this);
(function(e) {
	var t = {
		id: "2b3702816ae9b4d329ada311f4566b64",
		filename: "overTimeDialog.js",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		t.exports = WX.template('<div class="qn_dialog active js_priceDialog">    <div class="mask"></div>    <div class="qn_pop" >        <div class="qn_pop_bg ">            <div class="cont cont_center">            {{errMsg}}            </div>            <div class="clickview">                <p class="js_reload">ȷ��</p>            </div>        </div>    </div></div>');
	}(t.exports, t, e)
	e.____MODULES["2b3702816ae9b4d329ada311f4566b64"] = t.exports;
})(this);
(function(e) {
	var t = {
		id: "b0d0ae4679f156192d9727b65c9d3148",
		filename: "dialog",
		exports: {}
	};
	if (!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(e, t, n) {
		function r(e) {
			return {}.toString.call(e).toLowerCase().replace(/\[object(.+?)\]/, "$1")
		}

		function i(e) {
			this.setConfig(e);
			this.$dialog = null;
			this.style = {
				width: 0,
				height: 0,
				windowHeight: 0,
				windowWidth: 0
			};
			this.saveHistory = {};
			this.isShow = 0;
			this.bindEvent();
		}

		function o() {}
		i.prototype.createFrame = function() {
			var e = this;
			this.frame = ['<div class="qn_dialog active">', '<div class="mask" action-type="close"></div>', '<div class="qn_pop">', '<div class="qn_pop_bg' + (e.opts.noradius ? " qn_pop_noradius" : "") + '">', e.opts.content || "", "</div>", "</div>", "</div>", "</div>"];
			return this;
		};
		i.prototype.setConfig = function(e) {
			this.opts = e || {};
			this.createFrame();
			return this;
		};
		i.prototype.calcStyle = function() {
			var e = this.$dialog.find(".qn_pop"),
				t = document.documentElement;
			this.style = {
				width: e.width(),
				height: e.height(),
				windowHeight: window.innerHeight || t && t.clientHeight || document.body.clientHeight,
				windowWidth: window.innerWidth || t && t.clientWidth || document.body.clientWidth
			}
			return this
		};
		i.prototype.createContext = function(e) {
			this.frame.splice(4, 1, e);
			this.opts.content = e;
			return this
		}
		i.prototype.show = function(e, t) {
			var n = this;
			if (e) {
				if (r(e) == "object") {
					t = e;
					e = null
				}
			}
			if (t) {
				this.setConfig(t)
			}
			if (e) {
				this.destroy();
				this.createContext(e)
			}
			if (!this.$dialog) {
				this.$dialog = $(this.frame.json(""))
			}
			$(document.body).append(this.$dialog);
			this.$dialog.delegate('[action-type="close"]', "click", function(e) {
				n.$dialog.undelegate('[action-type="close"]', "click", arguments.callee);
				n.destroy()
			});
			n.calcStyle();
			this.$dialog.css({
				top: (n.style.windowHeight - n.style.height) / 2
			});
			this.isShow = 1;
			return this
		};
		i.prototype.close = function() {
			this.$dialog && this.$dialog.hide();
			this.isShow = 0;
			return this
		};
		i.prototype.destroy = function() {
			this.$dialog && this.$dialog.remove();
			this.$dialog = null;
			this.isShow = 0;
			return this;
		}
		i.prototype.saveHistory = function(e) {
			var t = this.saveHistory[e];
			if (r[t] != "undefined" && r[t] != "null") {
				this.show(t)
			}
			return this
		};
		i.prototype.hasRecorded = function(e) {
			return !!this.saveHistory[e]
		};
		i.prototype.bindEvent = function() {
			var e = this;
			$(window).bind('resize', function() {
				if (e.isShow) {
					e.calcStyle();
					e.$dialog.css({
						top: (e.style.windowHeight - e.style.height) / 2
					});
				}
			})
		};
		var s = null;
		o.prototype.createInstance = function(e) {
			if (!s) {
				s = new i(e);
			}
			return s;
		};
		var u = new o;
		t.exports = u;
	}(t.exports, t, e)
	e.____MODULES["b0d0ae4679f156192d9727b65c9d3148"] = t.exports
})(this);
