var cart = {
    init: function () {
        cart.registerEvents();
        cart.getProductCount();
    },
    registerEvents: function () {
        $('#btnAddToCart, i#btnAddToCart').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            cart.addItem(productId);
        });
    },
    addItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/Add',
            type: 'POST',
            dataType: 'json',
            data: {
                productId: productId
            },
            success: function (res) {
                if (res.status) {
                    cart.getProductCount();
                    $('.add-to-cart-success').delay(1000).fadeIn('slow').removeClass('hide');
                    $('.add-to-cart-success').delay(3000).fadeOut('slow');
                }
            }
        });
    },
    getProductCount: function () {
        var product_count = 0;
        $.ajax({
            url: '/ShoppingCart/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    $.each(data, function (i, item) {
                        product_count += item.Quantity;
                        cart.setProductCount(product_count);
                    });
                }
            }
        });
        return product_count;
    },
    setProductCount: function (num) {
        $('span.product-count').text(num);
    }
}
cart.init();