var ROUTESKEY = "YR_"
var routes = {
	init : function(){
		this.routes = this.keyListGet("ROUTE") ? this.keyListGet("ROUTE") : [];
		this.routes.push(window.location.pathname);
		this.keyListSet("ROUTE",Array.from(new Set(this.routes)));
		console.log(this.keyListGet("ROUTE"));
	},
	back : function(){
		var arr = this.keyListGet("ROUTE");
		var url = arr[arr.length - 1] ? arr[arr.length - 1] : '/';
		window.location.href = url;
	},
	// 获取指定key的list
	keyListGet : function(key){
		try{
			var str = localStorage.getItem(ROUTESKEY + key);
			if(str == undefined || str == null || str =='' || str == 'undefined' || typeof(JSON.parse(str)) == 'string'){
				str = '[]';
			}
			return JSON.parse(str);
		}catch(e){
			return [];
		}
	},
	// 将list写入到key中
	keyListSet : function(key, list){
		localStorage.setItem(ROUTESKEY + key, JSON.stringify(list));
	},
	// 添加一个list到key中
	keyListAdd : function(key, list){
		var arr = this.keyListGet(key);
		arr.push(list);
		this.keyListSet(key,arr);
	},
	// 将一个list从key中移除
	keyListRemove : function(key, list){
		var arr = this.keyListGet(key);
		var index = arr.indexOf(list);
		if (index > -1) {
		    arr.splice(index, 1);
		}
		this.keyListSet(key,arr);
	}
}
$(function(){
	routes.init();
})
function back(){
	routes.back();
}