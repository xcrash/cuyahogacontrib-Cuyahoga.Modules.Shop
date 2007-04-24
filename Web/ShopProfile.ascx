<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShopProfile.ascx.cs" Inherits="Cuyahoga.Modules.Shop.Web.ShopProfile" %>
<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<asp:placeholder id="phShopTop" runat="server"></asp:placeholder><asp:panel id="pnlProfile" runat="server" CssClass="articlesub">
	<TABLE id="tblProfile" cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD style="WIDTH: 298px" width="298">
				<asp:Label id="lblUserName" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:Literal id="ltlUserName" runat="server"></asp:Literal></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblRealName" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:Literal id="ltlRealName" runat="server"></asp:Literal></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblLocation" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:TextBox id="txtLocation" runat="server" Columns="40"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblOccupation" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:TextBox id="txtOccupation" runat="server" Columns="40"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblInterest" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:TextBox id="txtInterest" runat="server" Columns="40"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblGender" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:RadioButton id="rbMale" runat="server" Text="Male" GroupName="grpGender"></asp:RadioButton>&nbsp;
				<asp:RadioButton id="rbFemale" runat="server" Text="Female" GroupName="grpGender"></asp:RadioButton></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblHomePage" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:TextBox id="txtHomepage" runat="server" Columns="40"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblMSN" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:TextBox id="txtMSN" runat="server" Columns="40"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblYahooMessenger" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:TextBox id="txtYahooMessenger" runat="server" Columns="40"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblAIMName" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:TextBox id="txtAIMName" runat="server" Columns="40"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblICQNumber" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:TextBox id="txtICQNumber" runat="server" Columns="40"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblTimeZone" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:DropDownList id="ddlTimeZone" runat="server" DataValueField="Value" DataTextField="Name"></asp:DropDownList></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 298px">
				<asp:Label id="lblAvartar" runat="server" Visible="False">Label</asp:Label></TD>
			<TD>
				<asp:HyperLink id="HyperLink1" runat="server" Visible="False">HyperLink</asp:HyperLink></TD>
		</TR>
		<TR>
			<TD vAlign="top">
				<asp:Label id="lblSignature" runat="server">Label</asp:Label></TD>
			<TD>
				<asp:TextBox id="txtSignature" runat="server" Columns="40" Rows="3" TextMode="MultiLine"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD vAlign="top"></TD>
			<TD>
				<asp:Button id="btnSave" runat="server" CssClass="shop" Text="Save" OnClick="btnSave_Click"></asp:Button>&nbsp;
				<asp:Button id="btnCancel" runat="server" CssClass="shop" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click"></asp:Button></TD>
		</TR>
	</TABLE>
</asp:panel><asp:placeholder id="phShopFooter" runat="server"></asp:placeholder>