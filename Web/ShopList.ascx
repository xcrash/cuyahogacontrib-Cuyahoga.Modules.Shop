<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopList.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<asp:Panel ID="dummy" Runat="server">
	<asp:placeholder id="phShopTop" runat="server"></asp:placeholder>
	<table class="grid" id="tblCategoryTable" cellSpacing="0" cellPadding="0">
		<TR class="gridsubheader">
			<td width="1%">&nbsp;</td>
			<td align="left" width="58%"><asp:label id="lblShop" runat="server" Visible="false">Shop</asp:label></td>
			<td align="left" width="8%">
				<asp:label id="lblHdrProducts" runat="server">Products</asp:label></td>
			<td align="left" width="25%">
				<asp:label id="lblHdrLastProduct" runat="server">Lastpost</asp:label></td>
		</tr>
	</table>
	<table class="grid">
		<asp:repeater id="rptCategoryList" runat="server">
			<ItemTemplate>
				<tr class="shoprow">
					<td colspan="5" width="100%" class="gridsubheader">
						<asp:HyperLink id="hplShopCategory" runat="server" CssClass="shop">Category</asp:HyperLink></td>
				</tr>
				<asp:repeater id="rptShopList" runat="server">
					<ItemTemplate>
						<tr class="shoprow">
							<td width="1%" valign="top" class="newcolum">&nbsp;</td>
							<td width="58%" class="shopcolumn"><%# GetShopLink(Container.DataItem) %><br>
								<%# DataBinder.Eval(Container.DataItem, "Description") %>
							</td>
							<td width="8%" valign="top" class="shopcolumn"><%# GetShopProductCount(Container.DataItem)%></td>
							<td width="25%" valign="top" class="lastpostcolumn"><%# DataBinder.Eval(Container.DataItem, "LastPublished") %></td>
						</tr>
					</ItemTemplate>
					<AlternatingItemTemplate>
						<tr class="shoprowalt">
							<td width="1%" valign="top" class="newcolumn">&nbsp;</td>
							<td width="58%" class="shopcolumn"><%# GetShopLink(Container.DataItem) %><br>
								<%# DataBinder.Eval(Container.DataItem, "Description") %>
							</td>
							<td width="8%" valign="top" class="shopcolumn"><%# GetShopProductCount(Container.DataItem)%></td>
							<td width="25%" valign="top" class="lastpostcolumn"><%# DataBinder.Eval(Container.DataItem, "LastPublished")%></td>
						</tr>
					</AlternatingItemTemplate>
				</asp:repeater>
			</ItemTemplate>
		</asp:repeater></table>
	<asp:placeholder id="phShopFooter" runat="server"></asp:placeholder>
</asp:Panel>
