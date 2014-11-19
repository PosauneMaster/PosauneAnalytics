<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PosauneAnalytics.Web.UI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<meta charset='utf-8' />
<link href='Content/fullcalendar.css' rel='stylesheet' />
<link href='Content/fullcalendar.print.css' rel='stylesheet' media='print' />
<script src='Scripts/moment.min.js'></script>
<script src='Scripts/jquery-1.10.2.min.js'></script>
<script src='Scripts/jquery-ui-1.11.2.min.js'></script>
<script src='Scripts/fullcalendar.min.js'></script>
<script>

    $(document).ready(function () {

        $('#myEvent1').data('event', {title: 'myEvent1', stick: true });

        /* initialize the external events
		-----------------------------------------------------------------*/

        $('#external-events .fc-event').each(function () {

            var eventObject = {
                title: $.trim($(this).text()), // use the element's text as the event title
                backgroundColor: $(this).css('background-color'),
                textColor: $(this).css('color'),
                weight: $(this).attr('data-weight').valueOf()

            };

            // store data so the calendar knows to render an event upon drop
            $(this).data('eventObject', {
                title: $.trim($(this).text()), // use the element's text as the event title
                stick: true, // maintain when user navigates (see docs on the renderEvent method)
                color: $(this).color,
                backgroundColor: $(this).css('background-color'),
                textColor: $(this).css('color'),
                weight: $(this).attr('data-weight').valueOf()

            });

            // make the event draggable using jQuery UI
            $(this).draggable({
                zIndex: 999,
                revert: true,      // will cause the event to go back to its
                revertDuration: 0  //  original position after the drag
            });

        });


        /* initialize the calendar
		-----------------------------------------------------------------*/

        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month'
            },
            editable: true,
            droppable: true, // this allows things to be dropped onto the calendar
            drop: function (date, allDay) { // this function is called when something is dropped

                // retrieve the dropped element's stored Event Object
                var originalEventObject = $(this).data('eventObject');

                // we need to copy it, so that multiple events don't have a reference to the same object
                var copiedEventObject = $.extend({}, originalEventObject);

                // assign it the date that was reported
                copiedEventObject.start = date;
                copiedEventObject.allDay = allDay;
                copiedEventObject.title = originalEventObject.title;
                copiedEventObject.backgroundColor = originalEventObject.backgroundColor;
                copiedEventObject.textColor = originalEventObject.textColor;
                copiedEventObject.weight = originalEventObject.weight;
                copiedEventObject.id = date.toDateString();
                copiedEventObject.editable = false;

                $('#calendar').fullCalendar('removeEvents', copiedEventObject.id);

                postEvent();

                if (copiedEventObject.weight != "1")
                {
                    $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);
                }


                // render the event on the calendar
                // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
                //$('#calendar').fullCalendar('renderEvent', copiedEventObject, true);

                //// is the "remove after drop" checkbox checked?
                //if ($('#drop-remove').is(':checked')) {
                //    // if so, remove the element from the "Draggable Events" list
                //    $(this).remove();
                //}

            }
        });

        function postEvent() {

            $.ajax({
                type: 'POST',
                url: 'WebForm1.aspx/TestAjax',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json'


            });

        };


    });

</script>
<style>

	body {
		margin-top: 40px;
		text-align: center;
		font-size: 14px;
		font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
	}
		
	#wrap {
		width: 1100px;
		margin: 0 auto;
	}
		
	#external-events {
		float: left;
		width: 150px;
		padding: 0 10px;
		border: 1px solid #ccc;
		background: #eee;
		text-align: left;
	}
		
	#external-events h4 {
		font-size: 16px;
		margin-top: 0;
		padding-top: 1em;
	}
		
	#external-events .fc-event {
		margin: 10px 0;
		cursor: pointer;
	}
		
	#external-events p {
		margin: 1.5em 0;
		font-size: 11px;
		color: #666;
	}
		
	#external-events p input {
		margin: 0;
		vertical-align: middle;
	}

	#calendar {
		float: right;
		width: 900px;
	}

</style>
</head>
<body>
	<div id='wrap'>

        <div id='external-events'>
            <h4>Weights</h4>
            <div class='fc-event' data-weight="0">Weight: Zero</div>
            <div class='fc-event' data-weight="1" style="background-color:black; color:white;">Weight: Normal</div>
            <div class='fc-event' data-weight="1.5" style="background-color:darkblue; color:white;">Weight: 1.5</div>
            <div class='fc-event' data-weight="2.0" style="background-color:green; color:white;">Weight: 2.0</div>
            <div class='fc-event' data-weight="2.5" style="background-color:olive; color:white;">Weight: 2.5</div>
            <div class='fc-event' data-weight="3.0" style="background-color:orange; color:black;">Weight: 3.0</div>
            <div class='fc-event' data-weight="4.0" style="background-color:gold; color:black;">Weight: Custom</div>
        </div>

		<div id='calendar'></div>

		<div style='clear:both'></div>

	</div>
</body>
</html>
