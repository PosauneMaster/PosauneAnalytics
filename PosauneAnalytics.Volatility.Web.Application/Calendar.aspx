<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="PosauneAnalytics.Volatility.Web.Application.Calendar" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <%: Scripts.Render("~/bundles/FullCalendarJs") %>
    <%: Scripts.Render("~/bundles/CalendarPageJs") %>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">

     <%: Styles.Render("~/bundles/FullCalendarCss")  %>
     <%: Styles.Render("~/bundles/CalendarPageCss")  %>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
        <div style="height:50px;"></div>
    <div><asp:Button runat="server" Text="Clear" Width="120px" Height="26px" ClientIDMode="Static" ID="btnClear" UseSubmitBehavior="false" OnClientClick="removeAll(); return false;"/></div>

    <table id="mainTable">
        <tr>
            <td style="vertical-align: top; padding: 50px 12px 0 0;">
                <table>
                    <tr>
                        <td>
                            <div id='external-events'>
                                <h4>Weights</h4>
                                <div class='fc-event' id="weight_zero" data-weight="0">Weight: Zero</div>
                                <div class='fc-event' id="weight_1" data-weight="1.0" style="background-color: black; color: white;">Weight: Normal</div>
                                <div class='fc-event' id="weight_1_5" data-weight="1.5" style="background-color: darkblue; color: white;">Weight: 1.5</div>
                                <div class='fc-event' id="weight_2_0" data-weight="2.0" style="background-color: green; color: white;">Weight: 2.0</div>
                                <div class='fc-event' id="weight_2_5" data-weight="2.5" style="background-color: olive; color: white;">Weight: 2.5</div>
                                <div class='fc-event' id="weight_3_0" data-weight="3.0" style="background-color: orange; color: black;">Weight: 3.0</div>
                                <div>
                                    <div style="margin-bottom: 4px;">
                                        <input type="checkbox" id="recurring-event" style="float: left; margin-right: 0.4em;" />
                                        <label for="recurring-event" style="font-size: 12px; font-weight: normal;">Recurring Event</label>
                                    </div>
                                    <div style="vertical-align: bottom;">
                                        <label for="txtWeight" style="font-size: 12px; font-weight: normal;">Weight:</label>
                                        <input id="txtWeight" style="width: 50px; margin-left: 15px; height: 24px;" /><br />
                                    </div>
                                </div>
                                <div class='fc-event' id="weight_custom" data-weight="-1.0" style="background-color: gold; color: black;">Weight: Custom</div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="profile-options">
                                <div><asp:Label runat="server" ID="Label3" Text="Profiles:"></asp:Label></div>
                                <div><asp:DropDownList runat="server" ID="ddlProfilenames" ClientIDMode="Static" Width="160px" AutoPostBack="false"></asp:DropDownList></div>
                                <div style="margin-top:10px;"><asp:Label runat="server" ID="Label4" Text="Profile Name:"></asp:Label></div>
                                <div><asp:TextBox runat="server" ID="txtProfilename" Width="162px"></asp:TextBox></div>
                                <div style="margin-top:16px">
                                    <asp:Button runat="server" ID="btnProfilenameLoad" Text="Load" ClientIDMode="Static" UseSubmitBehavior="false" CssClass="btn btn-primary btn-sm" OnClientClick="loadProfile(); return false;" />
                                    <asp:Button runat="server" ID="btnProfilenameSave" Text="Save" ClientIDMode="Static" CssClass="btn btn-primary btn-sm" OnClick="btnProfileNameSave_Click" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width:500px; height:500px;">
                <div id='calendar'></div>
            </td>
        </tr>
    </table>

</asp:Content>
