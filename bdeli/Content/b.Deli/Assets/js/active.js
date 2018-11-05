var loadCart;
var orderArr = Object.assign([], JSON.parse(localStorage.getItem('order')));

(function ($) {
    "use strict";

    $(document).ready(function () {
        const $cart = $("tbody.tbodyCart");
        const $count = $("small.counter");
        const $order = $("button.order");
        // Our Menu Sliding Tab
        $('.menu-slider').owlCarousel({
            items: 1,
            animateOut: 'slideOutDown',
            animateIn: 'flipInX',
            loop: true,
            lazyLoad: true,
            margin: 10,
            nav: false,
            dots: true,
            autoplay: false,
            mouseDrag: false,
            touchDrag: false,
            dotsContainer: '.dotsCont'
        });

        $('.owl-dot').click(function () {
            $('.menu-slider').trigger('to.owl.carousel', [$(this).index(), 300]);
        });

        $('.menu-slider-2').owlCarousel({
            items: 1,
            animateOut: 'slideOutDown',
            animateIn: 'flipInX',
            loop: true,
            lazyLoad: true,
            margin: 10,
            nav: false,
            dots: true,
            autoplay: true,
            mouseDrag: false,
            touchDrag: false,
            dotsContainer: '.dotsCont-2'
        });

        $('.owl-dot').click(function () {
            $('.menu-slider-2').trigger('to.owl.carousel', [$(this).index(), 300]);
        });

        // Testimonial Slider
        $(".typeGift").owlCarousel({
            items: 1,
            nav: true,
            dots: false,
            autoplay: false,
            animateOut: 'slideOutDown',
            animateIn: 'flipInX',
            loop: true,
            navText: [$('i.type_prev'), $('i.type_next')],
            mouseDrag: false,
            touchDrag: false,
        });

        $(".paginate_call").owlCarousel({
            items: 1,
            nav: true,
            dots: false,
            autoplay: false,
            animateOut: 'slideOutDown',
            animateIn: 'flipInX',
            loop: true,
            navText: [$('i.pagination_prev'), $('i.pagination_next')],
            mouseDrag: false,
            touchDrag: false,
        });

        // Popup Gallery
        $(".gallery-lightbox").magnificPopup({
            type: 'image',
            gallery: {
                enabled: true
            }
        });

        $(".menu-lightbox").magnificPopup({
            type: 'image',
            gallery: {
                enabled: true
            }
        });

        // Responsive Menu
        $("ul#navigation").slicknav({
            prependTo: ".responsive-menu-wrap"
        });

        // Section Animations
        new WOW().init();

        // Smooth Scroll
        var scroll = new SmoothScroll('a[href*="#"]');

        // Show or hide the sticky footer button
        $(window).on("scroll", function () {
            if ($(this).scrollTop() > 200) {
                $('.go-top').fadeIn(200);
            } else {
                $('.go-top').fadeOut(200);
            }
        });

        // Custom Scroll Spy
        $(window).on('scroll', function () {
            $('div[scroll-spy="true"]').each(function () {
                if ($(window).scrollTop() >= $(this).offset().top - 85) {
                    var id = $(this).attr('id');
                    $('.main-menu li a').parent('li').removeClass('active');
                    $('.main-menu li a[href="#' + id + '"]').parent('li').addClass('active');
                }
            });
        });

        // Instagram Setting
        //$(function () {
        //    var userFeed = new Instafeed({
        //        get: 'user',
        //        userId: '2005102763', // Your User Id here 
        //        accessToken: '2005102763.3a81a9f.11972442d69d4f7f861171e947a22ea9', // Access token here
        //        resolution: 'thumbnail',
        //        template: '<a href="{{link}}" target="_blank" id="{{id}}"><img src="{{image}}" /></a>',
        //        sortBy: 'most-recent',
        //        limit: 3,
        //        links: false
        //    });
        //    userFeed.run();
        //});

        //Fanpage Setting
        (function(d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = 'https://connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v3.2&appId=179319576211993&autoLogAppEvents=1';
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));

        // Google Map Setting
        $(function () {
            var map = new GMaps({
                el: "#map1",
                lat: 10.811830, //To show your address on above Map, change the Latitude from here.
                lng: 106.664841, //To show your address on above Map, change the Longitude from here.
                zoom: 15,
                styles: [
                {
                    "featureType": "all",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "all",
                    "elementType": "labels.text.fill",
                    "stylers": [
                        {
                            "saturation": 36
                        },
                        {
                            "color": "#000000"
                        },
                        {
                            "lightness": 40
                        }
                    ]
                },
                {
                    "featureType": "all",
                    "elementType": "labels.text.stroke",
                    "stylers": [
                        {
                            "visibility": "on"
                        },
                        {
                            "color": "#000000"
                        },
                        {
                            "lightness": 16
                        }
                    ]
                },
                {
                    "featureType": "all",
                    "elementType": "labels.icon",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "administrative",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "color": "#000000"
                        },
                        {
                            "lightness": 20
                        }
                    ]
                },
                {
                    "featureType": "administrative",
                    "elementType": "geometry.stroke",
                    "stylers": [
                        {
                            "color": "#000000"
                        },
                        {
                            "lightness": 17
                        },
                        {
                            "weight": 1.2
                        }
                    ]
                },
                {
                    "featureType": "administrative.country",
                    "elementType": "labels.text.fill",
                    "stylers": [
                        {
                            "color": "#000000"
                        }
                    ]
                },
                {
                    "featureType": "administrative.locality",
                    "elementType": "labels.text.fill",
                    "stylers": [
                        {
                            "color": "#8d8d8d"
                        }
                    ]
                },
                {
                    "featureType": "administrative.neighborhood",
                    "elementType": "labels.text.fill",
                    "stylers": [
                        {
                            "color": "#f3db2e"
                        }
                    ]
                },
                {
                    "featureType": "landscape",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#000000"
                        },
                        {
                            "lightness": 20
                        }
                    ]
                },
                {
                    "featureType": "poi",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#000000"
                        },
                        {
                            "lightness": 21
                        },
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "poi.business",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "road",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "saturation": "12"
                        },
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "road",
                    "elementType": "geometry.stroke",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "color": "#cb7432"
                        },
                        {
                            "lightness": "0"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "geometry.stroke",
                    "stylers": [
                        {
                            "color": "#000000"
                        },
                        {
                            "lightness": 29
                        },
                        {
                            "weight": 0.2
                        },
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "labels.text",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "labels.text.fill",
                    "stylers": [
                        {
                            "color": "#ffffff"
                        },
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "labels.text.stroke",
                    "stylers": [
                        {
                            "color": "#cb7432"
                        },
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "lightness": 18
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "color": "#F1B41C"
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "labels.text.fill",
                    "stylers": [
                        {
                            "color": "#ffffff"
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "labels.text.stroke",
                    "stylers": [
                        {
                            "color": "#2c2c2c"
                        }
                    ]
                },
                {
                    "featureType": "road.local",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#000000"
                        },
                        {
                            "lightness": 16
                        }
                    ]
                },
                {
                    "featureType": "road.local",
                    "elementType": "labels.text.fill",
                    "stylers": [
                        {
                            "color": "#999999"
                        }
                    ]
                },
                {
                    "featureType": "transit",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#000000"
                        },
                        {
                            "lightness": 19
                        }
                    ]
                },
                {
                    "featureType": "transit.line",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "color": "#deea00"
                        }
                    ]
                },
                {
                    "featureType": "water",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#000000"
                        },
                        {
                            "lightness": 17
                        }
                    ]
                }
                ]
            });

            map.addMarker({
                lat: 10.811830, //To show your address on above Map, change the Latitude from here.
                lng: 106.664841, //To show your address on above Map, change the Longitude from here.
                title: 'b.deli',
                animation: google.maps.Animation.BOUNCE,
                icon: {
                    url: 'Content/b.Deli/Assets/img/Food_3.svg'
                },
                infoWindow: {
                    content: '<h5>b.deli</h5><p>Welcome to b.deli.</p>'
                }
            });
        });

        $count.text(orderArr.length);

        //Ajax
        $("a.cart-gf").bind("click", function () {
            let id = $(this).data("id");

            $.ajax({
                async: true,
                type: 'GET',
                url: '/gift/addcart/'+ id,
                dataType: "json",
                cache: false,
                //dataType: "json",
                error: function (data) {
                    console.log('error:' + data + ';' + JSON.stringify(data, null, 4));
                    $('.form-response').html('Something went wrong!');
                },
                success: function (data) {
                    delete data.data.Type;
                    let as = orderArr.some(x => x.ID == parseInt(id));
                    if (!as) {
                        data.data.Quantity = 1;
                        orderArr.push(data.data);
                        if (typeof (Storage) !== "undefined") {
                            localStorage.setItem('order', JSON.stringify(orderArr));
                            $count.text(orderArr.length);
                        } else {
                            console.log("dont have local storage");
                        }
                    } else {
                        for (var i in orderArr) {
                            if (orderArr[i].ID == parseInt(id)) {
                                orderArr[i].Quantity++;
                                break;
                            }
                        }
                        localStorage.setItem('order', JSON.stringify(orderArr));
                    }
                }
            });
        });

        //save order
        $order.bind("click", function () {

            $.ajax({
                async: true,
                type: 'POST',
                url: '/Gift/AddToCart',
                cache: false,
                dataType: "json",
                data: JSON.stringify(orderArr),
                error: function (data) {
                    console.log('error:' + data + ';' + JSON.stringify(data, null, 4));
                    $('.form-response').html('Something went wrong!');
                },
                success: function (data) {
                    location.href = "/Checkout/Index";
                }
            });
        });

        loadCart = function () {
            const dataLength = orderArr.length;
            $cart.html("");
            $count.text(orderArr.length);
            (!dataLength) ? $order.attr("disabled", "disabled") : $order.removeAttr("disabled");
            for (let i = 0; i < dataLength; i++) {
                $cart.append(pre(orderArr[i]));
            }
        };

        //open cart
        $("button.btn-cart").bind("click", function () {
            loadCart();
        });
    });

    $(window).on('load', function () {
        
        jQuery(".cafetora-site-preloader-wrap").fadeOut(500);

        // Wrap every letter in a span
        anime.timeline({ loop: false })
       .add({
           targets: '.intro-heading .line',
           opacity: [0.5, 1],
           scaleX: [0, 1],
           easing: "easeInOutExpo",
           duration: 900
       }).add({
           targets: '.intro-heading .line',
           duration: 600,
           easing: "easeOutExpo",
           translateY: function (e, i, l) {
               var offset = -0.625 + 0.625 * 2 * i;
               return offset + "em";
           }
       }).add({
           targets: '.intro-heading .ampersand',
           opacity: [0, 1],
           scaleY: [0.5, 1],
           easing: "easeOutExpo",
           duration: 900,
           offset: '-=600'
       }).add({
           targets: '.intro-heading .letters-left',
           opacity: [0, 1],
           translateX: ["0.5em", 0],
           easing: "easeOutExpo",
           duration: 900,
           offset: '-=300'
       }).add({
           targets: '.intro-heading .letters-right',
           opacity: [0, 1],
           translateX: ["-0.5em", 0],
           easing: "easeOutExpo",
           duration: 900,
           offset: '-=600'
       }).add({
           targets: '.intro-heading',
           opacity: 1,
           duration: 1000,
           easing: "easeOutExpo",
           delay: 1000
       });

    });

}(jQuery));

//delete cart
var deleteCart = (id) => {
    orderArr = orderArr.filter(x => x.ID != id);
    localStorage.setItem('order', JSON.stringify(orderArr));
    loadCart();
}

var FormatCurrency = (value) => {
    let $dola = value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
    return $dola.slice(1, $dola.indexOf(".00"));
}

var pre = (data) => {
    let DOM = `<tr>
                <td><img src="../Images/b.Deli/imageGift/${data.Image}" class ="img-thumbnail img-fluid" alt="Cinque Terre" width="150" height="68"></td>
                <td>${data.Name}</td>
                <td><input type="number" class ="form-control" value="${data.Quantity}" min="1" max="999" value="1"></td>
                <td nowrap class="text-center">${FormatCurrency(data.Price * data.Quantity)}</td>
                <td><div class ="text-right"><a href="javascript:void(0);" onclick="deleteCart(${data.ID})" class ="badge badge-warning badge-pill">&times; </a></div></td>
            </tr>`;
    return DOM;
}