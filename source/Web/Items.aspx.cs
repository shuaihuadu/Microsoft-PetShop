using PetShop.Model;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Caching;

// PetShop specific imports
using PetShop.BLL;
using PetShop.Web.Controls;

namespace PetShop.Web
{
	public class Items : Page
	{
		protected SimplePager items;
		protected NavBar header;
		protected System.Web.UI.WebControls.Label productName;

		private void InitializeComponent() {}

		protected void PageChanged(object sender, DataGridPageChangedEventArgs e){

			items.CurrentPageIndex = e.NewPageIndex;

			// Get the productId from the query string
			string productId = WebComponents.CleanString.InputText(Request["productId"], 50);

			// Array for the data
			IList itemsByProduct = null;

			// Check if the data exists in the data cache
			if(Cache[productId] != null){
				itemsByProduct = (IList)Cache[productId];
			}else{
				// If the data is not in the cache then fetch the data from the business logic tier
				Item item = new Item();
				itemsByProduct =  item.GetItemsByProduct(productId);
				// store the output in the data cache with a 12 hour expiry
				Cache.Add(productId, itemsByProduct, null, DateTime.Now.AddHours(12), Cache.NoSlidingExpiration , CacheItemPriority.High, null);
			}

			// Set the control datasource
			items.DataSource = itemsByProduct;

			// If there is data fetch the product name
			if(itemsByProduct.Count > 0)
				productName.Text = ((ItemInfo)itemsByProduct[0]).ProductName;
			
			// Bind the data to the the control
			items.DataBind();
		}
	}
}