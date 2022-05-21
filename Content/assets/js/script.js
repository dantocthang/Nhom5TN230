$(document).ready(function () {
    AOS.init();
    $('.tutorial__list').slick({
        dots: true,
        infinite: true,
        speed: 600,
        slidesToShow: 3,
        slidesToScroll: 3,
        nextArrow: '<button class="slider__button next"><i class="fa-solid fa-chevron-right"></i></button>',
        prevArrow: '<button class="slider__button previous"><i class="fa-solid fa-chevron-left"></i></button>',
        responsive: [
            {
                breakpoint: 1324,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true,
                    dots: true
                }
            },
            {
                breakpoint: 1000,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 700,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ]
    });

    //$.ajax({
    //    type: 'GET',
    //    url: '/Cart/CartQuick',
    //    data: {},
    //    success: function (data) {
    //        console.log(data)
    //        $('#header-cart-list').html(data)
    //    }
    //})

    
});

