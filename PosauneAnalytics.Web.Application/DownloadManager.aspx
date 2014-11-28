<%@ Page Language="C#" Title="Downloads" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="DownloadManager.aspx.cs" Inherits="PosauneAnalytics.Web.Application.DownloadManager" %>

<asp:Content ContentPlaceHolderID="headerPalceHolder" runat="server">

    <script type="text/javascript">
        var allCheckBoxSelector = '#<%=gvAvailableFiles.ClientID%> input[id*="chkAll"]:checkbox';
        var checkBoxSelector = '#<%=gvAvailableFiles.ClientID%> input[id*="chkSelected"]:checkbox';

        function ToggleCheckUncheckAllOptionAsNeeded() {
            var totalCheckboxes = $(checkBoxSelector),
                checkedCheckboxes = totalCheckboxes.filter(":checked"),
                noCheckboxesAreChecked = (checkedCheckboxes.length === 0),
                allCheckboxesAreChecked = (totalCheckboxes.length === checkedCheckboxes.length);

            $(allCheckBoxSelector).attr('checked', allCheckboxesAreChecked);
        }

        $(document).ready(function () {
            $(allCheckBoxSelector).on('click', function () {
                $(checkBoxSelector).attr('checked', $(this).is(':checked'));

                ToggleCheckUncheckAllOptionAsNeeded();
            });

            $(checkBoxSelector).on('click', ToggleCheckUncheckAllOptionAsNeeded);

            ToggleCheckUncheckAllOptionAsNeeded();
        });
    </script>


    <style type="text/css">

        .checkbox_header {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            line-height: 14px;
            background-color:gray;
            color:white;
            font-weight: normal;
            padding-bottom: 1px;
            padding-left: 1px;
            padding-top: 1px;
            padding-right: 1px;
            line-height: 18px;
            text-align: center;
        }
        .header_grid {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            line-height: 14px;
            background-color:gray;
            color:white;
            font-weight: normal;
            padding-bottom: 1px;
            padding-left: 1px;
            padding-top: 1px;
            padding-right: 1px;
            line-height: 18px;
        }

        .data_grid {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            color:black;
            padding: 0px 0px 0px 0px;
            font-weight: normal;
            line-height: 16px;
            height: 18px;
        }

    </style>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 24px;">
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Files available at CME"></asp:Label>
                </td>
                <td>
                    <div style="margin-left:20px;">
                        <asp:Label runat="server" Text="Downloaded files"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="vertical-align:top;">
                    <div> 
                    <asp:GridView runat="server" ID="gvAvailableFiles" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="false" HeaderStyle-ForeColor="Wheat" CssClass="data_grid">
                        <Columns>
                            <asp:TemplateField HeaderText="Checkbox">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="chkAll" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkSelected" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="checkbox_header" />
                                <ItemStyle CssClass="data_grid" HorizontalAlign="Center" Width="60px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="TimeStamp" SortExpression="TimeStamp" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblTimeStamp" runat="server" CommandName="Select" Text='<%# Bind("TimeStamp")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="File Name" SortExpression="Provider">
                                <ItemTemplate>
                                    <asp:Label ID="lblFilename" runat="server" Text='<%# Bind("FileName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle BackColor="LightGray" />
                    </asp:GridView>
                    </div>
                    <div style="text-align:right; margin-top:10px;">
                        <asp:Button runat="server" ID="btnDownload" Text="Download" OnClick="btnDownload_Click" />
                    </div>

                </td>
                <td style="vertical-align:top;">
                    <div style="margin-left:20px;">
                        <asp:GridView runat="server" ID="gvDownloadedFiles" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="false"
                             HeaderStyle-ForeColor="Wheat" CssClass="data_grid">
                            <Columns>

                            <asp:TemplateField HeaderText="File Name" SortExpression="Provider">
                                <ItemTemplate>
                                    <asp:Label ID="lblFilename" runat="server" Text='<%# Bind("filename") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>
                </td>
            </tr>
        </table>
    </div>


</asp:Content>

