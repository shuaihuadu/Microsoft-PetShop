using System;

//References to PetShop specific libraries
//PetShop DAL interfaces
using PetShop.IDAL;
using PetShop.Model;

namespace PetShop.BLL{

	/// <summary>
	/// A business component to manage the inventory management for an item
	/// </summary>
	public class Inventory{

		/// <summary>
		/// A method to get the current quanity in stock for an individual item
		/// </summary>
		/// <param name="itemId">A unique identifier for an item</param>
		/// <returns>Current in quantity in stock</returns>
		public int CurrentQuantityInStock(string itemId){

			// Validate input
			if (itemId.Trim() == string.Empty)
				return 0;
			
			// Get an instance of the Inventory DAL using the DALFactory
			IInventory dal = PetShop.DALFactory.Inventory.Create();

			// Query the DAL for the current quantity in stock
			return dal.CurrentQtyInStock(itemId);
		}

		/// <summary>
		/// Reduce the current quantity in stock for an order's lineitems
		/// </summary>
		/// <param name="items">An array of order line items</param>
		public void TakeStock(LineItemInfo[] items){

			// Get an instance of the Inventory DAL using the DALFactory
			IInventory dalc = PetShop.DALFactory.Inventory.Create();

			// Reduce the stock level in the data store
			dalc.TakeStock(items);
		}
	}
}
