$(document).ready(function () {

    $('.expireInfo').keypress(function (e) {

        var v = $('#' + e.currentTarget.id).val();
        var verified;

        if (v.indexOf('.') >= 0) {
            verified = (e.which == 8 || e.which == undefined || e.which == 0) ? null : String.fromCharCode(e.which).match(/[^0-9]/);
        }
        else {
            verified = (e.which == 8 || e.which == undefined || e.which == 0 || e.which == 46) ? null : String.fromCharCode(e.which).match(/[^0-9]/);
        }

        if (verified) {
            e.preventDefault();
        }

    });

    $('.expireInfo').change(function (e) {

        var v = $('#' + e.currentTarget.id).val();

        if ($.isNumeric(v)) {
            $('#' + e.currentTarget.id).val(v + '%');
        }
        else {
            $('#' + e.currentTarget.id).val('');
        }
    });


    $('#txtWeight').keyup(function (obj) {

        if ($.isNumeric(this.value)) {
            $('#weight_custom').html('Weight: ' + this.value);

            var eventObj = $('#weight_custom').data($('#weight_custom').attr('id'));
            eventObj.weight = this.value;
        }
        else {
            obj.stopPropagation();
        }
    });

    $('#txtWeight').keypress(function (e) {

        var v = $('#txtWeight').val();
        var verified;

        if (v.indexOf('.') >= 0) {
            verified = (e.which == 8 || e.which == undefined || e.which == 0) ? null : String.fromCharCode(e.which).match(/[^0-9]/);
        }
        else {
            verified = (e.which == 8 || e.which == undefined || e.which == 0 || e.which == 46) ? null : String.fromCharCode(e.which).match(/[^0-9]/);
        }

        if (verified) {
            e.preventDefault();
        }
    });


    $('#myEvent1').data('event', { title: 'myEvent1', stick: true });

    $('#external-events .fc-event').each(function () {

        var id = $(this).attr('id');

        var eventObject = {
            title: $.trim($(this).text()),
            stick: true,
            color: $(this).color,
            backgroundColor: $(this).css('background-color'),
            textColor: $(this).css('color'),
            weight: $(this).attr('data-weight').valueOf()
        };

        $(this).data(id, eventObject);

        $(this).draggable({
            zIndex: 999,
            revert: true,
            revertDuration: 0
        });

    });

    $('#calendar').fullCalendar({
        header: {
            left: '',
            center: 'title',
            right: 'today prev,next '
        },
        editable: true,
        droppable: true,
        drop: function (date, allDay) {

            var title = $.trim($(this).text());
            var id = $(this).attr('id');
            addEvent(id, title, date, allDay);

        }
    });
});

function addEvent(id, title, date, allDay, weight) {

    var originalEventObject = $('#' + id).data(id);

    if (originalEventObject == null) {
        return;
    }

    var wght = originalEventObject.weight;

    if (arguments.length == 5) {
        wght = weight;
    }

    var copyEvent = createEvent(date, allDay, originalEventObject, wght);

    $('#calendar').fullCalendar('removeEvents', copyEvent.id);

    var calEvent =
    {
        Id: id,
        EventDate: date.toDateString(),
        Weight: wght
    }

    if (id == "weight_1") {
        removeEvent(calEvent);
        return;
    }

    var fullCalendarEvents = $.makeArray(copyEvent);

    var calEvents = $.makeArray(calEvent);

    if ($("#recurring-event").is(':checked')) {
        for (i = 1; i < 53; i++) {
            var nextDate = new Date(date);
            nextDate.setDate(date.getDate() + (i * 7));

            var nextEvent = createEvent(nextDate, allDay, originalEventObject, wght);
            $('#calendar').fullCalendar('removeEvents', nextEvent.id);

            var item =
                {
                    Id: id,
                    EventDate: nextEvent.start.toDateString(),
                    Weight: nextEvent.weight
                }

            calEvents.push(item);
            fullCalendarEvents.push(nextEvent);
        }
    }

    var result = $.ajax({
        type: 'POST',
        url: 'CalendarAnalysis.aspx/AddEvent',
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: "{'calEvents':" + JSON.stringify(calEvents) + "}",
        error: function (data) {
            //alert("Error");
        },
        success: function (data) {
            //alert("Success");
        }
    });

    if (originalEventObject.weight != '1.0') {
        $('#calendar').fullCalendar('addEventSource', fullCalendarEvents);
    }

    if (originalEventObject.title.indexOf('Custom') > 0) {
        originalEventObject.weight = "-1.0";
    }

    $('#weight_custom').html('Weight: Custom');
    $('#txtWeight').val('');
    $("#recurring-event").prop('checked', false);
}

function removeAll() {
    var eventsToDelete = $('#calendar').fullCalendar('removeEvents');

    var result = $.ajax({
        type: 'POST',
        url: 'CalendarAnalysis.aspx/ClearAllEvents',
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        error: function (data) {
            //alert("Error");
        },
        success: function (data) {
            //alert("Success");
        }
    });
}

function loadProfile() {
    removeAll();

    var profilename = $('#ddlProfilenames option:selected').text();

    var result = $.ajax({
        type: 'POST',
        url: 'CalendarAnalysis.aspx/LoadProfile',
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: "{'profilename':" + JSON.stringify(profilename) + "}",
        error: function (data) {
            var events = data;
            alert("Error");
        },
        success: function (data) {

            $.each(data.d, function (index, value) {
                var eventObj = value;
                var id = eventObj.Id;
                var title = 'Weight: ' + eventObj.Weight;
                var eventDate = new Date(eventObj.EventDate);
                try {
                    addEvent(id, title, eventDate, true, eventObj.Weight);
                }
                catch (err) {

                }

            });
        }
    });
}

function createEvent(date, allDay, originalEventObject, weight) {

    var copiedEventObject = $.extend({}, originalEventObject);

    copiedEventObject.start = date;
    copiedEventObject.allDay = allDay;
    copiedEventObject.title = "Weight: " + weight;
    copiedEventObject.backgroundColor = originalEventObject.backgroundColor;
    copiedEventObject.textColor = originalEventObject.textColor;
    copiedEventObject.weight = weight;
    copiedEventObject.id = date.toDateString();
    copiedEventObject.editable = false;

    return copiedEventObject;
}

var _MS_PER_DAY = 1000 * 60 * 60 * 24;

function removeEvent(calEvent) {

    var calEvents = $.makeArray(calEvent);
    removeEvents(calEvents);

}

function removeEvents(calEvents) {

    var result = $.ajax({
        type: 'POST',
        url: 'CalendarAnalysis.aspx/RemoveEvents',
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: "{'calEvents':" + JSON.stringify(calEvents) + "}",
        error: function (data) {
            //alert("Error");
        },
        success: function (data) {
            //alert("Success");
        }
    });
}
