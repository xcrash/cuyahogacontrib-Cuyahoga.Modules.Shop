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

namespace Cuyahoga.Modules.Shop
{
    public partial class ShopProfile : BaseModuleControl
    {
        private ShopModule _module;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this._module = base.Module as ShopModule;
                // Add the CSS
                string cssfile = String.Format("{0}Modules/Shop/Images/Standard/shop.css", UrlHelper.GetApplicationPath());
                this.RegisterStylesheet("shopcss", cssfile);

                if (this.Page.User.Identity.IsAuthenticated)
                {
                    Cuyahoga.Core.Domain.User currentUser = Context.User.Identity as Cuyahoga.Core.Domain.User;
                }

                this.BindTopFooter();

                if (!this.Page.IsPostBack)
                {
                    this.BindAddress();
                }

                base.LocalizeControls();

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load the Shop module ", ex);
            }
        }

        private void BindAddress()
		{
			Cuyahoga.Core.Domain.User user = Context.User.Identity as Cuyahoga.Core.Domain.User;

            this.DataListAddress.DataSource = this._module.GetShopUserAddress(user);
            this.DataListAddress.DataBind();

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
            tShopFooter.Module = this._module;
            this.phShopFooter.Controls.Add(tShopFooter);
        }

        protected void ButtonAddNewAddress_Click(object sender, EventArgs e)
        {
            Cuyahoga.Core.Domain.User currentUser = Context.User.Identity as Cuyahoga.Core.Domain.User;

            ShopUserAddress address = new ShopUserAddress();
            address.User = currentUser;
            this._module.SaveShopUserAddress(address);

            this.BindAddress();

            foreach (DataListItem item in this.DataListAddress.Items)
            {
                HiddenField id = (HiddenField)item.FindControl("HiddenFieldId");
                int addressid = int.Parse(id.Value);
                if (address.AddressId == addressid)
                {
                    this.DataListAddress.EditItemIndex = item.ItemIndex;
                }
            }
            this.ButtonAddNewAddress.Visible = false;

            this.BindAddress();
            base.LocalizeControls();
        }

        protected void DataListAddress_EditCommand(object source, DataListCommandEventArgs e)
        {
            this.DataListAddress.EditItemIndex = e.Item.ItemIndex;
            this.BindAddress();
            this.ButtonAddNewAddress.Visible = false;

            base.LocalizeControls();
        }

        protected void DataListAddress_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField id = e.Item.FindControl("HiddenFieldId") as HiddenField;

            ShopUserAddress address = this._module.GetShopUserAddress(int.Parse(id.Value));

            this._module.DeleteShopUserAddress(address);

            this.BindAddress();
            base.LocalizeControls();
        }

        protected void DataListAddress_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField id = e.Item.FindControl("HiddenFieldId") as HiddenField;

            ShopUserAddress address = this._module.GetShopUserAddress(int.Parse(id.Value));

            address.Firstname = ((TextBox)e.Item.FindControl("TextBoxFirstnameValue")).Text;
            address.Lastname = ((TextBox)e.Item.FindControl("TextBoxLastnameValue")).Text;
            address.Mobile = ((TextBox)e.Item.FindControl("TextBoxMobileValue")).Text;
            address.Region = ((TextBox)e.Item.FindControl("TextBoxRegionValue")).Text;
            address.Telephone1 = ((TextBox)e.Item.FindControl("TextBoxTelephone1Value")).Text;
            address.Telephone2 = ((TextBox)e.Item.FindControl("TextBoxTelephone2Value")).Text;
            address.Zip = ((TextBox)e.Item.FindControl("TextBoxZipValue")).Text;
            address.Address1 = ((TextBox)e.Item.FindControl("TextBoxAddress1Value")).Text;
            address.Address2 = ((TextBox)e.Item.FindControl("TextBoxAddress2Value")).Text;
            address.City = ((TextBox)e.Item.FindControl("TextBoxCityValue")).Text;
            address.Country = ((TextBox)e.Item.FindControl("TextBoxCountryValue")).Text;
            if (((CheckBox)e.Item.FindControl("CheckBoxDeliveryValue")).Checked)
            {
                address.Delivery = 1;
            }
            else
            {
                address.Delivery = 0;
            }

            this.DataListAddress.EditItemIndex = -1;

            this._module.SaveShopUserAddress(address);

            this.ButtonAddNewAddress.Visible = true;

            this.BindAddress();
            base.LocalizeControls();

        }

        protected String GetDeliveryText(object delivery)
        {
            int value = int.Parse(delivery.ToString());
            if (value == 0)
            {
                return GetText("no");
            }
            else
            {
                return GetText("yes");
            }
        }

        protected Boolean GetDelivery(object delivery)
        {
            int value = int.Parse(delivery.ToString());
            if (value == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void DataListAddress_CancelCommand(object source, DataListCommandEventArgs e)
        {
            this.DataListAddress.EditItemIndex = -1;
            this.ButtonAddNewAddress.Visible = true;

            this.BindAddress();
            base.LocalizeControls();
        }
    }
}