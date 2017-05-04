"use strict";
$(document).ready(function () {
    $("button[data-basket='add']").click(function (event) {
        let foodId = $(event.currentTarget).attr("data-food-id");
        $.ajax({
            url: "/Basket/Add",
            data: {
                foodId: foodId
            },
            type: "POST",
            dataType: "json"
        }).done(function (json) {
            console.log(json);
        });
    });
});
