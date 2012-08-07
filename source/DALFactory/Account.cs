using System;
using System.Reflection;
using System.Configuration;

namespace PetShop.DALFactory {
	
	/// <summary>
	/// Factory implementaion for the Account DAL object
	/// </summary>
	public class Account
	{
		public static PetShop.IDAL.IAccount Create()
		{			
			/// Look up the DAL implementation we should be using
			string path = System.Configuration.ConfigurationSettings.AppSettings["WebDAL"];
			string className = path + ".Account";

			// Using the evidence given in the config file load the appropriate assembly and class
			return (PetShop.IDAL.IAccount) Assembly.Load(path).CreateInstance(className);
		}
	}
}
