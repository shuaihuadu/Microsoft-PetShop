namespace PetShop.Web.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for Cart.
	/// </summary>
	public abstract class usercart : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.ImageButton btnRemove;
		protected System.Web.UI.WebControls.HyperLink DetailLink;
		protected System.Web.UI.WebControls.TextBox txtQty;
		protected System.Web.UI.WebControls.ImageButton btnUpdate;

		public bool AllowEdit = true;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ShowCart();
		}

		// Display the cart		
		public void ShowCart() {
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
			this.ID = "usercart";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
