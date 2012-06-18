using System.Web.UI;

// PetShop specific imports
using PetShop.BLL;
using PetShop.Model;
using PetShop.Web.Controls;

namespace PetShop.Web{
	public class OrderShipping : Page{

		protected NavBar header;
		protected System.Web.UI.WebControls.ImageButton btnContinue;
		protected System.Web.UI.HtmlControls.HtmlForm frmShip;
		protected System.Web.UI.WebControls.Panel enterShipAddress;
		protected System.Web.UI.WebControls.Panel confirmAddress;
		protected Controls.StaticAddress staticAddressBilling;
		protected Controls.StaticAddress staticAddressShipping;
		protected AddressUI shipAddr;

		private void InitializeComponent() {

			if (!IsPostBack){
				enterShipAddress.Visible = true;
				confirmAddress.Visible = false;
			}
		}

		protected void ContinueClicked(object sender, ImageClickEventArgs e)
		{
			if (Page.IsValid){
				ProcessFlow.CartController cartController = new ProcessFlow.CartController();
				
				AddressInfo shippingAddress = shipAddr.Address;
				
				cartController.SetAlternateShippingAddress( shippingAddress );

				AddressInfo billingAddress = cartController.GetBillingAddress();

				enterShipAddress.Visible = false;
				confirmAddress.Visible = true;

				staticAddressBilling.ShowAddress(billingAddress);
				staticAddressShipping.ShowAddress(shippingAddress);
			}
		}
	}
}