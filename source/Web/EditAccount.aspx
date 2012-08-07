<%@ Page Language="c#" CodeBehind="EditAccount.aspx.cs" Inherits="PetShop.Web.EditAccount" EnableSessionState="true" EnableViewState="true" AutoEventWireup="false" %>
<%@ Register TagPrefix="Controls" TagName="Preferences" Src="Controls/Preferences.ascx" %>
<%@ Register TagPrefix="Controls" TagName="AddressUI" Src="Controls/AddressUI.ascx" %>
<%@ Register TagPrefix="Controls" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<HTML>
	<HEAD>
		<title>Edit Account</title>
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<Controls:NavBar id="header" runat="server" />
		<blockquote>
			<form id="frmEditAcct" runat="server" method="post">
				<span class="title">My Account</span><p>
					<table cellpadding="1" cellspacing="0">
						<tr>
							<td class="label" width="125">User ID:</td>
							<td colspan="3"><asp:label id="lblUserId" runat="server" /></td>
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
					<controls:addressui id="addr" runat="server" />
				<p><span class="title">My Preferences</span>
				<p>
					<controls:preferences id="prefs" runat="server" />
				<p>
					<asp:imagebutton id="btnSubmit" runat="server" onclick="SubmitClicked" imageurl="Images/buttonSubmit.gif" alternatetext="Submit" />
			</form>
			</P> </blockquote>
	</body>
</HTML>
