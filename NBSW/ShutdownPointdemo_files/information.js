(function(e) {
	var t = {
		id: "70c8abbe70d080f11d4fa931bb61ctpl",
		filename: "tpl.js",
		exports: {}
	};
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var temp = WX.template('{{each data as value index}}<li><a style="display: block;color: #555;" href="detail.html?uid={{value.id}}&type={{value.type}}&title={{value.title}}"><div class="yywd_left font2"><span>{{index+1}}</span></div><div class="yywd_right"><span class="font3" style="margin-top: 10px;">{{value.title}}</span></a></div><div class="clear"></div></li>{{/each}}')
		n.exports = {
			te: temp
		}
	}(t.exports, t, e);
	e.____MODULES["70c8abbe70d080f11d4fa931bb61ctpl"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "d7072644d0a336d998891be1c5b24ccc",
		filename: "child.js",
		exports: {}
	};
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var map = WX.template('{{each data as value index}}<li><a style="display: block;color: #555;" href="{{value.content}}"><div class="yywd_left font2"><span>{{index+1}}</span></div><div class="yywd_right"><span class="font3" style="margin-top: 10px;">{{value.title}}</span></a></div><div class="clear"></div></li>{{/each}}')
		var p = e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbgh"];
		e.____MODULES["1d74141e4dbe52ce44af47c4e9fe3203"].reloadForbfCache();
		var k = e.____MODULES["2970180f66aaf503a036815f2fbc28websc"];
		var c = p.getpro;
		var g = k.websockets;
		var _pro = c($CONFIG.type);
		var m = {
			msg: function() {
				g(_pro, _pro.agr_500014, function(event) {
					return util.tp(event.rtnData, 'list', map({
						title:decodeURI($CONFIG.title),
						data: event.rtnData
					}));
				});
			}
		}
		n.exports = m;
	}(t.exports, t, e);
	e.____MODULES["d7072644d0a336d998891be1c5b24ccc"] = t.exports
})(this);




(function(e) {
	var t = {
		id: "70c8abbe70d080f11d4fa931bb61detail",
		filename: "message.js",
		exports: {}
	};
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var temp = WX.template('{{each data as value index}}<h3 style="text-align: center;" id="title">{{value.title}}</h3><div class="list-group" id="content" style="margin-top:3px;">{{#value.content}}</div>{{/each}}');
		n.exports = {
			te: temp
		}
	}(t.exports, t, e);
	e.____MODULES["70c8abbe70d080f11d4fa931bb61detail"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "d7072644d0a336d998891be1c5b24cbn",
		filename: "yywd.js",
		exports: {}
	};
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var map = WX.template('{{each data as value index}}<div class="zdxq_top font1"><a style="display: block;color: #555;" href="http://apis.map.qq.com/uri/v1/marker?marker=coord:{{value.lat}},{{value.lng}};title:{{value.title}};addr:{{value.addr}}&referer=myapp"><ul><li style="width:80%"><span>名称：</span><span>{{value.title}}</span></li><li style="display: inline-block;width:80%;"><span>电话：</span><span>{{value.tel}}</span></li><li style="width:80%"><span>地址：</span><span>{{value.addr}}</span></li><div class="clear"></div></ul><div class="sfcx_cont_remove bgcolor1"><a id="deteleMeter" href="http://apis.map.qq.com/uri/v1/marker?marker=coord:{{value.lat}},{{value.lng}};title:{{value.title}};addr:{{value.addr}}&referer=myapp">地&nbsp;&nbsp;图</a></div></a></div>{{/each}}');
		var p = e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbgh"];
		e.____MODULES["1d74141e4dbe52ce44af47c4e9fe3203"].reloadForbfCache();
		var k = e.____MODULES["2970180f66aaf503a036815f2fbc28websc"];
		var c = p.getpro;
		var g = k.websockets;
		var _pro = c();
		var m = {
			msg: function() {
				g(_pro, _pro.agr_500012, function(event) {
					return util.tp(event.rtnData, 'list', map({
						data: event.rtnData
					}));
				});
			}
		}
		n.exports = m;
	}(t.exports, t, e);
	e.____MODULES["d7072644d0a336d998891be1c5b24cbn"] = t.exports
})(this);

(function(e) {
	var t = {
		id: "d7072644d0a336d998891be1c5b24c77",
		filename: "itemdetail.js",
		exports: {}
	}
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var p = e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbgh"];
		var h = e.____MODULES["70c8abbe70d080f11d4fa931bb61detail"];
		e.____MODULES["1d74141e4dbe52ce44af47c4e9fe3203"].reloadForbfCache();
		var k = e.____MODULES["2970180f66aaf503a036815f2fbc28websc"];
		var c = p.getpro;
		var g = k.websockets;
		var _pro = "";

		var m = {
			msg: function(a, b) {
				if($CONFIG.siglon == "true") {
					_pro = c(a,$CONFIG.type);
				} else {
					_pro = c(util.GetQueryString('uid'), util.GetQueryString('type'));
				}
				
				g(_pro, _pro.agr_5000140, function(event) {
					return util.tp(event.rtnData, 'list', h.te({
						data: event.rtnData
					}));
				});
			}
		}
		n.exports = m;
	}(t.exports, t, e)
	e.____MODULES['d7072644d0a336d998891be1c5b24c77'] = t.exports;
}(this));
(function(e) {
	var t = {
		id: "d7072644d0a336d998891be1c5b24c88",
		filename: "list_tpl.js",
		exports: {}
	}
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var p = e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbgh"];
		var l = e.____MODULES["70c8abbe70d080f11d4fa931bb61ctpl"];
		e.____MODULES["1d74141e4dbe52ce44af47c4e9fe3203"].reloadForbfCache();
		var k = e.____MODULES["2970180f66aaf503a036815f2fbc28websc"];
		var d = e.____MODULES["d7072644d0a336d998891be1c5b24c77"];
		console.log(d);
		var u = d.msg;
		var c = p.getpro;
		var g = k.websockets;
		var _pro = c($CONFIG.type);
		var m = {
			msg: function() {
				g(_pro, _pro.agr_500014, function(event) {
					if($CONFIG.siglon == "true") {
						u(event.rtnData[0].id, $CONFIG.type);
					} else {
						return util.tp(event.rtnData, 'list', l.te({
							type: $CONFIG.pageId,
							title:decodeURI($CONFIG.title),
							data: event.rtnData
						}));
					}

				});
			}
		}
		n.exports = m;
	}(t.exports, t, e)
	e.____MODULES['d7072644d0a336d998891be1c5b24c88'] = t.exports;
}(this));
(function(e) {
	var t = {
		id: "d7072644d0a336d998891be1c5b24yueop",
		filename: "init.js",
		exports: {}
	}
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var p = e.____MODULES["d7072644d0a336d998891be1c5b24c77"];
		var g = p.msg;
		var m = {
			msg: function() {
				return g();
			}
		};
		n.exports = m;
	}(t.exports, t, e)
	e.____MODULES['d7072644d0a336d998891be1c5b24yueop'] = t.exports;
}(this));
(function(e) {
	var t = {
		id: "d7072644d0a336d998891be1c5b24c11",
		filename: "tsinit.js",
		exports: {}
	};
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var p = e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbgh"];
		e.____MODULES["1d74141e4dbe52ce44af47c4e9fe3203"].reloadForbfCache();
		var k = e.____MODULES["2970180f66aaf503a036815f2fbc28websc"];
		var j = e.____MODULES["70c8abbe70d080f11d4fa931bb61ctpl"];
		var c = p.getpro;
		var g = k.websockets;
		var _pro = c();
		var m = {
			msg: function() {
				g(_pro, _pro.agr_500013, function(event) {
					return util.tp(event.rtnData, 'list', j.te({
						type: $CONFIG.pageId,
						data: event.rtnData
					}));
				});
			}
		}
		n.exports = m;
	}(t.exports, t, e);
	e.____MODULES["d7072644d0a336d998891be1c5b24c11"] = t.exports
})(this);
(function(e) {
	var t = {
		id: "d7072644d0a336d998891be1c5b24c33",
		filename: "tsdata.js",
		exports: {}
	};
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var p = e.____MODULES["b74d01a7cd1f6e55582e21bbb149bbgh"];
		e.____MODULES["1d74141e4dbe52ce44af47c4e9fe3203"].reloadForbfCache();
		var k = e.____MODULES["2970180f66aaf503a036815f2fbc28websc"];
		var c = p.getpro;
		var g = k.websockets;
		var _pro = c(util.GetQueryString('uid'));
		
		var f = WX.template('{{each data as value index}}<h3 style="text-align: center;" id="title">{{value.title}}</h3><div class="list-group" id="content" style="margin-top:3px;"><p style="text-align: left;">{{value.first}}</p><p style="text-align: left;text-indent: 2em;line-height:24px;font-size:18px">{{#value.content}}</p><p style="text-align:right;text-indent: 2em;">{{value.remark}}</p></div>{{/each}}');
		var m = {
			msg: function() {
				g(_pro, _pro.agr_5000130, function(event) {
					return util.tp(event.rtnData, 'list', f({
						data: event.rtnData
					}));
					console.log(event);
				});
			}
		}
		n.exports = m;
	}(t.exports, t, e)
	e.____MODULES['d7072644d0a336d998891be1c5b24c33'] = t.exports
}(this));
(function(e) {
	var t = {
		id: "d7072644d0a336d998891be1c5b24c22",
		filename: "initdetail.js",
		exports: {}
	};
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var p = e.____MODULES["d7072644d0a336d998891be1c5b24c33"];
		var g = p.msg;
		var m = {
			msg: function() {
				return g();
			}
		};
		n.exports = m;
	}(t.exports, t, e);
	e.____MODULES['d7072644d0a336d998891be1c5b24c22'] = t.exports
}(this));
(function(e) {
	var t = {
		id: "2970180f66aaf503a036815f2fbc2yuec",
		filename: "sing.js",
		exports: {}
	};
	if(!e.____MODULES) {
		e.____MODULES = {}
	}
	var n = function(t, n, r) {
		var p = e.____MODULES["d7072644d0a336d998891be1c5b24c88"];
		var r = e.____MODULES["d7072644d0a336d998891be1c5b24yueop"];
		var y = e.____MODULES["d7072644d0a336d998891be1c5b24cbn"];
		var s = e.____MODULES["d7072644d0a336d998891be1c5b24c11"];
		var i = e.____MODULES["d7072644d0a336d998891be1c5b24c22"];
		var v = e.____MODULES["d7072644d0a336d998891be1c5b24ccc"];
		var _v=v.msg;
		var k = y.msg;
		var c = r.msg;
		var m = p.msg;
		var q = s.msg;
		var j = i.msg;
		var V=function(){
			_v();
		}
		var D = function() {
			m();
		}
		var H = function() {
			c();
		}
		var N = function() {
			k();
		}
		var T = function() {
			q();
		}
		var I = function() {
			j();
		}
		
	/*	if(util.GetQueryString('type') != '' && util.GetQueryString('type') != "undefined" && util.GetQueryString('type') != null) {
			WX.page.add(H);
		} */
		if(util.GetQueryString('uid') !=undefined && util.GetQueryString('type')==''){
			WX.page.add(I);
		}
        else if(util.GetQueryString('uid') !=undefined){
             WX.page.add(H);
        }
		else if($CONFIG.page == 'yywd') {
			WX.page.add(N);
		} else if($CONFIG.page == 'tstz') {
			WX.page.add(T);
		}else if($CONFIG.page == "detail") {
			WX.page.add(I);
		} else if($CONFIG.page=='main'){
			WX.page.add(V);
		} else if($CONFIG.page=='submain'){
			WX.page.add(V);
		}else {
			WX.page.add(D);
		}
	}(t.exports, t, e);
	e.____MODULES["2970180f66aaf503a036815f2fbc2yuec"] = t.exports
})(this);