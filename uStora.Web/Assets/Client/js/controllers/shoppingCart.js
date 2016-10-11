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
        $('#btnContinute').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/";
        });
        $('#btnUpdate').off('click').on('click', function (e) {
            e.preventDefault();
            cart.updateCart();
        });
        $('#btnCheckout').off('click').on('click', function (e) {
            e.preventDefault();
            $('.bangthanhtoan').removeClass('hide');
            $('html, body').animate({
                scrollTop: $("#bangthanhtoan").offset().top
            }, 1000);
        });
        $('#btnDeleteAll').off('click').on('click', function (e) {
            e.preventDefault();
            cart.deleteAll("load");
        });
        $('#btnLoadUserInfo').off('click').on('click', function () {
            if ($(this).prop('checked')) {
                cart.getUserInfo();
                $(this).hide();
                $('#LoadUserInfo label').hide();
            }
            else {
                cart.resetValue();
                //window.location.reload();
                //$("html, body").animate({ scrollTop: 0 }, 500);
            }

        });
        $('#frmCheckout').bootstrapValidator({
            // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                fullname: {
                    validators: {
                        stringLength: {
                            min: 2,
                            message: "Nhập nhiều hơn 2 ký tự",
                        },
                        notEmpty: {
                            message: 'Vui lòng nhập họ tên'
                        },
                        stringLength: {
                            max: 100,
                            message: "Nhập không quá 100 ký tự",
                        }
                    }
                },

                email: {
                    validators: {
                        notEmpty: {
                            message: 'Vui lòng nhập địa chỉ Email'
                        },
                        emailAddress: {
                            message: 'Địa chỉ Email không hợp lệ'
                        },
                        stringLength: {
                            max: 100,
                            message: "Nhập không quá 100 ký tự",
                        }
                    }
                },
                phone: {
                    validators: {
                        notEmpty: {
                            message: 'Vui lòng nhập số điện thoại'
                        },
                        stringLength: {
                            min: 2,
                            message: "Nhập nhiều hơn 2 ký tự",
                        },
                        stringLength: {
                            max: 50,
                            message: "Nhập không quá 50 ký tự",
                        }
                    }
                },
                address: {
                    validators: {
                        notEmpty: {
                            message: 'Vui lòng nhập địa chỉ'
                        },
                        stringLength: {
                            min: 2,
                            message: "Nhập nhiều hơn 2 ký tự",
                        },
                        stringLength: {
                            max: 250,
                            message: "Nhập không quá 250 ký tự",
                        }
                    }
                },

                comment: {
                    validators: {
                        stringLength: {
                            min: 5,
                            message: 'Vui lòng nhập nội dung nhiều hơn 5 ký tự'
                        },
                        notEmpty: {
                            message: 'Vui lòng nhập nội dung tin nhắn'
                        }
                    }
                }
            }
        }).on('success.form.bv', function (e) {
            cart.createOrder();
        });
    },
    resetValue: function () {
        $('#fullname').val('');
        $('#email').val('');
        $('#phone').val('');
        $('#address').val('');
        $('#message').val('');
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
    getUserInfo: function () {
        $.ajax({
            url: '/ShoppingCart/GetUserInfo',
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var user = res.data;
                    $('#fullname').val(user.FullName);
                    $('#email').val(user.Email);
                    $('#phone').val(user.PhoneNumber);
                    $('#address').val(user.Address);
                }
            }
        })
    },
    createOrder: function () {
        var order = {
            CustomerName: $('#fullname').val(),
            CustomerEmail: $('#email').val(),
            CustomerAddress: $('#address').val(),
            CustomerMobile: $('#phone').val(),
            PaymentMethod: "Thanh toán tiền mặt",
            CustomerMessage: $('#message').val(),
            PaymentStatus: false,
            Status: true
        }
        $.ajax({
            url: '/ShoppingCart/CreateOrder',
            type: 'POST',
            dataType: 'json',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            success: function (res) {
                if (res.status) {
                    $('.bangthanhtoan').addClass('hide');
                    cart.deleteAll("");
                    setTimeout(function () {
                        $('#tblCartTable').html('<h4 class="text-center text-success">Chúc mừng!!! Bạn đã đặt hàng thành công. Bạn hãy để ý điện thoại của bạn... chúng tôi sẽ gọi lại cho bạn sớm nhất có thể.</h4>');
                        $('html, body').animate({
                            scrollTop: $("#product-big-title-area").offset().top
                        }, 1000);
                    }, 2000);

                }
            }
        })
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
                    if (html == '') {
                        $('#tblCartTable').html('<h4 class="text-center text-danger">Không có sản phẩm nào trong giỏ hàng.</h4>');
                    }
                    $('#ltlTotalOrder').text(numeral(cart.getTotalOrder().amount).format('0,0'));
                    $('#amount').text(numeral(cart.getTotalOrder().amount).format('0,0'));
                    $('span.product-count').text(cart.getTotalOrder().quantity);
                    cart.registerEvents();
                }
            }
        })
    },
    updateCart: function () {
        var cartListModel = [];
        $.each($('.txtQuantity'), function (i, item) {
            cartListModel.push({
                ProductId: $(item).data('id'),
                Quantity: $(item).val()
            })
        });

        $.ajax({
            url: '/ShoppingCart/Update',
            dataType: 'json',
            type: 'POST',
            data: {
                cartData: JSON.stringify(cartListModel)
            },
            success: function (res) {
                if (res.status) {
                    cart.loadData();
                    alert('Cập nhật thành công');
                }
            }
        });
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
                    alert("Sản phẩm được xóa khỏi giỏ hàng.");
                    cart.loadData();
                }
            }
        })
    },
    deleteAll: function (load) {
        $.ajax({
            url: '/ShoppingCart/DeleteAll',
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    if (load == "load") {
                        alert("Giỏ hàng đã được làm mới.");
                    }
                    cart.loadData();
                }
            }
        })
    },
    setProductCount: function (num) {
    }
}
cart.init();