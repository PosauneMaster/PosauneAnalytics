<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="VolatilityAnalysis.aspx.cs" Inherits="PosauneAnalytics.Volatility.Web.Application.VolatilityAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">

    <style type="text/css">
        #analysis-selector {
            float: left;
            width: 100%;
            padding: 0 10px;
            border: 1px solid #ccc;
            background: #eee;
            text-align: left;
            border-radius: 8px;
            margin-top: 12px;
        }

        .calendar_popup_image {
            padding-top:4px;
            padding-left:10px;
        }



    </style>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentSection" runat="server">

    <form runat="server" role="form">
        <div class="row>">
            <div class="col-md-2">
                <div id="analysis-selector">
                    <fieldset>
                        <div class="form-group">
                            <label class="control-label" for="txtAnalysisDate">Analysis Date:</label>
                            <asp:TextBox runat="server" ID="txtAnalysisDate" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:ImageButton runat="server" ID="imgAnalysisDate" CssClass="calendar_popup_image" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" />
<%--                            <ajaxToolkit:CalendarExtender runat="server" ID="calAnalysisDate" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgAnalysisDate"
                                         TargetControlID="txtAnalysisDate"></ajaxToolkit:CalendarExtender>--%>
                        </div>

                    </fieldset>

                </div>


            </div>


        </div>            



    </form>


</asp:Content>
