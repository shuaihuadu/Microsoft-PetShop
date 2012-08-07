<%@ Control Language="c#" AutoEventWireup="false" Codebehind="StaticAddress.ascx.cs" Inherits="PetShop.Web.Controls.StaticAddress" enableViewState="False"%>
<table cellpadding="2" cellspacing="0" border="0">
	<tr>
		<td>
			<font class="text">
				<asp:label id="lblFirstName" runat="server" />
				<asp:label id="lblLastName" runat="server" />
			</font>
		</td>
	</tr>
	<tr>
		<td>
			<font class="text">
				<asp:label id="lblAdr1" runat="server" />
			</font>
		</td>
	</tr>
	<tr>
		<td>
			<font class="text">
				<asp:label id="lblAdr2" runat="server" />
			</font>
		</td>
	</tr>
	<tr>
		<td>
			<font class="text">
				<asp:label id="lblCity" runat="server" />,
				<asp:label id="lblState" runat="server" />
				<asp:label id="lblPostalCode" runat="server" />
			</font>
		</td>
	</tr>
</table>
