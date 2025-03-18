$(document).on('click', '[id^="my-btn-"]', function () {
    let itemId = $(this).attr('id').split('-')[2];

    let item = {
        FoodItemId: parseInt($('#itemId-' + itemId).val()),
        Name: $('#itemName-' + itemId).val(),
        ImagePath: $('#itemImage-' + itemId).val(),
        Price: parseFloat($('#itemPrice-' + itemId).val()),
        Category: Categories[$('#itemType-' + itemId).val()],
        Status: 1
    }

    console.log(item);

    $.ajax({
        type: 'POST',
        url: '/Cart/AddToCart',
        contentType: 'application/json',
        data: JSON.stringify(item),
        dataType: 'json',
        success: function (data) {
            alert(data.status);
        },
        error: function (xhr, status, error) {
            console.log("AJAX Error: ", status, error);
            console.log("Response Text: ", xhr.responseText);
        }
    });
});

const Categories = {
    MonAn: 1,
    Combo: 2,
    Nuoc: 3,
    Khac: 4
};