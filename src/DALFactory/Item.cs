using System;
using System.Reflection;
using System.Configuration;

namespace PetShop.DALFactory {

	/// <summary>
	/// Factory implementaion for the Item DAL object
	/// </summary>
	public class Item {

		public static PetShop.IDAL.IItem Create() {

			/// Look up the DAL implementation we should be using
			string path = System.Configuration.ConfigurationSettings.AppSettings["WebDAL"];
			string className = path + ".Item";

			// Using the evidence given in the config file load the appropriate assembly and class
			return (PetShop.IDAL.IItem)Assembly.Load(path).CreateInstance(className);
		}
	}
}
