$(function () {
    $('a[href="#search"]').on('click', function(event) {
        event.preventDefault();
        $('#search').addClass('open');
        $('#search > form > input[type="text"]').focus();
    });
    
    $('#search, #search button.close').on('click keyup', function(event) {
        if (event.target == this || event.target.className == 'close' || event.keyCode == 27) {
            $(this).removeClass('open');
        }
    });
    
    
    // $(window).resize(function(){
    //     var boxWidth = $(window).width();
    //         $('input[type="search"]').css({"width": boxWidth});
    //         return false;
    // })
    
    //Do not include! This prevents the form from submitting for DEMO purposes only!
    $('form').submit(function(event) {
        event.preventDefault();
        return false;
    });

     $("body").tooltip({ selector: '[data-toggle=tooltip]' });
});