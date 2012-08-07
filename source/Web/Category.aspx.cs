using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Web.Caching;

// PetShop specific imports
using PetShop.BLL;
using PetShop.Web.Controls;

namespace PetShop.Web {
	public class Category : Page {
		protected NavBar header;
		protected SimplePager products;
		protected System.Web.UI.WebControls.Label lblPage;
		protected System.Web.UI.HtmlControls.HtmlForm form;

		private void InitializeComponent() {}

		protected void PageChanged(object sender, DataGridPageChangedEventArgs e) {
			
			products.CurrentPageIndex = e.NewPageIndex;

			// Get the category from the query string
			// string categoryKey = Request["categoryId"];
			string categoryKey = WebComponents.CleanString.InputText(Request["categoryId"], 50);

			// Check to see if the contents are in the Data Cache
			if(Cache[categoryKey] != null){
				// If the data is already cached, then used the cached copy
				products.DataSource = (IList)Cache[categoryKey];
			}else{
				// If the data is not cached, then create a new products object and request the data
				Product product = new Product();
				IList productsByCategory = product.GetProductsByCategory(categoryKey);
				// Store the results of the call in the Cache and set the time out to 12 hours
				Cache.Add(categoryKey, productsByCategory, null, DateTime.Now.AddHours(12), Cache.NoSlidingExpiration , CacheItemPriority.High, null);
				products.DataSource = productsByCategory;
			}

			// Bind the data to the control
			products.DataBind();
			// Set the label to be the query parameter
			lblPage.Text = categoryKey;
		}

	}
}