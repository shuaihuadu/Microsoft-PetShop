using System;
using System.Data;
using System.Data.SqlClient;
using PetShop.Model;
using PetShop.IDAL;

namespace PetShop.SQLServerDAL {
	/// <summary>
	/// Summary description for InventoryDALC.
	/// </summary>
	public class Inventory : IInventory{

		// Static constants
		private const string SQL_SELECT_INVENTORY = "SELECT Qty FROM Inventory WHERE ItemId = @ItemId";
		private const string SQL_TAKE_INVENTORY = "UPDATE Inventory SET Qty = Qty - ";

		/// <summary>
		/// Function to get the current quantity in stock
		/// </summary>
		/// <param name="ItemId">Unique identifier for an item</param>
		/// <returns>Current Qty in Stock</returns>
		public int CurrentQtyInStock(string ItemId){

			int Qty = 0;
			SqlParameter parm = new SqlParameter("@ItemId", SqlDbType.Char, 10);
			parm.Value = ItemId;

			Qty = Convert.ToInt32(SQLHelper.ExecuteScalar(SQLHelper.ConnectionString, CommandType.Text, SQL_SELECT_INVENTORY, parm));
			
			return Qty;
		}

		/// <summary>
		/// Function to update inventory based on purchased items
		/// Internally the function uses a batch query so the command is only sent to the database once
		/// </summary>
		/// <param name="items">Array of items purchased</param>
		public void TakeStock(LineItemInfo[] items){

			SqlParameter[] inventoryParms;			
			SqlCommand cmd = new SqlCommand();
			
			//Open a connection
			using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString)) {
				
				String strSQL = null;
				int i = 0;
				
				//Append a statement to the batch for each item in the array
				foreach (LineItemInfo item in items) {

					strSQL = strSQL + SQL_TAKE_INVENTORY;
					
					inventoryParms = GetInventoryParameters(i);
 					
					strSQL = strSQL + "@Quantity" +i + " WHERE ItemId = @ItemId" + i+ ";";
					
					//Bind parameters
					inventoryParms[0].Value = item.Quantity;
					inventoryParms[1].Value = item.ItemId;
					
					foreach (SqlParameter parm in inventoryParms)
						cmd.Parameters.Add(parm);
					i++;				
				}

				// Open the connection
				conn.Open();
				
				//Set up the command
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = strSQL;

				//Execute the query
				cmd.ExecuteNonQuery();
				cmd.Parameters.Clear();
				
			}
		}

		/// <summary>
		/// Internal function to get cached parameters
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		private static SqlParameter[] GetInventoryParameters(int i) {
			SqlParameter[] parms = SQLHelper.GetCachedParameters(SQL_TAKE_INVENTORY+i);
			
			if (parms == null) {
				parms = new SqlParameter[] {
					new SqlParameter("@Quantity" + i, SqlDbType.Int),
					new SqlParameter("@ItemId"+i, SqlDbType.Char, 10)};

				SQLHelper.CacheParameters(SQL_TAKE_INVENTORY+i, parms);
			}

			return parms;
		}
	}
}
