using PetShop.Model;
using PetShop.BLL;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShop.Web.Controls {
	public abstract class AddressUI : System.Web.UI.UserControl {
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtAddress1;
		protected System.Web.UI.WebControls.TextBox txtAddress2;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.DropDownList listState;
		protected System.Web.UI.WebControls.RequiredFieldValidator valFirstName;
		protected System.Web.UI.WebControls.RequiredFieldValidator valLastName;
		protected System.Web.UI.WebControls.RequiredFieldValidator valAddress1;
		protected System.Web.UI.WebControls.RequiredFieldValidator valCity;
		protected System.Web.UI.WebControls.RequiredFieldValidator valZip;
		protected System.Web.UI.WebControls.RequiredFieldValidator valPhone;
		protected System.Web.UI.WebControls.DropDownList listCountry;

		private void InitializeComponent() {
		
		}

		// Page property to set or get the address
		public AddressInfo Address {
			get {
				// Make sure we clean the input
				string firstName = WebComponents.CleanString.InputText(txtFirstName.Text, 50);
				string lastName = WebComponents.CleanString.InputText(txtLastName.Text, 50);
				string address1 = WebComponents.CleanString.InputText(txtAddress1.Text, 50);
				string address2 = WebComponents.CleanString.InputText(txtAddress2.Text, 50);
				string city = WebComponents.CleanString.InputText(txtCity.Text, 50);
				string state = WebComponents.CleanString.InputText(listState.SelectedItem.Text, 2);
				string zip = WebComponents.CleanString.InputText(txtZip.Text, 10);
				string country = WebComponents.CleanString.InputText(listCountry.SelectedItem.Text, 50);
				string phone = WebComponents.CleanString.InputText(txtPhone.Text, 10);

				return new AddressInfo(firstName, lastName, address1, address2, city, state, zip, country, phone);
			}
			set {
				txtFirstName.Text = value.FirstName;
				txtLastName.Text = value.LastName;
				txtAddress1.Text = value.Address1;
				txtAddress2.Text = value.Address2;
				txtCity.Text = value.City;
				txtZip.Text = value.Zip;
				txtPhone.Text = value.Phone;
				listState.SelectedItem.Value = value.State;
				listCountry.SelectedItem.Value = value.Country;			
			}
		}
	}
}