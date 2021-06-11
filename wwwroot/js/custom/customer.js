$(document).ready(function () {
    var dataTable = $("#customer").DataTable({
        ajax: {
            url: "/customer/getall/",
            dataSrc: ""
        },
        columns:
            [
                {
                    data: "id"
                },
                {
                    data: "name",
                    render: function (data, type, customer) {
                        return "<a href='/customer/edit/" + customer.id + "'>" + customer.name + "</a>";
                    }
                },
                {
                    data: "email"
                },
                {
                    data: "birthDate",
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
                    data: "membershipType.name"
                },
                {
                    data: "membershipType.discountRate",
                    render: function (data) {
                        return "<label>" + data + "%" + "</label>";
                    }
                },
                {
                    data: "isSubscribedToNewsLetter",
                    render: function (data) {
                        var value = "Yes";
                        if (data == "false" || data == false)
                            value = "No";
                        return " <label>" + value + "</label>";
                    }
                },
                {
                    data: "id",
                    render: function (data) {
                        return "<button data-customer-id=" + data + " " +
                            " class='btn js-delete' style='height: 40px; width: 40px; font-size: medium; color:red; border:hidden; background:none;'>X</button > ";
                    }
                }
            ]
    });
    $("#customer").on("click", ".js-delete", function () {
        var deleteButton = $(this);
        bootbox.confirm("Are you sure you want to delete this customer?", function (result) {
            if (result) {
                $.ajax
                    ({
                        url: "/customer/delete/" + deleteButton.attr("data-customer-id"),
                        success: function () {
                            dataTable.row(deleteButton.parents("tr")).remove().draw();
                        }
                    });
            }
        });
    });
});