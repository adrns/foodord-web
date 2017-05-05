"use strict";
let PRICE_LIMIT = 20000;
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
            handleBasketResult(json);
        });
    });
});

function handleBasketResult(json) {
    $("#food_count").html(json.basket.count);
    $("#basket_total").html(json.basket.total);

    $.each(json.basket.foods, function (key, food) {
        $("#food-" + food.foodId + "-cost").html(food.cost);
        $("#food-" + food.foodId + "-count").html(food.count);
    });

    if ("failure" == json.result) {
        switch (json.reason) {
            case "limitreached": displayError("Az ételek összege nem haladhatja meg a " + PRICE_LIMIT + " Ft-ot!"); break;
            case "nosuchfood": displayError("Nem található ilyen étel az adatbázisunkban/kosaradban!"); break;
        }
    }
}

function displayError(message) {
    $("#error_message").html(message);
    $("#error_box").fadeIn(400, function () {
        setTimeout(function () {
            $("#error_box").fadeOut();
        }, 5000);
    });
}