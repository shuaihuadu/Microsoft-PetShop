<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ConfirmAddresses.ascx.cs" Inherits="PetShop.Web.Controls.ConfirmAddresses" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="PetsControl" TagName="StaticAddress" Src="StaticAddress.ascx" %>
<BLOCKQUOTE>Please confirm that the following information is correct and press the <B>Continue</B>
	button to process your order.
	<P><SPAN class="title">Billing Address</SPAN>
	<P>
		<PetsControl:StaticAddress id="staticAddressBilling" runat="server"></PetsControl:StaticAddress>
	<P><SPAN class="title">Shipping Address</SPAN>
	<P>
		<PetsControl:StaticAddress id="staticAddressShipping" runat="server"></PetsControl:StaticAddress>
	<P><A href="OrderProcess.aspx"><IMG alt="Continue" src="Images/buttonContinue.gif" border="0"></A></P>
</BLOCKQUOTE>
