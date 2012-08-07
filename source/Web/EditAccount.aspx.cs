using PetShop.Model;
using PetShop.BLL;
using PetShop.Web.Controls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShop.Web {
	public class EditAccount : Page {
	
		protected Label lblUserId;
		protected TextBox txtEmail;
		protected AddressUI addr;
		protected NavBar header;
		protected System.Web.UI.WebControls.RequiredFieldValidator valEmail;
		protected System.Web.UI.WebControls.ImageButton btnSubmit;
		protected System.Web.UI.HtmlControls.HtmlForm frmEditAcct;
		protected Preferences prefs;
		
		override protected void OnLoad(EventArgs e) {
			if (!IsPostBack) {

				ProcessFlow.AccountController accountController = new ProcessFlow.AccountController();

				// Retrieve the account information from the account controller
				AccountInfo myAccount = accountController.GetAccountInfo(true);
				
				lblUserId.Text = myAccount.UserId;
				txtEmail.Text = myAccount.Email;
				addr.Address = myAccount.Address;
				prefs.Language = myAccount.Language;
				prefs.Category = myAccount.Category;
				prefs.IsShowBanners = myAccount.IsShowBanners;
				prefs.IsShowFavorites = myAccount.IsShowFavorites;				
			}
		}

		private void InitializeComponent() {
		}

		protected void SubmitClicked(object sender, ImageClickEventArgs e) {
			if (Page.IsValid) {

				ProcessFlow.AccountController accountController = new ProcessFlow.AccountController();

				// Retrieve the account information from the account controller
				AccountInfo myAccount = accountController.GetAccountInfo(true);

				// Merge in the changes
				string email = WebComponents.CleanString.InputText(txtEmail.Text, 50);
				AddressInfo address = addr.Address;
				string language = prefs.Language;
				string favCategory = prefs.Category;
				bool showFavorites = prefs.IsShowFavorites;
				bool showBanners = prefs.IsShowBanners;

				AccountInfo updatedAccountInfo = new AccountInfo(myAccount.UserId, myAccount.Password, email, address, language, favCategory, showFavorites, showBanners);

				// Submit the changes back to the controller
				accountController.UpdateAccount(updatedAccountInfo);
			}
		}
	}
}