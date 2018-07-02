$(document).ready(function () {
    $(".trackable").click(function () {
        var fields = $(this).attr('id').split('-');
        var type = fields[0];
        var id = fields[1];
        var search = $('#SearchQuery').val();
        var name = $(this).text();
        $.ajax({
            url: "http://localhost:63098/api/tracking",
            type: "POST",
            data: { id: id, type: type, search: search, name: name }
        });
    });
});

