function set_cookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        //date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000)); // 1day
        date.setTime(date.getTime() + (1 * 1 * 1 * 10 * 1000)); // 10s
        expires = "; expires=" + date.toUTCString();
    }
    window.document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

function get_cookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) === 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

//function delete_cookie(name, sDomain, sPath) {
//    //document.cookie = name + '=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
//    document.cookie = encodeURIComponent(name) +
//        "=; expires=Thu, 01 Jan 1970 00:00:00 GMT" +
//        (sDomain ? "; domain=" + sDomain : "") +
//        (sPath ? "; path=" + sPath : "");
//}

function delete_cookie(cname) {
    var d = new Date();
    d.setTime(d.getTime() - (1000 * 60 * 60 * 24));
    var expires = "expires=" + d.toGMTString();
    window.document.cookie = cname + "=" + "; " + expires + "; path=/";
}


