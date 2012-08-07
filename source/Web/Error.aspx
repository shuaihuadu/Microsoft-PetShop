<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<%@ Page Language="c#" AutoEventWireup="false" enableSessionState="false" %>
<HTML>
	<HEAD>
		<title>Error</title>
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:NavBar id="header" runat="server" />
		<blockquote>
			<P>
				<span class="alert">An error occurred! The system administrator will be checking the web server's event log for details.</span></P>
			<P><SPAN class="alert">If you have any concerns about a pending transactions 
  please contact the Microsoft .NET Pet Shop on (555) 
555-1234</SPAN></P>
		</blockquote>
	</body>
</HTML>
