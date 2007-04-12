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
	public class ShopTop : LocalizedUserControl
	{
		protected System.Web.UI.WebControls.Panel pnlTop;
		protected System.Web.UI.WebControls.HyperLink hplShopBreadCrumb;
		protected System.Web.UI.WebControls.Label lblWelcomeText;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Welcome;
		protected System.Web.UI.WebControls.HyperLink hplProductlink;
		protected System.Web.UI.WebControls.HyperLink hplCategoryLink;
		protected System.Web.UI.WebControls.HyperLink hplShopLink;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.HyperLink Hyperlink3;
		protected System.Web.UI.WebControls.HyperLink Hyperlink4;
		protected System.Web.UI.WebControls.HyperLink hplSearch;
		protected System.Web.UI.WebControls.HyperLink hplShopProfile;
        protected System.Web.UI.WebControls.HyperLink hplShopCaddy;
        protected System.Web.UI.WebControls.Label lblForward_1;
		protected System.Web.UI.WebControls.Label lblForward_2;
		protected System.Web.UI.WebControls.Label lblForward_3;

		
		
		#region Private vars		
		private ShopModule		_module;
        private ShopShop _shopShop;
		private ShopCategory	_shopCategory;
		#endregion

		#region Properties
		
		public ShopModule Module
		{
			get { return this._module; }
			set { this._module = value; }
		}
		
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			this._module = this.Module as ShopModule;
			this.ShopBreadCrumb();
			this.Translate();
		}

		private void Translate()
		{
			string uname = "";
			if(this.Page.User.Identity.IsAuthenticated)
			{
				Cuyahoga.Core.Domain.User currentUser = Context.User.Identity as Cuyahoga.Core.Domain.User;
				uname = currentUser.FullName;

				// Add links
				this.hplShopProfile.Visible		= true;
				this.hplShopProfile.NavigateUrl	= String.Format("{0}/ShopProfile/{1}",UrlHelper.GetUrlFromSection(this._module.Section),currentUser.Id);
                this.hplShopCaddy.Visible = true;
                this.hplShopCaddy.NavigateUrl = String.Format("{0}/ShopCaddy", UrlHelper.GetUrlFromSection(this._module.Section));
            }
			else
			{
				uname = base.GetText("GUEST");
			}
			this.hplSearch.NavigateUrl	= String.Format("{0}/ShopSearch",UrlHelper.GetUrlFromSection(this._module.Section));
			
            this.lblWelcomeText.Text	= String.Format(base.GetText("lblWelcomeText"),uname);
		}

		private void ShopBreadCrumb()
		{
			if(this._module.CurrentShopId != 0)
			{
				this._shopShop	= this._module.GetShopById(this._module.CurrentShopId);
				this._shopCategory	= this._module.GetShopCategoryById(this._shopShop.CategoryId);

				this.hplShopLink.NavigateUrl	= String.Format("{0}/ShopView/{1}",UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId);
				this.hplShopLink.Text			= this._shopShop.Name;
				this.hplShopLink.Visible		= true;
				this.hplShopLink.CssClass		= "shop";

				this.lblForward_1.Visible = true;
				this.lblForward_2.Visible = true;

				this.hplCategoryLink.NavigateUrl	= String.Format("{0}/ShopCategoryList/{1}",UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopCategoryId);
				this.hplCategoryLink.Text			= this._shopCategory.Name;
				this.hplCategoryLink.Visible		= true;
				this.hplCategoryLink.CssClass		= "shop";
			}

			if(this._module.CurrentShopProductId != 0)
			{
				this.hplProductlink.NavigateUrl	= String.Format("{0}/ShopViewProduct/{1}/post/{2}",UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId,this._module.CurrentShopProductId);
				this.hplProductlink.Visible		= true;
				this.hplProductlink.Text			= this._module.GetShopProductById(this._module.CurrentShopProductId).Title;
				this.hplProductlink.CssClass		= "shop";
				this.lblForward_3.Visible		= true;
			}

			HyperLink hplBreadCrumb	= (HyperLink)this.FindControl("hplShopBreadCrumb");
			if(hplBreadCrumb != null)
			{
				hplBreadCrumb.Text			= base.GetText("FORUMHOME");
				hplBreadCrumb.NavigateUrl	= UrlHelper.GetUrlFromSection(this._module.Section);
                hplBreadCrumb.ToolTip = base.GetText("FORUMHOME");
				hplBreadCrumb.CssClass		= "shop";
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	}
}
