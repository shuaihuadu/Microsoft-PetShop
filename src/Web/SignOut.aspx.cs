using System;
using System.Web.UI;
using System.Web.Security;

// PetShop specific imports
using PetShop.Web.Controls;

namespace PetShop.Web {

	public class SignOut : Page {

		protected SignOutNavBar header;

		private void InitializeComponent() {}
	
		override protected void OnLoad(EventArgs e) {

			// Create an instance of the account controller
			ProcessFlow.AccountController accountController = new ProcessFlow.AccountController();

			// Tell the controller that the user is logging out
			accountController.LogOut();
		}
	}
}