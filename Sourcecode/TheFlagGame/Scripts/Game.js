Game = new Object();

Game.FlagsInit = function (cfg) {
    $('button.option').click(function () {
        $('button.option').removeClass('active');
        $(this).addClass('active');

        $('#go-next').show();
    });
    function sendScore(fnSuccess) {
        var value = $('button.option.active').attr('value');
        $.ajax({
            url: "/Score/",
            method: 'POST',
            data: {
                Index: value
            },
            success: function (r) {
                if (r.Scored)
                    alert("Acertou!");
                else
                    alert("Errou!");
                if (typeof fnSuccess == "function")
                    fnSuccess(r)
            }
        })

    }

    $('button#btn-next').click(function () {
        sendScore(function (response) {
            location.href = cfg.NextUrl;
        });
    })

    $('button#btn-result').click(function () {
        sendScore(function (response) {
            location.href = cfg.ResultUrl;
        });
    })
}

Game.ResultInit = function () {
    $('#btn-share').click(function () {
        $('div.form-share').show();
        $(this).hide();
    })
}