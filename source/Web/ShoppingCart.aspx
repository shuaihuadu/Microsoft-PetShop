<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<%@ Register TagPrefix="Controls" Namespace="PetShop.Web.Controls" Assembly="PetShop.Web" %>
<%@ Register TagPrefix="PetsControl" TagName="Banner" Src="Controls/Banner.ascx" %>
<%@ Page Language="c#" CodeBehind="ShoppingCart.aspx.cs" Inherits="PetShop.Web.ShoppingCart" EnableSessionState="true" EnableViewState="true" AutoEventWireup="false" %>
<HTML>
	<HEAD>
		<title>Shopping Cart</title>
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<table cellpadding="0" cellspacing="0" border="0" height="100%" width="100%">
			<TBODY>
				<tr valign="top">
					<td>
						<PetsControl:NavBar id="header" runat="server" />
						<blockquote>
							<form id="frmCart" method="post" runat="server">
								<table cellpadding="0" cellspacing="0">
									<TBODY>
										<tr valign="top">
											<td class="cart">
												<span class="title">Shopping Cart</span><p>
													<controls:viewstatepager id="cart" runat="server" pagesize="4" emptytext="Your cart is empty." onpageindexchanged="CartPageChanged" onitemcommand="CommandClicked">
														<headertemplate>
															<table cellpadding="0" cellspacing="0">
																<tr class="gridHead">
																	<td>&nbsp;</td>
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
																<td><asp:imagebutton id="btnRemove" runat="server" imageurl="Images/buttonRemove.gif" alternatetext="Remove" commandargument='<%# DataBinder.Eval(Container.DataItem, "ItemId") %>' /></td>
																<td><%# DataBinder.Eval(Container.DataItem, "ItemId") %></td>
																<td><a href='ItemDetails.aspx?itemId=<%# DataBinder.Eval(Container.DataItem, "ItemId") %>'><%# DataBinder.Eval(Container.DataItem, "Name") %></a></td>
																<td><%# DataBinder.Eval(Container.DataItem, "InStock") %></td>
																<td class="num"><%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %></td>
																<td><asp:textbox id="txtQty" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>' columns="3" maxlength="5" cssclass="num" /></td>
																<td class="num"><%# DataBinder.Eval(Container.DataItem, "Subtotal", "{0:c}") %></td>
															</tr>
														</itemtemplate>
														<footertemplate>
															<tr class="gridFoot">
																<td><asp:imagebutton id="btnUpdate" runat="server" imageurl="Images/buttonUpdate.gif" alternatetext="Update" commandname="update" border="0" /></td>
																<td class="num" colspan="6"><span class="label">Total:</span><%= Total.ToString("c") %></td>
															</tr>
								</table>
								</footertemplate> </controls:viewstatepager>
								<p><a id="link" runat="server" href="Checkout.aspx"><img src="Images/buttonCheckout.gif" alt="Proceed to Checkout" border="0"></a></p>
					</td>
					<td>
						<controls:viewstatepager id="favorites" runat="server" pagesize="3" onpageindexchanged="FavoritesPageChanged" visible="false">
							<headertemplate>
								<span class="title">Pet Favorites</span>
								<p>
									<table cellpadding="0" cellspacing="0">
										<tr class="gridHead">
											<td>Shop for more of your favorite pets here.</td>
										</tr>
							</headertemplate>
							<itemtemplate>
								<tr class="gridItem">
									<td><a href='Items.aspx?productId=<%# DataBinder.Eval(Container.DataItem, "Id") %>'><%# DataBinder.Eval(Container.DataItem, "Name") %>
											(<%# DataBinder.Eval(Container.DataItem, "Id") %>)</a></td>
								</tr>
							</itemtemplate>
							<footertemplate>
		</table>
		</footertemplate> 
		</controls:viewstatepager></TD></TR></TBODY></TABLE></FORM></BLOCKQUOTE></TD></TR>
		<tr valign="bottom">
			<td>
				<PetsControl:Banner id="Banner1" runat="server" />
			</td>
		</tr>
		</TBODY></TABLE>
	</body>
</HTML>
