using System;
using System.Collections;
using System.Web.UI.WebControls;

using Cuyahoga.Web.UI;
using Cuyahoga.Modules.Shop;
using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Web.Util;

namespace Cuyahoga.Modules.Shop
{
	/// <summary>
	///		Summary description for Links.
	/// </summary>
	public class ShopSearch : BaseModuleControl
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.PlaceHolder phShopTop;
		protected System.Web.UI.WebControls.PlaceHolder phShopFooter;
		protected System.Web.UI.WebControls.Panel pnlSearch;
		protected System.Web.UI.WebControls.Label lblSearch;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Panel pnlSearchResult;
		protected System.Web.UI.WebControls.Repeater rptSearchresult;
		protected System.Web.UI.WebControls.Label lblSearchresult;
		protected System.Web.UI.WebControls.TextBox txtSearchfor;
		private ShopModule _module;

		private void Page_Load(object sender, System.EventArgs e)
		{
			this._module = base.Module as ShopModule;
			// Add the CSS
			string cssfile = String.Format("{0}Modules/Shop/Images/Standard/shop.css",UrlHelper.GetApplicationPath());
			this.RegisterStylesheet("shopcss",cssfile);
            this.BindTopFooter();
            this.LocalizeControls();
        }

		private void BindTopFooter()
		{
			ShopTop tShopTop;
			ShopFooter tShopFooter;

			this._module = this.Module as ShopModule;
			tShopTop = (ShopTop)this.LoadControl("~/Modules/Shop/ShopTop.ascx");
			tShopTop.Module = this._module;
			this.phShopTop.Controls.Add(tShopTop);

			tShopFooter = (ShopFooter)this.LoadControl("~/Modules/Shop/ShopFooter.ascx");
			tShopFooter.Module	= this._module;
			this.phShopFooter.Controls.Add(tShopFooter);
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			this.pnlSearch.Visible	= false;
			this.pnlSearchResult.Visible = true;
			this.rptSearchresult.DataSource = this._module.SearchShopProducts(this.txtSearchfor.Text);
			this.rptSearchresult.DataBind();
		}

		public string GetShopProductLink(object o)
		{
			ShopProduct post = o as ShopProduct;
			return String.Format("<a href=\"{0}/ShopViewProduct/{1}/ProductId/{2}\" class=\"shop\">{3}</a>",UrlHelper.GetUrlFromSection(this._module.Section), post.ShopId,post.Id,post.Title);
		}

	}
}
