using PetShop.Model;
using PetShop.BLL;
using PetShop.Web.Controls;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Caching;

namespace PetShop.Web{

	public class ShoppingCart : Page{

		//Static constants
		private const string ID_TXT = "txtQty";
		private const string CMD_UPDATE = "update";
		private const string KEY_ITEM_ID = "itemId";
		private const string KEY_CATEGORY = "Category";
		private const string KEY_TOTAL = "Total";

		//Local page objects
		private Cart myCart;
		protected ViewStatePager cart;
		protected ViewStatePager favorites;
		protected System.Web.UI.HtmlControls.HtmlForm frmCart;
		protected HtmlAnchor link;

		override protected void OnLoad(EventArgs e){

			// Create an instance of the cart controller
			ProcessFlow.CartController cartController = new ProcessFlow.CartController();

			myCart = cartController.GetCart(true);

			if (!Page.IsPostBack){

				// Get the itemdId from the query string
				string itemId = Request["itemId"];

				if (itemId != null){
					// Clean the input string
					itemId = WebComponents.CleanString.InputText(itemId, 50);
					myCart.Add(itemId);
					cartController.StoreCart(myCart);
					
				}
			}

			//Get an account controller
			ProcessFlow.AccountController accountController = new ProcessFlow.AccountController();

			//Get the user's favourite category
			string favCategory = accountController.GetFavouriteCategory();

			//If we have a favourite category, render the favourites list
			if (favCategory != null){
				favorites.Visible = true;
				ViewState[KEY_CATEGORY] = favCategory;
			}

			Refresh();
		}

		//Property to show total
		protected decimal Total{
			get { return (decimal)ViewState[KEY_TOTAL]; }
		}

		/// <summary>
		/// Function to control user clicking on a button on the page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void CommandClicked(object sender, RepeaterCommandEventArgs e){

			// Check for update button
			if (e.CommandName == CMD_UPDATE){
				TextBox txt;
				int qty;
				int index;

				// Go through each item on the page
				for (int i = 0, j = cart.Items.Count; i < j; i++){

					// lookup the control
					txt = (TextBox)cart.Items[i].FindControl(ID_TXT);

					try{
						qty = int.Parse(txt.Text);
						index = cart.CurrentPageIndex * cart.PageSize + i;
						
						// If the new qty is zero, remove the item from the cart
						if (qty <= 0)
							myCart.RemoveAt(index);					
						// Update the item with the new quantity
						else
							myCart[index].Quantity = qty;
					}
					catch {}
				}
			
			}else
				// otherwise the command is to remove the an item
				myCart.Remove((string)e.CommandArgument);

			// Refresh the contents of the cart page
			Refresh();

			// Update the page count if required
			int pageCount = (myCart.Count - 1) / cart.PageSize;
			cart.SetPage(Math.Min(cart.CurrentPageIndex, pageCount));
		}

		/// <summary>
		/// Function called the user is trying to go 
		/// forward or backwards through the cart items list
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void CartPageChanged(object sender, DataGridPageChangedEventArgs e){

			//Udpate the page the cart is position on
			cart.CurrentPageIndex = e.NewPageIndex;
			//Rebind the cart items to the page
			cart.DataSource = myCart.GetCartItems();
			cart.DataBind();
		}

		/// <summary>
		/// Function called the user is trying to go 
		/// forward or backwards through the favourites list
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void FavoritesPageChanged(object sender, DataGridPageChangedEventArgs e) {
			
			//Update the current page count
			favorites.CurrentPageIndex = e.NewPageIndex;
			
			//Retrieve the list of favourites from Cache using the category name stored in viewstate
			if(Cache[(string)ViewState[KEY_CATEGORY]] != null){
				favorites.DataSource = (IList)Cache[(string)ViewState[KEY_CATEGORY]];
			}else{
				//If there is nothing in viewstate, then fetch the favourites from the middle tier
				Product product = new Product();
				IList productsByCategory = product.GetProductsByCategory((string)ViewState[KEY_CATEGORY]);
				//Store the results in the cache
				Cache.Add((string)ViewState[KEY_CATEGORY], productsByCategory, null, DateTime.Now.AddHours(12), Cache.NoSlidingExpiration , CacheItemPriority.High, null);
				favorites.DataSource = productsByCategory;
			}
		
			//Rebind the favourites list data to the control
			favorites.DataBind();
		}

		private void InitializeComponent() {}

		// Update the cart total etc
		private void Refresh(){

			ViewState[KEY_TOTAL] = myCart.Total;
			link.Visible = myCart.Count > 0;
		}
	}
}