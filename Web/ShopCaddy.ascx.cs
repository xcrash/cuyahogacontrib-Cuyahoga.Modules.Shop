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
using Cuyahoga.Core.Domain;
using Cuyahoga.Web.UI;
using Cuyahoga.Web.Util;

using Cuyahoga.Modules.Shop.Domain;

namespace Cuyahoga.Modules.Shop
{
    public partial class ShopCaddy : BaseModuleControl
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
                    this._module.SetCurrentOrder(currentUser);
                    this.BindShopCaddy();
                }

                this.BindTopFooter();
                base.LocalizeControls();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable load the Shop module ", ex);
            }
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

        private void BindShopCaddy()
        {
            // Bind the link
            HyperLink hpl = (HyperLink)this.FindControl("hplNewTitle");
            if (hpl != null)
            {
                hpl.Text = base.GetText("lblNewTitle");
                hpl.NavigateUrl = String.Format("{0}/ShopNewProduct/{1}", UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId);
                hpl.CssClass = "shop";
            }

            this.rptShopCaddyList.DataSource = this._module.CurrentShopOrder.OrderLines;
            this.rptShopCaddyList.DataBind();
        }


        public string GetTotal(object o)
        {
            //ShopCaddyItem item = o as ShopCaddyItem;
            decimal dTotal = 0; //item.Product.Price * item.Quantity;
            foreach (Object obj in this._module.CurrentShopOrder.OrderLines)
            {
                ShopOrderLine orderLine = obj as ShopOrderLine;
                ShopProduct product = orderLine.Product;
                dTotal += product.Price;
            }
            return String.Format("{0:c}", dTotal);
        }

        protected void rptShopCaddyList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int orderLineId = int.Parse(((HiddenField)e.Item.FindControl("OrderLineId")).Value);
                ShopOrderLine orderLine = this._module.GetShopOrderLine(orderLineId);
                this._module.CurrentShopOrder.OrderLines.Remove(orderLine);
                this._module.SaveOrder(this._module.CurrentShopOrder);

                this.BindShopCaddy();
            }
        }

        protected void ButtonCheckout_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("{0}", UrlHelper.GetUrlFromSection(this._module.Section)));
        }
    }
}