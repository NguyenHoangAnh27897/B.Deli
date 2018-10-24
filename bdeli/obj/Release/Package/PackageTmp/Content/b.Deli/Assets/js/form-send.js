$( document ).ready(function() {

    $( '.booking-form form' ).on( 'submit', function(event) {
        event.preventDefault();

        var clientName=$('#client-name').val();
        var clientMail=$('#client-email').val();
        var bookingDate=$('#booking-date').val();
        var bookingTime=$('#booking-time').val();
        var guestNo=$('#guest').val();
        var clientMessage=$('#client-message').val();

        if( clientName != '' && clientMail != '' && bookingDate != '' && bookingTime != ''  && guestNo != '' ) {
            $.ajax({
                data: "client-name=" + clientName + "&client-email=" + clientMail + "&booking-date=" + bookingDate + "&booking-time=" + bookingTime + "&guest=" + guestNo + "&client-message=" + clientMessage,
                type: 'POST',
                url: 'assets/php/booking-sendmail.php',
                //dataType: "json",
                error: function (data) {
                    console.log('error:' + data + ';' + JSON.stringify(data, null, 4));
                    $('.form-response').html('Something went wrong!');                                   
                },
                success: function (data) {
                    $('#client-name').val('');
                    $('#client-email').val('');
                    $('#booking-date').val('');
                    $('#booking-time').val('');
                    $('#guest').val('');
                    $('#client-message').val('');
                    $('.form-response').html('Thank you for your reservation request. We will get back to you shortly!');
                }
            });
        }

    });  

});