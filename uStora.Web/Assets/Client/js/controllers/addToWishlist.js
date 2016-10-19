var wishlist = {
    init: function () {
        wishlist.registerEvents();
    },
    registerEvents: function () {
        $('i#btnAddWishlist').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            wishlist.addWishlist(productId);
        });
    },
    addWishlist: function (productId) {
        $.ajax({
            url: '/Wishlist/Add',
            type: 'POST',
            dataType: 'json',
            data: {
                productId: productId
            },
            success: function (res) {
                if (res.status == 1)
                    toastr.success('Đã thêm vào mục yêu thích.');
                else
                    if (res.status == 2)
                        toastr.warning(res.message);
                    else
                        toastr.error('Thêm vào mục yêu thích không thành công.');
            }
        });
    }
}
wishlist.init();