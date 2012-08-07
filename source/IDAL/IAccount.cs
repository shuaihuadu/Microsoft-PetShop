using System;

//References to PetShop specific libraries
//PetShop busines entity library
using PetShop.Model;

namespace PetShop.IDAL
{
	/// <summary>
	/// Inteface for the Account DAL
	/// </summary>
	public interface IAccount
	{
		/// <summary>
		/// Authenticate a user
		/// </summary>
		/// <param name="userId">Unique identifier for a user</param>
		/// <param name="password">Password for the user</param>
		/// <returns>Details about the user who has just logged in</returns>
		AccountInfo SignIn(string userId, string password);

		/// <summary>
		/// Get a user's address stored in the database
		/// </summary>
		/// <param name="userId">Unique identifier for a user</param>
		/// <returns>Address information</returns>
		AddressInfo GetAddress(string userId);

		/// <summary>
		/// Insert an account into the database
		/// </summary>
		/// <param name="account">Account to insert</param>
		void Insert(AccountInfo account);

		/// <summary>
		/// Update an account in the database
		/// </summary>
		/// <param name="Account">Account information to update</param>
		void Update(AccountInfo Account);
	}
}
