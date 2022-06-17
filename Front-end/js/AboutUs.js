//$(document).ready(function () {
//    getAboutUs();
//    });
//function getAboutUs() {
//    $.ajax({
//        url: 'https://localhost:44366/api/AboutUs',
//        method: 'GET',
//        contentType: 'application\json',
//        dataType: 'json',
//        error: function (response) {},
//        success: function (response) {
//            const len = response.length;

//            console.log(response);
//            let table = '';
//            for (var i = 0; i < len; i++) {
//                table = table + '<tr>';
//                table = table + '<td>' + response[i].Hotline + '</td>';
//                table = table + '<td>' + response[i].DiaChi + '</td>';
//                table = table + '<td>' + response[i].LienLac + '</td>';
//                table = table + '</tr>';

//            }

//            $("#allContact").append(table)
//        },
//        fail: function (response) {}
//    });
//    }



$(document).ready(function () {
    getHotline();
});
function getHotline() {
    $.ajax({
        url: 'https://localhost:44366/api/AboutUs',
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (response) {
            const len = response.length;

            console.log(response);
            let string = '';
            for (var i = 0; i < len; i++) {
                string += response[i].Hotline;

            }

            $("#getHotline").append(string)
        },
        fail: function (response) { }
    });
}



$(document).ready(function () {
    getDiaChi();
});
function getDiaChi() {
    $.ajax({
        url: 'https://localhost:44366/api/AboutUs',
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (response) {

            const len = response.length;

            console.log(response);
            let string = '';
            for (var i = 0; i < len; i++) {
                string += response[i].DiaChi;

            }

            $("#getDiaChi").append(string)
        },
        fail: function (response) { }
    });
}

$(document).ready(function () {
    getLienLac();
});
function getLienLac() {
    $.ajax({
        url: 'https://localhost:44366/api/AboutUs',
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (response) {
            const len = response.length;

            console.log(response);
            let string = '';
            for (var i = 0; i < len; i++) {
                string += response[i].LienLac;

            }

            $("#getLienLac").append(string)
        },
        fail: function (response) { }
    });
}