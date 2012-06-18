using System;
using System.Web.UI;

namespace PetShop.Web
{
	public class MyAccount : Page
	{
		private const string ACTION_CREATE = "create";
		private const string ACTION_UPDATE = "update";
		private const string ACTION_SIGN_IN = "signIn";
		private const string TITLE_CREATE = "Create Account";
		private const string TITLE_UPDATE = "Edit Account";
		private const string TITLE_SIGN_IN = "Sign In";
		private const string MSG_CREATE = "Your account was successfully created.";
		private const string MSG_UPDATE = "Your account was successfully updated.";
		private const string MSG_SIGN_IN = "Welcome to the .NET Pet Shop Demo.";

		protected PetShop.Web.Controls.NavBar header;
		protected System.Web.UI.WebControls.Label lblMessage;

		private void InitializeComponent() {}

		override protected void OnLoad(EventArgs e)
		{
			string pageAction = WebComponents.CleanString.InputText(Request["action"], 20);

			switch(pageAction)
			{
				case ACTION_CREATE:
					lblMessage.Text = MSG_CREATE;
					break;

				case ACTION_UPDATE:
					lblMessage.Text = MSG_UPDATE;
					break;

				case ACTION_SIGN_IN:
					lblMessage.Text = MSG_SIGN_IN;
					break;
			}
		}
	}
}