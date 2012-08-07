using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using PetShop.Model;
using PetShop.IDAL;

namespace PetShop.SQLServerDAL {

	public class Item : IItem{

		// Static constants
		private const string SQL_SELECT_ITEM = "SELECT Item.ItemId, Item.Attr1, Inventory.Qty, Item.ListPrice, Product.Name, Product.Descn FROM Item INNER JOIN Inventory ON Item.ItemId = Inventory.ItemId INNER JOIN Product ON Item.ProductId = Product.ProductId WHERE Item.ItemId = @ItemId";
		private const string SQL_SELECT_ITEMS_BY_PRODUCT = "SELECT ItemId, Attr1, ListPrice, Name FROM Item INNER JOIN Product ON Item.ProductId = Product.ProductId WHERE Item.ProductId = @ProductId";
		
		private const string PARM_ITEM_ID = "@ItemId";
		private const string PARM_PRODUCT_ID = "@ProductId";

		/// <summary>
		/// Function to get a list of items within a product group
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		public IList GetItemsByProduct(string productId) {

			IList itemsByProduct = new ArrayList();

			SqlParameter parm = new SqlParameter(PARM_PRODUCT_ID, SqlDbType.Char, 10);
			parm.Value = productId;
			
			//Execute the query against the database
			using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQL_SELECT_ITEMS_BY_PRODUCT, parm)) {
				// Scroll through the results
				while (rdr.Read()){
					ItemInfo item = new ItemInfo(rdr.GetString(0).Trim(), rdr.GetString(1), rdr.GetDecimal(2), rdr.GetString(3), null);
					//Add each item to the arraylist
					itemsByProduct.Add(item);
				}
			}

			return itemsByProduct;
		}


		/// <summary>
		/// Get an individual item based on a the unique key
		/// </summary>
		/// <param name="itemId">unique key</param>
		/// <returns></returns>
		public ItemInfo GetItem(string itemId) {
			
			//Set up a return value
			ItemInfo item = null;

			//Create a parameter
			SqlParameter parm = new SqlParameter(PARM_ITEM_ID, SqlDbType.Char, 10);
			//Bind the parameter
			parm.Value = itemId;

			//Execute the query
			using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQL_SELECT_ITEM, parm)) {
				rdr.Read();
				item = new ItemInfo(rdr.GetString(0).Trim(), rdr.GetString(1), rdr.GetInt32(2), rdr.GetDecimal(3), rdr.GetString(4), rdr.GetString(5));
				 
			}
			return item;
		}
	}
}
