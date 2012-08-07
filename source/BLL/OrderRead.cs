using System;

//References to PetShop specific libraries
//PetShop busines entity library
using PetShop.Model;
//PetShop DAL interfaces
using PetShop.IDAL;

namespace PetShop.BLL {
	
	/// <summary>
	/// A business component to manage the retrieval of orders
	/// Creation of an order requires a distributed transaction, however
	/// reading the order does not, so the the component has been split into 2 parts
	/// By splitting the component into 2 we avoid the overhead of Enterprise Services
	/// </summary>
	public class OrderRead{

		/// <summary>
		/// A method to read an order from the system
		/// </summary>
		/// <param name="orderId">Unique identifier for an order</param>
		/// <returns></returns>
		public OrderInfo GetOrder(int orderId) {

			// Validate input
			if (orderId < 1)
				return null;

			// Get an instance of the Order DAL using the DALFactory
			IOrder dal = PetShop.DALFactory.Order.Create();

			// Return the order from the DAL
			return dal.GetOrder(orderId);
		}
	}
}