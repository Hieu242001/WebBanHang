$(document).ready(function () {
    getHDB();
});
var customer = JSON.parse(localStorage.getItem('user'))
function getHDB() {
    $.ajax({
        url: 'https://localhost:44366//api/HDB/' + customer.ID_KhachHang,
        //+ customer.ID_KhachHang',
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (response) {
            const len = response.length;
            console.log(response)
            let table = ''
            for (var i = 0; i < len; i++) {
                let money = response[i].Soluong * response[i].DonGia
                table = table + '<tr>';
                table = table + '<td>' + response[i].TenSanPham + '</td>';
                table = table + '<td>' + response[i].NgayLapHDB + '</td>';
                table = table + '<td>' + response[i].DonGia.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }); + '</td>';
                table = table + '<td>' + response[i].Soluong + '</td>';
                table = table + '<td>' + money.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }); + '</td>';

                table = table + '</tr>';
            }
            $("#HDB").append(table)
        },
        fail: function (response) { }
    });

}