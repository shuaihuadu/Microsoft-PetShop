using System;

namespace PetShop.Model {

	/// <summary>
	/// Business entity used to model addresses
	/// </summary>
	[Serializable]
	public class AddressInfo {

		// Internal member variables
		private string _firstName;
		private string _lastName;
		private string _address1;
		private string _address2;
		private string _city;
		private string _state;
		private string _zip;
		private string _country;
		private string _phone;

		/// <summary>
		/// Default constructor
		/// </summary>
		public AddressInfo(){
		}

		/// <summary>
		/// Constructor with specified initial values
		/// </summary>
		/// <param name="firstName">First Name</param>
		/// <param name="lastName">Last Name</param>
		/// <param name="address1">Address line 1</param>
		/// <param name="address2">Address line 2</param>
		/// <param name="city">City</param>
		/// <param name="state">State</param>
		/// <param name="zip">Postal Code</param>
		/// <param name="country">Country</param>
		/// <param name="phone">Phone number at this address</param>
		public AddressInfo(string firstName, string lastName, string address1, string address2, string city, string state, string zip, string country, string phone) {
			this._firstName = firstName;
			this._lastName = lastName;
			this._address1 = address1;
			this._address2 = address2;
			this._city = city;
			this._state = state;
			this._zip = zip;
			this._country = country;
			this._phone = phone;
		}

		// Properties
		public string FirstName {
			get { return _firstName; }
			set { _firstName = value; }
		}

		public string LastName {
			get { return _lastName; }
			set { _lastName = value; }
		}

		public string Address1 {
			get { return _address1; }
			set { _address1 = value; }
		}

		public string Address2 {
			get { return _address2; }
			set { _address2 = value; }
		}

		public string City {
			get { return _city; }
			set { _city = value; }
		}

		public string State {
			get { return _state; }
			set { _state = value; }
		}

		public string Zip {
			get { return _zip; }
			set { _zip = value; }
		}

		public string Country {
			get { return _country; }
			set { _country = value; }
		}

		public string Phone {
			get { return _phone; }
			set { _phone = value; }
		}
	}
}