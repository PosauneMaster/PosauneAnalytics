<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="VolatilityAnalysis.aspx.cs" Inherits="PosauneAnalytics.Volatility.Web.Application.VolatilityAnalysis" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ScriptSection" runat="server">

    <%: Scripts.Render("~/bundles/BootstrapDatePickerJs") %>

   <script type="text/javascript">

       $(document).ready(function () {

           $('#datetimepicker1').datepicker();
       });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">

    <%: Styles.Render("~/bundles/BootstrapDatePickerCss")  %>

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

        .series_info {
            width: 100%;
            height:auto;
            border: 1px solid #ccc;
            background-color:#5596C1;
            color:white;
            text-align: left;
            border-radius:15px;
            padding:4px 10px 4px 10px;
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

        .fancy-green .ajax__tab_header {
            background: #1b435e;
            cursor: pointer;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer {
            /*background: url(green_left_Tab.gif) no-repeat left top;*/
            background:#3E648D;
        }

        .fancy .ajax__tab_header {
            font-size: 13px;
            font-weight: bold;
            color: #000;
            font-family: sans-serif;
        }

        .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer {
            height: 46px;
        }

        .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner {
            height: 46px;
            margin-left: 16px; /* offset the width of the left image */
        }

        .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab {
            margin: 16px 16px 0px 0px;
        }

        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab {
            color: #fff;
        }

        .fancy .ajax__tab_body {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
            border-radius: 8px;
        }

    </style>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="container">
        <div class="row">
            <div class='col-md-2'>
                <div id="analysis-selector">
                    <div class="form-group">
                        <fieldset>
                            <label>Analysis Date:</label>
                            <div class="input-group date" id="datetimepicker1">
                                <asp:TextBox runat="server" ID="txtAnalysisDate" CssClass="form-control" />
                                <span class="input-group-addon">
                                    <i class="glyphicon glyphicon-th"></i></span>
                            </div>
                        </fieldset>
                        <fieldset style="margin-top:20px">
                            <label for="ddlProfilenames">Profile:</label>
                            <asp:DropDownList runat="server" ID="ddlProfilenames" CssClass="form-control"></asp:DropDownList>
                        </fieldset>
                        <fieldset style="margin-top:20px">
                        <asp:Button runat="server" ID="btnRunAnalysis" CssClass="btn btn-primary btn-sm" Text="Run Analysis" OnClick="btnRunAnalysis_Click" />
                        </fieldset>
                    </div>
                </div>
            </div>
            <div class='col-md-2'>
                <div class="series_info">
                    <div class="form-group">
                        <fieldset>
                            <asp:Label runat="server" Text="Series:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSeries1" CssClass="form-control" Height="26px"></asp:TextBox>
                        </fieldset>
                        <fieldset>
                            <asp:Label runat="server" Text="Underlying:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtUnderlying1" CssClass="form-control" Height="26px"></asp:TextBox>
                        </fieldset>
                        <fieldset>
                            <asp:Label runat="server" Text="Underlying Price:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtUnderlyingPrice1" CssClass="form-control" Height="26px"></asp:TextBox>
                        </fieldset>
                        <fieldset>
                            <asp:Label runat="server" Text="Expiration Date:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtExpirationDate" CssClass="form-control" Height="26px"></asp:TextBox>
                        </fieldset>
                        <fieldset>
                            <asp:Label runat="server" Text="Days to Expiration:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDaysToExpiration" CssClass="form-control" Height="26px"></asp:TextBox>
                        </fieldset>
                        <fieldset>
                            <asp:Label runat="server" Text="Weighted Days:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtWeightedDays" CssClass="form-control" Height="26px"></asp:TextBox>
                        </fieldset>
                        <fieldset>
                            <asp:Label runat="server" Text="Risk Free Rate:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtRiskFreeRate" CssClass="form-control" Height="26px"></asp:TextBox>
                        </fieldset>
                        <fieldset>
                            <asp:Label runat="server" Text="Symbol:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSymbol1" CssClass="form-control" Height="26px"></asp:TextBox>
                        </fieldset>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <ajaxToolkit:TabContainer runat="server" CssClass="fancy fancy-green" ID="tcVolGrids" BorderStyle="None" Visible="false">
                </ajaxToolkit:TabContainer>
            </div>
        </div>
    </div>
</asp:Content>
