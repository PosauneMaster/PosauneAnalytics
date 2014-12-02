<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVolatiltyTabContent.ascx.cs" Inherits="PosauneAnalytics.Web.Application.ucVolatiltyTabContent" %>

<asp:Panel runat="server">

    <table>
        <tr>
            <td style="vertical-align: top;">
                <div class="series_info">
                    <div>
                        <asp:Label runat="server" Text="Series:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtSeries1" CssClass="series_info_textbox" BorderStyle="None"></asp:TextBox>
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
                        <asp:Label runat="server" Text="Symbol:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtSymbol1" CssClass="series_info_textbox"></asp:TextBox>
                    </div>
                </div>
            </td>
            <td>
                <div style="width: 500px; padding-left: 50px; overflow: auto;">
                    <asp:GridView runat="server" ID="gvSeriesInfo1" AutoGenerateColumns="false" OnRowCreated="gvSeriesInfo1_RowCreated">
                        <Columns>

                            <asp:TemplateField HeaderText="Implied Vol" SortExpression="ImpliedVolCall">
                                <ItemTemplate>
                                    <asp:Label ID="lblImpliedCVolCall" runat="server" Text='<%# Bind("ImpliedVolCall")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Settle" SortExpression="SettlePriceCall">
                                <ItemTemplate>
                                    <asp:Label ID="lblSettlePriceCall" runat="server" Text='<%# Bind("SettlePriceCall")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Strike" SortExpression="StrikePrice">
                                <ItemTemplate>
                                    <asp:Label ID="lblStrikePrice" runat="server" Text='<%# Bind("StrikePrice")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                <ItemStyle CssClass="data_grid_center" HorizontalAlign="Left" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Settle" SortExpression="SettlePricePut">
                                <ItemTemplate>
                                    <asp:Label ID="lblSettlePricePut" runat="server" Text='<%# Bind("SettlePricePut")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Implied Vol" SortExpression="ImpliedVolPut">
                                <ItemTemplate>
                                    <asp:Label ID="lblImpliedVolPut" runat="server" Text='<%# Bind("ImpliedVolPut")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle BackColor="LightBlue" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>

</asp:Panel>
