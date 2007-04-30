<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShopCaddy.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopCaddy" %>
<asp:PlaceHolder ID="phShopTop" runat="server"></asp:PlaceHolder>
<asp:Panel ID="Panel1" runat="server">
        <asp:Repeater ID="rptShopCaddyList" runat="server" OnItemCommand="rptShopCaddyList_ItemCommand">
            <HeaderTemplate>
            <table class="grid">
                <tr class="gridsubheader">
                     <td align="left" width="5%">
                       </td>
                   <td align="left" width="45%">
                        <asp:Label ID="lblHdrTitleProduct" runat="server">Product</asp:Label></td>
                    <td align="left" width="13%">
                        <asp:Label ID="lblHdrPrice" runat="server">Price</asp:Label></td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="shoprow">
                    <td class="shopcolumn" width="5%">
                        <asp:LinkButton ID="LinkButtonRemove" runat="server" CommandName="Remove">Remove</asp:LinkButton>
                        <asp:HiddenField ID="OrderLineId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </td>
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
                     <td class="shopcolumn" width="5%">
                        <asp:LinkButton ID="LinkButtonRemove" runat="server" CommandName="Remove">Remove</asp:LinkButton>
                         <asp:HiddenField ID="OrderLineId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                   </td>
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
                                   <td align="left" width="5%">
                       </td>
                      <td class="shopcolumn" width="45%">
                    </td>
                    <td class="shopcolumn" valign="top" width="8%" align="right">
                    </td>
                </tr> 
                     <tr class="shoprowalt" style="background-color:InactiveBorder">
                                        <td align="left" width="5%">
                       </td>
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
<asp:Button ID="ButtonCheckout" runat="server" OnClick="ButtonCheckout_Click" />
<br />
<br />
<asp:PlaceHolder ID="phShopFooter" runat="server"></asp:PlaceHolder>
&nbsp;
