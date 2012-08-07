using System;
using System.Reflection;
using System.Configuration;

namespace PetShop.DALFactory {
	
	/// <summary>
	/// Factory implementaion for the Profile DAL object
	/// </summary>
	public class Profile {

		public static PetShop.IDAL.IProfile Create() {
			
			/// Look up the DAL implementation we should be using
			string path = System.Configuration.ConfigurationSettings.AppSettings["WebDAL"];
			string className = path + ".Profile";

			// Using the evidence given in the config file load the appropriate assembly and class
			return (PetShop.IDAL.IProfile)Assembly.Load(path).CreateInstance(className);
		
		}
	}
}
