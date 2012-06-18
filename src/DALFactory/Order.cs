using System;
using System.EnterpriseServices;
using System.Reflection;
using System.Configuration;

namespace PetShop.DALFactory {
	
	/// <summary>
	/// Factory implementaion for the Order DAL object
	/// </summary>
	public class Order {

		//public static PetShop.IDAL.IOrder GetOrder() {
		public static PetShop.IDAL.IOrder Create() {

			/// Look up the DAL implementation we should be using
			string path = System.Configuration.ConfigurationSettings.AppSettings["OrdersDAL"];
			string className = path + ".Order";

			// Using the evidence given in the config file load the appropriate assembly and class
			return (PetShop.IDAL.IOrder)Assembly.Load(path).CreateInstance(className);	
		}
	}
}
