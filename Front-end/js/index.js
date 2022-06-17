$(document).ready(function () {
    getAllProducts()
    if (localStorage.getItem('hd') === null) createBill()
});
var customer = JSON.parse(localStorage.getItem('user'))
function getAllProducts() {
    $.ajax({
        url: 'https://localhost:44366//api/product',
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (response) {
            //console.log(response)
            const len = response.length;
            let product = ''
            let newDiv = document.createElement("div")
            newDiv.classList.add("col-lg-3")
            let product_items = document.createElement("div")
            product_items.classList.add("product_items")
            newDiv.append(product_items)
            let check = 0
            let item = ''
            for (let i = 0; i < len; i++) {

                item += `<article class="single_product" style = "margin : auto">
                                    <figure>
                                        <div class="product_thumb">
                                            <a class="primary_img" href="product-details.html" onclick="storeData(${response[i].Id})"><img
                                                    src="assets/image/${response[i].Image}" alt=""></a>

                                            <div class="action_links">
                                                <ul>
                                                    <li class="add_to_cart"><a href="cart.html" title="Add to cart"><i
                                                                class="icon-shopping-bag"></i></a></li>

                                                    <li class="wishlist"><a href="wishlist.html"
                                                            title="Add to Wishlist"><i class="icon-heart"></i></a></li>
                                                    <li class="quick_button"><a href="#" data-bs-toggle="modal"
                                                            data-bs-target="#modal_box" title="quick view"> <i
                                                                class="icon-eye"></i></a></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <figcaption class="product_content">
                                            <div class="product_rating">
                                                <ul>
                                                    <li><a href="#"><i class="icon-star"></i></a></li>
                                                    <li><a href="#"><i class="icon-star"></i></a></li>
                                                    <li><a href="#"><i class="icon-star"></i></a></li>
                                                    <li><a href="#"><i class="icon-star"></i></a></li>
                                                    <li><a href="#"><i class="icon-star"></i></a></li>
                                                </ul>
                                            </div>
                                            <h4 class="product_name"><a href="product-details.html">${response[i].TenSP}</a></h4>
                                            <div class="price_box">
                                                <span class="current_price">${response[i].Gia}</span>

                                            </div>
                                        </figcaption>
                                    </figure>
                                </article>`
               
                check++;
                if (check == 2) {
                    product_items.innerHTML = item
                    item = ''
                    $("#items").append(newDiv)
                    newDiv = document.createElement("div")
                    newDiv.classList.add("col-lg-3")
                    product_items = document.createElement("div")
                    product_items.classList.add("product_items")
                    newDiv.append(product_items)
                    check = 0
                }
                
            }
            
            //$("items").innerHTML = product
            
        },
        fail: function (response) { }
    });

}
function storeData(data) {
    localStorage.setItem('sp', null)
    if (data < 10) data = '0' + data
    localStorage.setItem('sp', data)
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