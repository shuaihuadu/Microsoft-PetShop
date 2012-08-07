using System;
using System.Data;
using System.Data.SqlClient;
using PetShop.IDAL;

namespace PetShop.SQLServerDAL {

	public class Profile : IProfile{

	private const string SQL_SELECT_BANNERDATA = "Select BannerData from BannerData where FavCategory = @FavCategory";

		/// <summary>
		/// Get the banner information for a given category
		/// </summary>
		/// <param name="FavCategory">A user's favourite category</param>
		/// <returns>Get the banner image path</returns>
		public string GetBannerPath(string FavCategory) {

			string BannerPath = "";

			SqlParameter parm = new SqlParameter("@FavCategory", SqlDbType.Char, 10);
			parm.Value = FavCategory;

			BannerPath = Convert.ToString(SQLHelper.ExecuteScalar(SQLHelper.ConnectionString, CommandType.Text, SQL_SELECT_BANNERDATA, parm));			

			return BannerPath;
		}
	}
}
