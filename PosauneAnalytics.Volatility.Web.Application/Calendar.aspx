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
    <form runat="server" role="form">
        <div class="row">
            <div class="col-md-2">
                <div class="container">
                    <div class="row" style="padding-top: 44px;"></div>
                    <div class="row">
                        <div class="col-md-2 col-md-12">
                            <div id='external-events'>
                                <h4>Weights</h4>
                                <div class='fc-event' id="weight_zero" data-weight="0">Weight: Zero</div>
                                <div class='fc-event' id="weight_1" data-weight="1.0" style="background-color: black; color: white;">Weight: Normal</div>
                                <div class='fc-event' id="weight_1_5" data-weight="1.5" style="background-color: darkblue; color: white;">Weight: 1.5</div>
                                <div class='fc-event' id="weight_2_0" data-weight="2.0" style="background-color: green; color: white;">Weight: 2.0</div>
                                <div class='fc-event' id="weight_2_5" data-weight="2.5" style="background-color: olive; color: white;">Weight: 2.5</div>
                                <div class='fc-event' id="weight_3_0" data-weight="3.0" style="background-color: orange; color: black;">Weight: 3.0</div>
                                <div style="border-top: 1px solid darkgray; padding-top: 6px;">
                                    <fieldset>
                                        <div class="form-group">
                                            <input type="checkbox" id="recurring-event" />
                                            <label for="recurring-event">Recurring Event</label>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtWeight" class="control-label">Weight:</label>
                                            <input id="txtWeight" class="form-control input-sm col-sm-2" /><br />
                                        </div>
                                    </fieldset>
                                    <div class='fc-event' id="weight_custom" data-weight="-1.0" style="background-color: gold; color: black;">Weight: Custom</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 col-md-12">
                            <div id="profile-selector">
                                <fieldset>
                                    <div class="form-group">
                                        <label class="control-label" for="ddlProfilenames">Profiles:</label>
                                        <asp:DropDownList runat="server" ID="ddlProfilenames" CssClass="form-control input-sm" ClientIDMode="Static" AutoPostBack="false"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label" for="txtProfilename">Profile Name:</label>
                                        <asp:TextBox runat="server" ID="txtProfilename" CssClass="form-control input-sm"></asp:TextBox>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 col-md-12">
                            <div class="calendar-buttons">
                                <div class="btn-group">
                                    <asp:Button runat="server" ID="btnClear" Text="Clear" ClientIDMode="Static" CssClass="btn btn-primary btn-sm" UseSubmitBehavior="false" OnClientClick="removeAll(); return false;" />
                                    <asp:Button runat="server" ID="btnProfilenameLoad" Text="Load" ClientIDMode="Static" UseSubmitBehavior="false" CssClass="btn btn-primary btn-sm" OnClientClick="loadProfile(); return false;" />
                                    <asp:Button runat="server" ID="btnProfilenameSave" Text="Save" ClientIDMode="Static" CssClass="btn btn-primary btn-sm" OnClick="btnProfileNameSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-10">
                <div id='calendar'></div>
            </div>
        </div>
    </form>
</asp:Content>
