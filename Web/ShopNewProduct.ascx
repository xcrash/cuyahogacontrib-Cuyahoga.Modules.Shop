<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopNewProduct.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopNewProduct" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<asp:placeholder id="phShopTop" runat="server"></asp:placeholder>
<asp:panel id="pnlTop" runat="server" CssClass="articlelist">
	<asp:Literal id="ltJsInject" Runat="server"></asp:Literal>
	<TABLE class="grid" id="tblTopTable">
		<TR class="shoprow">
			<TD class="gridsubheader" colSpan="2"><asp:Label id="lblNewTitle" runat="server">New product</asp:Label></TD>
		</TR>
		<TR>
			<TD vAlign="top" width="25%">
				<asp:Label id="lblPreview" runat="server" Visible="False">Preview</asp:Label></TD>
			<TD vAlign="top" width="75%">
				<asp:Panel id="pnlPreview" runat="server" Visible="False" BackColor="#E0E0E0" BorderColor="Silver"
					BorderStyle="Solid" BorderWidth="1px" EnableViewState="False">
					<asp:Literal id="ltPreviewProduct" Runat="server" Visible="False"></asp:Literal>
				</asp:Panel></TD>
		</TR>
		<TR>
			<TD vAlign="top" width="25%"><asp:Literal id="ltTitle" Runat="server" Visible="True"></asp:Literal></TD>
			<TD width="75%">
				<asp:TextBox id="txtSubject" runat="server" CssClass="shop" Columns="70" MaxLength="50"></asp:TextBox>
				<asp:RequiredFieldValidator id="rfvSubject" runat="server" ErrorMessage="Title is required" ControlToValidate="txtSubject"></asp:RequiredFieldValidator></TD>
		</TR>
		<TR>
			<TD vAlign="top" width="25%"><asp:Literal id="ltMessage" Runat="server" Visible="True"></asp:Literal>
				<asp:Panel id="pnlSmily" runat="server" CssClass="shopsmily">
					<asp:Repeater id="rptSmily" Runat="server">
						<ItemTemplate>
							<%# GetEmoticonIcon(Container.DataItem) %>
						</ItemTemplate>
					</asp:Repeater>
				</asp:Panel></TD>
			<TD vAlign="top" width="75%">
				<asp:TextBox id="txtMessage" runat="server" CssClass="shop" Columns="70" TextMode="MultiLine"
					Rows="20"></asp:TextBox>
				<asp:RequiredFieldValidator id="rfvMessage" runat="server" ErrorMessage="Message is required" ControlToValidate="txtMessage"></asp:RequiredFieldValidator></TD>
		</TR>
		<TR>
			<TD vAlign="top" width="25%"><asp:Label id="llbPrice" runat="server" Visible="True">Price</asp:Label></TD>
			<TD vAlign="top" width="75%"><asp:TextBox id="txtPrice" runat="server" CssClass="shop"></asp:TextBox><asp:Label id="llbCurrency" runat="server" Visible="True">Dollars</asp:Label></TD>
		</TR>
		<TR>
			<TD vAlign="top" width="25%"><asp:Label id="llbAttachImage" runat="server" Visible="True">Image</asp:Label></TD>
			<TD vAlign="top" width="75%"><INPUT class="shop" id="txtAttachment" style="WIDTH: 300px" type="file" name="filUpload"
					runat="server"></TD>
		</TR>
		<TR>
			<TD align="center" width="100%" colSpan="2">
				<asp:Button id="btnPreview" runat="server" CssClass="shop" Text="Preview" Visible=false></asp:Button>&nbsp;
				<asp:Button id="btnPublish" runat="server" CssClass="shop" Text="Publish"></asp:Button>&nbsp;
				<asp:Button id="btnCancel" runat="server" CssClass="shop" Text="Cancel" CausesValidation="False"></asp:Button></TD>
		</TR>
	</TABLE>
	<asp:Panel id="pnlUploadError" runat="server" Visible="False">
		<asp:Literal id="ltlUploadError" runat="server"></asp:Literal>
	</asp:Panel>
</asp:panel><asp:placeholder id="phShopFooter" runat="server"></asp:placeholder>
