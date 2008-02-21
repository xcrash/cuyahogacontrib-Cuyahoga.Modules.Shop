<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<%@ Page language="c#" Codebehind="AdminEditTag.aspx.cs" AutoEventWireup="false" Inherits="Cuyahoga.Modules.Shop.AdminEditTag" ValidateRequest="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Edit Emoticon</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body ms_positioning="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<div id="moduleadminpane">
				<h1>Edit shop tags</h1>
				<div class="group">
					<h4>Tag</h4>
					<table>
						<tr>
							<td style="WIDTH: 137px">Shop code start</td>
							<td><asp:textbox id="txtShopCodeStart" runat="server" width="592px"></asp:textbox><asp:requiredfieldvalidator id="rfvShopCodeStart" runat="server" cssclass="validator" display="Dynamic" errormessage="Shop start code is required"
									enableclientscript="False" controltovalidate="txtShopCodeStart"></asp:requiredfieldvalidator></td>
						</tr>
						<tr>
							<td style="WIDTH: 137px">Shop code end</td>
							<td>
								<asp:textbox id="txtShopCodeEnd" runat="server" width="592px"></asp:textbox>
								<asp:requiredfieldvalidator id="rfvShopCodeEnd" runat="server" controltovalidate="txtShopCodeEnd" enableclientscript="False"
									errormessage="Shop code end is required" display="Dynamic" cssclass="validator"></asp:requiredfieldvalidator></td>
						</tr>
						<tr>
							<td style="WIDTH: 137px">HTML code start</td>
							<td>
								<asp:textbox id="txtHtmlCodeStart" runat="server" width="592px"></asp:textbox>
								<asp:requiredfieldvalidator id="rfvHtmlCodeStart" runat="server" controltovalidate="txtHtmlCodeStart" enableclientscript="False"
									errormessage="HTML code start is required" display="Dynamic" cssclass="validator"></asp:requiredfieldvalidator></td>
						</tr>
						<tr>
							<td style="WIDTH: 137px">HTML code end</td>
							<td>
								<asp:textbox id="txtHtmlCodeEnd" runat="server" width="592px"></asp:textbox>
								<asp:requiredfieldvalidator id="rfvHtmlCodeEnd" runat="server" controltovalidate="txtHtmlCodeEnd" enableclientscript="False"
									errormessage="HTML code start is required" display="Dynamic" cssclass="validator"></asp:requiredfieldvalidator></td>
						</tr>
					</table>
				</div>
				<p><asp:button id="btnSave" runat="server" text="Save"></asp:button><asp:button id="btnDelete" runat="server" text="Delete" visible="False"></asp:button><input id="btnCancel" type="button" value="Cancel" runat="server"></p>
			</div>
		</form>
	</body>
</HTML>
