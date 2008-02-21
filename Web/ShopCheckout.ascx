<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShopCheckout.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopCheckout" %>
<asp:PlaceHolder ID="phShopTop" runat="server"></asp:PlaceHolder>
<asp:Panel ID="Panel1" runat="server">
<asp:Button ID="ButtonEmail" runat="server"/><br />
<asp:Button ID="ButtonPaypal" runat="server"/><br />
</asp:Panel>
<p>
</p>
<asp:Button ID="ButtonContinueShopping" runat="server" OnClick="ButtonContinueShopping_Click" />
<br />
<asp:PlaceHolder ID="phShopFooter" runat="server"></asp:PlaceHolder>
&nbsp;
