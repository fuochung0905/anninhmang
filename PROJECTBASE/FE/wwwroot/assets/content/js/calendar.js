(function ($) {
    'use strict';
    $(function () {
        if ($('#calendar').length) {
            $('#calendar').fullCalendar({
                minTime: "00:00",
                maxTime: "24:00",
                dayNamesShort: ['Chủ nhật', 'Thứ 2', 'Thứ 3', 'Thứ 4', 'Thứ 5', 'Thứ 6', 'Thứ 7'],
                header: {
                    left: 'prev, next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay,addEventButton'
                },
                viewRender: function (view, element) {
                    //Edit lại title của header center
                    $(".fc-center h2").text("Hôm nay: " + moment(new Date()).format("LT, dd M/D/YYYY"));
                },
                timeZone: 'UTC',
                initialView: 'resourceTimeGridDay',
                customButtons: {
                    addEventButton: {
                        text: 'Thêm cuộc họp',
                        click: function () {
                            var dateStr = prompt('Enter a date in YYYY-MM-DD format');
                            var date = new Date(dateStr + 'T00:00:00'); // will be in local time

                            if (!isNaN(date.valueOf())) { // valid?
                                calendar.addEvent({
                                    title: 'dynamic event',
                                    start: date,
                                    allDay: true
                                });
                                alert('Great. Now, update your database...');
                            } else {
                                alert('Invalid date.');
                            }
                        }
                    }
                },
                locale: "vi",
                defaultDate: '2022-12-01',
                eventColor: '#CE7A58',
                navLinks: true, // can click day/week names to navigate views
                editable: true,
                eventLimit: true, // allow "more" link when too many events
                dayMaxEvents: true, // when too many events in a day, show the popover
                events: [{
                    title: 'All Day Event',
                    start: '2022-12-01T16:00:00'
                },
                {
                    title: 'All Day Event',
                    start: '2022-12-01T15:00:00'
                },
                {
                    title: 'All Day Event',
                    start: '2022-12-01T16:00:00'
                },
                {
                    title: 'All Day Event',
                    start: '2022-12-01T16:00:00'
                },
                {
                    title: 'All Day Event',
                    start: '2022-12-01T16:00:00'
                },
                {
                    title: 'Test',
                    start: '2022-12-12T12:00:00',
                    end: '2022-12-12T14:00:00'
                },
                {
                    title: 'Long Event',
                    start: '2017-07-01',
                    end: '2017-07-07'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: '2017-07-09T16:00:00'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: '2017-07-16T16:00:00'
                },
                {
                    title: 'Conference',
                    start: '2017-07-11',
                    end: '2017-07-13'
                },
                {
                    title: 'Meeting',
                    start: '2017-07-12T10:30:00',
                    end: '2017-07-12T12:30:00'
                },
                {
                    title: 'Lunch',
                    start: '2017-07-12T12:00:00'
                },
                {
                    title: 'Meeting',
                    start: '2017-07-12T14:30:00'
                },
                {
                    title: 'Happy Hour',
                    start: '2017-07-12T17:30:00'
                },
                {
                    title: 'Dinner',
                    start: '2017-07-12T20:00:00'
                },
                {
                    title: 'Birthday Party',
                    start: '2017-07-13T07:00:00'
                },
                {
                    title: 'Click for Google',
                    url: 'http://google.com/',
                    start: '2017-07-28'
                }
                ]
            })


            //var days = $(".fc-day-top");
            //var attributes = [];

            //var rangeStart = moment("2022-12-08");
            //var rangeEnd = moment("2022-12-15");
            //days.each(function (index, element) {
            //    var day = moment($(this).data("date"));
            //    if (day.isBetween(rangeStart, rangeEnd)) {
            //        $(element).append("<div class='card' style='width: 100%; background-color:unset'><div class='card-body' style='padding: 4px !important'><div><p class='text-info mb-1'>Địa điểm: <span class=''>ABC</span></p><p class='mb-1'>Thành phần: <span class=''>ABC</span></p><p class='mb-2'><span class='label label-primary fs-90ft'>9:30 <i class='fas fa-microphone'></i></span></p><p class='mb-1'><span class='lable label-default fs-90ft'>Họp đánh giá công vụ</span></p></div></div></div>");
            //    }
            //});
        }
    });
})(jQuery);