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

        .calendar_popup_image {
            padding-top:4px;
            padding-left:10px;
        }

    </style>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="container">
        <div class="row">
            <div class='col-sm-2'>
                <div class="input-group date" id="datetimepicker1">
                    <input type="text" class="form-control" />
                        <span class="input-group-addon">
                        <i class="glyphicon glyphicon-th"></i></span>
                </div>
            </div>
            <div class="col-sm-10">



            </div>
        </div>
    </div>
</asp:Content>
