<%@ Page Language="C#" Title="Calendar" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CalendarAnalysis.aspx.cs" Inherits="PosauneAnalytics.Web.Application.CalendarAnalysis" %>


<asp:Content ContentPlaceHolderID="headerPalceHolder" runat="server">

    <style type="text/css">

        #expirationTable td {
            white-space:nowrap;
        }

        .expiration {
            width:120px;
        }

        .volatility {
            width:100px;
        }

        #expirationTable th {
            text-align:center;
        }

        #expirationTable th td{
            padding:5px;
            padding-top:12px;
        }

        .expireDateInfo {
	        background: white;
	        border: 1px solid #808080;
	        border-radius: 5px;
	        box-shadow: 0 0 5px #DDD inset;
	        color: #666;
	        float: left;
	        padding: 5px 10px;
	        width: 120px;
	        outline: none;
        }

        .expireInfo {
	        background: white;
	        border: 1px solid #808080;
	        border-radius: 5px;
	        box-shadow: 0 0 5px #DDD inset;
	        color: #666;
	        float: left;
	        padding: 5px 10px;
	        width: 80px;
	        outline: none;
        }

        #calendar {
            width: 600px;
            margin: 0 auto;
            font-size: 12px;
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

    #analysis-date {
        width: 260px;
        height:50px;
        padding: 6px 0 0 5px;
		border: 1px solid #ccc;
		background: #eee;
		text-align: left;
    }
        
    </style>

    <script type="text/javascript">

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

                if (verified)
                {
                    e.preventDefault();
                }

            });

            $('.expireInfo').change(function (e) {

                var v = $('#' + e.currentTarget.id).val();

                if ($.isNumeric(v))
                {
                    $('#' + e.currentTarget.id).val(v + '%');
                }
                else
                {
                    $('#' + e.currentTarget.id).val('');
                }
            });


            $('#txtWeight').keyup(function (obj) {

                if ($.isNumeric(this.value))
                {
                    $('#customEvent').html('Weight: ' + this.value);

                    var eventObj = $('#customEvent').data('eventObject');
                    eventObj.weight = this.value;
                }
                else
                {
                    obj.stopPropagation();
                }
            });

            $('#txtWeight').keypress(function (e) {

                var v = $('#txtWeight').val();
                var verified;

                if (v.indexOf('.') >= 0)
                {
                    verified = (e.which == 8 || e.which == undefined || e.which == 0 ) ? null : String.fromCharCode(e.which).match(/[^0-9]/);
                }
                else
                {
                    verified = (e.which == 8 || e.which == undefined || e.which == 0 || e.which == 46) ? null : String.fromCharCode(e.which).match(/[^0-9]/);
                }

                if (verified)
                {
                    e.preventDefault();
                }
            });


            $('#myEvent1').data('event', { title: 'myEvent1', stick: true });

            $('#external-events .fc-event').each(function () {

                var eventObject = {
                    title: $.trim($(this).text()),
                    backgroundColor: $(this).css('background-color'),
                    textColor: $(this).css('color'),
                    weight: $(this).attr('data-weight').valueOf()

                };

                $(this).data('eventObject', {
                    title: $.trim($(this).text()),
                    stick: true,
                    color: $(this).color,
                    backgroundColor: $(this).css('background-color'),
                    textColor: $(this).css('color'),
                    weight: $(this).attr('data-weight').valueOf()

                });

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


                    var originalEventObject = $(this).data('eventObject');
                    var copyEvent = createEvent(date, allDay, originalEventObject);

                    $('#calendar').fullCalendar('removeEvents', copyEvent.id);

                    var fullCalendarEvents = $.makeArray(copyEvent);

                    var calEvent =
                        {
                            EventDate: date.toDateString(),
                            Weight: originalEventObject.weight
                        }

                    var calEvents = $.makeArray(calEvent);

                    if ($("#recurring-event").is(':checked'))
                    {
                            for (i = 1; i < 53; i++ ) 
                            {
                                var nextDate = new Date(date);
                                nextDate.setDate(date.getDate() + (i * 7));

                                var nextEvent = createEvent(nextDate, allDay, originalEventObject);
                                $('#calendar').fullCalendar('removeEvents', nextEvent.id);

                                var item =
                                    {
                                        EventDate: nextEvent.start.toDateString(),
                                        Weight: nextEvent.weight
                                    }

                                calEvents.push(item);
                                fullCalendarEvents.push(nextEvent);
                            }
                    }


                    var result = $.ajax({
                        type: 'POST',
                        url: 'CalendarAnalysis.aspx/AjaxPost',
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

                    if (originalEventObject.title.indexOf('Custom') > 0)
                    {
                        originalEventObject.weight = "-1.0";
                    }

                    $('#customEvent').html('Weight: Custom');
                    $('#txtWeight').val('');
                    $("#recurring-event").prop('checked', false);

                }
            });
        });

        function createEvent(date, allDay, originalEventObject) {

            var copiedEventObject = $.extend({}, originalEventObject);

            copiedEventObject.start = date;
            copiedEventObject.allDay = allDay;
            copiedEventObject.title = "Weight: " + originalEventObject.weight;
            copiedEventObject.backgroundColor = originalEventObject.backgroundColor;
            copiedEventObject.textColor = originalEventObject.textColor;
            copiedEventObject.weight = originalEventObject.weight;
            copiedEventObject.id = date.toDateString();
            copiedEventObject.editable = false;

            return copiedEventObject;

        }

        var _MS_PER_DAY = 1000 * 60 * 60 * 24;

    </script>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
    <div style="height:50px;"></div>

    <table id="mainTable">
        <tr>
            <td style="vertical-align:top; padding:50px 12px 0 0;">
                <div id='external-events'>
                    <h4>Weights</h4>
                    <div class='fc-event' data-weight="0">Weight: Zero</div>
                    <div class='fc-event' data-weight="1.0" style="background-color:black; color:white;">Weight: Normal</div>
                    <div class='fc-event' data-weight="1.5" style="background-color:darkblue; color:white;">Weight: 1.5</div>
                    <div class='fc-event' data-weight="2.0" style="background-color:green; color:white;">Weight: 2.0</div>
                    <div class='fc-event' data-weight="2.5" style="background-color:olive; color:white;">Weight: 2.5</div>
                    <div class='fc-event' data-weight="3.0" style="background-color:orange; color:black;">Weight: 3.0</div>
                    <div>
                        <div style="margin-bottom:4px;">
                            <input type="checkbox" id="recurring-event" style="float:left; margin-right: 0.4em;"/>
                            <label for="recurring-event" style="font-size:12px; font-weight:normal;">Recurring Event</label>
                        </div>
                        <div style="vertical-align:bottom;">
                            <label for="txtWeight" style="font-size:12px; font-weight:normal;">Weight:</label>
                            <input id="txtWeight" style="width:50px; margin-left:15px; height:24px;" /><br />
                        </div>
                    </div>
                    <div class='fc-event' id="customEvent" data-weight="-1.0" style="background-color:gold; color:black;">Weight: Custom</div>
                </div>
            </td>
            <td style="width:500px; height:500px;">
                <div id='calendar'></div>
            </td>
        </tr>


    </table>


</asp:Content>
