using System;

namespace PetShop.Model
{
	/// <summary>
	/// Business entity used to model an item.
	/// </summary>
	[Serializable]
	public class ItemInfo{

		// Internal member variables
		private string _id;
		private string _name;
		private int _quantity;
		private decimal _price;
		private string _productName;
		private string _productDesc;

		/// <summary>
		/// Constructor with specified initial values
		/// </summary>
		/// <param name="id">Item Id</param>
		/// <param name="name">Item Name</param>
		/// <param name="quantity">Quantity in stock</param>
		/// <param name="price">Price</param>
		/// <param name="productName">Parent product name</param>
		/// <param name="productDesc">Parent product description</param>
		public ItemInfo(string id, string name, int quantity, decimal price, string productName, string productDesc) {
			this._id = id;
			this._name = name;
			this._quantity = quantity;
			this._price = price;
			this._productName = productName;
			this._productDesc = productDesc;
		}

		/// <summary>
		/// Constructor with specified initial values, except inventory information
		/// </summary>
		/// <param name="id">Item Id</param>
		/// <param name="name">Item Name</param>
		/// <param name="price">Price</param>
		/// <param name="productName">Parent product name</param>
		/// <param name="productDesc">Parent product description</param>
		public ItemInfo(string id, string name, decimal price, string productName, string productDesc) {
			this._id = id;
			this._name = name;
			this._price = price;
			this._productName = productName;
			this._productDesc = productDesc;
		}

		// Properties
		public string Id {
			get { return _id; }
		}

		public string Name {
			get { return _name; }
		}

		public string ProductName {
			get { return _productName; }
		}

		public string ProductDesc {
			get { return _productDesc; }
		}

		public int Quantity {
			get { return _quantity; }
		}

		public decimal Price {
			get { return _price; }
		}
	}
}
