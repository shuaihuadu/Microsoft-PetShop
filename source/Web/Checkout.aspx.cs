using PetShop.BLL;
using PetShop.Web.Controls;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PetShop.Web {
	public class Checkout : Page {
		protected SimplePager cart;
		protected HtmlAnchor link;
		protected NavBar header;
		protected Cart myCart;

		override protected void OnLoad(EventArgs e) {

			// Create an instance of the cart controller
			ProcessFlow.CartController cartController = new ProcessFlow.CartController();
			// Fetch the cart state from the controller
			myCart = cartController.GetCart(false);
			
			// If there is something in the cart then show the continue button
			link.Visible = myCart.Count > 0;
		}

		protected void CartPageChanged(object sender, DataGridPageChangedEventArgs e) {

			// (re)bind the data when the page changes
			cart.CurrentPageIndex = e.NewPageIndex;
			cart.DataSource = myCart.GetCartItems();
			cart.DataBind();

		}
	}
}