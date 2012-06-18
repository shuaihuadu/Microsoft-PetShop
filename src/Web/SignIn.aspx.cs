using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShop.Web {
	public class SignIn : Page {

		protected TextBox txtUserId;
		protected TextBox txtPassword;
		protected PetShop.Web.Controls.NavBar header;
		protected System.Web.UI.WebControls.RequiredFieldValidator valPassword;
		protected System.Web.UI.WebControls.ImageButton btnSubmit;
		protected System.Web.UI.HtmlControls.HtmlForm frmSignIn;
		protected RequiredFieldValidator valUserId;

		private const string MSG_FAILURE = "Sign in failed! Please try again.";

		private void InitializeComponent() {
		}

		protected void SubmitClicked(object sender, ImageClickEventArgs e) {
			if (Page.IsValid) {
				
				// Get the user info from the text boxes
				string userId = WebComponents.CleanString.InputText(txtUserId.Text, 50);
				string password = WebComponents.CleanString.InputText(txtPassword.Text, 50);

				// Hand off to the account controller to control the naviagtion
				ProcessFlow.AccountController accountController = new ProcessFlow.AccountController();

				if (!accountController.ProcessLogin(userId, password)){

					// If we fail to login let the user know
					valUserId.ErrorMessage = MSG_FAILURE;
					valUserId.IsValid = false;
				}
			}
		}
	}
}