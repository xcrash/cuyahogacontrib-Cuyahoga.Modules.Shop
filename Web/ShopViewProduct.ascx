<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopViewProduct.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopViewProduct" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register Assembly="ImageControl" Namespace="PAB.WebControls" TagPrefix="cc2" %>
<asp:placeholder id="phShopTop" runat="server"></asp:placeholder>
<table class="grid" width="100%">
	<tbody>
		<tr class="shoprow">
			<td class="gridsubheader"><asp:label id="lblTitle" Runat="server">Shop title / info</asp:label></td>
			<td class="gridsubheader" align="right">
			<asp:LinkButton ID="lbtnBuy" runat="server" OnClick="lbtnBuy_Click" cssclass="shop" Visible="false">Buy</asp:LinkButton>&nbsp;
			<asp:hyperlink id="hplReply" runat="server" CssClass="shop">Add comment</asp:hyperlink>&nbsp;
			<asp:hyperlink ID="HyperLinkEdit" CssClass="shop" runat="server">Edit</asp:hyperlink></td>
		</tr>
		<tr class="shoprow">
			<td width="20%">						
		<asp:repeater id="rptShopProductImagesList" runat="server" OnItemDataBound="rptShopProductImagesList_ItemDataBound">
		<HeaderTemplate><table id="TableImages" cellspacing="1" cellpadding="1" width="100%" border="0">
		</HeaderTemplate>
			<ItemTemplate>
				<tr class="shoprow">
					<td width="100%"><cc2:ImageControl id="imgProduct" ImageType="Jpeg" runat="server" /></td>
				</tr>
			</ItemTemplate>
			<FooterTemplate></table></FooterTemplate>
		</asp:repeater>	
			<asp:label id="lblUserInfo" runat="server">Label</asp:label></td>
			<td width="80%">
			<table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
				<tr class="shoprow">
					<td width="100%"><asp:literal id="lblMessages" runat="server">Label</asp:literal></td>
				</tr>
				<tr class="shoprow">
					<td width="100%"><asp:literal id="lblPublishedDate" runat="server">Label</asp:literal></td>
				</tr>
				<tr class="shoprow">
					<td width="100%"><asp:hyperlink id="hplAuthor" runat="server">Label</asp:hyperlink></td>
				</tr>		
				<tr class="shoprow">
					<td width="100%"><asp:literal id="lblPrice" runat="server" /></td>
				</tr>										
			</table>
			</td>
		</tr>
		<tr class="shoprowalt">
			<td width="20%">&nbsp;</td>
			<td width="80%">&nbsp;</td>
		</tr>
		<tr>
			<td width="20%" bgcolor="darkgray" style="height: 10px"><asp:Literal id="Comments" runat="server">Public comments: </asp:Literal></td>
			<td width="80%" bgcolor="darkgray" style="height: 10px"></td>
		</tr>
		<tr>
			<td colspan="2">					
		<asp:repeater id="rptShopProductCommentsList" runat="server" OnItemCommand="rptShopProductCommentsList_ItemCommand" OnItemDataBound="rptShopProductCommentsList_ItemDataBound">
		<HeaderTemplate><table id="TableImages" cellspacing="1" cellpadding="1" width="100%" border="0">
		</HeaderTemplate>
		<ItemTemplate>
				<tr class="shoprowalt">
					<td width="20%" valign="top"><%# GetUserProfileLink(Container.DataItem) %></td>
					<td width="80%" valign="top"><%# GetPublishedDate(Container.DataItem) %></td>
				</tr>
				<tr class="shoprow">
					<td width="20%"><asp:Literal id="Rating" runat="server">Rating: </asp:Literal><%# GetRating(Container.DataItem) %></td>
					<td width="80%"><%# GetMessage(Container.DataItem) %></td>
				</tr>
				<tr class="shoprowalt">
					<td width="20%">
                        <asp:HiddenField ID="HiddenFieldId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <asp:HyperLink ID="HyperLinkEdit" runat="server">Edit</asp:HyperLink>
                        <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton></td>
					<td width="80%">&nbsp;</td>
				</tr>
				<tr>
					<td width="20%" bgcolor="darkgray" height="10"></td>
					<td width="80%" bgcolor="darkgray" height="10"></td>
				</tr>
			</ItemTemplate>
			<FooterTemplate></table></FooterTemplate>
		</asp:repeater>	
		</td></tr>		
</tbody></table><asp:placeholder id="phShopFooter" runat="server"></asp:placeholder>
