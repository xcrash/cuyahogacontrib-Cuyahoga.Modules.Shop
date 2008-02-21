using System;
using System.Collections;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Cuyahoga.Core.Util;
using Cuyahoga.Web.UI;
using Cuyahoga.Web.Util;
using Cuyahoga.Modules.Shop;
using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Modules.Shop.Utils;
using PAB.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;


namespace Cuyahoga.Modules.Shop
{
	/// <summary>
	///		Summary description for Links.
	/// </summary>
	public class ShopView : BaseModuleControl
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl Welcome;
		protected System.Web.UI.WebControls.Repeater rptShopProductList;
		protected System.Web.UI.WebControls.Label lblShopName;
		protected System.Web.UI.WebControls.HyperLink hplNewTitle;
		protected System.Web.UI.WebControls.PlaceHolder phShopTop;
		protected System.Web.UI.WebControls.PlaceHolder phShopFooter;
		protected System.Web.UI.WebControls.Panel Panel1;


		private ShopModule _module;
        private ShopShop _shopShop;

		private void Page_Load(object sender, System.EventArgs e)
		{
            try
            {
                this._module = base.Module as ShopModule;
                // Add the CSS
                string cssfile = String.Format("{0}Modules/Shop/Images/Standard/shop.css", UrlHelper.GetApplicationPath());
                this.RegisterStylesheet("shopcss", cssfile);

                this._shopShop = this._module.GetShopById(this._module.CurrentShopId);
                this._module.CurrentShopCategoryId = this._shopShop.CategoryId;

                if (this._shopShop.AllowGuestPublish == 1 || this.Page.User.Identity.IsAuthenticated)
                {
                    this.hplNewTitle.Visible = true;
                }
                else
                {
                    this.hplNewTitle.Visible = false;
                }
                this.BindShopProducts();
                this.BindTopFooter();
                base.LocalizeControls();
                this.Translate();
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
			tShopFooter.Module	= this._module;
			this.phShopFooter.Controls.Add(tShopFooter);
		}

		private void Translate()
		{
			this.lblShopName.Text = this._shopShop.Name;
		}

		private void BindShopProducts()
		{
			// Bind the link
			HyperLink hpl = (HyperLink)this.FindControl("hplNewTitle");
			if(hpl != null)
			{
				hpl.Text = base.GetText("lblNewTitle");
				hpl.NavigateUrl	= String.Format("{0}/ShopEditProduct/{1}",UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId);
				hpl.CssClass = "shop";
			}
			this.rptShopProductList.DataSource	= this._module.GetAllShopProducts(this._module.CurrentShopId);
			this.rptShopProductList.DataBind();
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

		public string GetTitleLink(object o)
		{
			ShopProduct product = o as ShopProduct;
			return String.Format("<a href=\"{0}/ShopViewProduct/{1}/ProductId/{2}\" class=\"shop\">{3}</a>",UrlHelper.GetUrlFromSection(this._module.Section), product.ShopId,product.Id,product.Title);
		}

        protected void rptShopProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                   e.Item.ItemType == ListItemType.Item)
            {
                IList imageList = this._module.GetAllShopProductImages((int)DataBinder.Eval(e.Item.DataItem, "Id"));
                
                ShopImage image = (ShopImage)imageList[0];

                if (image.Data != null)
                {
                    ImageControl imgControl = (ImageControl)e.Item.FindControl("imgProduct");

                    imgControl.Bitmap = Utils.Utils.ImageResize(image.Data, this._module.ThumbWidth);
                }
            }

        }

        public string GetShopCommentCount(object o)
        {
            ShopProduct product = o as ShopProduct;
            string strReturn = this._module.GetCommentCount(product)[0].ToString();
            return strReturn;
        }

	}
}
