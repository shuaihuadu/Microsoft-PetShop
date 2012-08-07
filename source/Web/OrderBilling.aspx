<%@ Page Language="c#" CodeBehind="OrderBilling.aspx.cs" Inherits="PetShop.Web.OrderBilling" EnableSessionState="true" AutoEventWireup="false"%>
<%@ Register TagPrefix="PetsControl" TagName="StaticAddress" Src="Controls/StaticAddress.ascx" %>
<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<%@ Register TagPrefix="PetsControl" TagName="AddressUI" Src="Controls/AddressUI.ascx" %>
<HTML>
	<HEAD>
		<title>Order Information</title>
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:NavBar id="header" runat="server" />
		<blockquote>
			<form id="frmBill" runat="server" method="post">
				<asp:Panel ID="enterAddress" Runat="server" Visible="True">
					<SPAN class="title">Payment Information</SPAN>
					<P>
						<TABLE cellSpacing="0" cellPadding="1">
							<TR>
								<TD class="label" width="125">Credit Card Type:</TD>
								<TD>
									<asp:dropdownlist id="listCardType" runat="server">
										<asp:listitem>Visa</asp:listitem>
										<asp:listitem>MasterCard</asp:listitem>
										<asp:listitem>American Express</asp:listitem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="label">Card Number:</TD>
								<TD>
									<asp:textbox id="txtCardNumber" runat="server" maxlength="20" columns="20" text="9999 9999 9999 9999"></asp:textbox>
									<asp:requiredfieldvalidator id="valCardNumber" runat="server" enableclientscript="False" errormessage="Please enter card number." controltovalidate="txtCardNumber"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD class="label">Expiration Date:</TD>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0">
										<TR>
											<TD class="label">Month:</TD>
											<TD>
												<asp:dropdownlist id="listMonth" runat="server">
													<asp:listitem>01</asp:listitem>
													<asp:listitem>02</asp:listitem>
													<asp:listitem>03</asp:listitem>
													<asp:listitem>04</asp:listitem>
													<asp:listitem>05</asp:listitem>
													<asp:listitem>06</asp:listitem>
													<asp:listitem>07</asp:listitem>
													<asp:listitem>08</asp:listitem>
													<asp:listitem>09</asp:listitem>
													<asp:listitem>10</asp:listitem>
													<asp:listitem>11</asp:listitem>
													<asp:listitem>12</asp:listitem>
												</asp:dropdownlist></TD>
											<TD class="label" width="50">Year:</TD>
											<TD>
												<asp:dropdownlist id="listYear" runat="server">
													<asp:listitem>2002</asp:listitem>
													<asp:listitem>2003</asp:listitem>
													<asp:listitem>2004</asp:listitem>
													<asp:listitem>2005</asp:listitem>
													<asp:listitem>2006</asp:listitem>
												</asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					<P><SPAN class="title">Billing Address</SPAN>
					<P>
						<PetsControl:addressui id="billAddr" runat="server"></PetsControl:addressui>
					<P>
						<TABLE cellSpacing="0" cellPadding="1">
							<TR>
								<TD>
									<asp:checkbox id="chkShipBilling" runat="server" checked="True"></asp:checkbox></TD>
								<TD>Ship to billing address</TD>
							</TR>
						</TABLE>
					<P>
						<asp:imagebutton id="btnContinue" onclick="ContinueClicked" runat="server" border="0" alternatetext="Continue" imageurl="Images/buttonContinue.gif"></asp:imagebutton>
				</asp:Panel>
				<br>
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
