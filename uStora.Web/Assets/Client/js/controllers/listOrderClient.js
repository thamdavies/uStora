var listOrder = {
    init: function () {
        listOrder.eventRegisters();
    },
    eventRegisters: function () {
        listOrder.loadOrderList();
    },
    loadOrderList: function () {
        $.ajax({
            url: '/ShoppingCart/GetListOrder',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#templateListCart').html();
                    var html = '';
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductName: item.Name,
                            ProductId: item.ProductId,
                            Image: item.Image,
                            FPrice: numeral(item.Price).format('0,0'),
                            Quantity: item.Quantity,
                            Alias: item.Alias,
                            PaymentStatus: (item.PaymentStatus == 0 ? "Chờ duyệt": "Đang chuyển hàng")
                        });
                    });
                    $('#listCartBody').html(html);
                    cart.registerEvents();
                }
            }
        });
    }
}
listOrder.init();

