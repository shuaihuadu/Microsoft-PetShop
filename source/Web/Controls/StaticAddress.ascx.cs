namespace PetShop.Web.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using PetShop.Model;

	/// <summary>
	///		Summary description for StaticAddress.
	/// </summary>
	public abstract class StaticAddress : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblFirstName;
		protected System.Web.UI.WebControls.Label lblLastName;
		protected System.Web.UI.WebControls.Label lblAdr1;
		protected System.Web.UI.WebControls.Label lblAdr2;
		protected System.Web.UI.WebControls.Label lblCity;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.Label lblPostalCode;

		public AddressInfo address = null;

		private void Page_Load(object sender, System.EventArgs e){

			// Put user code to initialize the page here
			if (!IsPostBack) {

				ShowAddress(this.address);
			}
		}

		public void ShowAddress(AddressInfo address) {
			
			if (address!= null){
			
				// update fields with info
				lblFirstName.Text = address.FirstName;
				lblLastName.Text = address.LastName;
				lblAdr1.Text = address.Address1;
				lblAdr2.Text = address.Address2;
				lblCity.Text = address.City;
				lblState.Text = address.State;
				lblPostalCode.Text = address.Zip;
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
