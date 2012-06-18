using System;
using System.Collections;

//References to PetShop specific libraries
//PetShop busines entity library
using PetShop.Model;

namespace PetShop.BLL {
	
	/// <summary>
	/// An object to represent a customer's shopping cart
	/// </summary>
	[Serializable]
	public class Cart : IEnumerable {

		/// <summary>
		/// Internal storage for a cart
		/// </summary>
		private ArrayList _items = new ArrayList();

		private decimal _total=0;

		/// <summary>
		/// Returns an enumerator for the cart items in a cart
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator() {
			return _items.GetEnumerator();
		}

		// Properties
		public decimal Total {
			get { return _total; }
			set { _total = value; }
		}

		/// <summary>
		/// Returns number of items in cart
		/// </summary>
		public int Count {
			get { return _items.Count; }
		}

		/// <summary>
		/// Return CartItem representation of object at a given address
		/// </summary>
		public CartItemInfo this[int index] {
			get { return (CartItemInfo)_items[index]; }
		}

		/// <summary>
		/// Add an item to the cart
		/// </summary>
		/// <param name="ItemId">ItemId of item to add</param>
		public void Add(string ItemId) {
			foreach (CartItemInfo cartItem in _items) {
				if (ItemId == cartItem.ItemId) {
					cartItem.Quantity++;
					cartItem.InStock = (GetInStock(ItemId) - cartItem.Quantity) >= 0 ? true : false;
					_total = _total+(cartItem.Price*cartItem.Quantity);
					return;
				}
			}

			Item item = new Item();

			ItemInfo data = item.GetItem(ItemId);
			CartItemInfo newItem = new CartItemInfo(ItemId,data.Name, (data.Quantity >= 1), 1, (decimal)data.Price); 
			_items.Add(newItem);
			_total = _total+(data.Price);
		}

		/// <summary>
		/// Remove item from the cart based on itemId
		/// </summary>
		/// <param name="itemId">ItemId of item to remove</param>
		public void Remove(string itemId) {
			foreach (CartItemInfo item in _items) {
				if (itemId == item.ItemId) {
					_items.Remove(item);
					_total = _total-(item.Price*item.Quantity);
					return;
				}
			}
		}

		/// <summary>
		/// Removes item from cart at specific index
		/// </summary>
		/// <param name="index">Element number of item to remove</param>
		public void RemoveAt(int index) {
			CartItemInfo item = (CartItemInfo)_items[index];
			_total = _total-(item.Price*item.Quantity);
			_items.RemoveAt(index);
			
		}

		/// <summary>
		/// Returs internal array list of cart items
		/// </summary>
		/// <returns></returns>
		public ArrayList GetCartItems() {
			return _items;
		}

		/// <summary>
		/// Method to convert internal array of cart items to order line items
		/// </summary>
		/// <returns>New array list of order line items</returns>
		public ArrayList GetOrderLineItems() {

			ArrayList orderLineItems = new ArrayList();

			int lineNum = 1;

			foreach (CartItemInfo item in _items) {

				LineItemInfo lineItem = new LineItemInfo(item.ItemId, item.Name, lineNum, item.Quantity, item.Price);
				orderLineItems.Add(lineItem);
				lineNum++;
			}

			return orderLineItems;
		}

		
		/// <summary>
		/// Internal method to get the stock level of an item
		/// </summary>
		/// <param name="ItemId">Unique identifier of item to get stock level of</param>
		/// <returns></returns>
		private int GetInStock(string ItemId){
			Inventory inventory = new Inventory();

			return inventory.CurrentQuantityInStock(ItemId);
		}
	}
}