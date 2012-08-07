using System;

namespace PetShop.Model {

	/// <summary>
	/// Business entity used to model items in a shopping cart
	/// </summary>
	[Serializable]
	public class CartItemInfo {

		private const string YES = "Yes";
		private const string NO = "No";

		// Internal member variables
		private int _quantity = 1;
		private bool _inStock = false;
		private string _itemId = null;
		private string _name;
		private decimal _price;

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="itemId">Every cart item requires an itemId</param>
		public CartItemInfo(string itemId) {
			this._itemId = itemId;
		}

		/// <summary>
		/// Constructor with specified initial values
		/// </summary>
		/// <param name="itemId">Id of item to add to cart</param></param>
		/// <param name="name">Name of item</param>
		/// <param name="inStock">Is the item in stock</param>
		/// <param name="qty">Quantity to purchase</param>
		/// <param name="price">Price of item</param>
		public CartItemInfo(string itemId, string name, bool inStock, int qty, decimal price) {
		
			this._itemId = itemId;
			this._name = name;
			this._quantity = qty;
			this._price = price;
			this._inStock = inStock;
		}

		// Properties
		public int Quantity {
			get { return _quantity; }
			set { _quantity = value; }
		}

		public bool InStock {
			get { return _inStock; }
			set { _inStock = value; }
		}

		public decimal Subtotal {
			get { return (decimal)(this._quantity * this._price); }
		}

		public string ItemId {
			get { return _itemId; }
		}

		public string Name {
			get { return _name; }
		}

		public decimal Price {
			get { return _price; }
		}
	}
}