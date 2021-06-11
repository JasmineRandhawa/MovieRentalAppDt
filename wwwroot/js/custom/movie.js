$(document).ready(function () {
    var dataTable = $("#movie").DataTable({
        ajax: {
            url: "/movie/getall/",
            dataSrc: ""
        },
        columns:
            [
                {
                    data: "id"
                },
                {
                    data: "name",
                    render: function (data, type, movie) {
                        return "<a href='/movie/edit/" + movie.id + "'>" + movie.name + "</a>";
                    }
                },
                {
                    data: "genre.name"
                },
                {
                    data: "numberOfStock"
                },
                {
                    data: "releaseDate",
                    "render": function (data) {
                        var date = new Date(data);
                        var monthShortNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
                            "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
                        ];
                        var month = monthShortNames[date.getMonth()] + "";
                        return date.getDate() + " " + month + " , " + date.getFullYear();
                    }
                },
                {
                    data: "id",
                    render: function (data) {
                        return "<button data-movie-id=" + data + " " +
                            " class='btn js-delete' style='height: 40px; width: 40px; font-size: medium; color:red; border:hidden; background:none;'>X</button > ";
                    }
                }
            ]
    });
    $("#movie").on("click", ".js-delete", function () {
        var deleteButton = $(this);
        bootbox.confirm("Are you sure you want to delete this movie?", function (result) {
            if (result) {
                $.ajax
                    ({
                        url: "/movie/delete/" + deleteButton.attr("data-movie-id"),
                        success: function () {
                            dataTable.row(deleteButton.parents("tr")).remove().draw();
                        }
                    });
            }
        });
    });
});