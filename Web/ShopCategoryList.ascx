<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopCategoryList.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopCategoryList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<asp:PlaceHolder id="phShopTop" runat="server"></asp:PlaceHolder>
<table id="tblCategoryTable" class="grid">
	<asp:repeater id="rptShopList" runat="server">
		<HeaderTemplate>
			<tr class="gridsubheader">
				<td width="1%">&nbsp;</td>
				<td align="left" width="58%"><asp:label id="lblCategoryName" runat="server">Category</asp:label></td>
				<td align="left" width="8%"><asp:label id="lblHdrProducts" runat="server">Products</asp:label></td>
				<td align="left" width="25%"><asp:label id="lblHdrLastProduct" runat="server">Lastpost</asp:label></td>
			</tr>
		</HeaderTemplate>
		<ItemTemplate>
			<tr class="shoprow">
				<td width="1%" valign="top">&nbsp;</td>
				<td width="58%"><%# GetShopLink(Container.DataItem) %><br><%# DataBinder.Eval(Container.DataItem, "Description") %></td>
				<td width="8%" valign="top"><%# GetShopProductCount(Container.DataItem)%></td>
				<td width="25%" valign="top"><%# DataBinder.Eval(Container.DataItem, "LastPublished") %></td>
			</tr>
		</ItemTemplate>
		<AlternatingItemTemplate>
			<tr class="shoprowalt">
				<td width="1%" valign="top">&nbsp;</td>
				<td width="58%" class="shopcolumn"><%# GetShopLink(Container.DataItem) %><br><%# DataBinder.Eval(Container.DataItem, "Description") %></td>
				<td width="8%" valign="top" class="shopcolumn"><%# GetShopProductCount(Container.DataItem)%></td>
				<td width="25%" valign="top" class="lastpostcolumn"><%# DataBinder.Eval(Container.DataItem, "LastPublished")%></td>
			</tr>
		</AlternatingItemTemplate>
	</asp:repeater>
</table>
<asp:PlaceHolder id="phShopFooter" runat="server"></asp:PlaceHolder>
