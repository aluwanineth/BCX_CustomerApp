
var importCustomers = function () {
    $.ajax({
        // url: '@Url.Action("Import", "Customer"',
        url: "Customer/Import",
        type: "GET",
        success: function (data) {
            Swal.fire({
                title: "Good job!",
                text: "Customer imported successfully!",
                icon: "success",
                onAfterClose: () => {
                    location.reload();
                }
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            Swal.fire({
                title: "Error!",
                text: "Something went wrong!",
                icon: "error",
                onAfterClose: () => {
                    location.reload();
                }
            });
        }
    });
};