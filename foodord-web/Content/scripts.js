"use strict";
$(document).ready(function () {
    console.log("ok, jquery works!");
    $("button[data-basket='add']").click(function (event) {
        let itemId = $(event.currentTarget).attr("data-food-id");
        console.log(itemId);
    });
});
