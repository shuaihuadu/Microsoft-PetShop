<%@ Control Language="c#" CodeBehind="Preferences.ascx.cs" Inherits="PetShop.Web.Controls.Preferences" AutoEventWireup="false" %>
<table cellpadding="1" cellspacing="0">
	<tr>
		<td colspan="2">
			<table cellpadding="0" cellspacing="0">
				<tr>
					<td>Show the .NET Pet Shop in&nbsp;</td>
					<td>
						<asp:dropdownlist id="listLanguage" runat="server">
							<asp:listitem>English</asp:listitem>
							<asp:listitem>Japanese</asp:listitem>
						</asp:dropdownlist>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="2">
			<table cellpadding="0" cellspacing="0">
				<tr>
					<td>My favorite category is&nbsp;</td>
					<td>
						<asp:dropdownlist id="listCategory" runat="server">
							<asp:ListItem Value="FISH">Fish</asp:ListItem>
							<asp:ListItem Value="DOGS">Dogs</asp:ListItem>
							<asp:ListItem Value="REPTILES">Reptiles</asp:ListItem>
							<asp:ListItem Value="CATS">Cats</asp:ListItem>
							<asp:ListItem Value="BIRDS">Birds</asp:ListItem>
						</asp:dropdownlist>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td><asp:checkbox id="chkShowFavorites" runat="server" checked="True" /></td>
		<td>Make items in my favorite category more prominent as I shop.</td>
	</tr>
	<tr>
		<td><asp:checkbox id="chkShowBanners" runat="server" checked="True" /></td>
		<td>Show pet tips based on my favorite category.</td>
	</tr>
</table>
