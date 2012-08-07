<%@ Register TagPrefix="Controls" Namespace="PetShop.Web.Controls" Assembly="PetShop.Web" %>
<%@ Page Language="c#" CodeBehind="Checkout.aspx.cs" Inherits="PetShop.Web.Checkout" AutoEventWireup="false" enableSessionState="ReadOnly"%>
<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<HTML>
	<HEAD>
		<title>Checkout</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:NavBar id="header" runat="server" />
		<blockquote>
			<span class="title">Shopping Cart</span><p>
				<controls:simplepager id="cart" runat="server" pagesize="4" emptytext="Your cart is empty." onpageindexchanged="CartPageChanged">
					<headertemplate>
						<table cellpadding="0" cellspacing="0">
							<tr class="gridHead">
								<td>Item ID</td>
								<td>Product</td>
								<td>In Stock</td>
								<td>Price</td>
								<td>Quantity</td>
								<td>Subtotal</td>
							</tr>
					</headertemplate>
					<itemtemplate>
						<tr class="gridItem">
							<td><%# DataBinder.Eval(Container.DataItem, "ItemId") %></td>
							<td><a href='ItemDetails.aspx?itemId=<%# DataBinder.Eval(Container.DataItem, "ItemId") %>'><%# DataBinder.Eval(Container.DataItem, "Name") %></a></td>
							<td><%# DataBinder.Eval(Container.DataItem, "InStock") %></td>
							<td class="num"><%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %></td>
							<td class="num"><%# DataBinder.Eval(Container.DataItem, "Quantity") %></td>
							<td class="num"><%# DataBinder.Eval(Container.DataItem, "Subtotal", "{0:c}") %></td>
						</tr>
					</itemtemplate>
					<footertemplate>
						<tr class="gridFoot">
							<td class="num" colspan="6"><span class="label">Total:</span><%= myCart.Total.ToString("c") %></td>
						</tr>
					</table>
				</footertemplate>
				</controls:simplepager>
			<p><a id="link" runat="server" href="OrderBilling.aspx"><img src="Images/buttonContinue.gif" alt="Continue" border="0"></a></p>
		</blockquote>
	</body>
</HTML>
