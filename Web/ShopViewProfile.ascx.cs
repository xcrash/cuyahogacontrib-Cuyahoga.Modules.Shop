using System;
using System.Collections;
using System.Web.UI.WebControls;

using Cuyahoga.Web.UI;
using Cuyahoga.Web.Util;
using Cuyahoga.Modules.Shop;
using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Core.Domain;

namespace Cuyahoga.Modules.Shop
{
	/// <summary>
	///		Summary description for Links.
	/// </summary>
	public class ShopViewProfile : BaseModuleControl
	{
		protected System.Web.UI.WebControls.PlaceHolder phShopTop;
		protected System.Web.UI.WebControls.PlaceHolder phShopFooter;
		protected System.Web.UI.WebControls.Literal ltrUserName;
		protected System.Web.UI.WebControls.Label lblRealName;
		protected System.Web.UI.WebControls.Literal ltrRealName;
		protected System.Web.UI.WebControls.Label lblLocation;
		protected System.Web.UI.WebControls.Literal ltrLocation;
		protected System.Web.UI.WebControls.Label lblOccupation;
		protected System.Web.UI.WebControls.Literal ltroccupation;
		protected System.Web.UI.WebControls.Label lblInterest;
		protected System.Web.UI.WebControls.Literal ltrInterest;
		protected System.Web.UI.WebControls.Label lblGender;
		protected System.Web.UI.WebControls.Literal ltrGender;
		protected System.Web.UI.WebControls.Label lblHomepage;
		protected System.Web.UI.WebControls.Literal ltrHomepage;
		protected System.Web.UI.WebControls.Label lblMSN;
		protected System.Web.UI.WebControls.Literal ltrMSN;
		protected System.Web.UI.WebControls.Label lblYahooMessenger;
		protected System.Web.UI.WebControls.Literal ltrYahooMessenger;
		protected System.Web.UI.WebControls.Label lblAIMName;
		protected System.Web.UI.WebControls.Literal ltrAIMName;
		protected System.Web.UI.WebControls.Label lblICQNumber;
		protected System.Web.UI.WebControls.Literal ltrICQNumber;
		protected System.Web.UI.WebControls.Label lblUserName;

		

		#region Private vars
		private ShopUser	_shopUser;
		private ShopModule _module;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			this._module	= base.Module as ShopModule;
			this._shopUser	= this._module.GetShopUserByUserId(this._module.CurrentUserId);

			// Add the CSS
			string cssfile = String.Format("{0}Modules/Shop/Images/Standard/shop.css",UrlHelper.GetApplicationPath());
			this.RegisterStylesheet("shopcss",cssfile);

			if(this._shopUser == null) // The user have NOT modified his profile, so we create an empty one
			{
				this._shopUser = new ShopUser();
				this._module.SaveShopUser(this._shopUser);
			}

            this.BindTopFooter();
            this.BindProfile();
            base.LocalizeControls();
        }

		private void BindTopFooter()
		{
			ShopTop	tShopTop;
			ShopFooter	tShopFooter;

			this._module		= this.Module as ShopModule;
			tShopTop			= (ShopTop)this.LoadControl("~/Modules/Shop/ShopTop.ascx");
			tShopTop.Module	= this._module;
			this.phShopTop.Controls.Add(tShopTop);

			tShopFooter		= (ShopFooter)this.LoadControl("~/Modules/Shop/ShopFooter.ascx");
			tShopFooter.Module	= this._module;
			this.phShopFooter.Controls.Add(tShopFooter);
		}

		private void BindProfile()
		{
			Cuyahoga.Core.Domain.User tUser;

			tUser = (Cuyahoga.Core.Domain.User)Context.User.Identity;
			this.ltrUserName.Text		= tUser.UserName;
			this.ltrRealName.Text		= tUser.FullName;

            //TODO: Bind Address

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
