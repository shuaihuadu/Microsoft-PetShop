using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShop.Web.Controls {
	public abstract class Preferences : UserControl {
	
		protected System.Web.UI.WebControls.DropDownList listLanguage;
		protected System.Web.UI.WebControls.DropDownList listCategory;
		protected System.Web.UI.WebControls.CheckBox chkShowFavorites;
		protected System.Web.UI.WebControls.CheckBox chkShowBanners;

		// Control property to show list of language
		public string Language {
			get { return WebComponents.CleanString.InputText(listLanguage.SelectedItem.Value, 50); }
			set { 
				ListItem item = listLanguage.Items.FindByValue(value);
				if (item != null){
					item.Selected = true;
				}
			}
		}

		// Control property to show list of categorys
		public string Category {
			get { return WebComponents.CleanString.InputText(listCategory.SelectedItem.Value, 50); }
			set { 
				ListItem item = listCategory.Items.FindByValue(value);
				if (item != null){
					item.Selected = true;
				}
			}
		}

		// Control property to show checkbox for show favorites list
		public bool IsShowFavorites {
			get { return chkShowFavorites.Checked; }
			set { chkShowFavorites.Checked = value; }
		}

		// Control property to show checkbox for show banners
		public bool IsShowBanners {
			get { return chkShowBanners.Checked; }
			set { chkShowBanners.Checked = value; }
		}
	}
}