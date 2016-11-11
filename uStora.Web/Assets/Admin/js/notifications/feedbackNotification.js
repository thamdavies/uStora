$(function () {
    // Click on notification icon for show notification
    $('li.notifications-menu').off('click').on('click', function (e) {
        updateNotification();
    });

    // update notification 
    function updateNotification() {
        $('#noti-content').empty();
        $('#noti-content').append($('<li>Đang tải dữ liệu...</li>'));

        $.ajax({
            type: 'GET',
            url: '/Admin/GetNotificationFeedbacks',
            success: function (response) {
                $('#noti-content').empty();
                if (response.length == 0) {
                    $('span.noti-count').addClass('hide');
                    $('li.noti-status').html('Không có thông báo mới!');
                    $('#all-notification').addClass('hide');
                } else {
                    $('span.noti-count').removeClass('hide');
                    $('span.noti-count').html(response.length);
                    $.each(response, function (index, value) {
                        $('li.noti-status').html('Bạn có ' + response.length + ' thông báo.');
                        var html = "<li class='count-item'><a href='#'>" +
                            "<i class='fa fa-users text-aqua'></i>" +
                            " Phản hồi từ " + value.Name + " .</a> </li>";
                        $('#noti-content').append($(html));
                    });
                }
               
            },
            error: function (error) {
                console.log(error);
            }
        })
    }

    // signalr js code for start hub and send receive notification
    var notificationHub = $.connection.notificationHub;
    $.connection.hub.start().done(function () {
        console.log('Notification hub started');
        updateNotification();
    });

    //signalr method for push server message to client
    notificationHub.client.notify = function (message) {
        if (message && message.toLowerCase() == "added") {
            updateNotification();
        }
    }

})