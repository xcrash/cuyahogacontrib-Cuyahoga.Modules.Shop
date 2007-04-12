using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Cuyahoga.Core.Util;
using Cuyahoga.Web.UI;
using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Modules.Shop.Utils;

namespace Cuyahoga.Modules.Shop
{
	/// <summary>
	/// Summary description for Edit Shops.
	/// </summary>
	public class AdminShop : ModuleAdminBasePage
	{
		protected System.Web.UI.WebControls.Repeater rptShopCategories;
		protected Cuyahoga.ServerControls.Pager pgrShopCategories;
		protected System.Web.UI.WebControls.Button btnNewCategory;
		protected System.Web.UI.WebControls.Repeater rptShoplist;
		protected Cuyahoga.ServerControls.Pager Pager1;
		protected System.Web.UI.WebControls.Button btnNewShop;
		protected System.Web.UI.WebControls.Repeater rptEmoticons;
		protected Cuyahoga.ServerControls.Pager pgEmoticons;
		protected System.Web.UI.WebControls.Button btnNewEmoticon;
		protected Cuyahoga.ServerControls.Pager pgrShopTags;
		protected System.Web.UI.WebControls.Repeater rptTags;
		protected System.Web.UI.WebControls.Button btnNewTag;
		private ShopModule _module;

		private void Page_Load(object sender, System.EventArgs e)
		{
            try
            {
                base.Title = "Shop administration";
                this._module = base.Module as ShopModule;
                if (!this.IsPostBack)
                {
                    this.rptShopCategories.DataSource = this._module.GetAllCategories();
                    this.rptShopCategories.DataBind();

                    this.rptShoplist.DataSource = this._module.GetAllShops();
                    this.rptShoplist.DataBind();

                    
                    this.rptEmoticons.DataSource = this._module.GetAllEmoticons();
                    this.rptEmoticons.DataBind();

                    this.rptTags.DataSource = this._module.GetAllTags();
                    this.rptTags.DataBind();
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error when loading shop module ", ex);
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.rptTags.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptTags_ItemDataBound);
			this.rptShopCategories.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptShopCategories_ItemDataBound);
			this.btnNewCategory.Click += new System.EventHandler(this.btnNewCategory_Click);
			this.rptShoplist.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptShoplist_ItemDataBound);
			this.btnNewShop.Click += new System.EventHandler(this.btnNewShop_Click);
			this.rptEmoticons.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptEmoticons_ItemDataBound);
			this.btnNewEmoticon.Click += new System.EventHandler(this.btnNewEmoticon_Click);
			this.btnNewTag.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void rptShopCategories_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			ShopCategory shopcategory = e.Item.DataItem as ShopCategory;

			HyperLink hplEdit = e.Item.FindControl("hpledit") as HyperLink;
			if (hplEdit != null)
			{
				hplEdit.NavigateUrl = String.Format("~/Modules/Shop/AdminEditCategory.aspx{0}&CategoryId={1}", base.GetBaseQueryString(), shopcategory.Id);
			}
		}

		private void btnNewCategory_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(String.Format("~/Modules/Shop/AdminEditCategory.aspx?NodeId={0}&SectionId={1}&CategoryId=-1",this.Node.Id, this.Section.Id));
		}

		private void btnNewShop_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(String.Format("~/Modules/Shop/AdminEditShop.aspx?NodeId={0}&SectionId={1}&CategoryId=-1",this.Node.Id, this.Section.Id));
		
		}

		private void rptShoplist_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			ShopShop shop = e.Item.DataItem as ShopShop;

			HyperLink hplEdit = e.Item.FindControl("hplShopEdit") as HyperLink;
			if (hplEdit != null)
			{
				hplEdit.NavigateUrl = String.Format("~/Modules/Shop/AdminEditShop.aspx{0}&ShopId={1}", base.GetBaseQueryString(), shop.Id);
			}
		
		}

		private void btnNewEmoticon_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(String.Format("~/Modules/Shop/AdminEditEmoticon.aspx?NodeId={0}&SectionId={1}&EmoticonId=-1",this.Node.Id, this.Section.Id));
		}

		private void rptEmoticons_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			ShopEmoticon emoticon = e.Item.DataItem as ShopEmoticon;

			HyperLink hplEdit = e.Item.FindControl("hplEditEmoticon") as HyperLink;
			if (hplEdit != null)
			{
				hplEdit.NavigateUrl = String.Format("~/Modules/Shop/AdminEditEmoticon.aspx{0}&EmoticonId={1}", base.GetBaseQueryString(), emoticon.Id);
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(String.Format("~/Modules/Shop/AdminEditTag.aspx?NodeId={0}&SectionId={1}&TagId=-1",this.Node.Id, this.Section.Id));		
		}

		private void rptTags_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			ShopTag tag = e.Item.DataItem as ShopTag;

			HyperLink hplEdit = e.Item.FindControl("hplTagEdit") as HyperLink;
			if (hplEdit != null)
			{
				hplEdit.NavigateUrl = String.Format("~/Modules/Shop/AdminEditTag.aspx{0}&TagId={1}", base.GetBaseQueryString(), tag.Id);
			}
		}
	
	}
}
