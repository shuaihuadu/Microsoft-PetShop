<%@ Page Language="c#" CodeBehind="Items.aspx.cs" Inherits="PetShop.Web.Items" AutoEventWireup="false" enableSessionState="false" %>
<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<%@ Register TagPrefix="Controls" Namespace="PetShop.Web.Controls" Assembly="PetShop.Web" %>
<HTML>
	<HEAD>
		<title>Items</title>
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:NavBar id="header" runat="server" />
		<blockquote>
			<span class="title">
				<asp:Label ID="productName" Runat="server"></asp:Label>
			</span><p>
				<controls:simplepager id="items" runat="server" pagesize="4" emptytext="No items found." onpageindexchanged="PageChanged">
					<headertemplate>
						<table cellpadding="0" cellspacing="0">
							<tr class="gridHead">
								<td>Item ID</td>
								<td>Name</td>
								<td>Price</td>
								<td>&nbsp;</td>
							</tr>
					</headertemplate>
					<itemtemplate>
						<tr class="gridItem">
							<td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
							<td><a href='ItemDetails.aspx?itemId=<%# DataBinder.Eval(Container.DataItem, "Id") %>'><%# DataBinder.Eval(Container.DataItem, "Name") %></a></td>
							<td class="num"><%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %></td>
							<td><a href='ShoppingCart.aspx?itemId=<%# DataBinder.Eval(Container.DataItem, "Id") %>'><img src="Images/buttonAdd.gif" alt="Add to Cart" border="0"></a></td>
						</tr>
					</itemtemplate>
					<footertemplate>
					</table>
				</footertemplate>
				</controls:simplepager></p>
		</blockquote>
	</body>
</HTML>
