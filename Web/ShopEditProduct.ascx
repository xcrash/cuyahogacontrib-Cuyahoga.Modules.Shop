<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopEditProduct.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopEditProduct" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register Assembly="ImageControl" Namespace="PAB.WebControls" TagPrefix="cc2" %>
<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<asp:placeholder id="phShopTop" runat="server"></asp:placeholder>
<asp:panel id="pnlTop" runat="server" CssClass="articlelist">
	<asp:Literal id="ltJsInject" Runat="server"></asp:Literal>
	<table class="grid" id="tblTopTable">
		<tr class="shoprow">
			<td class="gridsubheader" colSpan="2"><asp:Label id="lblNewTitle" runat="server">New product</asp:Label></td>
		</tr>
		<tr>
			<td vAlign="top" width="25%"><asp:Literal id="ltTitle" Runat="server" Visible="True"></asp:Literal></td>
			<td width="75%">
				<asp:TextBox id="txtSubject" runat="server" CssClass="shop" Columns="70" MaxLength="50"></asp:TextBox>
				<asp:RequiredFieldValidator id="rfvSubject" runat="server" ErrorMessage="Title is required" ControlToValidate="txtSubject"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td vAlign="top" width="25%" style="height: 347px"><asp:Literal id="ltMessage" Runat="server" Visible="True"></asp:Literal>
				<asp:Panel id="pnlSmily" runat="server" CssClass="shopsmily">
					<asp:Repeater id="rptSmily" Runat="server">
						<ItemTemplate>
							<%# GetEmoticonIcon(Container.DataItem) %>
						</ItemTemplate>
					</asp:Repeater>
				</asp:Panel></td>
			<td vAlign="top" width="75%" style="height: 347px">
				<asp:TextBox id="txtMessage" runat="server" CssClass="shop" Columns="70" TextMode="MultiLine"
					Rows="20"></asp:TextBox>
				<asp:RequiredFieldValidator id="rfvMessage" runat="server" ErrorMessage="Message is required" ControlToValidate="txtMessage"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td vAlign="top" width="25%"><asp:Label id="llbPrice" runat="server" Visible="True">Price</asp:Label></td>
			<td vAlign="top" width="75%"><asp:TextBox id="txtPrice" runat="server" CssClass="shop"></asp:TextBox><asp:Label id="llbCurrency" runat="server">$</asp:Label></td>
		</tr>
		<tr>
			<td vAlign="top" width="25%"><asp:Label id="llbAttachImage" runat="server" Visible="True">Image</asp:Label></td>
			<td vAlign="top" width="75%">
                <cc2:ImageControl ID="ImageControl1" runat="server" ImageType="Jpeg" Visible="False">
                </cc2:ImageControl>
                <asp:FileUpload ID="FileUploadDocument" runat="server" CssClass="shop" /></td>
		</tr>
		<tr>
			<td align="center" width="100%" colSpan="2" style="height: 26px">
				<asp:Button id="btnDelete" runat="server" CssClass="shop" Text="Delete" Visible=False OnClick="btnDelete_Click1"></asp:Button>&nbsp;&nbsp;
				<asp:Button ID="ButtonPreview" runat="server" CssClass="shop"
                    OnClick="ButtonPreview_Click1" Text="Preview" />&nbsp;
				<asp:Button id="btnSave" runat="server" CssClass="shop" Text="Save" OnClick="btnSave_Click1"></asp:Button>&nbsp;
				<asp:Button id="btnCancel" runat="server" CssClass="shop" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click1"></asp:Button></td>
		</tr>
        <tr>
			<td vAlign="top" width="25%">
				<asp:Label id="lblPreview" runat="server" Visible="False">Preview</asp:Label></td>
			<td vAlign="top" width="75%">
				<asp:Panel id="pnlPreview" runat="server" Visible="False" BackColor="#E0E0E0" BorderColor="Silver"
					BorderStyle="Solid" BorderWidth="1px" EnableViewState="False">
					<asp:Literal id="ltPreviewProduct" Runat="server" Visible="False"></asp:Literal>
				</asp:Panel></td>
        </tr>
	</table>
	<asp:Panel id="pnlUploadError" runat="server" Visible="False">
		<asp:Literal id="ltlUploadError" runat="server"></asp:Literal>
	</asp:Panel>
</asp:panel><asp:placeholder id="phShopFooter" runat="server"></asp:placeholder>
