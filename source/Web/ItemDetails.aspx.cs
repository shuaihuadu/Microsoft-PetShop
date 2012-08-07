using System;
using System.Web.UI;
using System.Web.UI.WebControls;

// PetShop specific imports
using PetShop.Model;
using PetShop.BLL;

namespace PetShop.Web {
	public class ItemDetails : Page {
		
		private const string MSG_BACK_ORDERED = "Back Ordered";
		private const string CSS_ALERT = "alert";

		protected ItemInfo itemInfo;
		protected PetShop.Web.Controls.NavBar header;
		protected Label lblQty;
		protected Label lblDescription;
		protected Label lblName;
		protected Label lblProductName;
		protected Label lblPrice;
		protected Label lblSearchResults;

		private void InitializeComponent() {}

		override protected void OnLoad(EventArgs e) {

			// Fetch the key field from the query stirng
			string itemId = WebComponents.CleanString.InputText(Request["itemId"], 50);

			// Create an instance of the item business components
			Item item = new Item();

			// Get the item info from the item component
			itemInfo = item.GetItem(itemId);

			// If an item is found then display the results
			if(itemInfo != null){

				lblDescription.Text = itemInfo.ProductDesc;
				lblName.Text = itemInfo.Name;
				lblProductName.Text = itemInfo.ProductName;
				lblPrice.Text = itemInfo.Price.ToString("c");
			
				// Modify the message if an item is out of stock
				if (itemInfo.Quantity > 0)
					lblQty.Text = itemInfo.Quantity.ToString();
				else {
					lblQty.Text = MSG_BACK_ORDERED;
					lblQty.CssClass = CSS_ALERT;
				}
			}else{
				lblSearchResults.Text = "Item not found";
			}
		}
	}
}