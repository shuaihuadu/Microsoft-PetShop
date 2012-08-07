using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Data.SqlClient;
using PetShop.Model;
using PetShop.IDAL;

namespace PetShop.SQLServerDAL {

	public class Order : IOrder{

		//Static constants
		private const string SQL_INSERT_ORDER = "Declare @ID int; Declare @ERR int; INSERT INTO Orders VALUES(@UserId, @Date, @ShipAddress1, @ShipAddress2, @ShipCity, @ShipState, @ShipZip, @ShipCountry, @BillAddress1, @BillAddress2, @BillCity, @BillState, @BillZip, @BillCountry, 'UPS', @Total, @BillFirstName, @BillLastName, @ShipFirstName, @ShipLastName, @CardNumber, @CardExpiration, @CardType, 'US_en'); SELECT @ID=@@IDENTITY; INSERT INTO OrderStatus VALUES(@ID, @ID, GetDate(), 'P'); SELECT @ERR=@@ERROR;";
		private const string SQL_INSERT_ITEM = "INSERT INTO LineItem VALUES( ";
		private const string SQL_SELECT_ORDER = "SELECT o.OrderDate, o.UserId, o.CardType, o.CreditCard, o.ExprDate, o.BillToFirstName, o.BillToLastName, o.BillAddr1, o.BillAddr2, o.BillCity, o.BillState, BillZip, o.BillCountry, o.ShipToFirstName, o.ShipToLastName, o.ShipAddr1, o.ShipAddr2, o.ShipCity, o.ShipState, o.ShipZip, o.ShipCountry, o.TotalPrice, l.ItemId, l.LineNum, l.Quantity, l.UnitPrice FROM Orders as o, lineitem as l WHERE o.OrderId = @OrderId AND o.orderid = l.orderid";
		private const string PARM_USER_ID = "@UserId";
		private const string PARM_DATE = "@Date";
		private const string PARM_SHIP_ADDRESS1 = "@ShipAddress1";
		private const string PARM_SHIP_ADDRESS2 = "@ShipAddress2";
		private const string PARM_SHIP_CITY = "@ShipCity";
		private const string PARM_SHIP_STATE = "@ShipState";
		private const string PARM_SHIP_ZIP = "@ShipZip";
		private const string PARM_SHIP_COUNTRY = "@ShipCountry";
		private const string PARM_BILL_ADDRESS1 = "@BillAddress1";
		private const string PARM_BILL_ADDRESS2 = "@BillAddress2";
		private const string PARM_BILL_CITY = "@BillCity";
		private const string PARM_BILL_STATE = "@BillState";
		private const string PARM_BILL_ZIP = "@BillZip";
		private const string PARM_BILL_COUNTRY = "@BillCountry";
		private const string PARM_TOTAL = "@Total";
		private const string PARM_BILL_FIRST_NAME = "@BillFirstName";
		private const string PARM_BILL_LAST_NAME = "@BillLastName";
		private const string PARM_SHIP_FIRST_NAME = "@ShipFirstName";
		private const string PARM_SHIP_LAST_NAME = "@ShipLastName";
		private const string PARM_CARD_NUMBER = "@CardNumber";
		private const string PARM_CARD_EXPIRATION = "@CardExpiration";
		private const string PARM_CARD_TYPE = "@CardType";
		private const string PARM_ORDER_ID = "@OrderId";
		private const string PARM_LINE_NUMBER = "@LineNumber";
		private const string PARM_ITEM_ID = "@ItemId";
		private const string PARM_QUANTITY = "@Quantity";
		private const string PARM_PRICE = "@Price";

		public int Insert(OrderInfo order) {

			int orderId = 0;
			String strSQL = null;
			try{
			
				// Get each commands parameter arrays
				SqlParameter[] orderParms = GetOrderParameters();
				SqlParameter statusParm = new SqlParameter(PARM_ORDER_ID, SqlDbType.Int);
				SqlCommand cmd = new SqlCommand();

				// Set up the parameters
				orderParms[0].Value = order.UserId;
				orderParms[1].Value = order.Date;
				orderParms[2].Value = order.ShippingAddress.Address1;
				orderParms[3].Value = order.ShippingAddress.Address2;
				orderParms[4].Value = order.ShippingAddress.City;
				orderParms[5].Value = order.ShippingAddress.State;
				orderParms[6].Value = order.ShippingAddress.Zip;
				orderParms[7].Value = order.ShippingAddress.Country;
				orderParms[8].Value = order.BillingAddress.Address1;
				orderParms[9].Value = order.BillingAddress.Address2;
				orderParms[10].Value = order.BillingAddress.City;
				orderParms[11].Value = order.BillingAddress.State;
				orderParms[12].Value = order.BillingAddress.Zip;
				orderParms[13].Value = order.BillingAddress.Country;
			
				orderParms[14].Value = order.OrderTotal;
				orderParms[15].Value = order.BillingAddress.FirstName;
				orderParms[16].Value = order.BillingAddress.LastName;
				orderParms[17].Value = order.ShippingAddress.FirstName;
				orderParms[18].Value = order.ShippingAddress.LastName;
				orderParms[19].Value = order.CreditCard.CardNumber;
				orderParms[20].Value = order.CreditCard.CardExpiration;
				orderParms[21].Value = order.CreditCard.CardType;
				foreach (SqlParameter parm in orderParms)
							cmd.Parameters.Add(parm);
				
				// Create the connection to the database
				using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString)) {
				
					// Open the database connection
					
					// Insert the order status
					strSQL = SQL_INSERT_ORDER;
					SqlParameter[] itemParms ;
					// For each line item, insert an orderline record
					int i = 0;
					foreach (LineItemInfo item in order.LineItems) {
						strSQL = strSQL + SQL_INSERT_ITEM + " @ID" + ", @LineNumber"+i + ", @ItemId" + i+ ", @Quantity" + i + ", @Price" + i + "); SELECT @ERR=@ERR+@@ERROR;";
						
						//Get the cached parameters
						itemParms = GetItemParameters(i);
						
						itemParms[0].Value = item.Line;
						itemParms[1].Value = item.ItemId;
						itemParms[2].Value = item.Quantity;
						itemParms[3].Value = item.Price;
						//Bind each parameter
						foreach (SqlParameter parm in itemParms)
							cmd.Parameters.Add(parm);
						i++;
						
					}
					
					conn.Open();
					cmd.Connection = conn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = strSQL + "SELECT @ID, @ERR";
					
					// Read the output of the query, should return orderid and error count
					using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)){
						
						//Read the result
						rdr.Read();
						// If the error count is not zero throw an exception
						if (rdr.GetInt32(1) != 0)
							throw new Exception("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
						
						//Fetch the orderId
						orderId = rdr.GetInt32(0);
					}
					//Clear the parameters
					cmd.Parameters.Clear();
				}

			}catch(Exception e){
				throw e;
			}finally{				
			}	
			return orderId;
		}

		/// <summary>
		/// Read an order from the database
		/// </summary>
		/// <param name="orderId"></param>
		/// <returns></returns>
		public OrderInfo GetOrder(int orderId) {
			
			//Create a parameter
			SqlParameter parm = new SqlParameter(PARM_ORDER_ID, SqlDbType.Int);
			parm.Value = orderId;

			//Execute a query to read the order
			using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQL_SELECT_ORDER, parm)) {
				
				if (rdr.Read()) {

					//Generate an order header from the first row
					CreditCardInfo creditCard = new CreditCardInfo(rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
					AddressInfo billingAddress = new AddressInfo(rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), null);
					AddressInfo shippingAddress = new AddressInfo(rdr.GetString(13), rdr.GetString(14), rdr.GetString(15), rdr.GetString(16), rdr.GetString(17), rdr.GetString(18), rdr.GetString(19), rdr.GetString(20), null);

					OrderInfo order = new OrderInfo(orderId, rdr.GetDateTime(0), rdr.GetString(1), creditCard, billingAddress, shippingAddress, rdr.GetDecimal(21));								

					ArrayList lineItems = new ArrayList();
					LineItemInfo item = null; 
				
					//Create the lineitems from the first row and subsequent rows
					do{												
						item = new LineItemInfo(rdr.GetString(22), string.Empty, rdr.GetInt32(23), rdr.GetInt32(24), rdr.GetDecimal(25));
						lineItems.Add(item);
					}while(rdr.Read());

					order.LineItems = (LineItemInfo[])lineItems.ToArray(typeof(LineItemInfo));

					return order;					
				}
			}

			return null;
		}
		
		/// <summary>
		/// Internal function to get cached parameters
		/// </summary>
		/// <returns></returns>
		private static SqlParameter[] GetOrderParameters() {
			SqlParameter[] parms = SQLHelper.GetCachedParameters(SQL_INSERT_ORDER);
			
			if (parms == null) {
				parms = new SqlParameter[] {
					new SqlParameter(PARM_USER_ID, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_DATE, SqlDbType.DateTime, 12),
					new SqlParameter(PARM_SHIP_ADDRESS1, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_SHIP_ADDRESS2, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_SHIP_CITY, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_SHIP_STATE, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_SHIP_ZIP, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_SHIP_COUNTRY, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_BILL_ADDRESS1, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_BILL_ADDRESS2, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_BILL_CITY, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_BILL_STATE, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_BILL_ZIP, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_BILL_COUNTRY, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_TOTAL, SqlDbType.Decimal, 8),
					new SqlParameter(PARM_BILL_FIRST_NAME, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_BILL_LAST_NAME, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_SHIP_FIRST_NAME, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_SHIP_LAST_NAME, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_CARD_NUMBER, SqlDbType.VarChar, 80),
					new SqlParameter(PARM_CARD_EXPIRATION, SqlDbType.Char, 10),
					new SqlParameter(PARM_CARD_TYPE, SqlDbType.VarChar, 80)};

				SQLHelper.CacheParameters(SQL_INSERT_ORDER, parms);
			}

			return parms;
		}

		private static SqlParameter[] GetItemParameters(int i) {
			SqlParameter[] parms = SQLHelper.GetCachedParameters(SQL_INSERT_ITEM + i);
		
			if (parms == null) {
				parms = new SqlParameter[] {
					//new SqlParameter(PARM_ORDER_ID + i, SqlDbType.Int, 4),
					new SqlParameter(PARM_LINE_NUMBER + i, SqlDbType.Int, 4),
					new SqlParameter(PARM_ITEM_ID+i, SqlDbType.Char, 10),
					new SqlParameter(PARM_QUANTITY+i, SqlDbType.Int, 4),
					new SqlParameter(PARM_PRICE+i, SqlDbType.Decimal, 8)};

				SQLHelper.CacheParameters(SQL_INSERT_ITEM+i, parms);
			}

			return parms;
		}
	}
}
