<%@ Page Language="c#" CodeBehind="MyAccount.aspx.cs" Inherits="PetShop.Web.MyAccount" AutoEventWireup="false" enableSessionState="false" %>
<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<HTML>
	<HEAD>
		<title>
			MyAccount
		</title>
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:NavBar id="header" runat="server" />
		<blockquote>
			<span class="title">My Account</span><p>
				<asp:Label ID="lblMessage" Runat="server"></asp:Label>
			</p>
		</blockquote>
	</body>
</HTML>
