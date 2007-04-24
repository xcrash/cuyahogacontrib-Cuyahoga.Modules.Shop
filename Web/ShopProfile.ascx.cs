using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Core.Util;
using Cuyahoga.Web.UI;
using Cuyahoga.Web.Util;

namespace Cuyahoga.Modules.Shop.Web
{
    public partial class ShopProfile : BaseModuleControl
    {
        private ShopModule _module;
        private ShopUser _shopUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            this._module = base.Module as ShopModule;
            // Add the CSS
            // Add the CSS
            string cssfile = String.Format("{0}Modules/Shop/Images/Standard/shop.css", UrlHelper.GetApplicationPath());
            this.RegisterStylesheet("shopcss", cssfile);

            if (this.Page.User.Identity.IsAuthenticated)
            {
                Cuyahoga.Core.Domain.User currentUser = Context.User.Identity as Cuyahoga.Core.Domain.User;
                this._shopUser = this._module.GetShopUserByUserId(currentUser.Id);
                if (this._shopUser == null)
                {
                    this._shopUser = new ShopUser();
                    this._module.SaveShopUser(this._shopUser);
                }
            }


            if (!this.Page.IsPostBack)
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

        
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(String.Format("{0}", UrlHelper.GetUrlFromSection(this._module.Section)));
        }

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			Cuyahoga.Core.Domain.User currentUser = Context.User.Identity as Cuyahoga.Core.Domain.User;
			this._shopUser.UserId	= currentUser.Id;

			//TODO: Bind Address

			Response.Redirect(String.Format("{0}/ShopList",UrlHelper.GetUrlFromSection(this._module.Section)));
		}
    }
}