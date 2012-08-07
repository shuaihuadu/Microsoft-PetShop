using System;

//References to PetShop specific libraries
//PetShop busines entity library
using PetShop.Model;

//PetShop DAL interfaces
using PetShop.IDAL;

namespace PetShop.BLL {

	/// <summary>
	/// A business Component used to manage accounts
	/// The PetShop.Model.Account is used in most methods 
	/// and is used to store serializable information about an account
	/// </summary>
	public class Account {
		
		/// <summary>
		/// Method to login into the system. The user must supply a username and password
		/// </summary>
		/// <param name="userId">Unique identifier for a user</param>
		/// <param name="password">Password for a user</param>
		/// <returns>If the login is successful it returns information abount the account</returns>
		public AccountInfo SignIn(string userId, string password) {

			// Validate input
			if ((userId.Trim() == string.Empty) || (password.Trim() == string.Empty))
				return null;

			// Get an instance of the account DAL using the DALFactory
			IAccount dal = PetShop.DALFactory.Account.Create();

			// Try to sign in with the given credentials
			AccountInfo account = dal.SignIn(userId, password);

			// Return the account
			return account;
		}

		/// <summary>
		/// Returns the address information for a specific user
		/// </summary>
		/// <param name="userId">Unique identifier for an account/customer</param>
		/// <returns>Returns the address information for the user</returns>
		public AddressInfo GetAddress(string userId) {

			// Validate input
			if (userId.Trim() == string.Empty)
				return null;
			
			// Get an instance of the account DAL using the DALFactory
			IAccount dal = PetShop.DALFactory.Account.Create();

			// Return the address information for the given userId from the DAL
			return dal.GetAddress(userId); 
		}

		/// <summary>
		/// A method to insert a new Account
		/// </summary>
		/// <param name="account">An account entity with information about the new account</param>
		public void Insert(AccountInfo account) {

			// Validate input
			if (account.UserId.Trim() == string.Empty)
				return;

			// Get an instance of the account DAL using the DALFactory
			IAccount dal = PetShop.DALFactory.Account.Create();

			// Call the DAL to insert the account
			dal.Insert(account);
		}

		/// <summary>
		/// A method to update an existing account
		/// </summary>
		/// <param name="account">An account entity with information about the account to be updated</param>
		public void Update(AccountInfo account) {

			// Validate input
			if (account.UserId.Trim() == string.Empty)
				return;

			// Get an instance of the account DAL using the DALFactory
			IAccount dal = PetShop.DALFactory.Account.Create();

			// Send the udpated account information to the DAL
			dal.Update(account);
		}
	}
}