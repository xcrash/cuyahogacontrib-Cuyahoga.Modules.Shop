<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopNewComment.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopNewComment" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:placeholder id="phShopTop" runat="server"></asp:placeholder><asp:panel id="pnlShopNewComment" runat="server" CssClass="articlelist">
	<asp:Literal id="ltJsInject" Runat="server"></asp:Literal>
	<TABLE class="grid" id="tblTopTable">
		<TR class="shoprow">
			<TD class="gridsubheader" width="100%" colSpan="2"><asp:Label id="lblReplyTitle" runat="server">Reply to product</asp:Label></TD>
		</TR>
		<TR>
			<TD vAlign="top" width="25%">
				<asp:Label id="lblOrigTitle" runat="server">Original messages</asp:Label>
			<TD width="75%">
				<asp:Panel id="pnlOrigProduct" runat="server" BackColor="GhostWhite" BorderColor="Gray" BorderWidth="1px"
					BorderStyle="Solid">
					<asp:Literal id="ltOrigProduct" runat="server"></asp:Literal>
				</asp:Panel></TD>
		</TR>
		<TR>
			<TD vAlign="top" width="25%">
				<asp:Label id="lblPreview" runat="server" Visible="False">Preview</asp:Label>
			<TD vAlign="top" width="75%">
				<asp:Panel id="pnlPreview" runat="server" BackColor="#E0E0E0" BorderColor="DarkGray" BorderWidth="1px"
					BorderStyle="Solid" Visible="False">
					<asp:Literal id="ltPreviewProduct" Runat="server" Visible="False"></asp:Literal>
				</asp:Panel></TD>
		</TR>
		<TR>
			<TD width="100%" colSpan="2">&nbsp;</TD>
		</TR>
		<TR>
			<TD vAlign="top" width="25%"><asp:Literal id="ltMessage" Runat="server" Visible="True">Message</asp:Literal>
				<asp:Panel id="pnlSmily" runat="server">
					<asp:Repeater id="rptSmily" Runat="server" EnableViewState="False">
						<ItemTemplate>
							<%# GetEmoticonIcon(Container.DataItem) %>
						</ItemTemplate>
					</asp:Repeater>
				</asp:Panel></TD>
			<TD width="75%">
				<asp:TextBox id="txtMessage" runat="server" CssClass="shop" EnableViewState="False" Columns="70"
					Rows="20" TextMode="MultiLine"></asp:TextBox>
				<asp:RequiredFieldValidator id="rfvMessage" runat="server" EnableClientScript="False" ControlToValidate="txtMessage"
					ErrorMessage="Message is required"></asp:RequiredFieldValidator></TD>
		</TR>
		<TR>
			<TD vAlign="top" width="25%"><asp:Label id="llbRating" runat="server" Visible="True">Attach file</asp:Label></TD>
			<TD vAlign="top" width="75%">
                <asp:DropDownList ID="ddnRating" runat="server">
                    <asp:ListItem Value="0">0 stars</asp:ListItem>
                    <asp:ListItem Value="1">1 star</asp:ListItem>
                    <asp:ListItem Value="2">2 stars</asp:ListItem>
                    <asp:ListItem Value="3">3 stars</asp:ListItem>
                    <asp:ListItem Value="4">4 stars</asp:ListItem>
                    <asp:ListItem Value="5">5 stars</asp:ListItem>
                    <asp:ListItem Value="6">6 stars</asp:ListItem>
                    <asp:ListItem Value="7">7 stars</asp:ListItem>
                    <asp:ListItem Value="8">8 stars</asp:ListItem>
                    <asp:ListItem Value="9">9 stars</asp:ListItem>
                    <asp:ListItem Value="10">10 stars</asp:ListItem>
                </asp:DropDownList></TD>
		</TR>
		<TR>
			<TD align="center" width="100%" colSpan="2">
				<asp:Button id="btnPreview" runat="server" CssClass="shop" Text="Preview"></asp:Button>&nbsp;
				<asp:Button id="btnPublish" runat="server" CssClass="shop" Text="Publish"></asp:Button>&nbsp;
				<asp:Button id="btnCancel" runat="server" CssClass="shop" Text="Cancel" CausesValidation="False"></asp:Button></TD>
		</TR>
	</TABLE>
	<asp:Panel id="pnlUploadError" runat="server" Visible="False">
		<asp:Literal id="ltlUploadError" runat="server"></asp:Literal>
	</asp:Panel>
</asp:panel><asp:placeholder id="phShopFooter" runat="server"></asp:placeholder>
