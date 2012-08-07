<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Cart.ascx.cs" Inherits="PetShop.Web.Controls.usercart" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<span class="title">Shopping Cart</span>
<p><Controls:viewstatepager id="usercart" onitemcommand="CommandClicked" onpageindexchanged="CartPageChanged" emptytext="Your cart is empty." pagesize="4" runat="server"><HEADERTEMPLATE>
			<TABLE cellSpacing="0" cellPadding="0">
				<TBODY>
					<TR class="gridHead">
						<TD>&nbsp;</TD>
						<TD>Item ID</TD>
						<TD>Product</TD>
						<TD>In Stock</TD>
						<TD>Price</TD>
						<TD>Quantity</TD>
						<TD>Subtotal</TD>
					</TR>
		</HEADERTEMPLATE>
		<ITEMTEMPLATE>
			<TR class="gridItem">
				<TD>
					<asp:imagebutton id=btnRemove runat="server" imageurl="../Images/buttonRemove.gif" alternatetext="Remove" commandargument='<%# DataBinder.Eval(Container.DataItem, "ItemID")%>'>
					</asp:imagebutton></TD>
				<TD><%# DataBinder.Eval(Container.DataItem, "ItemId") %></TD>
				<TD>
					<asp:hyperlink id=DetailLink runat="server" navigateurl='<%# "../ItemDetails.aspx?itemId=" + DataBinder.Eval(Container.DataItem, "ItemID")%>' cssclass="text">
						<%# DataBinder.Eval(Container.DataItem, "Name") %>
					</asp:hyperlink></TD>
				<TD><%# DataBinder.Eval(Container.DataItem, "InStock") %></TD>
				<TD class="num"><%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %></TD>
				<TD>
					<asp:textbox id=txtQty runat="server" cssclass="num" text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>' columns="3" maxlength="5">
					</asp:textbox></TD>
				<TD class="num"><%# DataBinder.Eval(Container.DataItem, "Subtotal", "{0:c}") %></TD>
			</TR>
		</ITEMTEMPLATE>
		<FOOTERTEMPLATE>
  <TR class="gridFoot">
				<TD>
					<asp:imagebutton id="btnUpdate" runat="server" imageurl="../Images/buttonUpdate.gif" alternatetext="Update" commandname="update" border="0"></asp:imagebutton></TD>
				<TD class="num" colSpan="6"><SPAN class="label">Total:</SPAN>Total</TD>
			</TR></TBODY></TABLE></FOOTERTEMPLATE>
	</Controls:viewstatepager></p>
