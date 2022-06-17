$(document).ready(function () {
    getCart();
});
var customer = JSON.parse(localStorage.getItem('user'))
function getCart() {
    $.ajax({
        url: 'https://localhost:44366//api/cart/' + customer.ID_KhachHang,
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (response) {
            const len = response.length;
            
            let table = ''
            $("#list_Products").empty()
            let total = 0
            
            for (var i = 0; i < len; i++)
            {
                let money = response[i].Soluong * response[i].Gia
                console.log(response[i].Id)
                //console.log(response[i].Id_hd + " " + response[i].Id)
                let id = parseInt(response[i].Id_hd);
                total += money
                money = money.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                table += `<tr>
                                            <td class="product_remove"><div onclick="delete_element(${response[i].Id},${id})" style="cursor:pointer"><i class="fa fa-trash-o"></i></div>
                                            </td>
                                            <td class="product_thumb"><a href="#" ><img
                                                        src="assets/image/${response[i].Image}" alt=""></a></td>
                                            <td class="product_name"><a href="product-details.html" onclick="setProduct(${response[i].Id})">${response[i].TenSP}</a></td>
                                            <td class="product-price">${response[i].Gia.toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</td>
                                            <td class="product_quantity"><label>Quantity</label> <input min="1"
                                                    max="100" value="${response[i].Soluong}" type="number"></td>
                                            <td class="product_total">${money}</td>


                                        </tr>`
               
            }
            $("#list_Products").append(table)
            total = total.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
            $("#amount").html(total)
            
        },
        fail: function (response) { }
    });
}
function setProduct(id_sp) {
    if (parseInt(id_sp) < 10) id_sp = "0" + id_sp
    localStorage.setItem('sp', id_sp)
}
function delete_element(id_sp,id_hd) {
   
    $.ajax({
        url: 'https://localhost:44366//api/cart?id_hd=' + id_hd + '&id_sp=' + id_sp,
        method: 'DELETE',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (response) {

            console.log(response)
            getCart();
        },
        fail: function (response) { }
    });
}

function thanhtoan() {
    $.ajax({
        url: 'https://localhost:44366//api/bill?id=' + customer.ID_KhachHang,
        method: 'PUT',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (response) {

            alert("Thanh toan thanh cong")
            getCart();
            createBill()
        },
        fail: function (response) { }
    });
}

function createBill() {
    $.ajax({
        url: 'https://localhost:44366/api/bill?id_KH=' + customer.ID_KhachHang,
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (response) {

            //console.log(response)
            localStorage.setItem('hd', JSON.stringify(response))


        },
        fail: function (response) { }
    });
}