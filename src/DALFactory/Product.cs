using System;
using System.Reflection;
using System.Configuration;
using System.Security.Policy;

namespace PetShop.DALFactory {

	/// <summary>
	/// Factory implementaion for the Product DAL object
	/// </summary>
	public class Product {

		public static PetShop.IDAL.IProduct Create() {
			
			/// Look up the DAL implementation we should be using
			string path = System.Configuration.ConfigurationSettings.AppSettings["WebDAL"];
			string className = path + ".Product";

			// Using the evidence given in the config file load the appropriate assembly and class
			return (PetShop.IDAL.IProduct)Assembly.Load(path).CreateInstance(className);
		}
	}
}
