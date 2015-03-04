<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVolatiltyTabContent.ascx.cs" Inherits="PosauneAnalytics.Volatility.Web.Application.ucVolatiltyTabContent" %>

<div class="container">
<div class="row">
    <div class="col-sm-2">
        <div class="series_info">
            <fieldset>
                <div class="form-group">
                        <asp:Label runat="server" class="control-label" Text="Series:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtSeries1" CssClass="form-control input-sm" Height="26px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" class="control-label" Text="Underlying:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtUnderlying1" CssClass="form-control input-sm" Height="26px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" class="control-label" Text="Underlying Price:"></asp:Label>
                    <asp:TextBox runat="server" class="control-label" ID="txtUnderlyingPrice1" CssClass="form-control input-sm" Height="26px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" class="control-label" Text="Expiration Date:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtExpirationDate" CssClass="form-control input-sm" Height="26px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" class="control-label" Text="Days to Expiration:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtDaysToExpiration" CssClass="form-control input-sm" Height="26px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" class="control-label" Text="Weighted Days:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtWeightedDays" CssClass="form-control input-sm" Height="26px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" class="control-label" Text="Risk Free Rate:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtRiskFreeRate" CssClass="form-control input-sm" Height="26px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" class="control-label" Text="Symbol:"></asp:Label>
                    <asp:TextBox runat="server" ID="txtSymbol1"  CssClass="form-control input-sm" Height="26px"></asp:TextBox>
                </div>
            </fieldset>
        </div>
    </div>
    <div class="col-sm-10">
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
    </div>
</div>
</div>
