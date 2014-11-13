<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CalendarAnalytics.aspx.cs" Inherits="PosauneAnalytics.Web.Application.CalendarAnalytics" %>


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
        }

        .example1 {
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

    </style>




</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height:50px;"></div>

    <table>
        <tr>
            <td>
                <span>Analysis Date:</span>
                <asp:TextBox runat="server" ID="txtAnalysisDate" CssClass="expiration"></asp:TextBox>
                <asp:ImageButton runat="server" ID="imgAnalysisDate" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" />
                <ajaxToolkit:CalendarExtender runat="server" ID="calAnalysisDate" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgAnalysisDate" TargetControlID="txtAnalysisDate"></ajaxToolkit:CalendarExtender>

                <table id="expirationTable">
                    <tr style="height:24px;"></tr>
                    <tr>
                        <th>Expiration Date</th>
                        <th></th>
                        <th></th>
                        <th>Volatility</th>
                        <th>Days</th>
                        <th>Weighted Days</th>

                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate1" CssClass="example1"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar1" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1"/>
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar1" TargetControlID="txtExpirationDate1"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility1" CssClass="volatility"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender1" TargetControlID="txtVolatility1" Mask="99.99%" MaskType="None" AcceptNegative="None" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays1" CssClass="volatility"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays1" CssClass="volatility"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate2" CssClass="expiration"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar2" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender2" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar2" TargetControlID="txtExpirationDate2"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility2" CssClass="volatility"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender2" TargetControlID="txtVolatility2" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays2" CssClass="volatility"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays2" CssClass="volatility"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate3" CssClass="expiration"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar3" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender3" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar3" TargetControlID="txtExpirationDate3"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility3" CssClass="volatility"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender3" TargetControlID="txtVolatility3" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays3" CssClass="volatility"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays3" CssClass="volatility"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate4" CssClass="expiration"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar4" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender4" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar4" TargetControlID="txtExpirationDate4"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility4" CssClass="volatility"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender4" TargetControlID="txtVolatility4" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays4" CssClass="volatility"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays4" CssClass="volatility"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate5" CssClass="expiration"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar5" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender5" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar5" TargetControlID="txtExpirationDate5"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility5" CssClass="volatility"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender5" TargetControlID="txtVolatility5" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays5" CssClass="volatility"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays5" CssClass="volatility"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate6" CssClass="expiration"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar6" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender6" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar6" TargetControlID="txtExpirationDate6"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility6" CssClass="volatility"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender6" TargetControlID="txtVolatility6" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays6" CssClass="volatility"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays6" CssClass="volatility"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate7" CssClass="expiration"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar7" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender7" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar7" TargetControlID="txtExpirationDate7"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility7" CssClass="volatility"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender7" TargetControlID="txtVolatility7" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays7" CssClass="volatility"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays7" CssClass="volatility"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate8" CssClass="expiration"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar8" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender8" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar8" TargetControlID="txtExpirationDate8"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility8" CssClass="volatility"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender8" TargetControlID="txtVolatility8" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays8" CssClass="volatility"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays8" CssClass="volatility"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate9" CssClass="expiration"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar9" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender9" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar9" TargetControlID="txtExpirationDate9"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility9" CssClass="volatility"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender9" TargetControlID="txtVolatility9" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays9" CssClass="volatility"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays9" CssClass="volatility"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtExpirationDate10" CssClass="expiration"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton runat="server" ID="imgCalendar10" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" TabIndex="-1" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender10" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgCalendar10" TargetControlID="txtExpirationDate10"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtVolatility10" CssClass="volatility"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender runat="server" ID="volExtender10" TargetControlID="txtVolatility10" Mask="99.99%" MaskType="Number" />
                        </td>
                        <td><asp:TextBox runat="server" ID="txtDays10" CssClass="volatility"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" ID="txtWdays10" CssClass="volatility"></asp:TextBox></td>
                    </tr>
                </table>
            </td>

        </tr>


    </table>


</asp:Content>
