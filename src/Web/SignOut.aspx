<%@ Register TagPrefix="PetsControl" TagName="SignOutNavBar" Src="Controls/SignOutNavBar.ascx" %>
<%@ Page Language="c#" CodeBehind="SignOut.aspx.cs" Inherits="PetShop.Web.SignOut" AutoEventWireup="false" enableSessionState="true"%>
<HTML>
	<HEAD>
		<title>Sign Out</title>
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:SignOutNavBar id="header" runat="server" />
		<blockquote>
			<span class="title">Thank You!</span><p>
				Please visit us again soon.</p>
		</blockquote>
	</body>
</HTML>
