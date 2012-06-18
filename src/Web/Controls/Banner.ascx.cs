namespace PetShop.Web.Controls{

	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.Caching;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using PetShop.Model;
	using PetShop.BLL;

	/// <summary>
	///		Summary description for Banner.
	/// </summary>
	public abstract class Banner : System.Web.UI.UserControl{

		protected System.Web.UI.HtmlControls.HtmlGenericControl areaBanner;
		protected System.Web.UI.HtmlControls.HtmlGenericControl areaImage;

		private void Page_Load(object sender, System.EventArgs e) {
			ShowBanner();
		}

		/// <summary>
		/// Hide or show the banner depending on user preference.
		/// </summary>
		private void ShowBanner() {

			if (Request.IsAuthenticated == true){

				ProcessFlow.AccountController accountController = new ProcessFlow.AccountController();

				// Retrieve the account information from the account controller
				AccountInfo myAccount = accountController.GetAccountInfo(false);

				if (myAccount != null) {
					areaBanner.Visible = myAccount.IsShowBanners;
				
					string categoryKey = myAccount.Category;
					string bannerKey = "Banner" + categoryKey;
					string bannerPath = "";

					if(Cache[bannerKey] != null){
						// If the data is already cached, then used the cached copy
						bannerPath = ( (string)Cache[bannerKey] );
					}else{
						// If the data is not cached, then create a new profile object object and request the data
						Profile profile = new Profile();

						bannerPath = profile.GetBannerPath(categoryKey);

						// Store the results of the call in the Cache and set the time out to 6 hours
						Cache.Add(bannerKey, bannerPath, null, DateTime.Now.AddHours(6), Cache.NoSlidingExpiration , CacheItemPriority.High, null);
					}

					areaImage.InnerHtml = bannerPath;
				}
			}
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
