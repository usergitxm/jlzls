$(function () {

    var list = 3;

    $('.activeimg').css({
        width: list * window.innerWidth
    });

    $('.activeimg').css({
        height: 320 / 800 * window.innerWidth
    });

    $('.top-img img').css({
        width: window.innerWidth
    });

    $('.top-img img').css({
        height: 320 / 800 * window.innerWidth
    });

    //自动播放 无限循环
    var timer = '';
    var num = 0;
    timer = setInterval(function () { //打开定时器
        num++;
        if (num > parseFloat(list) - 1) {
            num = 0;
            $('.activeimg').css({ left: 0 });
        } else {
            $('.activeimg').animate({ left: num * -window.innerWidth }, "slow");
        }
    }, 3000);


    $(".MainContent").css("min-height", window.innerHeight - 65);
    $("#main").css("width", window.innerWidth - 30);
})