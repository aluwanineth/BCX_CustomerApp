function deleteOrderItem(orderItemId) {
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
                url: "/Order/DeleteOrderItem",
                type: "POST",
                data: { orderItemId: orderItemId },
                success: function (result) {
                    if (result.success) {
                        Swal.fire({
                            title: 'Order item deleted successfully.',
                            icon: 'info',
                            onAfterClose: () => {
                                location.reload();
                            }
                        });
                    } else {
                        Swal.fire({
                            title: 'Error deleting order item.',
                            icon: 'error',
                            onAfterClose: () => {
                                location.reload();
                            }
                        });
                    }
                },
                error: function () {
                    alert("Error deleting order item. Please try again.");
                }
            });
        }
    });
}