<%@ Page language="c#" Codebehind="AdminEditShop.aspx.cs" AutoEventWireup="false" Inherits="Cuyahoga.Modules.Shop.AdminEditShop" ValidateRequest="false" %>
<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditArticle</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body ms_positioning="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<div id="moduleadminpane">
				<h1>Edit shop</h1>
				<div class="group">
					<h4>Shop</h4>
					<table>
						<tr>
							<td style="WIDTH: 139px">Name</td>
							<td><asp:textbox id="txtName" runat="server" width="592px"></asp:textbox><asp:requiredfieldvalidator id="rfvTitle" runat="server" cssclass="validator" display="Dynamic" errormessage="Name is required"
									enableclientscript="False" controltovalidate="txtName"></asp:requiredfieldvalidator></td>
						</tr>
						<tr>
							<td style="WIDTH: 139px; HEIGHT: 61px" vAlign="top">Description</td>
							<td style="HEIGHT: 61px">
								<asp:TextBox id="txtDescription" runat="server" Width="592px" TextMode="MultiLine"></asp:TextBox>
								<asp:RequiredFieldValidator id="rfvDescription" runat="server" ErrorMessage="Description is required" ControlToValidate="txtDescription"></asp:RequiredFieldValidator></td>
						</tr>
						<tr>
							<td style="WIDTH: 139px">Category</td>
							<td>
								<asp:DropDownList id="lstCategories" runat="server"></asp:DropDownList></td>
						</tr>
						<tr>
							<td style="WIDTH: 139px">Allow GuestProduct</td>
							<td>
								<asp:CheckBox id="ckbAllowGuestProduct" runat="server"></asp:CheckBox></td>
						</tr>
					</table>
				</div>
				<p><asp:button id="btnSave" runat="server" text="Save"></asp:button><asp:button id="btnDelete" runat="server" text="Delete" visible="False"></asp:button><input id="btnCancel" type="button" value="Cancel" runat="server"></p>
			</div>
		</form>
	</body>
</HTML>
