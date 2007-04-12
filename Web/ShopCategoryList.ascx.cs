using System;
using System.Collections;
using System.Web.UI.WebControls;

using Cuyahoga.Core.Util;
using Cuyahoga.Web.UI;
using Cuyahoga.Web.Util;
using Cuyahoga.Modules.Shop;
using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Modules.Shop.Utils;

namespace Cuyahoga.Modules.Shop
{
	/// <summary>
	///		Summary description for Links.
	/// </summary>
	public class ShopCategoryList : BaseModuleControl
	{
		protected System.Web.UI.WebControls.Repeater rptShopList;
		protected System.Web.UI.WebControls.PlaceHolder phShopTop;
		protected System.Web.UI.WebControls.PlaceHolder phShopFooter;
        protected System.Web.UI.WebControls.Label lblHdrProducts;
        protected System.Web.UI.WebControls.Label lblHdrNumProducts;
        protected System.Web.UI.WebControls.Label lblHdrLastProduct;

		private ShopModule _module;

		private void Page_Load(object sender, System.EventArgs e)
		{
			this._module = this.Module as ShopModule;
			// Add the CSS
			string cssfile = String.Format("{0}Modules/Shop/Images/Standard/shop.css",UrlHelper.GetApplicationPath());
			this.RegisterStylesheet("shopcss",cssfile);


            this.BindTopFooter();
            this.BindShops();
            base.LocalizeControls();
        }

		private void BindShops()
		{
			this.rptShopList.DataSource	= this._module.GetShopsByCategoryId(this._module.CurrentShopCategoryId);
			this.rptShopList.DataBind();
		}

		private void BindTopFooter()
		{
            ShopTop tShopTop;
            ShopFooter tShopFooter;

            tShopTop = (ShopTop)this.LoadControl("~/Modules/Shop/ShopTop.ascx");
            tShopTop.Module = this.Module as ShopModule;
            this.phShopTop.Controls.Add(tShopTop);

            tShopFooter = (ShopFooter)this.LoadControl("~/Modules/Shop/ShopFooter.ascx");
            tShopFooter.Module = this.Module as ShopModule;
            this.phShopFooter.Controls.Add(tShopFooter);
		}

		public string GetShopLink(object o)
		{
			ShopShop shop = o as ShopShop;
			string strReturn = String.Format("<a href=\"{0}/ShopView/{1}\" class=\"shop\">{2}</a>",UrlHelper.GetUrlFromSection(this._module.Section), shop.Id,shop.Name);
			return strReturn;

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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.rptShopList.ItemDataBound += new RepeaterItemEventHandler(this.rptShopList_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void rptShopList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				ShopShop shop = e.Item.DataItem as ShopShop;
				HyperLink hpl = (HyperLink)e.Item.FindControl("hplShoplink");
				if(hpl != null)
				{
					hpl.Text = shop.Name;
					hpl.NavigateUrl	= String.Format("{0}/ShopView/{1}",UrlHelper.GetUrlFromSection(this._module.Section), shop.Id);
					hpl.CssClass = "shop";
				}
			}
            else if (e.Item.ItemType == ListItemType.Header )
            {
                Label labelCategory = (Label)e.Item.FindControl("lblCategoryName");
                labelCategory.Text = this._module.GetShopCategoryById(this._module.CurrentShopCategoryId).Name;
            }
		}
	}
}
