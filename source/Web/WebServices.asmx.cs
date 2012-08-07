using PetShop.Model;
using PetShop.BLL;
using System.Web.Services;

namespace PetShop.Web {

	[WebService(Description="Retrieves order information for a given order ID.")]
	public class WebServices : WebService {
	
	[WebMethod]
	public OrderInfo GetOrder(int orderId) {

		// Use the order component optimized for reads
		OrderRead orderWS = new OrderRead();

		return orderWS.GetOrder(orderId);
		}
	}
}
