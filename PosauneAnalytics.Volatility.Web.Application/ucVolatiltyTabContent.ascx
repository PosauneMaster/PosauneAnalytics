<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVolatiltyTabContent.ascx.cs" Inherits="PosauneAnalytics.Volatility.Web.Application.ucVolatiltyTabContent" %>

<asp:Panel runat="server">
    <asp:GridView runat="server" ID="gvSeriesInfo1" AutoGenerateColumns="false" OnRowCreated="gvSeriesInfo1_RowCreated">
        <Columns>

            <asp:TemplateField HeaderText="Weighted" SortExpression="TheoCall_Weighted">
                <ItemTemplate>
                    <asp:Label ID="lblTheoCallPrice_Weighted" runat="server" Text='<%# Bind("TheoCall_Weighted")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Unweighted" SortExpression="TheoCall">
                <ItemTemplate>
                    <asp:Label ID="lblTheoCallPrice" runat="server" Text='<%# Bind("TheoCall")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Weighted" SortExpression="ImpliedVolCall_Weighted">
                <ItemTemplate>
                    <asp:Label ID="lblImpliedCVolCall_Weighted" runat="server" Text='<%# Bind("ImpliedVolCall_Weighted")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Unweighted" SortExpression="ImpliedVolCall">
                <ItemTemplate>
                    <asp:Label ID="lblImpliedCVolCall" runat="server" Text='<%# Bind("ImpliedVolCall")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Settle" SortExpression="SettlePriceCall">
                <ItemTemplate>
                    <asp:Label ID="lblSettlePriceCall" runat="server" Text='<%# Bind("SettlePriceCall")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Strike" SortExpression="StrikePrice">
                <ItemTemplate>
                    <asp:Label ID="lblStrikePrice" runat="server" Text='<%# Bind("StrikePrice")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid_center" HorizontalAlign="Left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Settle" SortExpression="SettlePricePut">
                <ItemTemplate>
                    <asp:Label ID="lblSettlePricePut" runat="server" Text='<%# Bind("SettlePricePut")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Weighted" SortExpression="ImpliedVolPut_Weighted">
                <ItemTemplate>
                    <asp:Label ID="lblImpliedVolPut_Weighted" runat="server" Text='<%# Bind("ImpliedVolPut_Weighted")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Unweighted" SortExpression="ImpliedVolPut">
                <ItemTemplate>
                    <asp:Label ID="lblImpliedVolPut" runat="server" Text='<%# Bind("ImpliedVolPut")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Weighted" SortExpression="TheoPut_Weighted">
                <ItemTemplate>
                    <asp:Label ID="lblTheoPutPrice_Weighted" runat="server" Text='<%# Bind("TheoPut_Weighted")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Unweighted" SortExpression="TheoPut">
                <ItemTemplate>
                    <asp:Label ID="lblTheoPutPrice" runat="server" Text='<%# Bind("TheoPut")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
            </asp:TemplateField>

        </Columns>
        <AlternatingRowStyle BackColor="LightBlue" />
    </asp:GridView>
</asp:Panel>
