(function () {
    $(document).ready(function () {
        $('#send-message').click(sendMessage)
        $('#leave').click(function () {
            window.location.replace($(this).attr('data-url'));
        })
        setTimeout(refresh, 10000);
    })

    function refresh() {
        $.ajax({
            type: "GET",
            url: "/chat/refresh/",
            success: function (data) {
                $('#RefreshArea').html(data);
            }
        });
        setTimeout(refresh, 3000);
    }

    function sendMessage() {
        let message = $('#new-message');
        if (message.val().length == 0)
            return;

        $.ajax({
            type: "POST",
            url: $(this).attr('data-url'),
            data: {
                message: {
                    Text: message.val()
                }
            },
            success: function (data) {
                $('#RefreshArea').html(data);
                message.val("");
            }
        });
    }
}());
