<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ShopViewProduct.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopViewProduct" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:placeholder id="phShopTop" runat="server"></asp:placeholder>
<table class="grid" width="100%">
	<TBODY>
		<tr class="shoprow">
			<td class="gridsubheader"><asp:label id="lblTitle" Runat="server">Shop title / info</asp:label></td>
			<td class="gridsubheader" align="right">
			<asp:LinkButton ID="lbtnBuy" runat="server" OnClick="lbtnBuy_Click" cssclass="shop" Visible=false>Buy</asp:LinkButton>&nbsp;
			<asp:hyperlink id="hplReply" runat="server" CssClass="shop">Add comment</asp:hyperlink>&nbsp;
				<asp:hyperlink id="hplNewTitle" runat="server" CssClass="shop">New Title</asp:hyperlink></td>
		</tr>
		<tr class="shoprow">
			<td width="20%">
						<table id="TableImages" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<asp:repeater id="rptShopProductImagesList" runat="server">
			<ItemTemplate>
				<tr class="shoprow">
					<td width="100%"><asp:ImageButton id="imgShopImage" runat=server ImageUrl="<%# GetImageURL(Container.DataItem) %>" /></td>
				</tr>
			</ItemTemplate>
		</asp:repeater>
		</table>
			<asp:label id="lblUserInfo" runat="server">Label</asp:label></td>
			<td width="80%">
			<table id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
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
		<TR>
			<TD width="20%" bgColor="darkgray" height="10"><asp:Literal id="Comments" runat="server">Public comments: </asp:Literal></TD>
			<TD width="80%" bgColor="darkgray" height="10"></TD>
		</TR>			
		<asp:repeater id="rptShopProductCommentsList" runat="server">
			<ItemTemplate>
				<tr class="shoprowalt">
					<td width="20%" valign="top"><%# GetUserProfileLink(Container.DataItem) %></td>
					<td width="80%" valign="top">
						<table width="100%">
							<tr class="shoprowalt">
								<td width="80%"><%# GetPublishedDate(Container.DataItem) %></td>
								<td width="20%"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr class="shoprow">
					<td width="20%"><asp:Literal id="Rating" runat="server">Rating: </asp:Literal><%# GetRating(Container.DataItem) %></td>
					<td width="80%"><%# GetMessage(Container.DataItem) %></td>
				</tr>
				<asp:panel id="pnlReplyAttachment" Runat="server" Visible="False">
					<TR class="shoprow">
						<TD width="20%">
							<asp:label id="Label2" runat="server">&nbsp;</asp:label></TD>
						<TD width="80%">
							<asp:Label id="lblReplyAttachment" runat="server">Label</asp:Label>&nbsp;
							<asp:HyperLink id="hplReplyttachment" runat="server" CssClass="shop">HyperLink</asp:HyperLink>&nbsp;
							<asp:Literal id="ltlReplyFileinfo" runat="server"></asp:Literal></TD>
					</TR>
				</asp:panel>
				<tr class="shoprowalt">
					<td width="20%">&nbsp;</td>
					<td width="80%">&nbsp;</td>
				</tr>
				<TR>
					<TD width="20%" bgColor="darkgray" height="10"></TD>
					<TD width="80%" bgColor="darkgray" height="10"></TD>
				</TR>
			</ItemTemplate>
		</asp:repeater>			
</TBODY></TABLE><asp:placeholder id="phShopFooter" runat="server"></asp:placeholder>
