<%@ Register TagPrefix="Controls" Namespace="PetShop.Web.Controls" Assembly="PetShop.Web" %>
<%@ Page Language="c#" CodeBehind="ItemDetails.aspx.cs" Inherits="PetShop.Web.ItemDetails" AutoEventWireup="false" enableSessionState="false" %>
<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<HTML>
	<HEAD>
		<title>Item Details</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:NavBar id="header" runat="server" />
		<blockquote>
			<asp:label id="lblSearchResults" runat="server" />
			<p></p>
			<table cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td class="desc" width="130"><asp:label id="lblDescription" runat="server" /></td>
					<td>
						<span class="title">
							<asp:label id="lblName" runat="server" />
							<asp:label id="lblProductName" runat="server" />
						</span>
						<p>
							<table cellpadding="1" cellspacing="0">
								<tr>
									<td class="label">Price:</td>
									<td><asp:label id="lblPrice" runat="server" /></td>
								</tr>
								<tr>
									<td class="label">Quantity:</td>
									<td><asp:label id="lblQty" runat="server" /></td>
								</tr>
							</table>
						<p><a href='ShoppingCart.aspx?itemId=<%= Request["itemId"] %>'><img src="Images/buttonAdd.gif" alt="Add to Cart" border="0"></a></p>
					</td>
				</tr>
			</table>
		</blockquote>
	</body>
</HTML>
