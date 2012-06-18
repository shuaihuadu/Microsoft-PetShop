<%@ Page Language="c#" CodeBehind="OrderShipping.aspx.cs" Inherits="PetShop.Web.OrderShipping" EnableSessionState="true" AutoEventWireup="false" enableSessionState="true"%>
<%@ Register TagPrefix="PetsControl" TagName="AddressUI" Src="Controls/AddressUI.ascx" %>
<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<%@ Register TagPrefix="PetsControl" TagName="StaticAddress" Src="Controls/StaticAddress.ascx" %>
<HTML>
	<HEAD>
		<title>Order Information</title>
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:NavBar id="header" runat="server" />
		<blockquote>
			<form id="frmShip" runat="server" method="post">
				<asp:Panel ID="enterShipAddress" Runat="server" Visible="True">
					<SPAN class="title">Shipping Address</SPAN>
					<P>
						<PetsControl:addressui id="shipAddr" runat="server"></PetsControl:addressui>
					<P>
						<asp:imagebutton id="btnContinue" onclick="ContinueClicked" runat="server" alternatetext="Continue" imageurl="Images/buttonContinue.gif"></asp:imagebutton>
				</asp:Panel>
				<asp:Panel ID="confirmAddress" Runat="server" Visible="False">
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
				</asp:Panel>
			</form>
			<P></P>
		</blockquote>
	</body>
</HTML>
