///CHỈNH SỬA LẦN CUỐI VÀO NGÀY 13/03/2024

///Message string
var noDataMessage = 'Bạn chưa chọn dữ liệu!';
var errorMessage = 'Hết phiên làm việc, xin vui lòng đăng nhập lại!';
var titleConfirm = 'Thông báo xác nhận';
var deleteContent = 'Bạn muốn xóa thông tin này không?';
var guiDuyetContent = 'Bạn muốn gửi duyệt thông tin này không?';
var duyetContent = 'Bạn muốn duyệt thông tin này không?';
var khongDuyetContent = 'Bạn muốn không duyệt thông tin này không?';
var deleteSuccess = 'Xóa thông tin thành công!';
var updateSuccess = 'Cập nhật dữ liệu thành công!';
var addSuccess = 'Thêm dữ liệu thành công!';

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
        var contentHTML = "<div class='sweet-alert  showSweetAlert visible' tabindex='-1' data-custom-class='' data-has-cancel-button='true' data-has-confirm-button='true' data-allow-outside-click='true' data-has-done-function='true' data-animation='pop' data-timer='null' style='display: block;'>";
        contentHTML += "<div class='modal-body' style='display: block;'>";
        contentHTML += "<h3 class='text-danger mb-0'>";
        contentHTML += message;
        contentHTML += "</h3>";
        contentHTML += "</div>";
        contentHTML += "<p class='lead text-muted '></p>";
        contentHTML += "<div class='modal-footer' style='padding: 4px'>";
        for (index = 0; index < buttons.length; ++index) {
            if (buttons[index].text == "Có") {
                contentHTML += "<button class='confirm btn btn-sm btn-success btn-class-confirm-" + index + "' tabindex='1' style='display: inline-block;'>" + "<i class='fas fa-check-square'></i> " + buttons[index].text + "</button>";
            }
            else {
                contentHTML += "<button class='cancel btn btn-sm btn-warning btn-class-confirm-" + index + "' tabindex='" + (index + 1) + "' style='display: inline-block;'>" + "<i class='fas fa-times-square'></i> " + buttons[index].text + "</button>";
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
                    //console.log(e.data.text);
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
            width: 350,
            index: 999999,
        });
        kendoWindow.css("z-index", 10052);
        kendoWindow.data("kendoWindow")
            .content(contentHTML)
            .center().open();

        for (index = 0; index < buttons.length; ++index) {
            var b = buttons[index];
            kendoWindow
                .find('.btn-class-confirm-' + index)
                .click(b, function (e) {
                    //console.log(e.data.text);
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
                    //console.log(e.data.text);
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
                    //console.log(e.data.text);
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
        //console.log(gridName + "--" + chkboxAllName + "--" + urlAction);
        var arrID = [];
        var grid = $(gridName).data().kendoGrid;
        for (var i = 0; i < grid.dataSource.view().length; i++) {
            // console.log(grid.dataSource.view()[i]);
            if (grid.dataSource.view()[i]['IsSelected'] == true)

                //add vô array ID
                arrID.push(grid.dataSource.view()[i]['ID']);

        }
        //console.log("final :" + arrID);
        if (arrID.length > 0) {
            var dataArr = JSON.stringify({ 'arr': arrID });
            console.log(dataArr);
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
                        console.log(request + ' ' + err);
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
    },

    datedIff: function (first, second) {
        return Math.round((second - first) / (1000 * 60 * 60 * 24));
    },

    random_guid: function () {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'
            .replace(/[xy]/g, function (c) {
                const r = Math.random() * 16 | 0,
                    v = c == 'x' ? r : (r & 0x3 | 0x8);
                return v.toString(16);
            });
    }
}
