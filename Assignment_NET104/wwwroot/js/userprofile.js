$(document).ready(function () {

    $.ajax({
        type: 'GET',
        url: '/Account/ProfileDetail',
        dataType: "json",
        success: function (data) {

            $('#name').html(data.user.name);
            $('#email').html(data.user.email);
            $('#address').html(data.user.streetAddress);
            $('#city').html(data.user.city);

            var orders = data.order;

            orders.forEach(function (order) {

                var row = $('<tr></tr>');

                var date = new Date(order.createdDate);
                var formattedDate = date.toLocaleDateString();

                row.append('<td>' + formattedDate + '</td>');
                row.append('<td>' + order.orderId + '</td>');
                row.append('<td>' + order.total + '</td>');
                row.append('<td>' + getOrderStatus(order.status) + '</td>');

                $('#ordersTable tbody').append(row);
            })
        },
        error: function (xhr, status, error) {
            console.log("AJAX Error: ", status, error);
            console.log("Response Text: ", xhr.responseText);
        }
    });
});

const OrderStatus = {
    Pending: 1,
    Processing: 2,
    Completed: 3,
    Cancelled: 4
};

function getOrderStatus(status) {
    switch (status) {
        case OrderStatus.Pending:
            return "Đang đặt";
        case OrderStatus.Processing:
            return "Đang giao";
        case OrderStatus.Completed:
            return "Đã giao";
        case OrderStatus.Cancelled:
            return "Đã huỷ";
        default:
            return "Lỗi";
    }
}