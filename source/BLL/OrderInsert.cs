using System;
using System.Collections;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

//References to PetShop specific libraries
//PetShop busines entity library
using PetShop.Model;
//PetShop DAL interfaces
using PetShop.IDAL;

namespace PetShop.BLL {
	/// <summary>
	/// A business component to manage the creation of orders
	/// Creation of an order requires a distributed transaction
	/// so the Order class derives from ServicedComponents
	/// </summary>
	[Transaction(System.EnterpriseServices.TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ObjectPooling(MinPoolSize=4, MaxPoolSize=4)]
	[Guid("14E3573D-78C8-4220-9649-BA490DB7B78D")]
	public class OrderInsert : ServicedComponent {

		// These variables are used to demonstrate the rollback characterisitic 
		// of distributed transactions and would not form part of a production application
		private const string ACID_USER_ID = "ACID";
		private const string ACID_ERROR_MSG = "ACID test exception thrown for distributed transaction!";

		// Instruct COM+ whether this object can be returned to the pool
		protected override bool CanBePooled() {

			// Always return true
			return true; 
		}

		/// <summary>
		/// A method to insert a new order into the system
		/// The orderId will be generated within the method and should not be supplied
		/// As part of the order creation the inventory will be reduced by the quantity ordered
		/// </summary>
		/// <param name="order">All the information about the order</param>
		/// The new orderId is returned in the order object
		[AutoComplete]
		public int Insert(OrderInfo order) {

			// Get an instance of the Order DAL using the DALFactory
			IOrder dal = PetShop.DALFactory.Order.Create();

			// Call the insert method in the DAL to insert the header
			int orderId = dal.Insert(order);

			// Get an instance of the Inventory business component
			Inventory inventory = new Inventory();
			
			inventory.TakeStock( order.LineItems);
			
			// As part of the sample application we have created a user 
			// you can tested distributed transactions with
			// If the order has been created with the user 'Acid', 
			// then throw an exception which will rollback the entire transaction
			if (order.UserId == ACID_USER_ID)
				throw new ApplicationException(ACID_ERROR_MSG);

			// Set the orderId so that it can be returned to the caller
			return orderId;
		}
	}
}