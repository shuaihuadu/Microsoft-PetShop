<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<%@ Page Language="c#" CodeBehind="SignIn.aspx.cs" Inherits="PetShop.Web.SignIn" EnableSessionState="true" AutoEventWireup="false" %>
<HTML>
	<HEAD>
		<title>Sign In</title>
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:NavBar id="header" runat="server" />
		<blockquote>
			<form id="frmSignIn" runat="server" method="post">
				<span class="title">Are you a new user?</span><p>
					<a href="CreateAccount.aspx"><img src="Images/buttonRegister.gif" alt="Register Now" border="0"></a>
				<p>
					<span class="title">Or a registered user?</span>
				<p>
					<table cellpadding="1" cellspacing="0">
						<tr>
							<td class="label">User ID:</td>
							<td>
								<asp:textbox id="txtUserId" runat="server" text="DotNet" columns="15" maxlength="20" />
								<asp:requiredfieldvalidator id="valUserId" runat="server" controltovalidate="txtUserId" errormessage="Please enter user ID." enableclientscript="False" />
							</td>
						</tr>
						<tr>
							<td class="label">Password:</td>
							<td>
								<asp:textbox id="txtPassword" runat="server" value="DotNet" columns="15" maxlength="20" textmode="Password" />
								<asp:requiredfieldvalidator id="valPassword" runat="server" controltovalidate="txtPassword" errormessage="Please enter password." enableclientscript="False" />
							</td>
						</tr>
					</table>
				<p><asp:imagebutton id="btnSubmit" runat="server" onclick="SubmitClicked" imageurl="Images/buttonSubmit.gif" alternatetext="Submit" />
			</form>
			</P> </blockquote>
	</body>
</HTML>
