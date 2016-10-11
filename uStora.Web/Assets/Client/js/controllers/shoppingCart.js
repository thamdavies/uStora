var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvents();
    },
    registerEvents: function () {
        $('#btnRemoveItem').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            cart.deleteItem(productId);
        });
        $('.txtQuantity').off('keyup').on('keyup', function (e) {
            var quantity = parseInt($(this).val());
            var productId = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (!isNaN(quantity)) {
                var amount = quantity * price;
                $('#amount_' + productId).text(numeral(amount).format('0,0'));
                $('span.product-count').text(cart.getTotalOrder().quantity);
                $('#ltlTotalOrder').text(numeral(cart.getTotalOrder().amount).format('0,0'));
                $('#amount').text(numeral(cart.getTotalOrder().amount).format('0,0'));
            }
            else {
                $('#amount_' + productId).text(0);
                $('span.product-count').text(0);
                $('#ltlTotalOrder').text(0);
                $('#amount').text(0);
            }

        });
    },
    getTotalOrder: function () {
        var listTextbox = $('.txtQuantity');
        var total = {
            amount: 0,
            quantity: 0
        };
        $.each(listTextbox, function (i, item) {
            total.amount += parseInt($(item).val()) * parseFloat($(item).data('price'));
            total.quantity += parseInt($(item).val());
        });
        return total;
    },
    loadData: function () {
        $.ajax({
            url: '/ShoppingCart/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#templateCart').html();
                    var html = '';
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductId: item.ProductId,
                            ProductName: item.Product.Name,
                            Image: item.Product.Image,
                            Price: item.Product.Price,
                            FPrice: numeral(item.Product.Price).format('0,0'),
                            Quantity: item.Quantity,
                            Alias: item.Product.Alias,
                            Amount: numeral(item.Quantity * item.Product.Price).format('0,0'),
                        });
                    });
                    $('#cartBody').html(html);
                    $('#ltlTotalOrder').text(numeral(cart.getTotalOrder().amount).format('0,0'));
                    $('#amount').text(numeral(cart.getTotalOrder().amount).format('0,0'));
                    $('span.product-count').text(cart.getTotalOrder().quantity);
                    cart.registerEvents();
                }
            }
        })
    },
    deleteItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/DeleteItem',
            type: 'POST',
            dataType: 'json',
            data: {
                productId: productId
            },
            success: function (res) {
                if (res.status) {
                    alert("Xóa sản phẩm thành công.");
                    cart.loadData();
                }
            }
        })
    },
    setProductCount: function (num) {

    }
}
cart.init();