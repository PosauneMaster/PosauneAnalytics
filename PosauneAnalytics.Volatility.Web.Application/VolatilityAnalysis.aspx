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
    <%: Styles.Render("~/bundles/VolatilityPageCss")  %>
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentSection" runat="server">
    <form runat="server" class="form-inline" role="form">

        <ajaxToolkit:ToolkitScriptManager runat="server">
        </ajaxToolkit:ToolkitScriptManager>

        <div class="container">
            <div class="row bottom-buffer">
                <div class="col-sm-12">
                <div class="form-group">
                    <label>Analysis Date:</label>
                    <div class="input-group date" id="datetimepicker1">
                        <asp:TextBox runat="server" ID="txtAnalysisDate" CssClass="form-control" />
                        <span class="input-group-addon">
                            <i class="glyphicon glyphicon-th"></i></span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlProfilenames">Profile:</label>
                    <asp:DropDownList runat="server" ID="ddlProfilenames" CssClass="form-control"></asp:DropDownList>
                </div>
                <asp:Button runat="server" ID="btnRunAnalysis" CssClass="btn btn-primary btn-sm" Text="Run Analysis" OnClick="btnRunAnalysis_Click" />
            </div>
                </div>
           </div>
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <ajaxToolkit:TabContainer runat="server" CssClass="fancy fancy-green" ID="tcVolGrids" BorderStyle="None" Visible="false">
                    </ajaxToolkit:TabContainer>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
