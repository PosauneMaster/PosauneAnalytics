<%@ Page Language="C#" Title="Volatility" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="VolatilityAnalysis.aspx.cs" Inherits="PosauneAnalytics.Web.Application.VolatilityAnalysis" %>

<asp:Content ContentPlaceHolderID="headerPlaceHolder" runat="server">

    <style type="text/css">

        .calendar_popup_image {
            padding-top:4px;
            padding-left:10px;
        }

        #analysis-date {
            width: 200px;
            height: 200px;
            padding: 10px;
            border: 1px solid #ccc;
            background: #eee;
            text-align: left;
            margin-top: 24px;
            vertical-align:top;
            border-radius: 5px;
            box-shadow: 0 0 5px #DDD inset;
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

        .series_info {
            width: 180px;
            height:auto;
            padding: 10px;
            border: 1px solid #ccc;
            background-color:#5596C1;
            color:white;
            text-align: left;
            vertical-align:top;
            border-radius:15px;
            margin-top:20px;
        }

            .series_info div {
                padding: 5px 0 5px 0;
            }

        .data_grid {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #0F465B;
            padding: 0px 4px 0px 8px;
            font-weight: normal;
            line-height: 16px;
            height: 18px;
            text-align:right;
        }


        .data_grid_center {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            color:black;
            background-color:lightblue;
            padding: 0px 4px 0px 20px;
            font-weight: bold;
            line-height: 16px;
            height: 18px;
        }

        .header_grid {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            line-height: 14px;
            background-color: #1b435e;
            color: #ffffff;
            font-weight: normal;
            padding-bottom: 1px;
            padding-left: 1px;
            padding-top: 1px;
            padding-right: 1px;
            line-height: 18px;
            text-align:center;
        }

        .button {
            border-top: 1px solid #96d1f8;
            background: #579ac7;
            background: -webkit-gradient(linear, left top, left bottom, from(#343a3d), to(#579ac7));
            background: -webkit-linear-gradient(top, #343a3d, #579ac7);
            background: -moz-linear-gradient(top, #343a3d, #579ac7);
            background: -ms-linear-gradient(top, #343a3d, #579ac7);
            background: -o-linear-gradient(top, #343a3d, #579ac7);
            padding: 5px 10px;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
            -webkit-box-shadow: rgba(0,0,0,1) 0 1px 0;
            -moz-box-shadow: rgba(0,0,0,1) 0 1px 0;
            box-shadow: rgba(0,0,0,1) 0 1px 0;
            text-shadow: rgba(0,0,0,.4) 0 1px 0;
            color: white;
            font-size: 14px;
            font-family: Georgia, serif;
            text-decoration: none;
            vertical-align: middle;
        }

            .button:hover {
                border-top-color: #28597a;
                background: #28597a;
                color: #ccc;
            }

            .button:active {
                border-top-color: #1b435e;
                background: #1b435e;
            }

             .series_info_textbox {
                 text-align:right;
                 font-family: Verdana, Arial, Helvetica, sans-serif;
                 font-size: 11px;
                 color: #0F465B;
                 width:140px;
             }

    </style>


</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Panel runat="server" DefaultButton="btnRunAnalysis" ID="pnlSettings">
        <table>
            <tr>
                <td style="vertical-align:top;">
                    <div id="analysis-date">
                        <table>
                            <tr><td><asp:Label runat="server" Text="Analysis Date:"></asp:Label></td></tr>
                            <tr><td><asp:TextBox runat="server" ID="txtAnalysisDate" CssClass="expireDateInfo"></asp:TextBox>
                                    <div><asp:ImageButton runat="server" ID="imgAnalysisDate" CssClass="calendar_popup_image" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" /></div>
                                    <ajaxToolkit:CalendarExtender runat="server" ID="calAnalysisDate" Enabled="true" Format="MM/dd/yyyy" PopupButtonID="imgAnalysisDate"
                                         TargetControlID="txtAnalysisDate"></ajaxToolkit:CalendarExtender></td></tr>
                            <tr><td><div style="padding-top:6px;"><asp:Label runat="server" Text="Calendar Profile:"></asp:Label></div></td></tr>
                            <tr><td><asp:DropDownList runat="server" ID="ddlProfilenames" CssClass="expireDateInfo" Width="180px" ></asp:DropDownList></td></tr>
                            <tr><td><div style="padding-top:16px; text-align:right;"><asp:Button runat="server" ID="btnRunAnalysis" CssClass="btn btn-primary" Text="Run Analysis" OnClick="btnRunAnalysis_Click" /></div></td></tr>
                        </table>
                    </div>
                </td>
                <td>
                    <div style="margin-top: 24px; margin-left:24px;">
                        <ajaxToolkit:TabContainer runat="server" ID="tcVolGrids" Height="800px" Width="1000px" BorderStyle="None" Visible="false">
                        </ajaxToolkit:TabContainer>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
</asp:Content>

