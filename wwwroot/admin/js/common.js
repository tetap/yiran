$(function () {
    var wpan = JSON.parse(localStorage.getItem("tab_list"));
    if (wpan[$(window.frameElement).attr("tab-id")]) {
        $(".p_name").text(wpan[$(window.frameElement).attr("tab-id")].pname)
        $(".c_name").text(wpan[$(window.frameElement).attr("tab-id")].title)
    }
})
// 获取url参数 getUrlQuery("id")
function getUrlQuery(name) {
    let reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    if (window.location.href.indexOf("?") < 0) {
        return null;
    }
    let r = window.location.href.split("?")[1].match(reg);
    if (r != null) return decodeURIComponent(r[2]);
    return null;
}