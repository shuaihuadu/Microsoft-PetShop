using System;
using System.Web;
using System.Diagnostics;
using System.Configuration;

namespace PetShop.Web
{
	public class Global : HttpApplication
	{

		/// <summary>
		/// Custom caching using the VaryByCustom attribute in the 
		/// OuputCache directive.
		/// </summary>
		/// <param name="context">The current HTTP request</param>
		/// <param name="arg">Custom cache argument</param>
		/// <returns>Cache key</returns>
		public override string GetVaryByCustomString(HttpContext context, String arg) {

			// cache key that is returned
			string cacheKey = "";
			
			switch(arg) {

				// Custom caching for header control. We want to create two views
				// of the header... one if the user is logged in and another if
				// they are logged out.
				// We us the forms authentication flag to check if the user is logged in or not

				// Category page
				case "CategoryPageKey":

					if (Request.IsAuthenticated == true) {
						cacheKey = "QQQ" + WebComponents.CleanString.InputText(context.Request.QueryString["categoryId"], 50) + WebComponents.CleanString.InputText(context.Request.QueryString["page"], 15);
					}
					else {
						cacheKey = "AAA" + WebComponents.CleanString.InputText(context.Request.QueryString["categoryId"], 50) + WebComponents.CleanString.InputText(context.Request.QueryString["page"], 15);
					}

					break;

				// Search page
				case "SearchPageKey" : 

					if (Request.IsAuthenticated == true) {
						cacheKey = "QQQ" + WebComponents.CleanString.InputText(context.Request.QueryString["keywords"], 50) + WebComponents.CleanString.InputText(context.Request["page"], 15);
					}
					else {
						cacheKey = "AAA" + WebComponents.CleanString.InputText(context.Request.QueryString["keywords"], 50) + WebComponents.CleanString.InputText(context.Request["page"], 15);
					}

					break;

				// Item page
				case "ItemPageKey" :

					if (Request.IsAuthenticated == true) {
						cacheKey = "QQQ" + WebComponents.CleanString.InputText(context.Request.QueryString["productId"], 50) + WebComponents.CleanString.InputText(context.Request.QueryString["page"], 15);
					}
					else {
						cacheKey = "AAA" + WebComponents.CleanString.InputText(context.Request.QueryString["productId"], 50) + WebComponents.CleanString.InputText(context.Request.QueryString["page"], 15);
					}

					break;

				// Item details page
				case "ItemDetailsPageKey" :

					if (Request.IsAuthenticated == true) {
						cacheKey = "QQQ" + WebComponents.CleanString.InputText(context.Request.QueryString["itemId"], 50);
					}
					else {
						cacheKey = "AAA" + WebComponents.CleanString.InputText(context.Request.QueryString["itemId"], 50);
					}

					break;


				// Used for pages such as help and default
				case "UserId" : 

					if (Request.IsAuthenticated == true) {
						cacheKey = "UserIdIn";
					}
					else {
						cacheKey = "UserIdOut";
					}

					break;
			}

			return cacheKey;
		}
	}
}