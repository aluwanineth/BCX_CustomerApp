function addOrder(customerId) {
    var orderData = {
        CustomerId: customerId,
    };

    // Send AJAX request to the server
    $.ajax({
        url: "/Order/AddOrder",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ orderVM: orderData }),
        success: function (result) {
            if (result.success) {
                Swal.fire({
                    title: "Good job!",
                    text: "Order created successfully!",
                    icon: "success",
                    onAfterClose: () => {
                        location.reload();
                    }
                });
            } else {
                Swal.fire({
                    title: "Error!",
                    text: "Error adding order.!",
                    icon: "error",
                    onAfterClose: () => {
                        location.reload();
                    }
                });
            }
        },
        error: function () {
            Swal.fire({
                title: "Error!",
                text: "Error adding order. Please try again.!",
                icon: "error",
                onAfterClose: () => {
                    location.reload();
                }
            });
        }
    });
}
function deleteOrder(orderId) {
    Swal.fire({
        title: 'Do you want to delete this Order?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: "/Order/DeleteOrder",
                type: "POST",
                data: { orderId: orderId },
                success: function (result) {
                    if (result.success) {
                        Swal.fire({
                            title: 'Order deleted successfully.',
                            icon: 'info',
                            onAfterClose: () => {
                                location.reload();
                            }
                        });
                    } else {
                        Swal.fire({
                            title: 'Error deleting order.',
                            icon: 'error',
                            onAfterClose: () => {
                                location.reload();
                            }
                        });
                    }
                },
                error: function () {
                    alert("Error deleting order. Please try again.");
                }
            });
        }
    });
}