using PetShop.Model;
using PetShop.BLL;
using PetShop.Web.Controls;
//using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShop.Web {
	public class CreateAccount : Page {

		// Assume a duplicate record is the reason for the error
		private const string MSG_FAILURE = "Duplicate user ID! Please try again.";

		protected TextBox txtUserId;
		protected TextBox txtPassword;
		protected TextBox txtEmail;
		protected RequiredFieldValidator valUserId;
		protected AddressUI addr;
		protected NavBar header;
		protected System.Web.UI.WebControls.RequiredFieldValidator valPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator valEmail;
		protected System.Web.UI.WebControls.ImageButton btnSubmit;
		protected System.Web.UI.HtmlControls.HtmlForm frmCreateAcct;
		protected Preferences prefs;

		protected void SubmitClicked(object sender, ImageClickEventArgs e) {
			if (Page.IsValid) {

				string userId = WebComponents.CleanString.InputText(txtUserId.Text, 50);
				string password = WebComponents.CleanString.InputText(txtPassword.Text, 50);
				string email = WebComponents.CleanString.InputText(txtEmail.Text, 50);
				AddressInfo address = addr.Address;
				string language = prefs.Language;
				string favCategory = prefs.Category;
				bool showFavorites = prefs.IsShowFavorites;
				bool showBanners = prefs.IsShowBanners;

				// Store all the customers information in an account business entity
				AccountInfo accountInfo = new AccountInfo(userId, password, email, address, language, favCategory, showFavorites, showBanners);

				ProcessFlow.AccountController accountController = new ProcessFlow.AccountController();

				if (!accountController.CreateAccount(accountInfo)){

					// Tell the user they have failed to create an account
					valUserId.ErrorMessage = MSG_FAILURE;
					valUserId.IsValid = false;
				}
			}
		}
	}
}