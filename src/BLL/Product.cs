using System.Collections;

//References to PetShop specific libraries
//PetShop busines entity library
using PetShop.Model;
//PetShop DAL interfaces
using PetShop.IDAL;

namespace PetShop.BLL {

	/// <summary>
	/// A business component to manage products
	/// </summary>
	public class Product {

		/// <summary>
		/// A method to search products by category name
		/// </summary>
		/// <param name="category">The category name to search by</param>
		/// <returns>An interface to an arraylist of the search results</returns>
		public IList GetProductsByCategory(string category) {

			// Return null if the string is empty
			if (category.Trim() == string.Empty) 
				return null;

			// Get an instance of the Product DAL using the DALFactory
			IProduct dal = PetShop.DALFactory.Product.Create();

			// Run a search against the data store
			return dal.GetProductsByCategory(category);
		}

		/// <summary>
		/// A method to search products by keywords
		/// </summary>
		/// <param name="text">A list keywords delimited by a space</param>
		/// <returns>An interface to an arraylist of the search results</returns>
		public IList GetProductsBySearch(string text) {

			// Return null if the string is empty
			if (text.Trim() == string.Empty) 
					return null;

			// Split the input text into individual words
			string[] keywords = text.Split();

			// Get an instance of the Product DAL using the DALFactory
			IProduct dal = PetShop.DALFactory.Product.Create();

			// Run a search against the data store
			return dal.GetProductsBySearch(keywords);
		}
	}
}