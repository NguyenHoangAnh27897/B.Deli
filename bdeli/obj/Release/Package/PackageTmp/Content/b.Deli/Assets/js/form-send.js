$( document ).ready(function() {

    $( '.booking-form form' ).on( 'submit', function(event) {
        event.preventDefault();
        //Get data
        const token = $('input[type="hidden"]').val();
        const clientName = ($('#client-name').val());
        const clientMail = ($('#client-email').val());
        const clientTel = ($('#client-tel').val());
        const guestNo = ($('#guest').val());
        const bookingDate = ($('#booking-date').val());
        const bookingTime = ($('#booking-hour').val() + ":" + $('#booking-minutes').val() + " " + $('#booking-type').val());
        const clientMessage = ($('#client-message').val());
        //Json
        const data = {
            name: clientName,
            email: clientMail,
            tel: clientTel,
            date: bookingDate,
            time: bookingTime,
            amount: parseInt(guestNo),
            note: clientMessage
        };
        if (clientName != '' && clientTel != '' && clientMail != '' && bookingDate != '' && bookingTime != '' && guestNo != '') {
            $.ajax({
                async: true, 
                data: JSON.stringify(data),
                type: 'POST',
                url: '/home/save',
                dataType: "json",
                contentType: "application/json",
                cache: false,
                error: function (data) {
                    console.log('error:' + data + ';' + JSON.stringify(data, null, 4));
                    $('.form-response').html('Vui lòng nhập đúng, đầy đủ các thông tin trên.');                                   
                },
                success: function (data) {
                    $('#client-name').val('');
                    $('#client-email').val('');
                    $('#booking-date').val('');
                    $('#booking-hour').val('');
                    $('#booking-minutes').val('');
                    $('#booking-type').val('');
                    $('#client-tel').val('');
                    $('#guest').val('');
                    $('#client-message').val('');
                    $('.form-response').html('Cảm ơn bạn đã yêu cầu đặt trước. Chúng tôi sẽ sớm liên lạc lại với bạn!');
                }
            });
        }

    });  

});