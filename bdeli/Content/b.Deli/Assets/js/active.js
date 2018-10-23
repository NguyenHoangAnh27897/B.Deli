(function ($) {
	"use strict";

    $(document).ready(function() {
        
        // Our Menu Sliding Tab
        $('.menu-slider').owlCarousel({
            items: 1,
            loop:true,
            margin:10,
            nav:false,
            dots:true,
            autoplay: true,
            mouseDrag: false,
            touchDrag: false,
            dotsContainer: '.dotsCont'
        });

        $('.owl-dot').click(function () {
          $('.menu-slider').trigger('to.owl.carousel', [$(this).index(), 300]);
        });

        // Testimonial Slider
        $(".testimonial-slides").owlCarousel({
            items: 1,
            nav: false,
            dots: true,
            autoplay: true,
            animateOut: 'slideOutDown',
            animateIn: 'flipInX',
            loop: true,
            navText: ["<i class='fa fa-chevron-left'></i>", "<i class='fa fa-chevron-right'></i>"],
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
        $(window).on( "scroll", function() {
            if ($(this).scrollTop() > 200) {
                    $('.go-top').fadeIn(200);
                } else {
                    $('.go-top').fadeOut(200);
                }
        });
        
        // Custom Scroll Spy
        $(window).on('scroll', function() {
            $('div[scroll-spy="true"]').each(function() {
                if($(window).scrollTop() >= $(this).offset().top-85) {
                    var id = $(this).attr('id');
                    $('.main-menu li a').parent('li').removeClass('active');
                    $('.main-menu li a[href="#'+ id +'"]').parent('li').addClass('active');
                }
            });
        });
        
        // Instagram Setting
        $(function () { 
            var userFeed = new Instafeed({
                get: 'user',
                userId: '2005102763', // Your User Id here 
                accessToken: '2005102763.3a81a9f.11972442d69d4f7f861171e947a22ea9', // Access token here
                resolution: 'thumbnail',
                template: '<a href="{{link}}" target="_blank" id="{{id}}"><img src="{{image}}" /></a>',
                sortBy: 'most-recent',
                limit: 3,
                links: false
            });
            userFeed.run();
        });
        
        // Google Map Setting
        $(function () {
			var map = new GMaps({
			el: "#map1",
			lat: 23.7290156, //To show your address on above Map, change the Latitude from here.
			lng: 90.4141473, //To show your address on above Map, change the Longitude from here.
				  zoom: 15,
				  scrollwheel: false,
				  zoomControl : false,
				  zoomControlOpt: {
					position: "TOP_LEFT"
				  },
				  panControl : false,
				  streetViewControl : false,
				  mapTypeControl: false,
				  overviewMapControl: false
			  });
            
            map.addMarker({
                  lat: 23.7290156, //To show your address on above Map, change the Latitude from here.
                  lng: 90.41414738, //To show your address on above Map, change the Longitude from here.
                  title: 'cafetora',
                animation:google.maps.Animation.BOUNCE,
                  infoWindow: {
                      content: '<h5>Lorem Ipsum</h5><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>'
                    }
                });
		});
    
     });

    $(window).on('load', function(){
        
        jQuery(".cafetora-site-preloader-wrap").fadeOut(500);

        // Wrap every letter in a span
        anime.timeline({loop: false})
       .add({
         targets: '.intro-heading .line',
         opacity: [0.5,1],
         scaleX: [0, 1],
         easing: "easeInOutExpo",
         duration: 900
       }).add({
         targets: '.intro-heading .line',
         duration: 600,
         easing: "easeOutExpo",
         translateY: function(e, i, l) {
           var offset = -0.625 + 0.625*2*i;
           return offset + "em";
         }
       }).add({
         targets: '.intro-heading .ampersand',
         opacity: [0,1],
         scaleY: [0.5, 1],
         easing: "easeOutExpo",
         duration: 900,
         offset: '-=600'
       }).add({
         targets: '.intro-heading .letters-left',
         opacity: [0,1],
         translateX: ["0.5em", 0],
         easing: "easeOutExpo",
         duration: 900,
         offset: '-=300'
       }).add({
         targets: '.intro-heading .letters-right',
         opacity: [0,1],
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