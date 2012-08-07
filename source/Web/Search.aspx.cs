using PetShop.BLL;
using PetShop.Web.Controls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Caching;

namespace PetShop.Web
{
	public class Search : Page
	{
		protected NavBar header;
		protected SimplePager products;

		private void InitializeComponent() {}

		protected void PageChanged(object sender, DataGridPageChangedEventArgs e) {
			products.CurrentPageIndex = e.NewPageIndex;

			// Get the search terms from the query string
			string searchKey = WebComponents.CleanString.InputText(Request["keywords"], 100);

			if (searchKey != ""){

				// Create a data cache key
				string cacheKey = "search" + searchKey;

				// Check if the objects are in the cache
				if(Cache[cacheKey] != null){
					products.DataSource = (IList)Cache[cacheKey];
				}else{
					// If that data is not in the cache then use the business logic tier to fetch the data
					Product product = new Product();
					IList productsBySearch = product.GetProductsBySearch(searchKey);
					// Store the results in a cache
					Cache.Add(cacheKey, productsBySearch, null, DateTime.Now.AddHours(12), Cache.NoSlidingExpiration , CacheItemPriority.High, null);
					products.DataSource = productsBySearch;
				}

				// Databind the data to the controls
				products.DataBind();
			}
		}
	}
}