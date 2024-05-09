$(document).ready(function ()
{
    $("#searchInput").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: 'Section/search',
                type: "GET",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item
                        };
                    }));
                }
            });
        },
        minLength: 1
    });
});

