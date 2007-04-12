<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShopCaddy.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopCaddy" %>
<asp:PlaceHolder ID="phShopTop" runat="server"></asp:PlaceHolder>
<asp:Panel ID="Panel1" runat="server">
    <table class="grid" width="100%">
        <tr class="gridsubheader">
            <td colspan="5">
                <asp:Label ID="lblShopName" runat="server">Shop name</asp:Label></td>
            <td align="right">
                <asp:HyperLink ID="hplNewTitle" runat="server" CssClass="shop">New Title</asp:HyperLink></td>
        </tr>
    </table>
        <asp:Repeater ID="rptShopCaddyList" runat="server">
            <HeaderTemplate>
            <table class="grid">
                <tr class="gridsubheader">
                    <td align="left" width="45%">
                        <asp:Label ID="lblHdrTitleProduct" runat="server">Product</asp:Label></td>
                    <td align="left" width="13%">
                        <asp:Label ID="lblHdrPrice" runat="server">Price</asp:Label></td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="shoprow">
                    <td class="shopcolumn" width="45%">
                        <%# DataBinder.Eval(Container.DataItem, "Product.Title")%>
                    </td>
                    <td class="shopcolumn" valign="top" width="13%" align="right">
                        <%# DataBinder.Eval(Container.DataItem, "Product.Price", "{0:c}")%>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="shoprowalt">
                    <td class="shopcolumn" width="45%">
                        <%# DataBinder.Eval(Container.DataItem, "Product.Title")%>
                    </td>
                    <td class="shopcolumn" valign="top" width="13%" align="right">
                        <%# DataBinder.Eval(Container.DataItem, "Product.Price", "{0:c}")%>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                     <tr class="shoprowalt">
                    <td class="shopcolumn" width="45%">
                    </td>
                    <td class="shopcolumn" valign="top" width="8%" align="right">
                    </td>
                </tr> 
                     <tr class="shoprowalt" style="background-color:InactiveBorder">
                    <td class="shopcolumn" width="45%" style="font-weight:bold">
                    <asp:Label ID="lblHdrTitleTotal" runat="server">Total</asp:Label></td>
                    </td>
                    <td class="shopcolumn" valign="top" width="8%" align="right">
                        <%# GetTotal(Container.DataItem) %>
                    </td>
                </tr>        
            </table>
            </FooterTemplate>
        </asp:Repeater> 
</asp:Panel>
<p>
</p>
<asp:PlaceHolder ID="phShopFooter" runat="server"></asp:PlaceHolder>
