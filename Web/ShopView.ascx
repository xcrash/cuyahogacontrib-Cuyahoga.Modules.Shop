<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopView.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopView" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:PlaceHolder id="phShopTop" runat="server"></asp:PlaceHolder>
<asp:Panel runat="server" id="Panel1">
	<TABLE class="grid" width="100%">
		<TR class="gridsubheader">
			<TD colSpan="5">
				<asp:Label id="lblShopName" Runat="server">Shop name</asp:Label></TD>
			<TD align="right"><asp:HyperLink id="hplNewTitle" Runat="server" CssClass="shop">New Title</asp:HyperLink></TD>
		</TR>
	</TABLE>
	<table class="grid">
		<asp:repeater id="rptShopProductList" runat="server">
			<HeaderTemplate>
				<tr class="gridsubheader">
					<td width="5%" align="left"></td>
					<td width="45%" align="left">
						<asp:label id="lblHdrTitleTitle" runat="server">Products</asp:label></td>
					<td align="left" width="13%">
						<asp:label id="lblHdrTitleStarter" runat="server">Publisher</asp:label></td>
					<td align="left" width="8%">
						<asp:label id="lblHdrComments" runat="server">Comments</asp:label></td>
					<td align="left" width="8%">
						<asp:label id="lblHdrPrice" runat="server">Price</asp:label></td>
				</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr class="shoprow">
					<td width="5%" class="shopcolumn"><asp:ImageButton id="imgProduct" runat=server ImageUrl="<%# GetImageURL(Container.DataItem) %>" /></td>
					<td width="45%" class="shopcolumn"><%# GetTitleLink(Container.DataItem) %></td>
					<td width="13%" valign="top" class="shopcolumn"><%# DataBinder.Eval(Container.DataItem, "UserName") %></td>
					<td width="8%" valign="top" class="shopcolumn"><%# DataBinder.Eval(Container.DataItem, "Comments")%></td>
					<td width="8%" valign="top" class="shopcolumn"><%# DataBinder.Eval(Container.DataItem,"Price") %></td>
				</tr>
			</ItemTemplate>
			<AlternatingItemTemplate>
				<tr class="shoprowalt">
					<td width="5%" class="shopcolumn"><asp:ImageButton id="imgProduct" runat=server ImageUrl="<%# GetImageURL(Container.DataItem) %>" /></td>
					<td width="45%" class="shopcolumn"><%# GetTitleLink(Container.DataItem) %></td>
					<td width="13%" valign="top" class="shopcolumn"><%# DataBinder.Eval(Container.DataItem, "Username") %></td>
					<td width="8%" valign="top" class="shopcolumn"><%# DataBinder.Eval(Container.DataItem, "Comments")%></td>
					<td width="8%" valign="top" class="shopcolumn"><%# DataBinder.Eval(Container.DataItem,"Price") %></td>
				</tr>
			</AlternatingItemTemplate>
		</asp:repeater></table>
</asp:Panel>
<p></p>
<asp:PlaceHolder id="phShopFooter" runat="server"></asp:PlaceHolder>
