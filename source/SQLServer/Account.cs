using System;
using System.Data;
using System.Data.SqlClient;
using PetShop.Model;
using PetShop.IDAL;

namespace PetShop.SQLServerDAL {
	/// <summary>
	/// Summary description for AccountDALC.
	/// </summary>
	public class Account : IAccount{

		// Static constants
		private const string SQL_SELECT_ACCOUNT = "SELECT Account.Email, Account.FirstName, Account.LastName, Account.Addr1, Account.Addr2, Account.City, Account.State, Account.Zip, Account.Country, Account.Phone, Profile.LangPref, Profile.FavCategory, Profile.MyListOpt, Profile.BannerOpt FROM Account INNER JOIN Profile ON Account.UserId = Profile.UserId INNER JOIN SignOn ON Account.UserId = SignOn.UserName WHERE SignOn.UserName = @UserId AND SignOn.Password = @Password";
		private const string SQL_SELECT_ADDRESS = "SELECT Account.FirstName, Account.LastName, Account.Addr1, Account.Addr2, Account.City, Account.State, Account.Zip, Account.Country, Account.Phone FROM Account WHERE Account.UserId = @UserId";
		private const string SQL_INSERT_SIGNON = "INSERT INTO SignOn VALUES (@UserId, @Password)";
		private const string SQL_INSERT_ACCOUNT = "INSERT INTO Account VALUES(@UserId, @Email, @FirstName, @LastName, 'OK', @Address1, @Address2, @City, @State, @Zip, @Country, @Phone)";
		private const string SQL_INSERT_PROFILE = "INSERT INTO Profile VALUES(@UserId, @Language, @Category, @ShowFavorites, @ShowBanners)";
		private const string SQL_UPDATE_PROFILE = "UPDATE Profile SET LangPref = @Language, FavCategory = @Category, MyListOpt = @ShowFavorites, BannerOpt = @ShowBanners WHERE UserId = @UserId";
		private const string SQL_UPDATE_ACCOUNT = "UPDATE Account SET Email = @Email, FirstName = @FirstName, LastName = @LastName, Addr1 = @Address1, Addr2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, Phone = @Phone WHERE UserId = @UserId";
		private const string PARM_USER_ID = "@UserId";
		private const string PARM_PASSWORD = "@Password";
		private const string PARM_EMAIL = "@Email";
		private const string PARM_FIRST_NAME = "@FirstName";
		private const string PARM_LAST_NAME = "@LastName";
		private const string PARM_ADDRESS1 = "@Address1";
		private const string PARM_ADDRESS2 = "@Address2";
		private const string PARM_CITY = "@City";
		private const string PARM_STATE = "@State";
		private const string PARM_ZIP = "@Zip";
		private const string PARM_COUNTRY = "@Country";
		private const string PARM_PHONE = "@Phone";
		private const string PARM_LANGUAGE = "@Language";
		private const string PARM_CATEGORY = "@Category";
		private const string PARM_SHOW_FAVORITES = "@ShowFavorites";
		private const string PARM_SHOW_BANNERS = "@ShowBanners";

		public Account(){
		}

		/// <summary>
		/// Verify the users login credentials against the database
		/// If the user is valid return all information for the user
		/// </summary>
		/// <param name="userId">Username</param>
		/// <param name="password">password</param>
		/// <returns></returns>
		public AccountInfo SignIn(string userId, string password) {

			SqlParameter[] signOnParms = GetSignOnParameters();

			signOnParms[0].Value = userId;
			signOnParms[1].Value = password;

			using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQL_SELECT_ACCOUNT, signOnParms)) {
				if (rdr.Read()) {
					AddressInfo myAddress = new AddressInfo(rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9));
					return new AccountInfo(userId, password, rdr.GetString(0), myAddress, rdr.GetString(10), rdr.GetString(11), Convert.ToBoolean(rdr.GetInt32(12)), Convert.ToBoolean(rdr.GetInt32(13))); 
				}
				return null;
			}
		}

		/// <summary>
		/// Return the address information for a user
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public AddressInfo GetAddress(string userId) {
			AddressInfo address= null;
			
			SqlParameter[] addressParms = GetAddressParameters();
			
			addressParms[0].Value = userId;
			
			using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQL_SELECT_ADDRESS, addressParms)) {
				if (rdr.Read()) {					
					address = new AddressInfo(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8)); 					
				}
			}

			return address;
		}

		/// <summary>
		/// Insert a new account info the database
		/// </summary>
		/// <param name="acc">A thin data class containing all the new account information</param>
		public void Insert(AccountInfo acc) {
			SqlParameter[] signOnParms = GetSignOnParameters();
			SqlParameter[] accountParms = GetAccountParameters();
			SqlParameter[] profileParms = GetProfileParameters();

			signOnParms[0].Value = acc.UserId;
			signOnParms[1].Value = acc.Password;

			SetAccountParameters(accountParms, acc);
			SetProfileParameters(profileParms, acc);
							
			using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString)) {
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) {
					try {
						SQLHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_INSERT_SIGNON, signOnParms);
						SQLHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_INSERT_ACCOUNT, accountParms);
						SQLHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_INSERT_PROFILE, profileParms);
						trans.Commit();
					
					}catch {
						trans.Rollback();
						throw;
					}
				}
			}
		}

		/// <summary>
		/// Update an account in the database
		/// </summary>
		/// <param name="myAccount">Updated account parameters, you must supply all parameters</param>
		public void Update(AccountInfo myAccount) {
			SqlParameter[] accountParms = GetAccountParameters();
			SqlParameter[] profileParms = GetProfileParameters();
			
			SetAccountParameters(accountParms, myAccount);
			SetProfileParameters(profileParms, myAccount);
							
			using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString)) {
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) {
					try {
						SQLHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UPDATE_ACCOUNT, accountParms);
						SQLHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UPDATE_PROFILE, profileParms);
						trans.Commit();
					}catch {
						trans.Rollback();
						throw;
					}
				}
			}
		}

		/// <summary>
		/// An internal function to get the database parameters
		/// </summary>
		/// <returns>Parameter array</returns>
		private static SqlParameter[] GetSignOnParameters() {
			SqlParameter[] parms = SQLHelper.GetCachedParameters(SQL_INSERT_SIGNON);

			if (parms == null) {
				parms = new SqlParameter[] {
											   new SqlParameter(PARM_USER_ID, SqlDbType.VarChar, 80),
											   new SqlParameter(PARM_PASSWORD, SqlDbType.VarChar, 80)};

				SQLHelper.CacheParameters(SQL_INSERT_SIGNON, parms);
			}

			return parms;
		}

		/// <summary>
		/// An internal function to get the database parameters
		/// </summary>
		/// <returns>Parameter array</returns>
		private static SqlParameter[] GetAddressParameters() {
			SqlParameter[] parms = SQLHelper.GetCachedParameters(SQL_SELECT_ADDRESS);

			if (parms == null) {
				parms = new SqlParameter[] {
											   new SqlParameter(PARM_USER_ID, SqlDbType.VarChar, 80)};

				SQLHelper.CacheParameters(SQL_SELECT_ADDRESS, parms);
			}

			return parms;
		}

		/// <summary>
		/// An internal function to get the database parameters
		/// </summary>
		/// <returns>Parameter array</returns>
		private static SqlParameter[] GetAccountParameters() {
			SqlParameter[] parms = SQLHelper.GetCachedParameters(SQL_INSERT_ACCOUNT);

			if (parms == null) {
				parms = new SqlParameter[] {
					new SqlParameter(PARM_EMAIL, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_FIRST_NAME, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_LAST_NAME, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_ADDRESS1, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_ADDRESS2, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_CITY, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_STATE, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_ZIP, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_COUNTRY, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_PHONE, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_USER_ID, SqlDbType.VarChar, 80)};

				SQLHelper.CacheParameters(SQL_INSERT_ACCOUNT, parms);
			}

			return parms;
		}

		/// <summary>
		/// An internal function to get the database parameters
		/// </summary>
		/// <returns>Parameter array</returns>
		private static SqlParameter[] GetProfileParameters() {
			SqlParameter[] parms = SQLHelper.GetCachedParameters(SQL_INSERT_PROFILE);

			if (parms == null) {
				parms = new SqlParameter[] {
					new SqlParameter(PARM_LANGUAGE, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_CATEGORY, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_SHOW_FAVORITES, SqlDbType.Int, 4),
					new SqlParameter(PARM_SHOW_BANNERS, SqlDbType.Int, 4),
					new SqlParameter(PARM_USER_ID, SqlDbType.VarChar, 80)};

				SQLHelper.CacheParameters(SQL_INSERT_PROFILE, parms);
			}

			return parms;
		}

		/// <summary>
		/// An internal function to bind values parameters 
		/// </summary>
		/// <param name="parms">Database parameters</param>
		/// <param name="acc">Values to bind to parameters</param>
		private void SetAccountParameters(SqlParameter[] parms, AccountInfo acc) {
			parms[0].Value = acc.Email;
			parms[1].Value = acc.Address.FirstName;
			parms[2].Value = acc.Address.LastName;
			parms[3].Value = acc.Address.Address1;
			parms[4].Value = acc.Address.Address2;
			parms[5].Value = acc.Address.City;
			parms[6].Value = acc.Address.State;
			parms[7].Value = acc.Address.Zip;
			parms[8].Value = acc.Address.Country;
			parms[9].Value = acc.Address.Phone;
			parms[10].Value = acc.UserId;
		}

		/// <summary>
		/// An internal function to bind values parameters 
		/// </summary>
		/// <param name="parms">Database parameters</param>
		/// <param name="acc">Values to bind to parameters</param>
		private void SetProfileParameters(SqlParameter[] parms, AccountInfo acc) {
			parms[0].Value = acc.Language;
			parms[1].Value = acc.Category;
			parms[2].Value = acc.IsShowFavorites;
			parms[3].Value = acc.IsShowBanners;
			parms[4].Value = acc.UserId;
		}
	}
}
