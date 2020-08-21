/** 
 * 更多文档地址： https://www.showdoc.cc/805612872705921?page_id=4896699498255127
 * version : 0.0.2
 * 参数说明 
 * 		lang : 默认值 zh-cn （简体中文） 其他参数 zh-hk(繁体中文) en-us (英文)
 * 		Ajax : 是否阻止表单提交刷新 采用ajax方式提交表单
 * 		scroll : 错误时是否滚动到该input 屏幕中间位置 
 * 		blur : 是否在文本框失去焦点的时候进行验证
 * 		reglang :{} 错误提示的问题
 * 		regList :{} 部分验证用到的正则表达式
 * 		done : 验证成功的回调
 * 调用示例
 * $("form").form({
		options:{
			lang:"zh-cn",
			Ajax:true,
			scroll:false,
			blur:false
		},
		done:function(){
			// 在这里可以继续执行其他操作
		}
	})
 * 
*/

var erricon = '<svg t="1594267198815" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="1361" width="48" height="48"><path d="M664.96 630.4a32 32 0 0 1-22.4 54.72 32 32 0 0 1-22.72-9.28L506.56 562.56 393.6 675.84a32 32 0 0 1-22.72 9.28 32 32 0 0 1-22.72-9.28 32 32 0 0 1 0-45.44l113.28-112.96-113.28-113.28a32 32 0 0 1 0-45.12 32 32 0 0 1 45.44 0L506.56 472l113.28-112.96a32 32 0 1 1 45.12 45.12L552 517.44zM512 64a448 448 0 1 0 448 448A448 448 0 0 0 512 64z" p-id="1362" data-spm-anchor-id="a313x.7781069.0.i9" class="selected" fill="#F56C6C"></path></svg>'
var tipsapp = '<div class="tips yrani fadeInUp_qs100"></div>'
var tipstext = '<div class="tips_text"></div>'
var styles = '<style id="style">.tips{border: 1px solid #ebeef5;box-shadow: 0 2px 12px 0 rgba(0,0,0,.1);width: 200px;border-radius: 6px;padding: 10px;box-sizing: border-box;position: fixed;z-index: 9998;background-color: #fff;font-size: 0;-webkit-animation-fill-mode: both;animation-fill-mode: both;-webkit-animation-duration: .3s;animation-duration: .3s;}'+
'.tips::before{content: "";border-width: 6px;position: absolute;display: block;width: 0;height: 0;border-color: transparent;border-style: solid;top: -6px;margin-left: -6px;border-top-width: 0;border-bottom-color: #fff;}'+
'.tips::after{content: "";display: block;clear: both;}'+
'.tips svg{display: inline-block;vertical-align: middle;width: 30px;}'+
'.tips .tips_text{width: 78%;padding-left: 6px;display: inline-block;vertical-align: middle;color: #303133;font-size: 16px;box-sizing: border-box;word-wrap: break-word;}'+
'.tips.error .tips_text{color: #F56C6C;}</style>';

var form = {
	init:function(e,done,formid){
		if($("style[id=style]").length<=0){
			$("head").append(styles)
		}
		this.options = {
			lang:"zh-cn", //lang:"zh-hk",lang:"en-us"
			Ajax:false,//是否使用Ajax
			scroll:true,//是否自动滚动到input
			blur:false,// 是否失去焦点时进行验证
			reglang:{
				'zh-cn':{
					'required':"该选项不能为空",
					'checkbox':"请选择一项",
					'checkboxmin':"请最低选择{0}项",
					'checkboxmax':"最多只能选择{0}项",
					'email':"电子邮件格式错误",
					'phone':"手机号码格式错误",
					'number':"请输入正确的正整数",
					'min':"不能低于{0}位",
					'max':"不能高于{0}位",
					'repwd':"两次密码输入不一致"
				},
				'zh-hk':{
					'required':"該選項不能為空",
					'checkbox':"請選擇壹項",
					'checkboxmin':"請最低選擇{0}項",
					'checkboxmax':"最多只能選擇{0}項",
					'email':"電子郵件格式錯誤",
					'phone':"手機號碼格式錯誤",
					'number':"請輸入正確的數字",
					'min':"不能低於{0}位",
					'max':"不能高於{0}位",
					'repwd':"兩次密碼輸入不壹致"
				},
				'en-us':{
					'required':"This option cannot be empty",
					'checkbox':"Please select one",
					'checkboxmin':"Please select the lowest {0} item",
					'checkboxmax':"You can only select {0} items at most",
					'email':"Email format error",
					'phone':"Phone format error",
					'number':"Please enter the correct number",
					'min':"It cannot be lower than the {0} bit",
					'max':"Cannot be higher than the {0} bit",
					'repwd':"The two password inputs are inconsistent"
				}
			},
			regList:{
				email:/^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/,
				phone:/^1(3|4|5|6|7|8|9)\d{9}$/,
				number:/^[0-9]*[1-9][0-9]*$/,
			}
		}
		Object.assign(this.options,e);
		this.done = done;
		this.formId = formid;
		this.createform();
	},
	
	createform:function(){
		var _this = this;
		
		this.formId.bind('submit',function(e){
			var dom = _this.formId.find(":input");
			var flag = _this.formReg(dom);
			if(flag){_this.done(true);}else{return false;}
			return !_this.options.Ajax;
		})
		
		this.formId.find(":input").each(function(){
			switch($(this)[0].localName){
				case 'input':
					if($(this)[0].type == "checkbox"){
						// window[$(this).attr('name')] = window[$(this).attr('name')] ? window[$(this).attr('name')] : [];
						// window[$(this).attr('name')].push($(this));
						_this.notifyCheckbox($(this));
					}else if($(this)[0].type == "radio"){
						
					} else{
						_this.notifyInput($(this));
					}
					break;
				case 'button':
					_this.notifyButton($(this));
					break;
				case 'textarea':
					_this.notifyInput($(this));
					break;
				default:
					// 好困~！
					break;
			}
		})
	
	},
	
	formReg:function(dom){
		var _this = this;
		var flag = true;
		var idx = -1;
		for(var i = 0;i<dom.length;i++){
			idx = i;
			// 必填
			if(hasAttr(dom[i],"required") && $(dom[i])[0].type != 'checkbox' && $(dom[i])[0].type != 'radio'){
				if($.trim($(dom[i]).val()).length<1){
					_this.tips(dom[i],_this.options.reglang[_this.options.lang].required,$(dom[i]).attr("inputdom"));
					flag = false;
					break;
				}
			}
			//最大长度
			if($(dom[i]).attr("max") && $(dom[i])[0].type != 'checkbox' && $(dom[i])[0].type != 'radio'){
				if($(dom[i]).val().length > $(dom[i]).attr("max")){
					_this.tips(dom[i],_this.options.reglang[_this.options.lang].max.replace('{0}',$(dom[i]).attr("max")),$(dom[i]).attr("inputdom"));
					flag = false;
					break;
				}
			}
			//最小长度
			if($(dom[i]).attr("min") && $(dom[i])[0].type != 'checkbox' && $(dom[i])[0].type != 'radio'){
				if($(dom[i]).val().length < $(dom[i]).attr("min")){
					_this.tips(dom[i],_this.options.reglang[_this.options.lang].min.replace('{0}',$(dom[i]).attr("min")),$(dom[i]).attr("inputdom"));
					flag = false;
					break;
				}
			}
			// 邮箱
			if(hasAttr(dom[i],"email")){
				var reg = _this.options.regList.email;
				if(hasAttr(dom[i],"required")){
					if(!(reg.test($.trim($(dom[i]).val())))){
						_this.tips(dom[i],_this.options.reglang[_this.options.lang].email,$(dom[i]).attr("inputdom"));
						flag = false;
						break;
					}
				}else if($(dom[i]).val().length>=1){
					if(!(reg.test($.trim($(dom[i]).val())))){
						_this.tips(dom[i],_this.options.reglang[_this.options.lang].email,$(dom[i]).attr("inputdom"));
						flag = false;
						break;
					}
				}
			}
			// 手机
			if(hasAttr(dom[i],"phone")){
				var reg = _this.options.regList.phone;
				if(hasAttr(dom[i],"required")){
					if(!(reg.test($.trim($(dom[i]).val())))){
						_this.tips(dom[i],_this.options.reglang[_this.options.lang].phone,$(dom[i]).attr("inputdom"));
						flag = false;
						break;
					}
				}else if($(dom[i]).val().length>=1){
					if(!(reg.test($.trim($(dom[i]).val())))){
						_this.tips(dom[i],_this.options.reglang[_this.options.lang].phone,$(dom[i]).attr("inputdom"));
						flag = false;
						break;
					}
				}
			}
			// 整数型
			if(hasAttr(dom[i],"number")){
				var reg = _this.options.regList.number;
				if(hasAttr(dom[i],"required")){
					if(!(reg.test($.trim($(dom[i]).val())))){
						_this.tips(dom[i],_this.options.reglang[_this.options.lang].number,$(dom[i]).attr("inputdom"));
						flag = false;
						break;
					}
				}else if($(dom[i]).val().length>=1){
					if(!(reg.test($.trim($(dom[i]).val())))){
						_this.tips(dom[i],_this.options.reglang[_this.options.lang].number,$(dom[i]).attr("inputdom"));
						flag = false;
						break;
					}
				}
			}
			
			//多选框必选
			if($(dom[i]).attr("max") && $(dom[i])[0].type == 'checkbox'){
				if(_this.getCheckNumber($(dom[i])) > Number($(dom[i]).attr("max"))){
					_this.tips(dom[i],_this.options.reglang[_this.options.lang].checkboxmax.replace('{0}',$(dom[i]).attr("max")),$(dom[i]).attr("inputdom"));
					flag = false;
					break;
				}
			}
			if($(dom[i]).attr("min") && $(dom[i])[0].type == 'checkbox'){
				if(_this.getCheckNumber($(dom[i])) < Number($(dom[i]).attr("min"))){
					_this.tips(dom[i],_this.options.reglang[_this.options.lang].checkboxmin.replace('{0}',$(dom[i]).attr("min")),$(dom[i]).attr("inputdom"));
					flag = false;
					break;
				}
			}
			if(hasAttr(dom[i],"required") && $(dom[i])[0].type == 'checkbox'){
				if(_this.getCheckNumber($(dom[i])) < 1){
					_this.tips(dom[i],_this.options.reglang[_this.options.lang].checkbox,$(dom[i]).attr("inputdom"));
					flag = false;
					break;
				}
			}
			
		}
		
		if(_this.options.scroll && !flag){_this.scroll(dom[idx])}
		
		return flag;
	},
	
	tips:function(dom,text,input){
		if($(".tips[inputdom = "+input+"]").length<=0){
			var res = dom.getBoundingClientRect();
			var app = $(tipsapp);
			var t = $(tipstext);
			app.addClass("error").append(erricon).append(t.text(text)).css({
				"top":res.top + res.height,
				"left":res.x
			}).attr("inputdom",input);
			$("body").append(app);
		}
		$(window).resize(function(){
			if($(".tips[inputdom = "+input+"]").length>=1){
				$(".tips[inputdom = "+input+"]").each(function(){
					var res = dom.getBoundingClientRect();
					$(this).css({
						"top":res.top + res.height,
						"left":res.x
					})
				})
			}
		})
		$(window).scroll(function(){
			if($(".tips[inputdom = "+input+"]").length>=1){
				$(".tips[inputdom = "+input+"]").each(function(){
					var res = dom.getBoundingClientRect();
					$(this).css({
						"top":res.top + res.height,
						"left":res.x
					})
				})
			}
		})
	},
	
	notifyInput:function(e){
		var _this = this;
		e.attr("inputDom",e[0].name + e[0].localName + Math.floor(Math.random() * 100) + Math.floor(Math.random() * 300) )
		e.bind('input',function(event){
			// 文本输入
			if($(".tips[inputdom = "+e.attr("inputdom")+"]").length>=1){
				(function(e){
					$(".tips[inputdom = "+e.attr("inputdom")+"]").removeClass("fadeInUp_qs100").addClass("yrfadeOut")
					setTimeout(function(){
						$(".tips[inputdom = "+e.attr("inputdom")+"]").remove()
					},300)
				})(e);
			}
		})
		e.bind('focus',function(event){
			// 获取焦点
		})
		if(this.options.blur){
			e.bind('blur',function(event){
				// 失去焦点
				_this.formReg(e);
			})
		}
		
	},
	
	notifyCheckbox:function(e){
		window[$(e).attr('name')] = window[$(e).attr('name')] ? window[$(e).attr('name')] : e[0].name + e[0].localName + Math.floor(Math.random() * 100) + Math.floor(Math.random() * 300) ;
		$(e).attr("inputDom",window[$(e).attr('name')]);
		$(e).change(function() { 
			if($(".tips[inputdom = "+e.attr("inputdom")+"]").length>=1){
				(function(e){
					$(".tips[inputdom = "+e.attr("inputdom")+"]").removeClass("fadeInUp_qs100").addClass("yrfadeOut")
					setTimeout(function(){
						$(".tips[inputdom = "+e.attr("inputdom")+"]").remove()
					},300)
				})(e);
			}
		});
	},
	
	notifyButton:function(e){
		if(e.attr("sendmodel")){
			var _this = this;
			var model = e.attr("sendmodel");
			var func = e.attr("sendclick");
			var input = $("*[model= "+model+" ]");
			e.bind('click',function(){
				var f = _this.formReg(input);;
				if(f){
					eval(func)
				}
			})
		}
	},
	
	getCheckNumber:function(e){
		var name = $(e).attr("inputdom");
		var list = $("input[inputdom = "+name+"]");
		var cut = 0;
		for(var i = 0;i<list.length;i++){
			if($(list[i]).prop("checked")){cut++}
		}
		return cut;
	},
	
	scroll:function(e){
		var top = $(e).offset().top;
		var h = $(e).height();
		var wh = $(window).height();
		$("body,html").scrollTop(top - h - wh / 3);
	}
	
}

function hasAttr(obj, cls){
	var obj_class = obj.getAttribute('forms');
	var obj_class_lst = obj_class ? obj_class.split(/\s+/) : [];
	var x = 0;
	for(x in obj_class_lst) {
		if(obj_class_lst[x] == cls) {//循环数组, 判断是否包含cls
			return true;
		}
	}
	return false;
}

$.fn.form = function(e){
	form.init(e.options,e.done,$(this));
}