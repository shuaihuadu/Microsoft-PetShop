using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PetShop.Model;
using PetShop.IDAL;

namespace PetShop.SQLServerDAL {

	public class Product : IProduct{

		//Static constants
		private const string SQL_SELECT_PRODUCTS = "SELECT ProductId, Name, Descn FROM Product";
		private const string SQL_SELECT_PRODUCTS_BY_CATEGORY = "SELECT ProductId, Name FROM Product WHERE Category = @Category";
		private const string SQL_SELECT_PRODUCTS_BY_SEARCH1 = "SELECT ProductId, Name, Descn FROM Product WHERE ((";
		private const string SQL_SELECT_PRODUCTS_BY_SEARCH2 = "LOWER(Name) LIKE '%' + {0} + '%' OR LOWER(Category) LIKE '%' + {0} + '%'";
		private const string SQL_SELECT_PRODUCTS_BY_SEARCH3 = ") OR (";
		private const string SQL_SELECT_PRODUCTS_BY_SEARCH4 = "))";
		private const string PARM_CATEGORY = "@Category";
		private const string PARM_KEYWORD = "@Keyword";

		/// <summary>
		/// Query for products by category
		/// </summary>
		/// <param name="category">category name</param>
		/// <returns></returns>
		public IList GetProductsByCategory(string category) {

			IList productsByCategory = new ArrayList();

			SqlParameter parm = new SqlParameter(PARM_CATEGORY, SqlDbType.Char, 10);
			parm.Value = category;
			
			//Execute a query to read the products
			using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, SQL_SELECT_PRODUCTS_BY_CATEGORY, parm)) {
				while (rdr.Read()){
					ProductInfo product = new ProductInfo(rdr.GetString(0), rdr.GetString(1), null);
					productsByCategory.Add(product);
				}
			}

			return productsByCategory;
		}

		/// <summary>
		/// Query for products by keywords. 
		/// The results will include any product where the keyword appears in the category name or product name
		/// </summary>
		/// <param name="keywords">string array of keywords</param>
		/// <returns></returns>
		public IList GetProductsBySearch(string[] keywords) {
			
			IList productsBySearch = new ArrayList();

			int numKeywords = keywords.Length;

			//Create a new query string
			StringBuilder sql = new StringBuilder(SQL_SELECT_PRODUCTS_BY_SEARCH1);

			//Add each keyword to the query
			for (int i = 0; i < numKeywords; i++) {
				sql.Append(string.Format(SQL_SELECT_PRODUCTS_BY_SEARCH2, PARM_KEYWORD + i));
				sql.Append(i + 1 < numKeywords ? SQL_SELECT_PRODUCTS_BY_SEARCH3 : SQL_SELECT_PRODUCTS_BY_SEARCH4);
			}

			string sqlProductsBySearch = sql.ToString();
			SqlParameter[] parms = SQLHelper.GetCachedParameters(sqlProductsBySearch);
			
			// If the parameters are null build a new set
			if (parms == null) {
				parms = new SqlParameter[numKeywords];

				for (int i = 0; i < numKeywords; i++)
					parms[i] = new SqlParameter(PARM_KEYWORD + i, SqlDbType.VarChar, 80);

				SQLHelper.CacheParameters(sqlProductsBySearch, parms);
			}

			// Bind the new parameters
			for (int i = 0; i < numKeywords; i++)
				parms[i].Value = keywords[i];
			
			//Finally execute the query
			using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionString, CommandType.Text, sqlProductsBySearch, parms)) {
				while (rdr.Read()){
					ProductInfo product = new ProductInfo(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2));
					productsBySearch.Add(product);
				}
			}

			return productsBySearch;
		}
	}
}
