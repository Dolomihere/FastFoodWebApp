function AddItem() {
    let item = {};

    $.ajax({
        type: 'POST',
        url: '/Product/AddItem',
        data: JSON.stringify(item),
        contentType: 'application/json; charset=utf-8;',
        dataType: 'json',
        success: function (result) {

        },
        error: function (result) {

        }
    });
}

function EditItem() {
    let item = {};

    $.ajax({
        type: 'PUT',
        url: '/Product/EditItem',
        data: JSON.stringify(item),
        contentType: 'application/json; charset=utf-8;',
        dataType: 'json',
        success: function (result) {

        },
        error: function (result) {

        }
    });
}

function DeleteItem() {
    let item = {};

    $.ajax({
        type: 'DELETE',
        url: '/Product/DeleteItem',
        data: JSON.stringify(item),
        contentType: 'application/json; charset=utf-8;',
        dataType: 'json',
        success: function (result) {

        },
        error: function (result) {

        }
    });
}

function SearchItem() {
    let item = {};

    $.ajax({
        type: 'GET',
        url: '/Product/DeleteItem',
        data: JSON.stringify(item),
        contentType: 'application/json; charset=utf-8;',
        dataType: 'json',
        success: function (result) {

        },
        error: function (result) {

        }
    });
}