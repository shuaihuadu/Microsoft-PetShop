using System;

//References to PetShop specific libraries
//PetShop busines entity library
using PetShop.Model;

namespace PetShop.IDAL{
	
	/// <summary>
	/// Interface for the Order DAL
	/// </summary>
	public interface IOrder {

		/// <summary>
		/// Method to insert an order header
		/// </summary>
		/// <param name="order">Business entity representing the order</param>
		/// <returns>OrderId</returns>
		int Insert(OrderInfo order);

		/// <summary>
		/// Reads the order information for a given orderId
		/// </summary>
		/// <param name="orderId">Unique identifier for an order</param>
		/// <returns>Business entity representing the order</returns>
		OrderInfo GetOrder(int orderId);

		/// <summary>
		/// A function to dispose of resources used by the dal
		/// </summary>
		//void Dispose();
	}
}
