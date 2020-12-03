$(function () {
    var proModal = $(".single-product-item .pro-modal")
    proModal.click(function () {
        var proId = $(this).attr("pro-id")
        $.ajax({
            url: "/Products/ProDetail/" + proId,
            method: "Post",
            dataType: "HTML",
            success: function (res) {
                console.log(res);
                $("#myProModal").html(res);
            }
        })
    })
})

$(function () {
    var getCookieVal;
    if (Cookies.get("CartProduct") != null && Cookies.get("CartProduct") != "undefined" && Cookies.get("CartProduct")!="") {
        getCookieVal = [...Cookies.get("CartProduct").split("-")]
    }
    let productIDS = getCookieVal ?? [];
    $(".addToCart").click(function () {
        const proId = $(this).attr("pro-id");
        productIDS.push(proId)
        Cookies.set("CartProduct", productIDS.join("-"), { expires: 7 })
        Swal.fire(
            'Card !',
            'Product added successfully!',
            'success'
        )
    })
})