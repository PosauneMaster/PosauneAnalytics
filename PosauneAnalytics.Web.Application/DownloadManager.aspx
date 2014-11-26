<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="DownloadManager.aspx.cs" Inherits="PosauneAnalytics.Web.Application.DownloadManager" %>

<asp:Content ContentPlaceHolderID="headerPalceHolder" runat="server">

    <style type="text/css">
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
    <div style="margin-top:24px;">
        <asp:GridView runat="server" ID="gvAvailableFiles" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="false" HeaderStyle-ForeColor="Wheat" CssClass="data_grid">
            <Columns>
                <asp:TemplateField HeaderText="Checkbox">
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="chkAll" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelected" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="data_grid" HorizontalAlign="Center" Width="200px" />
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
                        <asp:Label ID="lblProvider" runat="server" Text='<%# Bind("FileName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle BackColor="LightGray" />
        </asp:GridView>
    </div>

        <asp:GridView runat="server" ID="GridView1" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Checkbox">
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="chkAll" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelected" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:TemplateField>

            </Columns>
        </asp:GridView>


</asp:Content>

