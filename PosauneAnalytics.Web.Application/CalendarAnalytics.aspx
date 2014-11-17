<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CalendarAnalytics.aspx.cs" Inherits="PosauneAnalytics.Web.Application.CalendarAnalytics" %>


<asp:Content ContentPlaceHolderID="headerPalceHolder" runat="server">

    <link rel='stylesheet' href='Content/fullcalendar.min.css' />
    <script src='Scripts/jquery.min.js'></script>
    <script src='Scripts/moment.min.js'></script>
    <script src='Scripts/fullcalendar.min.js'></script>
    <script src='Scripts/jquery-ui.custom.min.js'></script>
<%--    <script>var $j=jQuery.noConflict(true);</script>--%>


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

        
        /*.fc-header-title {
            font-size: 10px;
            white-space: normal !important;
        }*/



        /*.fc-header-title h2 {
            font-size: .9em;
            white-space: normal !important;
        }

        .fc-view-month .fc-event, .fc-view-agendaWeek .fc-event {
            font-size: 0;
            overflow: hidden;
            height: 2px;
        }

        .fc-view-agendaWeek .fc-event-vert {
            font-size: 0;
            overflow: hidden;
            width: 2px !important;
        }

        .fc-agenda-axis {
            width: 20px !important;
            font-size: .7em;
        }

        .fc-button-content {
            padding: 0;
        }*/

        /*#mainTable, th, td {
            border:1px solid green;
            border-collapse: collapse;
        }*/

    </style>

    <script type="text/javascript">

        $(document).ready(function () {

            var $j = jQuery.noConflict(true);
            $('#calendar').fullCalendar({
                header: {
                    left: 'prev, next, today',
                    center: 'title',
                    right: 'month, agendaWeek, agendaDay'
                },
                defaultView: 'month',
                editable: true,
                allDaySlot: false,
                selectable: true,
                slotMinutes: 15,
                droppable: true, // this allows things to be dropped onto the calendar
                drop: function () {
                    // is the "remove after drop" checkbox checked?
                    if ($('#drop-remove').is(':checked')) {
                        // if so, remove the element from the "Draggable Events" list
                        $(this).remove();
                    }
                }
            });

            $('#external-events .fc-event').each(function () {

                // store data so the calendar knows to render an event upon drop
                $(this).data('event', {
                    title: $.trim($(this).text()), // use the element's text as the event title
                    stick: true // maintain when user navigates (see docs on the renderEvent method)
                });

                // make the event draggable using jQuery UI
                $(this).draggable({
                    zIndex: 999,
                    revert: true,      // will cause the event to go back to its
                    revertDuration: 0  //  original position after the drag
                });

            });


        });




        var _MS_PER_DAY = 1000 * 60 * 60 * 24;

        function calcDateDiff(ctrlAnalysisDate, ctrlTarget) {

            var date1 = parseDate($("#<%= txtAnalysisDate.ClientID %>").val());
            var date2 = parseDate($(ctrlAnalysisDate).val());
            var diff = dateDiffInDays(date1, date2);
            $(ctrlTarget).val(diff);
        }

        function parseDate(str) {
            var mdy = str.split('/')
            return new Date(mdy[2], mdy[0] - 1, mdy[1]);
        }

        function dateDiffInDays(a, b) {
            var utc1 = Date.UTC(a.getFullYear(), a.getMonth(), a.getDate());
            var utc2 = Date.UTC(b.getFullYear(), b.getMonth(), b.getDate());
            return Math.floor((utc2 - utc1) / _MS_PER_DAY);
        }

    </script>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
    <div style="height:50px;"></div>

    <table id="mainTable">
        <tr>
            <td>
                <div>
                <table>
                    <tr>
                        <td><span>Analysis Date:</span></td>
                        <td><asp:TextBox runat="server" ID="txtAnalysisDate" CssClass="expireDateInfo"></asp:TextBox></td>
                        <td style="padding-top:12px;">
                            <asp:ImageButton runat="server" ID="imgAnalysisDate" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="calAnalysisDate" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgAnalysisDate" TargetControlID="txtAnalysisDate"></ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
                    </div>
                </td>
                <td style="width:80px;"></td>
                <td></td>
                </tr>
        <tr>
            <td>
                <div>
                <table id="expirationTable">
                    <tr>
                        <th>Expiration Date</th>
                        <th></th>
                        <th></th>
                        <th>Volatility</th>
                        <th>Days</th>
                        <th>Weighted</th>

                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate1" CssClass="expireDateInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar1" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1"/>
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar1" TargetControlID="txtExpirationDate1"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility1" CssClass="expireInfo" On></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender1" TargetControlID="txtVolatility1" Mask="99.99%" MaskType="None" AcceptNegative="None" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays1" CssClass="expireInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays1" CssClass="expireInfo"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate2" CssClass="expireDateInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar2" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender2" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar2" TargetControlID="txtExpirationDate2"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility2" CssClass="expireInfo"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender2" TargetControlID="txtVolatility2" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays2" CssClass="expireInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays2" CssClass="expireInfo"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate3" CssClass="expireDateInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar3" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender3" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar3" TargetControlID="txtExpirationDate3"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility3" CssClass="expireInfo"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender3" TargetControlID="txtVolatility3" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays3" CssClass="expireInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays3" CssClass="expireInfo"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate4" CssClass="expireDateInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar4" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender4" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar4" TargetControlID="txtExpirationDate4"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility4" CssClass="expireInfo"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender4" TargetControlID="txtVolatility4" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays4" CssClass="expireInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays4" CssClass="expireInfo"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate5" CssClass="expireDateInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar5" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender5" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar5" TargetControlID="txtExpirationDate5"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility5" CssClass="expireInfo"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender5" TargetControlID="txtVolatility5" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays5" CssClass="expireInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays5" CssClass="expireInfo"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate6" CssClass="expireDateInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar6" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender6" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar6" TargetControlID="txtExpirationDate6"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility6" CssClass="expireInfo"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender6" TargetControlID="txtVolatility6" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays6" CssClass="expireInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays6" CssClass="expireInfo"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate7" CssClass="expireDateInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar7" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender7" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar7" TargetControlID="txtExpirationDate7"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility7" CssClass="expireInfo"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender7" TargetControlID="txtVolatility7" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays7" CssClass="expireInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays7" CssClass="expireInfo"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate8" CssClass="expireDateInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar8" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender8" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar8" TargetControlID="txtExpirationDate8"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility8" CssClass="expireInfo"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender8" TargetControlID="txtVolatility8" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays8" CssClass="expireInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays8" CssClass="expireInfo"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate9" CssClass="expireDateInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar9" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender9" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar9" TargetControlID="txtExpirationDate9"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility9" CssClass="expireInfo"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender9" TargetControlID="txtVolatility9" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays9" CssClass="expireInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays9" CssClass="expireInfo"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate10" CssClass="expireDateInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar10" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender10" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar10" TargetControlID="txtExpirationDate10"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility10" CssClass="expireInfo"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender10" TargetControlID="txtVolatility10" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays10" CssClass="expireInfo" ClientIDMode="Static"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays10" CssClass="expireInfo"></asp:TextBox></td>
                    </tr>
                </table>
                    </div>
            </td>
            <td></td>
            <td>
                <div id='external-events'>
                    <h4>Draggable Events</h4>
                    <div class='fc-event'>My Event 1</div>
                    <div class='fc-event'>My Event 2</div>
                    <div class='fc-event'>My Event 3</div>
                    <div class='fc-event'>My Event 4</div>
                    <div class='fc-event'>My Event 5</div>
                    <p>
                        <input type='checkbox' id='drop-remove' />
                        <label for='drop-remove'>remove after drop</label>
                    </p>
                </div>
            </td>
            <td style="width:500px; height:500px;">
                <div id='calendar'></div>
            </td>
        </tr>


    </table>


</asp:Content>
