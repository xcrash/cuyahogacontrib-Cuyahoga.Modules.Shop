<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopTop.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopTop" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<TABLE id="tblTopTable" class="grid" width="100%">
	<TR class="gridsubheader">
		<TD width="30%"><asp:Label id="lblWelcomeText" runat="server">Label</asp:Label></TD>
		<TD width="70%" align="right">
		<asp:HyperLink id="hplSearch" runat="server" CssClass="shop">Search</asp:HyperLink>
		<asp:HyperLink id="hplShopProfile" runat="server" Visible="False" CssClass="shop">My profile</asp:HyperLink>&nbsp;
		<asp:HyperLink id="hplShopCaddy" runat="server" Visible="False" CssClass="shop">Caddy</asp:HyperLink>&nbsp;
		</TD>
	</TR>
</TABLE>
<TABLE id="tblTopTable2" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD width="100%">
			<asp:HyperLink id="hplShopBreadCrumb" runat="server">HyperLink</asp:HyperLink>
			<asp:Label id="lblForward_1" runat="server" Visible="False">&nbsp;::&nbsp;</asp:Label>
			<asp:HyperLink id="hplCategoryLink" runat="server" Visible="False">HyperLink</asp:HyperLink>
			<asp:Label id="lblForward_2" runat="server" Visible="False">&nbsp;::&nbsp;</asp:Label>
			<asp:HyperLink id="hplShopLink" runat="server" Visible="False">HyperLink</asp:HyperLink>
			<asp:Label id="lblForward_3" runat="server" Visible="False">&nbsp;::&nbsp;</asp:Label>
			<asp:HyperLink id="hplProductlink" runat="server" Visible="False">HyperLink</asp:HyperLink>
		</TD>
	</TR>
</TABLE>
