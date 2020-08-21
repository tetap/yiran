/*
*
*	手机端组件
*	文档地址: https://www.showdoc.cc/805612872705921?page_id=4429881966920245
* 	github: https://github.com/yirandidi/appjs
*	当前版本信息:0.0.4
* 	...
* 	0.0.3 :
* 		优化除了picker之外的所有事件与template
* 		加入PhotoSwipe
* 		添加notifi消息提示
*   0.0.4 : 
* 		修复notifi排序问题
*		
* 	修改备注：picker代码优化留着下次吧~ 完成后如果没有使用到PhotoSwipe,picker记得删除。体积有点大 好困好困好困！
*	
*/
// rem();
// $(window).resize(function(){rem()})
function rem() {
	var cw = $(window).width();
	cw = cw / 7.5;
	if(cw < 20) 
	{cw = 20;}
	if(cw > 100) 
	{cw = 100;}
	$('html').css("font-size", cw + 'px');
}
//层级
var zindex = 2501314;
//遮罩层
var yr_mack = '<div class="yr_mack hide" style="z-index:'+zindex+'"></div>';
//总框架
var yr_app = '<div class="yr_app yr_app_layout yrani yrzoomIn"></div>';
//标题
var yr_app_title = '<div class="yr_app_title">{{text}}</div>';
//内容
var yr_app_content = '<div class="yr_app_content">{{text}}</div>';
//按钮
var yr_app_btnbox = "<div class='yr_app_btnBox'></div>";
//按钮1样式
var yr_app_btnstyle1 = '<button class="yr_btnStyle1">{{text}}</button>'
//按钮2样式
var yr_app_btnstyle2 = '<button class="yr_btnStyle2">{{text}}</button>'
//透明遮罩层
var loadMack = '<div class="loadMack"></div>'
//toast
var yr_toast = '<div class="yr_app yr_app_showToast yrani yrfadeIn"></div>';
//打钩
var yr_success = '<div class="app_icon" style="color:rgb(76, 175, 80)">&#xe60a;</div>'
//打叉
var yr_error = '<div class="app_icon" style="color:#f03434">&#xe613;</div>'
//toast标题
var yr_toast_title = '<div class="yr_showToast_title">{{text}}</div>';
//加载图标
var yr_load = '<svg version="1.1" id="loader-1" x="0px" y="0px" width="50px" height="50px" viewBox="0 0 50 50" style="enable-background:new 0 0 50 50;" xml:space="preserve"><path fill="#0164DE" d="M43.935,25.145c0-10.318-8.364-18.683-18.683-18.683c-10.318,0-18.683,8.365-18.683,18.683h4.068c0-8.071,6.543-14.615,14.615-14.615c8.072,0,14.615,6.543,14.615,14.615H43.935z" transform="rotate(157.453 25 25)"><animateTransform attributeType="xml" attributeName="transform" type="rotate" from="0 25 25" to="360 25 25" dur="0.6s" repeatCount="indefinite"></animateTransform></path></svg>'
//加载框
var yr_showLoading = '<div class="yr_showLoading"></div>'
//图片预览框
var $html = ['<div class="pswp" tabindex="-1" role="dialog" aria-hidden="true">', '<div class="pswp__bg"></div>',
	'<div class="pswp__scroll-wrap">', '<div class="pswp__container">', '<div class="pswp__item"></div>',
	'<div class="pswp__item"></div>', '<div class="pswp__item"></div>', "</div>",
	'<div class="pswp__ui pswp__ui--hidden">', '<div class="pswp__top-bar">', '<div class="pswp__counter"></div>',
	'<button class="pswp__button pswp__button--close" title="Close (Esc)"></button>', '<div class="pswp__preloader">',
	'<div class="pswp__preloader__icn">', ' <div class="pswp__preloader__cut">',
	'<div class="pswp__preloader__donut"></div>', "</div>", "</div>", "</div>", "</div>",
	'<div class="pswp__share-modal pswp__share-modal--hidden pswp__single-tap">',
	'<div class="pswp__share-tooltip"></div> ', "</div>",
	'<button class="pswp__button pswp__button--arrow--left" title="Previous (arrow left)">', "</button>",
	'<button class="pswp__button pswp__button--arrow--right" title="Next (arrow right)">', "</button>",
	'<div class="pswp__caption">', '<div class="pswp__caption__center"></div>', "</div>", "</div>", "</div>", "</div>"
].join("");
//notifi 优先级比其他层低一级
var yr_notifi = '<div style="z-index:'+(zindex-1)+'" class="yr_notifi yrani1 fadeInRight_qs100"></div>'
//notifi padding
var yr_notifi_body = '<div class="yr_notifi_body"></div>'
// notifi title
var yr_notifi_title = '<div class="yr_notifi_title"></div>'
// notifi text
var yr_notifi_text = '<div class="yr_notifi_text"></div>'
// notifi icon
var yr_notifi_icon = '<div class="yr_notifi_icon app_icon">&#xe622;</div>'
var app = {
	init:function(){
		if($(".yr_mack").length<=0){$("body").append(yr_mack)}
		this.hideMack();
		$(".yr_app").remove();
		this.options = {
			title:"提示",//标题
			btn:['取消','确定'],//按钮
			content:"content", //内容
			duration:2000,//toast消失事件
			icon:"success",
			success:function(msg){},//成功回调
			fail:function(msg){}//失败回调
		}
	},
	//弹窗提示
	alert:function(e){
		try{
			this.init();
			if(typeof e == "string"){e = {content:e};}
			Object.assign(this.options,e);
			this.createElem("alert");
		}
		catch(err){
			console.log(err)
			this.options.fail(err)
		}
	},
	//带有确定取消按钮的对话框
	confirm:function(e){
		try{
			this.init();
			e = typeof e == "object" ? e : {};
			Object.assign(this.options,e);
			this.createElem("confirm");
		}
		catch(err){
			console.log(err)
			this.options.fail(err)
		}
	},
	//自动消失的提示框
	showToast:function(e){
		try{
			this.init();
			e = typeof e == "object" ? e : {};
			Object.assign(this.options,e);
			this.createElem("toast");
		}
		catch(err){
			console.log(err)
			this.options.fail(err)
		}
	},
	//加载框
	showLoading:function(e){
		try{
			this.init();
			e = typeof e == "object" ? e : {};
			Object.assign(this.options,e);
			this.createElem("loading");
		}
		catch(err){
			console.log(err)
			this.options.fail(err)
		}
	},
	//销毁加载
	hideLoading:function(){
		if($(".yr_showLoading").length>=1){this.init();$(".yr_showLoading").remove()}
	},
	//图片预览
	previewImage: function(e){
		app.showLoading({title:"加载中..."});
		if($(".pswp").length<=0){
			$("body").append($html);
			setTimeout(function(){
				app.previewImage(e)
			})
			return ;
		}
		var pswpElement = document.querySelectorAll('.pswp')[0];
		var items = [];
		var options = {};
		for(var i in e.urls){
			if(e.current == e.urls[i]){
				options = {
					index: Number(i)
				};
			}
			new getImage(e.urls[i],function(c,j){
				items[j] = c;
				if(items.length==e.urls.length){
					var gallery = new PhotoSwipe( pswpElement, PhotoSwipeUI_Default, items,options);
					gallery.init();
					app.hideLoading();
				}
			},i)
		}
	},
	//右上角消息通知
	notifi:function(e){
		try{
			this.init();
			e = typeof e == "object" ? e : {};
			Object.assign(this.options,e);
			this.createElem("notifi");
			this.notifiSort();
		}
		catch(err){
			console.log(err)
			this.options.fail(err)
		}
	},
	notifiSort:function(){
		$(".yr_notifi").each(function(index){
			if(index>0){
				var _self = this;
				var top = Number($(_self).prev().attr("top")) + $(_self).prev().height() +10;
				$(_self).css({"top":top}).attr("top",top)
			}else{
				$(this).css({"top":10}).attr("top",10)
			}
		})
	},
	//创建节点并绑定事件 重点！！！
	createElem:function(type){
		let _this = this;
		switch (type){
			case "alert":
				var app = $(yr_app);
				var content = $(yr_app_content.replace("{{text}}",this.options.content));
				var btn = $(yr_app_btnstyle2.replace("{{text}}",this.options.btn[1]));
				var btnbox = $(yr_app_btnbox).append(btn);
				app.append(content);
				app.append(btnbox);
				$(".yr_mack").removeClass("hide").addClass("show");
				$("body").append(app);
				app.css({top:this.getCenterY(app.height()),"z-index":zindex});
				(function(_this){
					btn.bind('click',function(){
						_this.destory(app);
						_this.options.success(true);
					});
				})(_this);
				break;
			case "confirm":
				var app = $(yr_app);
				var title = $(yr_app_title.replace("{{text}}",this.options.title));
				var content = $(yr_app_content.replace("{{text}}",this.options.content));
				var btn1 = $(yr_app_btnstyle1.replace("{{text}}",this.options.btn[0]));
				var btn2 = $(yr_app_btnstyle2.replace("{{text}}",this.options.btn[1]));
				var btnbox = $(yr_app_btnbox).append(btn1).append(btn2);
				app.append(title);
				app.append(content);
				app.append(btnbox);
				$(".yr_mack").removeClass("hide").addClass("show");
				$("body").append(app);
				app.css({top:this.getCenterY(app.height()),"z-index":zindex});
				(function(_this){
					btn1.bind('click',function(){
						_this.destory(app);
						_this.options.success(false);
					});
					btn2.bind('click',function(){
						_this.destory(app);
						_this.options.success(true);
					});
				})(_this);
				break;
			case "toast":
				var app = $(yr_toast);
				var icon = ""
				if(this.options.icon == "success"){
					icon = yr_success;
				}
				if(this.options.icon == "error"){
					icon = yr_error;
				}
				if(this.options.icon == "none"){
					icon = "";
				}
				var title = $(yr_toast_title.replace("{{text}}",this.options.title))
				app.append(icon).append(title).append(loadMack);
				$("body").append(app);
				app.css({top:this.getCenterY(app.height()),left:this.getCenterX(app.width()),"z-index":zindex});
				(function(_this,app){
					setTimeout(function(){
						app.remove();
						_this.options.success(true);
					},_this.options.duration)
				})(_this,app);
				break;
			case "loading":
				var app = $(yr_showLoading);
				var title = $(yr_toast_title.replace("{{text}}",this.options.title))
				app.append(yr_load).append(title).append(loadMack);
				$("body").append(app);
				app.css({top:this.getCenterY(app.height()),left:this.getCenterX(app.width()),"z-index":zindex});
				break;
			case "notifi":
				var app = $(yr_notifi);
				var body = $(yr_notifi_body);
				var icon = "";
				var title = $(yr_notifi_title).html(this.options.title);
				var text = $(yr_notifi_text).html(this.options.content);
				var clostbtn = $(yr_notifi_icon);
				app.addClass(this.options.icon+"icon")
				body.append(title).append(text).append(clostbtn);
				app.append(body);
				$("body").append(app);
				this.notifiSort();
				(function(_this,app){
					clostbtn.bind('click',function(){
						app.removeClass("fadeInRight_qs100").addClass("yrfadeOut");
						setTimeout(function(){
							$.when(app.remove()).then(_this.notifiSort());
						},300)
					});
					setTimeout(function(){
						if(app){
							app.removeClass("fadeInRight_qs100").addClass("yrfadeOut");
							setTimeout(function(){
								$.when(app.remove()).then(_this.notifiSort());
							},300)
						}
					},_this.options.duration)
				})(_this,app);
				break;
			default:
				this.options.fail("还没有这个组件哦!");
				throw new Error('还没有这个组件哦!');
				break;
		}
	},
	//销毁事件
	destory:function(e){
		let _this = this;
		e.removeClass("yrzoomIn").addClass("yrzoomOut");
		(function(e){
		    setTimeout(function(){
		        e.remove();
				_this.hideMack();
		    },300)
		})(e);
	},
	//隐藏遮罩层
	hideMack:function(){
		$(".yr_mack").removeClass("show").addClass("hide");
	},
	//计算Y轴中心点位置
	getCenterY:function(height){
		var Winheight = $(window).height();
		return (Winheight - height) / 2;
	},
	//计算X轴中心点位置
	getCenterX:function(width){
		var Winwidth = $(window).width();
		return (Winwidth - width) / 2;
	}
}
// 重新定义alert
function alert(text){
	if(typeof text == "number"){text = text.toString()}
	app.alert(text);
}
function toast(text) {
	app.showToast({
		icon: "none",
		duration: 2000,
		title: text.toString(),
	});
}
function isArray(o){return Object.prototype.toString.call(o)== '[object Array]';}
function getImage(src,fn,i){
	var img = new Image();
	img.src = src;
	img.onload = function(){
		let item = {src:src,w:img.width,h:img.height}
		fn(item,i)
	}
}