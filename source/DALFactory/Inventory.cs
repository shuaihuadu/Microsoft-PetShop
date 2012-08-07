using System;
using System.Reflection;
using System.Configuration;

namespace PetShop.DALFactory {

	/// <summary>
	/// Factory implementaion for the Inventory DAL object
	/// </summary>
	public class Inventory {

		public static PetShop.IDAL.IInventory Create() {

			/// Look up the DAL implementation we should be using
			string path = System.Configuration.ConfigurationSettings.AppSettings["WebDAL"];
			string className = path + ".Inventory";

			// Using the evidence given in the config file load the appropriate assembly and class
			return (PetShop.IDAL.IInventory)Assembly.Load(path).CreateInstance(className);
		}
	}
}

