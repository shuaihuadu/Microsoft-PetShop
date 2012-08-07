using System;

namespace PetShop.IDAL{
	
	/// <summary>
	/// Interface to the Profile DAL
	/// </summary>
	public interface IProfile{

		/// <summary>
		/// Return the location of the banner image given a favourite category
		/// </summary>
		/// <param name="FavCategory">The user's favourite category</param>
		/// <returns>The location of the banner image</returns>
		string GetBannerPath(string FavCategory);
	}
}
