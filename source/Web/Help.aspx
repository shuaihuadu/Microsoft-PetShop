<%@ Page Language="c#" AutoEventWireup="false" enableSessionState="false" %>
<%@ Register TagPrefix="PetsControl" TagName="NavBar" Src="Controls/NavBar.ascx" %>
<HTML>
	<HEAD>
		<title>Help</title>
		<link rel="stylesheet" href="Styles.css">
	</HEAD>
	<body>
		<PetsControl:NavBar id="header" runat="server" />
		<blockquote>
			<span class="title">Microsoft .NET Pet Shop Blueprint Application</span>
			<blockquote> The Microsoft .NET Pet Shop Blueprint Application is an online pet 
				store. Like most e-stores, you can browse and search the product catalog, 
				choose items to add to your shopping cart, amend your shopping cart, and order 
				the items in the shopping cart. You can perform many of these actions without 
				registering with or logging into the application. However, before you can order 
				items you must log in (sign in) to the application. In order to sign in, you 
				must have an account with the application, which is created when you register 
				(sign up) with the application.<p>
					<a href="#SigningUp">Signing Up</a><br>
					<a href="#SigningIn">Signing In</a><br>
					<a href="#Catalog">Working with the Product Catalog</a><br>
					<a class="indent2" href="#Browsing">Browsing the Catalog</a><br>
					<a class="indent2" href="#Searching">Searching the Catalog</a><br>
					<a href="#ShoppingCart">Working with the Shopping Cart</a><br>
					<a class="indent2" href="#Adding">Adding and Removing Items</a><br>
					<a class="indent2" href="#Updating">Updating the Quantity of an Item</a><br>
					<a class="indent2" href="#Ordering">Ordering Items</a><br>
					<a href="#Reviewing">Reviewing an Order</a><br>
					<a href="#WebServices">Using the Order Web Service</a><br>
					<a href="#Issues">Known Issues</a></p>
			</blockquote><a name="SigningUp"></a>
			<span class="title">Signing Up</span>
			<blockquote>To sign up, click the "Sign In" link on the top banner. Next, click the 
				"Register Now" button. Among other information, the sign up page requires you 
				to provide a user ID and password. This information is used to identify your 
				account and must be provided when signing in.</blockquote><a name="SigningIn"></a>
			<span class="title">Signing In</span>
			<blockquote> You sign in to the application by clicking the "Sign In" link on the 
				top banner, filling in the user ID and password, and clicking the "Submit" 
				button.<p>
					You will also be redirected to the sign in page when you try to place an order 
					and you have not already signed in.</p>
			</blockquote><a name="Catalog"></a>
			<span class="title">Working with the Product Catalog</span>
			<blockquote> This section describes how to browse and search the product catalog.<p>
					<a name="Browsing"></a><b>Browsing the Catalog</b><br>
				The pet store catalog is organized hierarchically as follows: categories, 
				products, and items.<p>
				You list the products in a category by clicking the category name or one of the 
				pictures on the home page, or by clicking the category name on the top banner 
				of other pages.<p>
				The Pet Shop will display a list of products within the selected category. 
				Clicking a product displays a list of items and their prices. Clicking an item 
				displays a text and visual description of the item and the number of that item 
				in stock.<p>
					<a name="Searching"></a><b>Searching the Catalog</b><br>
					You search for products by typing keywords in the search field on the top 
					banner.</p>
			</blockquote><a name="ShoppingCart"></a>
			<span class="title">Working with the Shopping Cart</span>
			<blockquote> <a name="Adding"></a><b>Adding and Removing Items</b><br>
				You add an item to your shopping cart by clicking the "Add to Cart" button next 
				to the item. This action also displays your shopping cart.<p>
				You remove an item from your shopping cart by clicking the "Remove" button next 
				to the item.<p>
				To continue shopping, select a category from the list on the top banner.<p>
					<a name="Updating"></a><b>Updating the Quantity of an Item</b><br>
				You adjust the quantity of an item by typing the quantity in the item's 
				"Quantity" field in the shopping cart and clicking the "Update" button.<p>
				If the quantity of items requested is greater than that in stock, the "In 
				Stock" field in the shopping cart will show that the item is back ordered.<p>
					<a name="Ordering"></a><b>Ordering Items</b><br>
				You order the items in the shopping cart by clicking the "Proceed to Checkout" 
				button. The Pet Shop will display a read-only list of your shopping cart 
				contents. To proceed with checkout, click the "Continue" button.<p>
					If you have not signed in, the application will display the sign in page, where 
					you will need to provide your user ID and password. Otherwise, the application 
					will display a page requesting order information. When you have filled in the 
					required information, click the "Continue" button and the application will 
					display a read-only page verifying your billing and shipping address. If you 
					need to change any information, click your browser's "Back" button and enter 
					the correct information. To complete the order, click the "Continue" button.</p>
			</blockquote><BLOCKQUOTE><a name="Reviewing"></a>
				<span class="title">Reviewing an Order</span>
				<P>The final screen displays your order details.</P>
			</BLOCKQUOTE><a name="WebServices"></a>
			<SPAN class="title">Using the Order Web Services</SPAN>
			<BLOCKQUOTE>By navigating to the <a href="webservices.asmx">Order Web Services asmx page</a>
				you can test the Order Web Service</BLOCKQUOTE><a name="Issues"></a>
			<span class="title">Known Issues</span>
			<blockquote>None.</blockquote></blockquote></blockquote>
	</body>
</HTML>
