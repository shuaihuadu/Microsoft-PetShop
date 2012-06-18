<%@ Register TagPrefix="Controls" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<%@ Register TagPrefix="Controls" TagName="Preferences" Src="Controls/Preferences.ascx" %>
<%@ Register TagPrefix="Controls" TagName="AddressUI" Src="Controls/AddressUI.ascx" %>
<%@ Page Language="c#" CodeBehind="CreateAccount.aspx.cs" Inherits="PetShop.Web.CreateAccount" EnableSessionState="true" AutoEventWireup="false" %>
<HTML>
	<HEAD>
		<title>Create Account</title> 
		<!-- %@ Register TagPrefix="Controls" Namespace="PetShop.Web.Controls" Assembly="PetShop.Web" % -->
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<Controls:NavBar id="header" runat="server" />
		<blockquote>
			<form id="frmCreateAcct" runat="server" method="post">
				<span class="title">My Account</span><p>
					<table cellpadding="1" cellspacing="0">
						<tr>
							<td class="label" width="125">User ID:</td>
							<td colspan="3">
								<asp:textbox id="txtUserId" runat="server" columns="15" maxlength="20" />
								<asp:requiredfieldvalidator id="valUserId" runat="server" controltovalidate="txtUserId" errormessage="Please enter user ID." enableclientscript="False" />
							</td>
						</tr>
						<tr>
							<td class="label">Password:</td>
							<td colspan="3">
								<asp:textbox id="txtPassword" runat="server" columns="15" maxlength="20" textmode="Password" />
								<asp:requiredfieldvalidator id="valPassword" runat="server" controltovalidate="txtPassword" errormessage="Please enter password." enableclientscript="False" />
							</td>
						</tr>
						<tr>
							<td class="label">E-mail Address:</td>
							<td colspan="3">
								<asp:textbox id="txtEmail" runat="server" columns="30" maxlength="80" />
								<asp:requiredfieldvalidator id="valEmail" runat="server" controltovalidate="txtEmail" errormessage="Please enter e-mail address." enableclientscript="False" />
							</td>
						</tr>
					</table>
				<p><span class="title">My Address</span>
				<p>
					<Controls:addressui id="addr" runat="server" />
				<p><span class="title">My Preferences</span>
				<p>
					<Controls:preferences id="prefs" runat="server" />
				<p>
					<asp:imagebutton id="btnSubmit" runat="server" onclick="SubmitClicked" imageurl="Images/buttonSubmit.gif" alternatetext="Submit" />
			</form>
			</P> </blockquote>
	</body>
</HTML>
