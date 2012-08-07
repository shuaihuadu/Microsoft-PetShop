using System;
using System.Web;
using System.Web.Security;

//PetShop specific references
using PetShop.Model;
using PetShop.BLL;

namespace PetShop.Web.ProcessFlow
{
	/// <summary>
	/// Acount Process Flow, controls navigation for account events
	/// </summary>
	public class AccountController {
		// Navigation constants

		private const string ACCOUNT_KEY = "ACCOUNT_KEY";
		private const string URL_DEFAULT = "default.aspx";
		private const string URL_SIGNIN  = "SignIn.aspx";
		private const string URL_ACCOUNTCREATE = "MyAccount.aspx?action=create";
		private const string URL_ACCOUNTSIGNIN = "MyAccount.aspx?action=signIn";
		private const string URL_ACCOUNTUPDATE = "MyAccount.aspx?action=update";
		
		/// <summary>
		/// Default constructor
		/// </summary>
		public AccountController(){
		}

		/// <summary>
		/// Verify Login process
		/// User passes in a user name and password and will be redirected on if successful
		/// </summary>
		/// <param name="userId">User name the customer is authenticating with</param>
		/// <param name="password">Password the customer is using</param>
		/// <returns>true if the login is successful</returns>
		public bool ProcessLogin(string userId, string password){

			// Use the account business logic layer to login
			Account account = new Account();
			AccountInfo myAccountInfo = account.SignIn(userId, password);

			//If login is successful then store the state in session and redirect
			if (myAccountInfo != null) {
				HttpContext.Current.Session[ACCOUNT_KEY] = myAccountInfo;
				
				// Determine where to redirect the user back too
				// If they came in from the home page, take them to a similar page
				if (FormsAuthentication.GetRedirectUrl(userId, false).EndsWith(URL_DEFAULT)) {

					FormsAuthentication.SetAuthCookie(userId, false);
					HttpContext.Current.Response.Redirect(URL_ACCOUNTSIGNIN, true);

				}else{
					// Take the customer back to where the came from
					FormsAuthentication.SetAuthCookie(userId, false);

					HttpContext.Current.Response.Redirect(FormsAuthentication.GetRedirectUrl(userId, false), true);
				}

				return true;
			
			}else {
				// Login has failed so return false
				return false;
			}
		}

		public bool CreateAccount(AccountInfo newAccountInfo){

			try {
				// Creata a new business logic tier
				Account account = new Account();

				// Call the insert method
				account.Insert(newAccountInfo);

				// Store the data in session state and store the authenticated cookie
				HttpContext.Current.Session[ACCOUNT_KEY] = newAccountInfo;
				FormsAuthentication.SetAuthCookie(newAccountInfo.UserId, false);
				
				//Finally forward to the welcome page
				HttpContext.Current.Response.Redirect(URL_ACCOUNTCREATE, true);
				
			
			}catch {
				return false;
			}

			return true;
		}

		/// <summary>
		/// A method to process an updated account
		/// </summary>
		/// <param name="updatedAccountInfo">Updated account information</param>
		public void UpdateAccount(AccountInfo updatedAccountInfo){

			// Create the business logic tier
			Account account = new Account();
			
			// Call the udpate method
			account.Update(updatedAccountInfo);

			//Store the update info back in session state
			HttpContext.Current.Session[ACCOUNT_KEY] = updatedAccountInfo;

			//Redirect the user to the my account page
			HttpContext.Current.Response.Redirect(URL_ACCOUNTUPDATE, true);
			
		}

		/// <summary>
		/// Retrieves the account information for a customer who has already logged in
		/// The method assume the account information is in session state
		/// If it can't find it the function will direct the user to login
		/// </summary>
		/// <returns>The account info for the currently logged in user</returns>
		public AccountInfo GetAccountInfo(bool required){
			AccountInfo myAccount = (AccountInfo)HttpContext.Current.Session[ACCOUNT_KEY];

			if (myAccount == null){
				if(required){
					HttpContext.Current.Response.Redirect(URL_SIGNIN, true);
					
				}
				return null;
			}else{
				return myAccount;
			}
		}

		/// <summary>
		/// Retrieves favourtie category of a customer if we know who they are
		/// The method assume the account information is in session state
		/// </summary>
		/// <returns>The customers favourite category</returns>
		public string GetFavouriteCategory(){

			AccountInfo myAccount = (AccountInfo)HttpContext.Current.Session[ACCOUNT_KEY];

			if (myAccount != null && myAccount.IsShowFavorites) {
				return myAccount.Category;
			}else{
				return null;
			}
		}

		/// <summary>
		/// Method to log the user out of the application
		/// When the user logs out there session is cleared and their authentication ticket is reset
		/// </summary>
		public void LogOut(){

			// Clear the authentication ticket
			FormsAuthentication.SignOut();
			// Clear the contents of their session
			HttpContext.Current.Session.Clear();
			// Tell the system to drop the session reference so that it does 
			// not need to be carried around with the user
			HttpContext.Current.Session.Abandon();
		}
	}
}
