<%@ Control Language="c#" CodeBehind="AddressUI.ascx.cs" Inherits="PetShop.Web.Controls.AddressUI" AutoEventWireup="false" %>
<table cellpadding="1" cellspacing="0">
	<tr>
		<td class="label" width="125">First Name:</td>
		<td>
			<asp:textbox id="txtFirstName" runat="server" columns="30" maxlength="80" />
			<asp:requiredfieldvalidator id="valFirstName" runat="server" controltovalidate="txtFirstName" errormessage="Please enter first name." enableclientscript="False" />
		</td>
	</tr>
	<tr>
		<td class="label">Last Name:</td>
		<td>
			<asp:textbox id="txtLastName" runat="server" columns="30" maxlength="80" />
			<asp:requiredfieldvalidator id="valLastName" runat="server" controltovalidate="txtLastName" errormessage="Please enter last name." enableclientscript="False" />
		</td>
	</tr>
	<tr>
		<td class="label">Street Address:</td>
		<td>
			<asp:textbox id="txtAddress1" runat="server" columns="55" maxlength="80" />
			<asp:requiredfieldvalidator id="valAddress1" runat="server" controltovalidate="txtAddress1" errormessage="Please enter street address." enableclientscript="False" />
		</td>
	</tr>
	<tr>
		<td></td>
		<td>
			<asp:textbox id="txtAddress2" runat="server" columns="55" maxlength="80" />
		</td>
	</tr>
	<tr>
		<td class="label">City:</td>
		<td>
			<asp:textbox id="txtCity" runat="server" columns="55" maxlength="80" />
			<asp:requiredfieldvalidator id="valCity" runat="server" controltovalidate="txtCity" errormessage="Please enter city." enableclientscript="False" />
		</td>
	</tr>
	<tr>
		<td class="label">State / Province:</td>
		<td>
			<table cellpadding="0" cellspacing="0">
				<tr>
					<td>
						<asp:dropdownlist id="listState" runat="server">
							<asp:listitem>California</asp:listitem>
							<asp:listitem>New York</asp:listitem>
							<asp:listitem>Texas</asp:listitem>
						</asp:dropdownlist>
					</td>
					<td class="label" width="100">Postal Code:</td>
					<td>
						<asp:textbox id="txtZip" runat="server" columns="12" maxlength="20" />
						<asp:requiredfieldvalidator id="valZip" runat="server" controltovalidate="txtZip" errormessage="Please enter postal code." enableclientscript="False" />
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td class="label">Country:</td>
		<td>
			<asp:dropdownlist id="listCountry" runat="server">
				<asp:listitem>USA</asp:listitem>
				<asp:listitem>Canada</asp:listitem>
				<asp:listitem>Japan</asp:listitem>
			</asp:dropdownlist>
		</td>
	</tr>
	<tr>
		<td class="label">Telephone Number:</td>
		<td>
			<asp:textbox id="txtPhone" runat="server" columns="20" maxlength="20" />
			<asp:requiredfieldvalidator id="valPhone" runat="server" controltovalidate="txtPhone" errormessage="Please enter telephone number." enableclientscript="False" />
		</td>
	</tr>
</table>
