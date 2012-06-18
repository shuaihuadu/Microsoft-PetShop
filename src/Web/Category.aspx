<%@ Register TagPrefix="controls" Namespace="PetShop.Web.Controls" Assembly="PetShop.Web" %>
<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<%@ Page Language="c#" CodeBehind="Category.aspx.cs" Inherits="PetShop.Web.Category" AutoEventWireup="false" enableSessionState="false" %>
<HTML>
	<HEAD>
		<title>Category</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<PetsControl:navbar id="header" runat="server"></PetsControl:navbar><br>
		<blockquote>
			<form id="form" method="post" runat="server">
				<!-- page header -->
				<asp:label id="lblPage" enableviewstate="False" runat="server" cssclass="pageHeader">Label</asp:label>
				<P><controls:SimplePager id="products" runat="server" pagesize="4" emptytext="No products found." onpageindexchanged="PageChanged">
						<HeaderTemplate>
							<TABLE cellSpacing="0" cellPadding="0">
								<TBODY>
									<TR class="gridHead">
										<TD>Product ID</TD>
										<TD>Name</TD>
									</TR>
						</HeaderTemplate>
						<ITEMTEMPLATE>
							<TR class="gridItem">
								<TD><%# DataBinder.Eval(Container.DataItem, "Id") %></TD>
								<TD><A href='Items.aspx?productId=<%# DataBinder.Eval(Container.DataItem, "Id") %>'><%# DataBinder.Eval(Container.DataItem, "Name") %></A></TD>
							</TR>
						</ITEMTEMPLATE>
						<FOOTERTEMPLATE></TBODY></TABLE></FOOTERTEMPLATE>
					</controls:SimplePager></P>
			</form>
		</blockquote>
	</body>
</HTML>
