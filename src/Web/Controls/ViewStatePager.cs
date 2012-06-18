using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShop.Web.Controls {

	/// <summary>
	/// A class derived from Simplepager which uses viewstate to maintain the current page counts
	/// The advantage of this is that you can have several ViewStatePagers on a single page ans each will
	/// maintain it's own page numbers, avoiding conflicts with controls reading each other's page number
	/// </summary>
	public class ViewStatePager : SimplePager {

		private const string KEY_ITEM_COUNT = "ItemCount";
		private const string KEY_CURRENT_PAGE_INDEX = "CurrentPageIndex";
		private const string IMG_PREV = "Images/buttonPrev.gif";
		private const string IMG_MORE = "Images/buttonMore.gif";
		private const string ALT_PREV = "Previous";
		private const string ALT_MORE = "More";
		
		private ImageButton btnPrev;
		private ImageButton btnMore;

		override protected int ItemCount {
			get { return (int)ViewState[KEY_ITEM_COUNT]; }
			set { ViewState[KEY_ITEM_COUNT] = value; }
		}

		override public int CurrentPageIndex {
			get { return (int)ViewState[KEY_CURRENT_PAGE_INDEX]; }
			set { ViewState[KEY_CURRENT_PAGE_INDEX] = value; }
		}

		override protected void OnLoad(EventArgs e) {
			if (!Page.IsPostBack && Visible) {
				CurrentPageIndex = 0;
				SetPage(0);
			}
		}

		private void PreviousClicked(object sender, ImageClickEventArgs e) {
			OnPageIndexChanged(new DataGridPageChangedEventArgs(sender, CurrentPageIndex - 1));
		}

		private void MoreClicked(object sender, ImageClickEventArgs e) {
			OnPageIndexChanged(new DataGridPageChangedEventArgs(sender, CurrentPageIndex + 1));
		}

		override protected void CreateControlHierarchy(bool useDataSource) {
			base.CreateControlHierarchy(useDataSource);

			btnPrev = new ImageButton();
			btnPrev.ImageUrl = IMG_PREV;
			btnPrev.AlternateText = ALT_PREV;
			btnPrev.Click += new ImageClickEventHandler(PreviousClicked);
			Controls.Add(btnPrev);
			
			btnMore = new ImageButton();
			btnMore.ImageUrl = IMG_MORE;
			btnMore.AlternateText = ALT_MORE;
			btnMore.Click += new ImageClickEventHandler(MoreClicked);
			Controls.Add(btnMore);
		}

		override protected void OnPreRender(EventArgs e) {
			btnPrev.Visible = CurrentPageIndex > 0;
			btnMore.Visible = CurrentPageIndex < PageCount;
		}

		override protected void Render(HtmlTextWriter writer) {
			if (ItemCount == 0) {
				writer.Write(emptyText);
				return;
			}

			writer.Write(HTML1);

			for (int i = 0, j = Controls.Count - 2; i < j; i++)
				Controls[i].RenderControl(writer);
			
			writer.Write(HTML2);
			btnPrev.RenderControl(writer);
			writer.Write(HTML3);
			btnMore.RenderControl(writer);
			writer.Write(HTML4);
		}
	}
}