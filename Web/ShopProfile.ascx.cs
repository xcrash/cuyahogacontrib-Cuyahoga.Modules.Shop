using System;
using System.Collections;
using System.Web.UI.WebControls;

using Cuyahoga.Core.Domain;
using Cuyahoga.Web.UI;
using Cuyahoga.Web.Util;
using Cuyahoga.Modules.Shop;
using Cuyahoga.Modules.Shop.Domain;

namespace Cuyahoga.Modules.Shop
{
	/// <summary>
	///		Summary description for Links.
	/// </summary>
	public class ShopProfile : BaseModuleControl
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.PlaceHolder phShopTop;
		protected System.Web.UI.WebControls.PlaceHolder phShopFooter;
		protected System.Web.UI.WebControls.Panel pnlProfile;
		protected System.Web.UI.WebControls.Label lblUserName;
		protected System.Web.UI.WebControls.Label lblRealName;
		protected System.Web.UI.WebControls.Label lblLocation;
		protected System.Web.UI.WebControls.Label lblMSN;
		protected System.Web.UI.WebControls.Label lblYahooMessenger;
		protected System.Web.UI.WebControls.Label lblAIMName;
		protected System.Web.UI.WebControls.Label lblICQNumber;
		protected System.Web.UI.WebControls.Label lblTimeZone;
		protected System.Web.UI.WebControls.Label lblOccupation;
		protected System.Web.UI.WebControls.Label lblInterest;
		protected System.Web.UI.WebControls.Label lblGender;
		protected System.Web.UI.WebControls.Label lblAvartar;
		protected System.Web.UI.WebControls.Label lblHomePage;
		protected System.Web.UI.WebControls.Label lblSignature;
		protected System.Web.UI.WebControls.Literal ltlUserName;
		protected System.Web.UI.WebControls.Literal ltlRealName;
		protected System.Web.UI.WebControls.RadioButton rbFemale;
		protected System.Web.UI.WebControls.DropDownList ddlTimeZone;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.TextBox txtSignature;
		protected System.Web.UI.WebControls.RadioButton rbMale;
		protected System.Web.UI.WebControls.TextBox txtLocation;
		protected System.Web.UI.WebControls.TextBox txtOccupation;
		protected System.Web.UI.WebControls.TextBox txtInterest;
		protected System.Web.UI.WebControls.TextBox txtHomepage;
		protected System.Web.UI.WebControls.TextBox txtMSN;
		protected System.Web.UI.WebControls.TextBox txtYahooMessenger;
		protected System.Web.UI.WebControls.TextBox txtAIMName;
		protected System.Web.UI.WebControls.TextBox txtICQNumber;
		protected System.Web.UI.WebControls.Button btnSave;
        protected System.Web.UI.WebControls.Button btnCancel;
		private ShopModule _module;
		private ShopUser	_fUser;

		private void Page_Load(object sender, System.EventArgs e)
		{
			this._module = base.Module as ShopModule;
			// Add the CSS
			// Add the CSS
			string cssfile = String.Format("{0}Modules/Shop/Images/Standard/shop.css",UrlHelper.GetApplicationPath());
			this.RegisterStylesheet("shopcss",cssfile);
			
			if(this.Page.User.Identity.IsAuthenticated)
			{
				Cuyahoga.Core.Domain.User currentUser = Context.User.Identity as Cuyahoga.Core.Domain.User;
				this._fUser	= this._module.GetShopUserByUserId(currentUser.Id);
				if(this._fUser == null)
				{
					this._fUser = new ShopUser();
					this._module.SaveShopUser(this._fUser);
				}
			}


			if(!this.Page.IsPostBack)
			{
                this.BindTopFooter();
                this.LocalizeControls();
                this.ddlTimeZone.DataSource = Utils.Utils.TimeZones();
				this.ddlTimeZone.DataBind();
				this.BindUser();
				// Add text

			}
		}

		private void BindUser()
		{
			Cuyahoga.Core.Domain.User tUser = Context.User.Identity as Cuyahoga.Core.Domain.User;
			this.ltlUserName.Text	= tUser.UserName;
			this.ltlRealName.Text	= tUser.FullName;

            //TODO: Bind Address

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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(String.Format("{0}", UrlHelper.GetUrlFromSection(this._module.Section)));
        }

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			Cuyahoga.Core.Domain.User currentUser = Context.User.Identity as Cuyahoga.Core.Domain.User;
			this._fUser.UserId	= currentUser.Id;

			//TODO: Bind Address

			Response.Redirect(String.Format("{0}/ShopList",UrlHelper.GetUrlFromSection(this._module.Section)));
		}

	}
}
