using PetShop.Web.Controls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

// PetShop specific imports
using PetShop.Model;
using PetShop.BLL;

namespace PetShop.Web {
	public class OrderBilling : Page {
		
		private const string FORMAT_EXPIRATION = "{0}/{1}";

		protected TextBox txtCardNumber;
		protected DropDownList listCardType;
		protected DropDownList listMonth;
		protected DropDownList listYear;
		protected AddressUI billAddr;
		protected NavBar header;
		protected System.Web.UI.WebControls.RequiredFieldValidator valCardNumber;
		protected System.Web.UI.WebControls.ImageButton btnContinue;
		protected System.Web.UI.HtmlControls.HtmlForm frmBill;
		protected System.Web.UI.WebControls.Panel enterAddress;
		protected System.Web.UI.WebControls.Panel confirmAddress;
		protected Controls.StaticAddress staticAddressBilling;
		protected Controls.StaticAddress staticAddressShipping;
		protected CheckBox chkShipBilling;

		override protected void OnLoad(EventArgs e) {
			if (!IsPostBack){

				enterAddress.Visible = true;
				confirmAddress.Visible = false;

				ProcessFlow.AccountController accountController = new ProcessFlow.AccountController();

				AccountInfo myAccount = accountController.GetAccountInfo(true);

				if (myAccount != null){
					Account account = new Account();
					billAddr.Address = account.GetAddress(myAccount.UserId);
				}
			}
		}

		private void InitializeComponent() {
		}

		protected void ContinueClicked(object sender, ImageClickEventArgs e) {
			if (Page.IsValid) {

				// Create a new cartController object
				ProcessFlow.CartController cartController = new ProcessFlow.CartController();

				// Fetch the creditcard info and store it 
				string cardType = WebComponents.CleanString.InputText(listCardType.SelectedItem.Text, 10);
				string cardNumber = WebComponents.CleanString.InputText(txtCardNumber.Text, 20);;
				string cardYear = WebComponents.CleanString.InputText(listYear.SelectedItem.Text, 4);;
				string cardMonth = WebComponents.CleanString.InputText(listMonth.SelectedItem.Text, 2);;

				CreditCardInfo creditCard = new CreditCardInfo(cardType, cardNumber, string.Format(FORMAT_EXPIRATION, cardMonth, cardYear));
				
				cartController.StoreCreditCard(creditCard);

				AddressInfo billingAddress = billAddr.Address;

				// Now store the billing information
				cartController.StoreBillingAddress(billAddr.Address);

				// Continue with the order process
				cartController.ContinueOrder(chkShipBilling.Checked);

				enterAddress.Visible = false;
				confirmAddress.Visible = true;

				staticAddressBilling.ShowAddress(billingAddress);
				staticAddressShipping.ShowAddress(billingAddress);
			}
		}
	}
}