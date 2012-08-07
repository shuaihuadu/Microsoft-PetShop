<%@ Page Language="c#" CodeBehind="OrderProcess.aspx.cs" Inherits="PetShop.Web.OrderProcess" AutoEventWireup="false" enableSessionState="true" %>
<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<%@ Register TagPrefix="PetsControl" TagName="StaticAddress" Src="Controls/StaticAddress.ascx" %>
<%@ Register TagPrefix="Controls" Namespace="PetShop.Web.Controls" Assembly="PetShop.Web" %>
<HTML>
	<HEAD>
		<title>Order Processed</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<LINK href="Styles.css" rel="stylesheet">
	</HEAD>
	<body>
		<PETSCONTROL:NAVBAR id="header" runat="server"></PETSCONTROL:NAVBAR>
		<blockquote><span class="title">Order 
  Complete!</span>
			<p>
				<table cellSpacing="0" cellPadding="4">
					<TBODY>
						<tr>
							<td class="label">Date:</td>
							<td><asp:label id="lblOrderDate" runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="label">User ID:</td>
							<td><asp:label id="lblUserId" runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="label">Order ID:</td>
							<td><asp:label id="lblOrderId" runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="label">Status:</td>
							<td>P</td>
						</tr>
						<tr vAlign="top">
							<td class="label">Payment Information:</td>
							<td><asp:label id="lblCardType" runat="server"></asp:label><br>
								<asp:label id="lblCardNumber" runat="server"></asp:label><br>
								<asp:label id="lblCardExpiration" runat="server"></asp:label></td>
						</tr>
						<tr vAlign="top">
							<td class="label">Billing Address:</td>
							<td><PETSCONTROL:STATICADDRESS id="statAddrBill" runat="server"></PETSCONTROL:STATICADDRESS></td>
						</tr>
						<tr vAlign="top">
							<td class="label">Shipping Address:</td>
							<td><PETSCONTROL:STATICADDRESS id="statAddrShip" runat="server"></PETSCONTROL:STATICADDRESS></td>
						</tr>
						<tr vAlign="top">
							<td class="label">Items:</td>
							<td><asp:repeater id="cart" runat="server">
									<headertemplate>
										<table cellpadding="0" cellspacing="0">
											<tr class="gridHead">
												<td>Item ID</td>
												<td>Product</td>
												<td>Price</td>
												<td>Quantity</td>
												<td>Subtotal</td>
											</tr>
									</headertemplate>
									<itemtemplate>
										<tr class="gridItem">
											<td><%# DataBinder.Eval(Container.DataItem, "ItemId") %></td>
											<td><a href='ItemDetails.aspx?itemId=<%# DataBinder.Eval(Container.DataItem, "ItemId") %>'><%# DataBinder.Eval(Container.DataItem, "Name") %></a></td>
											<td class="num"><%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %></td>
											<td class="num"><%# DataBinder.Eval(Container.DataItem, "Quantity") %></td>
											<td class="num"><%# DataBinder.Eval(Container.DataItem, "Subtotal", "{0:c}") %></td>
										</tr>
									</itemtemplate>
									<footertemplate>
				</table>
				</footertemplate> </asp:repeater></TD></TR>
				<tr>
					<td label class="label">Total:</td>
					<td class="numFooter" colspan="5"><span class="label"><asp:label id="lblOrderTotal" runat="server"></asp:label>
						</span></td>
				</tr>
				</TBODY></TABLE></p>
		</blockquote>
	</body>
</HTML>
