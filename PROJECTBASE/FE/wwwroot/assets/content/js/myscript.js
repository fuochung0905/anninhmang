
///Các hàm js dùng chung trong hệ thống.
var rowNumberGrid = 0;
var viewMode = "1";
var scaleMode = "SPECIFIC";
var printMode = "AutoSelect";
var scale = 1.5;

var xoFunc = {
    //func-001: Hiển thị thông báo.
    confirmDialog: function (message, title, buttons) {
        var index;
        var contentHTML = "<div class='sweet-alert  showSweetAlert visible' tabindex='-1' data-custom-class='' data-has-cancel-button='true' data-has-confirm-button='true' data-allow-outside-click='true' data-has-done-function='true' data-animation='pop' data-timer='null' style='display: block; margin-top: -131px;'>";
        contentHTML += "<div class='sa-icon sa-warning pulseWarning' style='display: block;'>";
        contentHTML += "<span class='sa-body pulseWarningIns'></span>";
        contentHTML += "<span class='sa-dot pulseWarningIns'></span>";
        contentHTML += "</div>";
        contentHTML += "<h2>";
        contentHTML += message;
        contentHTML += "</h2>";
        contentHTML += "<p class='lead text-muted '></p>";
        contentHTML += "<div class='sa-button-container'>";
        for (index = 0; index < buttons.length; ++index) {
            if (buttons[index].text == "Có") {
                contentHTML += "<div class='sa-confirm-button-container'>";
                contentHTML += "<button class='confirm btn btn-lg btn-info btn-class-confirm-" + index + "' tabindex='1' style='display: inline-block; margin-left:10px; min-width:100px;'>" + buttons[index].text + "</button>";
                contentHTML += "</div>";
            }
            else {
                contentHTML += "<button class='cancel btn btn-lg btn-danger btn-class-confirm-" + index + "' tabindex='" + (index + 1) + "' style='display: inline-block; margin-left:10px; min-width:100px;'>" + buttons[index].text + "</button>";
            }
        }
        contentHTML += "</div>";
        contentHTML += "</div>";

        var kendoWindow = $("<div />").kendoWindow({
            title: title,
            resizable: false,
            modal: true,
            width: 0
        });

        kendoWindow.data("kendoWindow")
            .content(contentHTML)
            .center().open();

        for (index = 0; index < buttons.length; ++index) {
            var b = buttons[index];
            kendoWindow
                .find('.btn-class-confirm-' + index)
                .click(b, function (e) {
                    if (e.data.onClick != null) {
                        if (e.data.argument == null)
                            e.data.onClick();
                        else
                            e.data.onClick(e.data.argument);
                    }
                    kendoWindow.data("kendoWindow").close();
                })
                .end();
        }
        return false;
    },
    confirmDialogDanger: function (message, title, buttons) {
        var index;
        var contentHTML = "<div>";
        contentHTML += "<table  style='min-height:80px; min-width:160px; margin:5px; width: 100%;'>";
        contentHTML += "<tr>";
        contentHTML += "<td style='width:30%;text-align:center;'>";
        contentHTML += "<i style='font-size:xx-large; color:#b94442;' class='fa fa-exclamation-triangle' aria-hidden='true'></i>";
        contentHTML += "</td>";
        contentHTML += "<td style='width:70%;'>";
        contentHTML += message;
        contentHTML += "</td>";
        contentHTML += "</tr>";
        contentHTML += "</table>";
        contentHTML += "</div>";
        contentHTML += "<div> <hr /> </div>" //hr
        contentHTML += "<div style='text-align:right;'>"
        for (index = 0; index < buttons.length; ++index) {
            contentHTML += "<button class=' k-button btn-class-confirm-" + index + "' style='min-width: 50px; margin-right: 5px;'>" + buttons[index].text + "</button>";
        }
        contentHTML += "</div>";

        var kendoWindow = $("<div />").kendoWindow({
            title: title,
            resizable: false,
            modal: true,
            width: 350
        });

        kendoWindow.data("kendoWindow")
            .content(contentHTML)
            .center().open();

        for (index = 0; index < buttons.length; ++index) {
            var b = buttons[index];
            kendoWindow
                .find('.btn-class-confirm-' + index)
                .click(b, function (e) {
                    if (e.data.onClick != null) {
                        if (e.data.argument == null)
                            e.data.onClick();
                        else
                            e.data.onClick(e.data.argument);
                    }
                    kendoWindow.data("kendoWindow").close();
                })
                .end();
        }
        return false;
    },
    confirmDialogSuccess: function (message, title, buttons) {
        var index;
        var contentHTML = "<div>";
        contentHTML += "<table  style='min-height:80px; min-width:160px; margin:5px; width: 100%;'>";
        contentHTML += "<tr>";
        contentHTML += "<td style='width:30%;text-align:center;'>";
        contentHTML += "<i style='font-size:xx-large; color:#3c763d;' class='fa fa-info-circle' aria-hidden='true'></i>";
        contentHTML += "</td>";
        contentHTML += "<td style='width:70%;'>";
        contentHTML += message;
        contentHTML += "</td>";
        contentHTML += "</tr>";
        contentHTML += "</table>";
        contentHTML += "</div>";
        contentHTML += "<div> <hr /> </div>" //hr
        contentHTML += "<div style='text-align:right;'>"
        for (index = 0; index < buttons.length; ++index) {
            contentHTML += "<button class=' k-button btn-class-confirm-" + index + "' style='min-width: 50px; margin-right: 5px;'>" + buttons[index].text + "</button>";
        }
        contentHTML += "</div>";

        var kendoWindow = $("<div />").kendoWindow({
            title: title,
            resizable: false,
            modal: true,
            width: 350
        });

        kendoWindow.data("kendoWindow")
            .content(contentHTML)
            .center().open();

        for (index = 0; index < buttons.length; ++index) {
            var b = buttons[index];
            kendoWindow
                .find('.btn-class-confirm-' + index)
                .click(b, function (e) {
                    if (e.data.onClick != null) {
                        if (e.data.argument == null)
                            e.data.onClick();
                        else
                            e.data.onClick(e.data.argument);
                    }
                    kendoWindow.data("kendoWindow").close();
                })
                .end();
        }
        return false;
    },
    //func-002: Hiển thị xác nhận.
    confirmDialogYesNo: function (message, title, onClickYes, yesText, noText) {
        yesText = (yesText == null) ? "Có" : yesText;
        noText = (noText == null) ? "Không" : noText;
        this.confirmDialog(message, title, [{ text: yesText, onClick: onClickYes }, { text: noText }]);

    },
    alert: function (message, title, buttons) {
        var index;
        var contentHTML = "<div>";
        contentHTML += "<table  style='min-height:80px; min-width:160px; margin:5px; width: 100%;'>";
        contentHTML += "<tr>";
        contentHTML += "<td style='width:30%;text-align:center;'>";
        contentHTML += "<i style='font-size:xx-large; color:#4285F4;' class='fa fa-info-circle' aria-hidden='true'></i>";
        contentHTML += "</td>";
        contentHTML += "<td style='width:70%;'>";
        contentHTML += message;
        contentHTML += "</td>";
        contentHTML += "</tr>";
        contentHTML += "</table>";
        contentHTML += "</div>";
        contentHTML += "<div> <hr /> </div>" //hr
        contentHTML += "<div style='text-align:right;'>"
        for (index = 0; index < buttons.length; ++index) {
            contentHTML += "<button class=' k-button btn-class-confirm-" + index + "' style='min-width: 50px; margin-right: 5px;'>" + buttons[index].text + "</button>";
        }
        contentHTML += "</div>";

        var kendoWindow = $("<div />").kendoWindow({
            title: title,
            resizable: false,
            modal: true,
            width: 350
        });

        kendoWindow.data("kendoWindow")
            .content(contentHTML)
            .center().open();

        for (index = 0; index < buttons.length; ++index) {
            var b = buttons[index];
            kendoWindow
                .find('.btn-class-confirm-' + index)
                .click(b, function (e) {
                    if (e.data.onClick != null) {
                        if (e.data.argument == null)
                            e.data.onClick();
                        else
                            e.data.onClick(e.data.argument);
                    }
                    kendoWindow.data("kendoWindow").close();
                })
                .end();
        }
        return false;
    },
    //func-003: Xác nhận xóa nhiều trên lưới.
    xoaNhieuCheckBoxGridView: function (gridName, chkboxAllName, urlAction, mess) {
        var arrID = [];
        var grid = $(gridName).data().kendoGrid;
        for (var i = 0; i < grid.dataSource.view().length; i++) {
            if (grid.dataSource.view()[i]['IsSelected'] == true)

                //add vô array ID
                arrID.push(grid.dataSource.view()[i]['ID']);

        }
        if (arrID.length > 0) {
            var dataArr = JSON.stringify({ 'arr': arrID });
            var deleteAll = function () {
                $.ajax({
                    data: dataArr,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'html',
                    url: urlAction,
                    type: 'POST',
                    success: function (data) {
                        var grid = $(gridName).data("kendoGrid");
                        grid.dataSource.page(1);
                        grid.dataSource.read();
                        $(chkboxAllName).prop("checked", false);
                    },
                    error: function (request, status, err) {
                        alert(err);
                    }
                });
            }
            return this.confirmDialogYesNo(mess, "Xác nhận", deleteAll);
        }
    },

    //func-004: Reset cột stt trên lưới.
    resetRowNumberGrid: function (e) {
        rowNumberGrid = 0;
    },

    //func-005: Render cột stt trên lưới.
    renderNumberGrid: function (data) {
        return ++rowNumberGrid;
    },

    //func-006: Xử lý hiển thị cột stt trên lưới ở sự kiện DataBinding
    onDataBindingGrid: function (e) {
        //Implement the event handler for DataBinding
        var page = e.sender.dataSource.page();
        var pageSize = e.sender.dataSource.pageSize();
        // reset row number based on the selected page in the pager
        rowNumberGrid = (page - 1) * pageSize;
    },

    onErrorGrid: function (e, status) {
        if (e.status == "customerror") {
            xoFunc.confirmDialogDanger("<span style='color:red;'> " + e.errors + "</span>", "Thông báo", [{ text: "Đóng", onClick: closeWindow }]);

        }
        else {
            xoFunc.confirmDialogDanger("<span style='color:red;'> Lỗi truy cập dữ liệu!  </span>", "Thông báo", [{ text: "Đóng", onClick: closeWindow }]);
        }
    },
    //func-007: waiting dialog.
    waitingDialog: function () {
        'use strict';
        // Creating modal dialog's DOM
        var $dialog = $(
            '<div class="modal fade"  role="dialog" style="padding-top:20%; overflow-y:visible;opacity: 0.8;">' +
            '<div class="modal-dialog modal-m" style="width:280px; height:140px;">' +
            '<div class="modal-content" style="width:280px; height:140px;">' +
            '<div class="modal-header"><h5 style="margin:0; color:#2a6496;"></h5></div>' +
            '<div class="modal-body" style="text-align:center;">' +
            //'<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i> ' +
            '<div class="progress progress-striped active" style="margin-bottom:0;"><div class="progress-bar" style="width: 100%"></div></div>' +
            '</div>' +
            '</div></div></div>');

        return {
            show: function (message, options) {
                // Assigning defaults
                if (typeof options == 'undefined') {
                    options = {};
                }
                if (typeof message == 'undefined') {
                    message = 'Đang tải...';
                }
                var settings = $.extend({
                    dialogSize: 'm',
                    progressType: '',
                    onHide: null // This callback runs after the dialog was hidden
                }, options);

                // Configuring dialog
                $dialog.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
                $dialog.find('.progress-bar').attr('class', 'progress-bar');
                if (settings.progressType) {
                    $dialog.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
                }
                $dialog.find('h5').text(message);
                // Adding callbacks
                if (typeof settings.onHide == 'function') {
                    $dialog.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                        settings.onHide.call($dialog);
                    });
                }
                // Opening dialog
                $dialog.modal();
            },
            /**
             * Closes dialog
             */
            hide: function () {
                $dialog.modal('hide');
            }
        };
    },

    //func-008: Kiểm tra file có hổ trợ xem online
    fileSupport: function (extension) {
        if (!/(ppt|pptx|xls|xlsx|pdf|docx|doc|jpg|jpeg|png|gif)$/ig.test(extension)) {
            var message = "Chỉ hỗ trợ xem các tệp: doc, docx, xls, xlsx, ppt, pptx, pdf, jpg, jpeg, png, gif";
            xoFunc.confirmDialogDanger("<span style='color:red;'>" + message + "</span>", "Thông báo", [{ text: "Đóng", onClick: closeWindow }]);
            return false;
        }
        return true;
    }
}

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};
    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });
    return indexed_array;
}

function getHeightDivSearchAdvanced() {
    var x = document.getElementById("divSearchAdvanced");
    if (x == null || x.style.display === "none") {
        return 0;
    } else {
        return $('#divSearchAdvanced').innerHeight();
    }
}

function SetGridHeight() {
    var gridElement = $("#grid"),
        newHeight = gridElement.innerHeight(),
        otherElements = gridElement.children().not(".k-grid-content"),
        otherElementsHeight = 0;
    otherElements.each(function () {
        otherElementsHeight += $(this).outerHeight();
    });
    var $windowHeight = $(window).height();
    var idnavbarmain = $('#idnavbarmain').innerHeight();
    var idtitle = $('#idtitle').innerHeight();
    var Height = $windowHeight - idnavbarmain - idtitle - 100;
    var k_header = $('.k-header').innerHeight();
    var k_grid_toolbar = $('.k-grid-toolbar').innerHeight();
    var k_filter_row = $('.k-filter-row').innerHeight();
    var k_pager_wrap = $('.k-pager-wrap').innerHeight();
    if (k_grid_toolbar != null && k_grid_toolbar != 0) {
        if (k_header != null && k_header != 0) {
            k_header = k_header + k_grid_toolbar;
        } else {
            k_header = k_grid_toolbar;
        }
    } else {
        if (k_header == null || k_header == 0) {
            k_header = 0;
        }
    }
    var divsearchadvanced = getHeightDivSearchAdvanced();
    k_header = (k_header == null ? 0 : k_header);
    k_pager_wrap = (k_pager_wrap == null ? 0 : k_pager_wrap);
    k_filter_row = (k_filter_row == null ? 0 : k_filter_row);
    var Height = Height - k_header - k_pager_wrap - k_filter_row - divsearchadvanced;
    if (Height > 20) {
        gridElement.children(".k-grid-content").height(Height);
    }
}

function SetGridHeightWWithId(idGrid) {
    var gridElement = $("#" + idGrid),
        newHeight = gridElement.innerHeight(),
        otherElements = gridElement.children().not(".k-grid-content"),
        otherElementsHeight = 0;
    otherElements.each(function () {
        otherElementsHeight += $(this).outerHeight();
    });
    var $windowHeight = $(window).height();
    var idnavbarmain = $('#idnavbarmain').innerHeight();
    var idtitle = $('#idtitle').innerHeight();
    var Height = $windowHeight - idnavbarmain - idtitle - 100;
    var k_header = $('.k-header').innerHeight();
    var k_grid_toolbar = $('.k-grid-toolbar').innerHeight();
    var k_filter_row = $('.k-filter-row').innerHeight();
    var k_pager_wrap = $('.k-pager-wrap').innerHeight();
    if (k_grid_toolbar != null && k_grid_toolbar != 0) {
        if (k_header != null && k_header != 0) {
            k_header = k_header + k_grid_toolbar;
        } else {
            k_header = k_grid_toolbar;
        }
    } else {
        if (k_header == null || k_header == 0) {
            k_header = 0;
        }
    }
    var divsearchadvanced = getHeightDivSearchAdvanced();
    k_header = (k_header == null ? 0 : k_header);
    k_pager_wrap = (k_pager_wrap == null ? 0 : k_pager_wrap);
    k_filter_row = (k_filter_row == null ? 0 : k_filter_row);
    var Height = Height - k_header - k_pager_wrap - k_filter_row - divsearchadvanced;
    if (Height > 20) {
        gridElement.children(".k-grid-content").height(Height);
    }
}

function SetGridRestoreHeight() {
    var gridElement = $("#gridRestore"),
        newHeight = gridElement.innerHeight(),
        otherElements = gridElement.children().not(".k-grid-content"),
        otherElementsHeight = 0;
    otherElements.each(function () {
        otherElementsHeight += $(this).outerHeight();
    });
    var $windowHeight = $(window).height();
    var idnavbarmain = $('#idnavbarmain').innerHeight();
    var idtitle = $('#idtitle').innerHeight();
    var tabBody = $('#tabBody').height();
    var formBackupDatabase = $('#formBackupDatabase').height();
    tabBody = (tabBody == null ? 0 : tabBody);
    formBackupDatabase = (formBackupDatabase == null ? 0 : formBackupDatabase);
    var Height = $windowHeight - idnavbarmain - idtitle - tabBody - formBackupDatabase - 110;
    var k_header = $('.k-header').innerHeight();
    var k_grid_toolbar = $('.k-grid-toolbar').innerHeight();
    var k_filter_row = $('.k-filter-row').innerHeight();
    var k_pager_wrap = $('.k-pager-wrap').innerHeight();
    if (k_grid_toolbar != null && k_grid_toolbar != 0) {
        if (k_header != null && k_header != 0) {
            k_header = k_header + k_grid_toolbar;
        } else {
            k_header = k_grid_toolbar;
        }
    } else {
        if (k_header == null || k_header == 0) {
            k_header = 0;
        }
    }
    var divsearchadvanced = getHeightDivSearchAdvanced();
    k_header = (k_header == null ? 0 : k_header);
    k_pager_wrap = (k_pager_wrap == null ? 0 : k_pager_wrap);
    k_filter_row = (k_filter_row == null ? 0 : k_filter_row);
    var Height = Height - k_header - k_pager_wrap - k_filter_row - divsearchadvanced;
    if (Height > 20) {
        gridElement.children(".k-grid-content").height(Height);
    }
}

function SetGridHeightWithNavTab() {
    var gridElement = $("#grid"),
        newHeight = gridElement.innerHeight(),
        otherElements = gridElement.children().not(".k-grid-content"),
        otherElementsHeight = 0;
    otherElements.each(function () {
        otherElementsHeight += $(this).outerHeight();
    });
    var $windowHeight = $(window).height();
    var idnavbarmain = $('#idnavbarmain').innerHeight();
    var idtitle = $('#idtitle').innerHeight();
    var tabBody = $('#tabBody').height();
    var card_header = $('.card-header').innerHeight();
    tabBody = (tabBody == null ? 0 : tabBody);
    card_header = (card_header == null ? 0 : card_header);
    var Height = $windowHeight - idnavbarmain - idtitle - tabBody - card_header - 120;
    var k_header = $('.k-header').innerHeight();
    var k_grid_toolbar = $('.k-grid-toolbar').innerHeight();
    var k_filter_row = $('.k-filter-row').innerHeight();
    var k_pager_wrap = $('.k-pager-wrap').innerHeight();
    if (k_grid_toolbar != null && k_grid_toolbar != 0) {
        if (k_header != null && k_header != 0) {
            k_header = k_header + k_grid_toolbar;
        } else {
            k_header = k_grid_toolbar;
        }
    } else {
        if (k_header == null || k_header == 0) {
            k_header = 0;
        }
    }
    var divsearchadvanced = getHeightDivSearchAdvanced();
    k_header = (k_header == null ? 0 : k_header);
    k_pager_wrap = (k_pager_wrap == null ? 0 : k_pager_wrap);
    k_filter_row = (k_filter_row == null ? 0 : k_filter_row);
    var Height = Height - k_header - k_pager_wrap - k_filter_row - divsearchadvanced;
    if (Height > 20) {
        gridElement.children(".k-grid-content").height(Height);
    }
}

function SetGridHeightWithNavTabIncludeId(idGrid) {
    var gridElement = $("#" + idGrid),
        newHeight = gridElement.innerHeight(),
        otherElements = gridElement.children().not(".k-grid-content"),
        otherElementsHeight = 0;
    otherElements.each(function () {
        otherElementsHeight += $(this).outerHeight();
    });
    var $windowHeight = $(window).height();
    var idnavbarmain = $('#idnavbarmain').innerHeight();
    var idtitle = $('#idtitle').innerHeight();
    var tabBody = $('#tabBody').height();
    var card_header = $('.card-header').innerHeight();
    tabBody = (tabBody == null ? 0 : tabBody);
    card_header = (card_header == null ? 0 : card_header);
    var Height = $windowHeight - idnavbarmain - idtitle - tabBody - card_header - 70;
    var k_header = $('.k-header').innerHeight();
    var k_grid_toolbar = $('.k-grid-toolbar').innerHeight();
    var k_filter_row = $('.k-filter-row').innerHeight();
    var k_pager_wrap = $('.k-pager-wrap').innerHeight();
    if (k_grid_toolbar != null && k_grid_toolbar != 0) {
        if (k_header != null && k_header != 0) {
            k_header = k_header + k_grid_toolbar;
        } else {
            k_header = k_grid_toolbar;
        }
    } else {
        if (k_header == null || k_header == 0) {
            k_header = 0;
        }
    }
    var divsearchadvanced = getHeightDivSearchAdvanced();
    k_header = (k_header == null ? 0 : k_header);
    k_pager_wrap = (k_pager_wrap == null ? 0 : k_pager_wrap);
    k_filter_row = (k_filter_row == null ? 0 : k_filter_row);
    var Height = Height - k_header - k_pager_wrap - k_filter_row - divsearchadvanced;
    if (Height > 20) {
        gridElement.children(".k-grid-content").height(Height);
    }
}

function SetTreeListHeight() {
    var gridElement = $("#grid"),
        newHeight = gridElement.innerHeight(),
        otherElements = gridElement.children().not(".k-grid-content"),
        otherElementsHeight = 0;
    otherElements.each(function () {
        otherElementsHeight += $(this).outerHeight();
    });
    var $windowHeight = $(window).height();
    var idnavbarmain = $('#idnavbarmain').innerHeight();
    var idtitle = $('#idtitle').innerHeight();
    var Height = $windowHeight - idnavbarmain - idtitle - 110;
    var k_header = $('.k-header').innerHeight();
    var k_grid_toolbar = $('.k-grid-toolbar').innerHeight();
    var k_filter_row = $('.k-filter-row').innerHeight();
    var k_pager_wrap = $('.k-pager-wrap').innerHeight();
    if (k_grid_toolbar != null && k_grid_toolbar != 0) {
        if (k_header != null && k_header != 0) {
            k_header = k_header + k_grid_toolbar;
        } else {
            k_header = k_grid_toolbar;
        }
    } else {
        if (k_header == null || k_header == 0) {
            k_header = 0;
        }
    }
    var divsearchadvanced = getHeightDivSearchAdvanced();
    k_header = (k_header == null ? 0 : k_header);
    k_pager_wrap = (k_pager_wrap == null ? 0 : k_pager_wrap);
    k_filter_row = (k_filter_row == null ? 0 : k_filter_row);
    var TreeViewHeight = Height;
    var Height = Height - k_header - k_pager_wrap - k_filter_row - divsearchadvanced;
    if (Height > 20) {
        gridElement.children(".k-grid-content").height(Height);
        gridElement.children(".col-sm-5").height(TreeViewHeight);
        var treelist = $("#treeListTab");
        treelist.height(TreeViewHeight);
    }
}

function SetHeightDanhSachCanhan() {
    var gridElement = $("#gridUser"),
        newHeight = gridElement.innerHeight(),
        otherElements = gridElement.children().not(".k-grid-content"),
        otherElementsHeight = 0;
    otherElements.each(function () {
        otherElementsHeight += $(this).outerHeight();
    });
    var $windowHeight = $(window).height();
    var contentHeight = $windowHeight - 90;
    $('#card-left').height(contentHeight);
    $('#card-right').height(contentHeight);
    var idCheckAndSeach = $('#idCheckAndSeach').innerHeight();
    var Height = $('#card-left').innerHeight() - idCheckAndSeach - 120;
    $("#mylistcbnoibo").height(Height);
    var treeview = $("#treedsnoibo");
    treeview.height(Height);
}

function SetHeightDanhSachDonvi() {
    var gridElement = $("#gridUser"),
        newHeight = gridElement.innerHeight(),
        otherElements = gridElement.children().not(".k-grid-content"),
        otherElementsHeight = 0;
    otherElements.each(function () {
        otherElementsHeight += $(this).outerHeight();
    });
    var $windowHeight = $(window).height();
    var contentHeight = $windowHeight - 90;
    $('#card-left').height(contentHeight);
    $('#card-right').height(contentHeight);
    var idCheckAndSeachDonvi = $('#idCheckAndSeachDonvi').innerHeight();
    var Height = $('#card-left').innerHeight() - idCheckAndSeachDonvi - 120;
    $("#mylistcbnoibo").height(Height);
    var treeview = $("#treedsnoibo");
    treeview.height(Height);
}

function SetGridHeightDonvi() {
    var gridElement = $("#gridDonvi");
    var k_grid_content = $('.k-grid-content').innerHeight();
    var tabBody = $('#tabBody').height();
    tabBody = (tabBody == null ? 0 : tabBody);
    var tabNavDonvi = $('#tabNavDonvi').innerHeight();
    var boxdonvi = $('#boxdonvi').innerHeight();
    var tabBody = $('#tabBody').height();
    var Height = k_grid_content - tabBody - tabNavDonvi - boxdonvi - tabBody + 55;
    gridElement.children(".k-grid-content").height(Height);
    var Tinhtrangxulyvanban = $('#Tinhtrangxulyvanban').innerHeight();
    $('#ChitietvanbanDonvi').height(Tinhtrangxulyvanban);
    $('#treeViewDiv').height(Tinhtrangxulyvanban);
}

function SetTreeViewHeight() {
    var gridElement = $("#grid"),
        newHeight = gridElement.innerHeight(),
        otherElements = gridElement.children().not(".k-grid-content"),
        otherElementsHeight = 0;
    otherElements.each(function () {
        otherElementsHeight += $(this).outerHeight();
    });
    var $windowHeight = $(window).height();
    var idnavbarmain = $('#idnavbarmain').innerHeight();
    var idtitle = $('#idtitle').innerHeight();
    var card_header = $('.card-header').innerHeight();
    card_header = (card_header == null ? 0 : card_header);
    var Height = $windowHeight - idnavbarmain - idtitle - card_header - 60;
    var treeview = $("#treeview");
    treeview.height(Height);
}

function SetHeightMainFormReport() {
    var $windowHeight = $(window).height();
    var idnavbarmain = $('#idnavbarmain').innerHeight();
    var idtitle = $('#idtitle').innerHeight();
    var tabBody = $('#tabBody').height();
    tabBody = (tabBody == null ? 0 : tabBody);
    var card_header = $('.card-header').innerHeight();
    card_header = (card_header == null ? 0 : card_header);
    var Height = $windowHeight - idnavbarmain - idtitle - tabBody - card_header - 50;
    var mainformreport = $("#MainFormReport");
    mainformreport.height(Height);
}

function SetHeightMainFormReportWithId(fromHeight, toHeight) {
    var mainId = $('#' + fromHeight).height();
    var Height = mainId - 200;
    var mainformreport = $("#" + toHeight);
    mainformreport.height(Height);
}

function LayThuCuaNgayHienTai(current_day) {
    var day_name = "";
    switch (current_day) {
        case 1:
            day_name = "Thứ Hai";
            break;
        case 2:
            day_name = "Thứ Ba";
            break;
        case 3:
            day_name = "Thứ Tư";
            break;
        case 4:
            day_name = "Thứ Năm";
            break;
        case 5:
            day_name = "Thứ Sáu";
            break;
        case 6:
            day_name = "Thứ Bảy";
        case 7:
            day_name = "Chủ Nhật";
            break;
    }
    return day_name;
}

function checkExistKendoGrid(gridName) {
    var kendoGrid = $("#" + gridName).data("kendoGrid");
    if (kendoGrid) {
        return true;
    }
    else {
        return false;
    }
}

function RefreshGrid() {
    $("#grid").data("kendoGrid").dataSource.read();
    $("#grid").data("kendoGrid").refresh();
}

function ButtonEnable(item, bool) {
    var id = '#' + item;
    if (bool) {
        $(id).removeAttr("disabled");
    } else {
        $(id).attr("disabled", "disabled");
    }
}

function ButtonVisible(item, bool) {
    var id = '#' + item;
    if (bool) {
        $(id).removeAttr("disabled");
        $(id).show();
    } else {
        $(id).attr("disabled", "disabled");
        $(id).hide();
    }
}

function RemoveSpecialChar(str) {
    return str.replace(/[^a-z0-9\s]/gi, '').replace(/^_+|_+$/g, '')
}

function ConvertViToEn(str, toUpperCase = true) {
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/\u0300|\u0301|\u0303|\u0309|\u0323/g, "");
    str = str.replace(/\u02C6|\u0306|\u031B/g, "");
    return toUpperCase ? str.toUpperCase() : str;
}

function func_exists(fname) {
    return (typeof window[fname] === 'function');
}

function closeWindow() { }

function setInnerHTMLNull(id) {
    var doc = document.getElementById(id);
    if (doc != null) {
        doc.innerHTML = "";
    }
}