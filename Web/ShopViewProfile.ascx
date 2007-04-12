<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopViewProfile.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopViewProfile" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:PlaceHolder id="phShopTop" runat="server"></asp:PlaceHolder>
<TABLE class="grid" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR class="gridsubheader">
		<TD width="30%"><asp:Label id="ltProfile" runat="server">Profile</asp:Label></TD>
		<TD width="70%"></TD>
	</TR>
	<TR>
		<TD width="30%">
			<asp:Label id="lblUserName" runat="server">Label</asp:Label></TD>
		<TD width="70%">
			<asp:Literal id="ltrUserName" runat="server"></asp:Literal></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblRealName" runat="server">Label</asp:Label></TD>
		<TD>
			<asp:Literal id="ltrRealName" runat="server"></asp:Literal></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 21px">
			<asp:Label id="lblLocation" runat="server">Label</asp:Label></TD>
		<TD style="HEIGHT: 21px">
			<asp:Literal id="ltrLocation" runat="server"></asp:Literal></TD>
	</TR>
	<TR>
		<TD style="height: 21px">
			<asp:Label id="lblOccupation" runat="server">Label</asp:Label></TD>
		<TD style="height: 21px">
			<asp:Literal id="ltroccupation" runat="server"></asp:Literal></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblInterest" runat="server">Label</asp:Label></TD>
		<TD>
			<asp:Literal id="ltrInterest" runat="server"></asp:Literal></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblGender" runat="server">Label</asp:Label></TD>
		<TD>
			<asp:Literal id="ltrGender" runat="server"></asp:Literal></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblHomepage" runat="server">Label</asp:Label></TD>
		<TD>
			<asp:Literal id="ltrHomepage" runat="server"></asp:Literal></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblMSN" runat="server">Label</asp:Label></TD>
		<TD>
			<asp:Literal id="ltrMSN" runat="server"></asp:Literal></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblYahooMessenger" runat="server">Label</asp:Label></TD>
		<TD>
			<asp:Literal id="ltrYahooMessenger" runat="server"></asp:Literal></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblAIMName" runat="server">Label</asp:Label></TD>
		<TD>
			<asp:Literal id="ltrAIMName" runat="server"></asp:Literal></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblICQNumber" runat="server">Label</asp:Label></TD>
		<TD>
			<asp:Literal id="ltrICQNumber" runat="server"></asp:Literal></TD>
	</TR>
</TABLE>
<asp:PlaceHolder id="phShopFooter" runat="server"></asp:PlaceHolder>
