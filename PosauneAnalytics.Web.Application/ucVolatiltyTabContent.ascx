<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVolatiltyTabContent.ascx.cs" Inherits="PosauneAnalytics.Web.Application.ucVolatiltyTabContent" %>

<asp:Panel runat="server">

    <table>
        <tr>
            <td style="vertical-align: top;">
                <div class="series_info">
                    <div>
                        <asp:Label runat="server" Text="Series:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtSeries1" CssClass="series_info_textbox"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Underlying:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtUnderlying1" CssClass="series_info_textbox"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Underlying Price:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtUnderlyingPrice1" CssClass="series_info_textbox"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Expiration Date:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtExpirationDate" CssClass="series_info_textbox"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Days to Expiration:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtDaysToExpiration" CssClass="series_info_textbox"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Risk Free Rate:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtRiskFreeRate" CssClass="series_info_textbox"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Symbol:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtSymbol1" CssClass="series_info_textbox"></asp:TextBox>
                    </div>
                </div>
            </td>
            <td>
                <div style="width: 800px; padding-left: 40px; overflow: auto; max-height:750px;">
                    <asp:GridView runat="server" ID="gvSeriesInfo1" AutoGenerateColumns="false" OnRowCreated="gvSeriesInfo1_RowCreated">
                        <Columns>

                            <asp:TemplateField HeaderText="Theo Call" SortExpression="TheoCall">
                                <ItemTemplate>
                                    <asp:Label ID="lblTheoCallPrice" runat="server" Text='<%# Bind("TheoCall")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Implied Vol" SortExpression="ImpliedVolCall">
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

                            <asp:TemplateField HeaderText="Implied Vol" SortExpression="ImpliedVolPut">
                                <ItemTemplate>
                                    <asp:Label ID="lblImpliedVolPut" runat="server" Text='<%# Bind("ImpliedVolPut")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Theo Put" SortExpression="TheoPut">
                                <ItemTemplate>
                                    <asp:Label ID="lblTheoPutPrice" runat="server" Text='<%# Bind("TheoPut")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left"/>
                            </asp:TemplateField>

                        </Columns>
                        <AlternatingRowStyle BackColor="LightBlue" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>

</asp:Panel>
