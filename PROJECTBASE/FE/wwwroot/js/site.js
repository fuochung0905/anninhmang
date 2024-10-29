function closeWindow() { }

function showLoading(value) {
    if (value) {
        $.blockUI({
            message: 
                '<div class="loader-demo-box">' +
                '<div class="bar-loader">' +
                '<span></span>' +
                '<span></span>' +
                '<span></span>' +
                '<span></span>' +
                '</div>'+
                '</div>'
        });
    }
    else {
        $.unblockUI();
    }
}

function showLoadingElement(value, id) {
    if (value) {
        $('#' + id).block({
            message: 
                '<div class="loader-demo-box">' +
                '<div class="bar-loader">' +
                '<span></span>' +
                '<span></span>' +
                '<span></span>' +
                '<span></span>' +
                '</div>' +
                '</div>'
        });
    }
    else {
        $('#' + id).unblock();
    }
}

function showSuccessNotify(message) {
    var settings = {
        theme: 'lime',
        sticky: false,
        horizontalEdge: 'bottom',
        verticalEdge: 'right',
        heading: 'Thông báo',
        life: '5000',
        icon: 'check-mark-2'
    };
    $.notific8('zindex', 11500);
    $.notific8($.trim(message), settings);
}

function showErrorNotify(message) {
    var settings = {
        theme: 'ruby',
        sticky: false,
        horizontalEdge: 'bottom',
        verticalEdge: 'right',
        heading: 'Lỗi',
        life: '5000',
        icon: 'bug'
    };
    $.notific8('zindex', 11500);
    $.notific8($.trim(message), settings);
}

function closePopUpSystem() {
    $('#modal-systemModal').modal('hide');
}

function ChangePassword() {
    showLoading(true);
    var url = '/TaiKhoan/ShowPopupChangePassword';

    $.get(url, function (data) {
        showLoading(false);
        $('#modelContainer-systemModal').html(data);
        $('#modal-systemModal').modal('show');
    });
}

function ChangeProfile() {
    showLoading(true);
    var url = '/TaiKhoan/ShowPopupChangeProfile';

    $.get(url, function (data) {
        showLoading(false);
        $('#modelContainer-systemModal').html(data);
        $('#modal-systemModal').modal('show');
    });
}

//Kiểm tra selected multi trên grid
function checkMultiSelectInGrid(listSelected) {
    if (listSelected.length == 0) {
        showErrorNotify(noDataMessage);
        return false;
    }

    if (listSelected.length > 1) {
        showErrorNotify("Chỉ được chọn 1 dòng dữ liệu để xử lý!");
        return false;
    }

    return true;
}
