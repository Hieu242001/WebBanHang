function login() {
    
    $.ajax({
        url: 'https://localhost:44366//api/customers/' + $("#user-name").val(),
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) {
            alert('Lỗi đăng nhập');
        },
        success: function (response) {
            localStorage.setItem('user', null)
            if (response == null) {
                alert('Tài khoản không tồn tại')
            }
            if (response.MatKhau.trim() == $("#pass").val()) {

                createBill(response.ID_KhachHang)
                alert('Đăng nhập thành công');
                
                
                localStorage.setItem("user", JSON.stringify(response))
                window.location.href = './index-2.html'
            }
            else {
                alert('Mật khẩu không chính xác')
            }
        },
        fail: function (response) {
            alert('Không tồn tại tài khoản');
        }
    });
}

function signup() {
    
    if (!$("#matkhau").val().trim() || !$("#full_name").val().trim() || !$("#acc").val().trim() || !$("#address").val().trim() || !$("#full_name").val().trim()) {
        alert('Khong duoc bo trong thong tin tai khoan')

    }
    else {
        $.ajax({
            url: 'https://localhost:44366/api/customers?fullName=' + $("#full_name").val() + '&phone=' + $("#acc").val() + '&address=' + $("#address").val()
                + '&pass=' + $("#matkhau").val(),
            method: 'POST',
            contentType: 'application\json',
            dataType: 'json',
            error: function (response) {
                alert("Them tai khoan that bai")
            },
            success: function (response) {
                console.log(response)
                if (response == 0) {
                    alert("So dien thoai da ton tai trong he thong!Vui long thay doi so dien thoai")
                }
                else {
                    alert("Dang ky thanh cong ")
                }
            },
            fail: function (response) {
                alert("Them tai khoan that bai")
            }
        });
    }
    
}

function createBill(response) {
    console.log(response)
    $.ajax({
        url: 'https://localhost:44366/api/bill?id_KH=' + response,
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (response) {
            localStorage.setItem('hd', null)
            //console.log(response)
            //localStorage.setItem('hd', null)
            localStorage.setItem('hd', JSON.stringify(response))


        },
        fail: function (response) { }
    });
}