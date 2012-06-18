using System;
using System.Web;
using System.Web.Security;

// PetShop specific imports
using PetShop.Model;
using PetShop.BLL;

namespace PetShop.Web.ProcessFlow{

	/// <summary>
	/// Cart Process Flow, controls navigation for cart based events
	/// </summary>
	public class CartController{

		private const string BILLING_KEY = "BILLING_KEY";
		private const string SHIPPING_KEY = "SHIPPING_KEY";
		private const string ACCOUNT_KEY = "ACCOUNT_KEY";
		private const string CART_KEY = "CART_KEY";
		private const string CREDITCARD_KEY = "CREDITCARD_KEY";
		private const string URL_NOCART = "ShoppingCart.aspx";

		public CartController(){}

		/// <summary>
		/// A method to return the current state of the cart
		/// </summary>
		/// <param name="create">Specifies whether a cart should be created if one does not exist</param>
		/// <returns>Cart object</returns>
		public Cart GetCart(bool create){
		
			// Fetch the cart object from session state
			Cart myCart = (Cart)HttpContext.Current.Session[CART_KEY];

			if ( myCart == null ){
				if (create){
					myCart = new Cart();
				}else{			
					HttpContext.Current.Server.Transfer(URL_NOCART);
					return null;
				}
			}
			
			return myCart;
		}

		/// <summary>
		/// A method to return the current state of the cart
		/// </summary>
		/// <param name="create">Specifies whether a cart should be created if one does not exist</param>
		/// <returns>Cart object</returns>
		public void StoreCart(Cart cart){
		
			// Store the cart object in session state
			HttpContext.Current.Session[CART_KEY] = cart;

		}

		/// <summary>
		/// A method to purchase the contents of the cart
		/// </summary>
		/// <returns>Order object with information about the new Order</returns>
		public OrderInfo PurchaseCart(){

			// Fetch the cart from session
			Cart myCart = (Cart)HttpContext.Current.Session[CART_KEY];

			// Make some checks on the cart
			if ( ( myCart == null ) || ( myCart.Count==0 ) ) {

				HttpContext.Current.Server.Transfer(URL_NOCART);
				//HttpContext.Current.Response.Redirect(URL_NOCART, false);
				return null;

			}else{
				
				// Build up the order
				OrderInfo newOrder = new OrderInfo();
				newOrder.UserId = ((AccountInfo)HttpContext.Current.Session[ACCOUNT_KEY]).UserId;
				newOrder.CreditCard = (CreditCardInfo)HttpContext.Current.Session[CREDITCARD_KEY];
				newOrder.BillingAddress = (AddressInfo)HttpContext.Current.Session[BILLING_KEY];
				newOrder.ShippingAddress = (AddressInfo)HttpContext.Current.Session[SHIPPING_KEY];
				
				newOrder.LineItems = (LineItemInfo[])myCart.GetOrderLineItems().ToArray(typeof(LineItemInfo));
								
				newOrder.OrderTotal = myCart.Total;			
				newOrder.Date = DateTime.Now;
				
				// Send the order to the middle tier
				OrderInsert order = new OrderInsert();						  
				newOrder.OrderId = order.Insert(newOrder);
				
				// clear the session objects used
				HttpContext.Current.Session[CART_KEY] = null;
				HttpContext.Current.Session[CREDITCARD_KEY] = null;
				HttpContext.Current.Session[BILLING_KEY] = null;
				HttpContext.Current.Session[SHIPPING_KEY] = null;

				return newOrder;
			}
		}

		/// <summary>
		/// A method to store credit card state information
		/// </summary>
		public void StoreCreditCard(CreditCardInfo creditCard){

			HttpContext.Current.Session[CREDITCARD_KEY] = creditCard;
				
		}

		/// <summary>
		/// A method to store the billing address information
		/// </summary>
		public void StoreBillingAddress(AddressInfo billingAddress){

			HttpContext.Current.Session[BILLING_KEY] = billingAddress;
				
		}

		/// <summary>
		/// A method to store the shipping address information
		/// </summary>
		public void StoreShippingAddress(AddressInfo shippingAddress){

			HttpContext.Current.Session[SHIPPING_KEY] = shippingAddress;
				
		}

		/// <summary>
		/// A method to get the billing address information from the state store
		/// </summary>
		public AddressInfo GetBillingAddress(){

			return (AddressInfo)HttpContext.Current.Session[BILLING_KEY];
				
		}

		/// <summary>
		/// A method to get the shipping address information from the state store
		/// </summary>
		public AddressInfo GetShippingAddress(){

			return (AddressInfo)HttpContext.Current.Session[SHIPPING_KEY];
				
		}

		/// <summary>
		/// A method to control the flow when 'continuing' an order
		/// The customer will have entered creditcard information and some address information
		/// </summary>
		public void ContinueOrder(bool useBillingAddress){

			// Set the billing address depending on what the user has selected
			if (useBillingAddress) {
				HttpContext.Current.Session[SHIPPING_KEY] = HttpContext.Current.Session[BILLING_KEY];
			} else {
				//If the user wants to use a different address then take them to the next page
				HttpContext.Current.Response.Redirect("OrderShipping.aspx", true);
			}				
		}

		/// <summary>
		/// A method to control the flow when picking an alternate shipping address
		/// </summary>
		public void SetAlternateShippingAddress(AddressInfo shippingAddress){

			HttpContext.Current.Session[SHIPPING_KEY] = shippingAddress;
		}
	}
}
