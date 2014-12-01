<%@ Page Language="C#" Title="Volatility" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="VolatilityAnalysis.aspx.cs" Inherits="PosauneAnalytics.Web.Application.VolatilityAnalysis" %>

<asp:Content ContentPlaceHolderID="headerPalceHolder" runat="server">

    <style type="text/css">
        #analysis-date {
            width: 260px;
            height: 60px;
            padding: 10px;
            border: 1px solid #ccc;
            background: #eee;
            text-align: left;
            margin-top: 24px;
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
            width: 200px;
            height: 240px;
            padding: 10px;
            border: 1px solid #ccc;
            background: #eee;
            text-align: left;
        }

            .series_info div {
                padding: 5px 0 5px 0;
            }

        .data_grid {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #0F465B;
            padding: 0px 0px 0px 20px;
            font-weight: normal;
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

    </style>


</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div id="analysis-date">
            <table>
                <tr>
                    <td><span>Analysis Date:</span></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAnalysisDate" CssClass="expireDateInfo"></asp:TextBox></td>
                    <td style="padding-top: 12px;">
                        <asp:ImageButton runat="server" ID="imgAnalysisDate" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" />
                        <ajaxToolkit:CalendarExtender runat="server" ID="calAnalysisDate" Enabled="true" Format="MM/dd/yyyy"
                            PopupButtonID="imgAnalysisDate" TargetControlID="txtAnalysisDate">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-top:8px; width:260px; text-align:right;">
            <asp:Button runat="server" ID="btnRunAnalysis" CssClass="button" Text="Run Analysis" OnClick="btnRunAnalysis_Click" />
        </div>
    </div>
    <div style="margin-top: 24px;">
        <ajaxToolkit:TabContainer runat="server" ID="tcVolGrids" Height="600px" Width="800px" BorderStyle="None">
            <ajaxToolkit:TabPanel runat="server" ID="tabPanel1" BorderStyle="None">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <div class="series_info">
                                    <div>
                                        <asp:Label runat="server" Text="Series:"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtSeries1"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:Label runat="server" Text="Underlying:"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtUnderlying1"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:Label runat="server" Text="Underlying Price:"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtUnderlyingPrice1"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:Label runat="server" Text="Symbol:"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtSymbol1"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div style="width: 500px; padding-left:50px; overflow: auto;">
                                    <asp:GridView runat="server" ID="gvSeriesInfo1" AutoGenerateColumns="false">
                                        <Columns>

<%--http://forums.asp.net/t/1923151.aspx?multiple+headers+gridview--%>

<%--http://csharpdotnetfreak.blogspot.com/2008/11/merging-gridview-headers-to-have.html--%>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <th colspan="2">Calls</th>
                                                    <th></th>
                                                    <th colspan="2">Puts</th>
                                                </HeaderTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Implied Vol Call" SortExpression="ImpliedVolCall">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImpliedCVolCall" runat="server" Text='<%# Bind("ImpliedVolCall")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Settle Price Call" SortExpression="SettlePriceCall">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSettlePriceCall" runat="server" Text='<%# Bind("SettlePriceCall")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Strike" SortExpression="StrikePrice">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStrikePrice" runat="server" Text='<%# Bind("StrikePrice")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Settle Price Put " SortExpression="SettlePricePut">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSettlePricePut" runat="server" Text='<%# Bind("SettlePricePut")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Implie Vol Put" SortExpression="ImpliedVolPut">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImpliedVolPut" runat="server" Text='<%# Bind("ImpliedVolPut")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="header_grid" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="data_grid" HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>

</asp:Content>

