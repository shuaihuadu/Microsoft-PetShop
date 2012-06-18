using PetShop.Model;
using PetShop.BLL;
using PetShop.Web.Controls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShop.Web {
	public class OrderProcess : Page {

		protected StaticAddress statAddrBill;
		protected StaticAddress statAddrShip;
		protected Repeater cart;
		protected NavBar header;
		protected System.Web.UI.WebControls.Label lblOrderDate;
		protected System.Web.UI.WebControls.Label lblUserId;
		protected System.Web.UI.WebControls.Label lblOrderId;
		protected System.Web.UI.WebControls.Label lblCardType;
		protected System.Web.UI.WebControls.Label lblCardExpiration;
		protected System.Web.UI.WebControls.Label lblCardNumber;
		protected System.Web.UI.WebControls.Label lblOrderTotal;

		protected OrderInfo myOrder;

		private void InitializeComponent() {}

		override protected void OnLoad(EventArgs e) {

			ProcessFlow.CartController cartController = new ProcessFlow.CartController();

			OrderInfo newOrder = cartController.PurchaseCart();

			//Display the order info to the user
			lblOrderId.Text = newOrder.OrderId.ToString();
			lblOrderDate.Text = newOrder.Date.ToLongDateString();;
			lblUserId.Text = newOrder.UserId;
			lblCardType.Text = newOrder.CreditCard.CardType;
			lblCardNumber.Text = newOrder.CreditCard.CardNumber;
			lblCardExpiration.Text = newOrder.CreditCard.CardExpiration;
			
			statAddrBill.address = newOrder.BillingAddress;
			statAddrShip.address = newOrder.ShippingAddress;
			
			cart.DataSource = newOrder.LineItems;
			cart.DataBind();

			lblOrderTotal.Text = newOrder.OrderTotal.ToString("c");
		}
	}
}