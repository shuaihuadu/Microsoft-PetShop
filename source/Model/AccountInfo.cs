using System;

namespace PetShop.Model {

	/// <summary>
	/// Business entity used to model accounts
	/// </summary>
	[Serializable]
	public class AccountInfo {

		// Internal member variables
		private string _userId;
		private string _password;
		private string _email;
		private AddressInfo _address;
		private string _language;
		private string _category;
		private bool _showFavorites;
		private bool _showBanners;

		/// <summary>
		/// Default constructor
		/// </summary>
		public AccountInfo() {
		}

		/// <summary>
		/// Constructor with specified initial values
		/// </summary>
		/// <param name="userId">Unique identifier</param>
		/// <param name="password">Password</param>
		/// <param name="email">Email address</param>
		/// <param name="address">The default address object</param>
		/// <param name="language">Prefered language</param>
		/// <param name="category">Favourite Category</param>
		/// <param name="showFavorites">Show customized favourites based on prefered category</param>
		/// <param name="showBanners">Show personalized banners</param>
		public AccountInfo(string userId, string password, string email, AddressInfo address, string language, string category, bool showFavorites, bool showBanners) {
			this._userId = userId;
			this._password = password;
			this._email = email;
			this._address = address;
			this._language = language;
			this._category = category;
			this._showFavorites = showFavorites;
			this._showBanners = showBanners;
		}

		// Properties
		public string UserId {
			get { return _userId; }
		}
		public string Password {
			get { return _password; }
		}
		public string Email {
			get { return _email; }
		}
		public AddressInfo Address {
			get { return _address; }
		}
		public string Language {
			get { return _language; }
		}
		public string Category {
			get { return _category; }
		}
		public bool IsShowFavorites {
			get { return _showFavorites; }
		}
		public bool IsShowBanners {
			get { return _showBanners; }
		}
	}
}