using System;

//References to PetShop specific libraries
//PetShop DAL interfaces
using PetShop.IDAL;

namespace PetShop.BLL{
	
	/// <summary>
	/// A business compoment to manage user profiles
	/// </summary>
	public class Profile{

		/// <summary>
		/// A method to get the banner location from the 
		/// data store give a favourite category
		/// </summary>
		/// <param name="favCategory">A user's favourite category</param>
		/// <returns>The location of the Banner Image</returns>
		public string GetBannerPath(string favCategory) {

			// Validate input
			if (favCategory.Trim() == string.Empty)
				return null;

			// Get an instance of the Profile DAL using the DALFactory
			IProfile dal = PetShop.DALFactory.Profile.Create();

			// Return the data from the DAL
			return dal.GetBannerPath(favCategory);
		}
	}
}
