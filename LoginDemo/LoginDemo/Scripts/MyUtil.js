function set_cookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        //date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        date.setTime(date.getTime() + (1 * 1 * 1 * 10 * 1000)); // 10s
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

function get_cookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function delete_cookie(name) {
    document.cookie = name + '=; Max-Age=-99999999;';
}