<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CalendarAnalytics.aspx.cs" Inherits="PosauneAnalytics.Web.Application.CalendarAnalytics" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td>
                <div style="border:solid 1px gray;">
                    <table id="expirationTable">
                        <tr>
                            <td><asp:Label runat="server" Text="Expiration Date:"></asp:Label></td>
                            <td><asp:TextBox runat="server" ID="txtExpirationDate"></asp:TextBox></td>
                            <td><asp:Label runat="server" Text="Or"></asp:Label></td>
                            <td><asp:Label runat="server" Text="Days"></asp:Label></td>




                        </tr>




                    </table>

                </div>



            </td>

        </tr>


    </table>


</asp:Content>
