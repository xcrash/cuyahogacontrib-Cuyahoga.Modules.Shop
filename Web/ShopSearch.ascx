<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopSearch.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopSearch" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:PlaceHolder id="phShopTop" runat="server"></asp:PlaceHolder>
<asp:Panel id="pnlSearch" runat="server">
	<TABLE class="grid" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR class="gridsubheader">
			<TD>
				<asp:Label id="lblSearch" runat="server">Label</asp:Label></TD>
		</TR>
		<TR>
			<TD align="center">&nbsp;
			</TD>
		</TR>
		<TR>
			<TD>
				<asp:TextBox id="txtSearchfor" runat="server" MaxLength="254" Columns="60"></asp:TextBox>&nbsp;
				<asp:Button id="btnSearch" runat="server" Text="Button" CssClass="shop"></asp:Button></TD>
		</TR>
	</TABLE>
</asp:Panel>
<asp:Panel id="pnlSearchResult" runat="server" Visible="False">
	<TABLE class="grid" id="tblSearchresult" cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR class="gridsubheader">
			<TD colSpan="4">
				<asp:Label id="lblSearchresult" runat="server">Label</asp:Label></TD>
		</TR>
		<asp:Repeater id="rptSearchresult" runat="server">
			<ItemTemplate>
				<tr class="shoprow">
					<td width="1%" valign="top" class="newcolum">&nbsp;</td>
					<td width="50%" class="shopcolumn"><%# GetShopProductLink(Container.DataItem) %></td>
					<td width="19%" valign="top" class="shopcolumn"><%# DataBinder.Eval(Container.DataItem, "UserName") %></td>
					<td width="30%" valign="top" class="shopcolumn"><%# DataBinder.Eval(Container.DataItem, "DateCreated") %></td>
				</tr>
			</ItemTemplate>
			<AlternatingItemTemplate>
				<tr class="shoprowalt">
					<td width="1%" valign="top" class="newcolumn">&nbsp;</td>
					<td width="50%" class="shopcolumn"><%# GetShopProductLink(Container.DataItem) %></td>
					<td width="19%" valign="top" class="shopcolumn"><%# DataBinder.Eval(Container.DataItem, "UserName") %></td>
					<td width="30%" valign="top" class="shopcolumn"><%# DataBinder.Eval(Container.DataItem, "DateCreated") %></td>
				</tr>
			</AlternatingItemTemplate>
		</asp:Repeater></TABLE>
</asp:Panel>
<asp:PlaceHolder id="phShopFooter" runat="server"></asp:PlaceHolder>
