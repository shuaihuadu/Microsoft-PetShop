using System;

namespace PetShop.Model {

	/// <summary>
	/// Business entity used to model a product
	/// </summary>
	[Serializable]
	public class ProductInfo {

		// Internal member variables
		private string _id;
		private string _name;
		private string _description;

		/// <summary>
		/// Default constructor
		/// </summary>
		public ProductInfo() {}

		/// <summary>
		/// Constructor with specified initial values
		/// </summary>
		/// <param name="id">Product Id</param>
		/// <param name="name">Product Name</param>
		/// <param name="description">Product Description</param>
		public ProductInfo(string id, string name, string description) {
			this._id = id;
			this._name = name;
			this._description = description;
		}

		// Properties
		public string Id {
			get { return _id; }
		}

		public string Name {
			get { return _name; }
		}

		public string Description {
			get { return _description; }
		}
	}
}