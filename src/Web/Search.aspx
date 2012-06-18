<%@ Register TagPrefix="PetsControl" Namespace="PetShop.Web.Controls" Assembly="PetShop.Web" %>
<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<%@ Page Language="c#" CodeBehind="Search.aspx.cs" Inherits="PetShop.Web.Search" AutoEventWireup="false" enableSessionState="false" %>
<HTML>
	<HEAD>
		<title>Search</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:NavBar id="header" runat="server"></PetsControl:NavBar><br>
		<blockquote>
			<span class="title">Search Results</span><p>
				<PetsControl:simplepager id="products" runat="server" pagesize="4" emptytext="No products found." onpageindexchanged="PageChanged">
					<headertemplate>
						<table cellpadding="0" cellspacing="0">
							<tr class="gridHead">
								<td>Product ID</td>
								<td>Name</td>
								<td>Description</td>
							</tr>
					</headertemplate>
					<itemtemplate>
						<tr class="gridItem">
							<td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
							<td><a href='Items.aspx?productId=<%# DataBinder.Eval(Container.DataItem, "Id") %>'><%# DataBinder.Eval(Container.DataItem, "Name") %></a></td>
							<td><%# DataBinder.Eval(Container.DataItem, "Description") %></td>
						</tr>
					</itemtemplate>
					<footertemplate>
						</tbody>
					</table>
				</footertemplate>
				</PetsControl:simplepager></p>
		</blockquote>
	</body>
</HTML>
