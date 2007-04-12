using System;
using System.Collections;
using System.Web.UI.WebControls;
using System.IO;

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
	public class ShopViewProduct : BaseModuleControl
	{
		private const int BUFFER_SIZE = 8192;
		#region Private vars
		private ShopProduct	_shopProduct;
		private ShopShop	_shopShop;
		private ShopModule	_module;
		#endregion

		protected System.Web.UI.WebControls.Repeater rptShopProductCommentsList;
        protected System.Web.UI.WebControls.Repeater rptShopProductImagesList;
        protected System.Web.UI.WebControls.Literal lblPublishedDate;
		protected System.Web.UI.WebControls.Label lblUserInfo;
		protected System.Web.UI.WebControls.Literal lblMessages;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.HyperLink hplReply;
        protected System.Web.UI.WebControls.LinkButton lbtnBuy;
        protected System.Web.UI.WebControls.HyperLink hplNewTitle;
		protected System.Web.UI.WebControls.PlaceHolder phShopTop;
		protected System.Web.UI.WebControls.PlaceHolder phShopFooter;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.HyperLink hplAuthor;
        protected System.Web.UI.WebControls.Literal lblPrice;
        protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Literal ltlFileinfo;
		protected System.Web.UI.WebControls.Panel pnlAttachment;
		protected System.Web.UI.WebControls.Label lblAttachment;
		protected System.Web.UI.WebControls.HyperLink hplProductAttachment;



		private void Page_Load(object sender, System.EventArgs e)
		{
			this._module = base.Module as ShopModule;
			// Add the CSS
			string cssfile = String.Format("{0}Modules/Shop/Images/Standard/shop.css",UrlHelper.GetApplicationPath());
			this.RegisterStylesheet("shopcss",cssfile);

			this._shopShop	= this._module.GetShopById(this._module.CurrentShopId);
			this._module.CurrentShopCategoryId = this._shopShop.CategoryId;

            if (this.Page.User.Identity.IsAuthenticated)
            {
                Cuyahoga.Core.Domain.User currentUser = Context.User.Identity as Cuyahoga.Core.Domain.User;
                this._module.SetCurrentOrder(currentUser);
            }

			this.BindTopFooter();
			if(this._shopShop.AllowGuestPublish == 1 || this.Page.User.Identity.IsAuthenticated)
			{
				this.hplNewTitle.Visible = true;
				this.hplReply.Visible = true;
                this.lbtnBuy.Visible = true;
            }
			else
			{
				this.hplNewTitle.Visible = false;
				this.hplReply.Visible = false;
                this.lbtnBuy.Visible = false;
            }


			if(!this.IsPostBack)
			{
                this.LocalizeControls();
                this.BindLinks();
				this.BindShopProduct();
                this.BindShopProductImages();
                this.BindShopProductComments();
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
			string uname = "";
			if(this.Page.User.Identity.IsAuthenticated)
			{
				Cuyahoga.Core.Domain.User currentUser = Context.User.Identity as Cuyahoga.Core.Domain.User;
				uname = currentUser.FullName;
			}
			else
			{
				uname = base.GetText("GUEST");
			}
		}

		private void BindLinks()
		{
			this.hplReply.NavigateUrl = String.Format("{0}/ShopNewComment/{1}/post/{2}",UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId,this._module.CurrentShopProductId);
			this.hplNewTitle.NavigateUrl = String.Format("{0}/ShopNewProduct/{1}",UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId);
		}

		private void BindShopProduct()
		{
			this._shopProduct	= this._module.GetShopProductById(this._module.CurrentShopProductId);
			this._shopProduct.Views++;
			this._module.SaveShopProduct(this._shopProduct);
			this.lblTitle.Text	= this._shopProduct.Title;

			if(this._shopProduct.UserId == 0)
			{
				this.hplAuthor.Text = "Guest";
				this.hplAuthor.CssClass = "shop";
				this.lblUserInfo.Text	= "&nbsp;";
			}
			else
			{
				this.hplAuthor.Text			= this._shopProduct.UserName;
				this.hplAuthor.NavigateUrl	= String.Format("{0}/ShopViewProfile/{1}",UrlHelper.GetUrlFromSection(this._module.Section), this._shopProduct.UserId);
				this.hplAuthor.CssClass		= "shop";
				this.lblUserInfo.Text		= "&nbsp;";
			}
			string msg				= this._shopProduct.Message;
			this.lblMessages.Text	= this._shopProduct.Message;
            this.lblPrice.Text = String.Format("{0:c}",this._shopProduct.Price);
			this.lblPublishedDate.Text = TimeZoneUtil.AdjustDateToUserTimeZone(this._shopProduct.DateCreated, this.Page.User.Identity).ToLongDateString() + " " +TimeZoneUtil.AdjustDateToUserTimeZone(this._shopProduct.DateCreated, this.Page.User.Identity).ToLongTimeString();            
		}


        private void BindShopProductImages()
        {
            this.rptShopProductImagesList.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptShopProductImagesList_ItemDataBound);
            this.rptShopProductImagesList.DataSource = this._module.GetAllShopProductImages(this._module.CurrentShopProductId);
            this.rptShopProductImagesList.DataBind();
        }


		private void BindShopProductComments()
		{
			// Bind the link
			HyperLink hpl = (HyperLink)this.FindControl("hplNewTitle");
			if(hpl != null)
			{
				hpl.Text = "New product";
				hpl.NavigateUrl	= String.Format("{0}/ShopNewProduct/{1}",UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId);
				hpl.CssClass	= "shop";
			}

			//this.rptShopProductCommentsList.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptShopProductCommentsList_ItemDataBound);
            this.rptShopProductCommentsList.DataSource = this._module.GetAllShopProductComments(this._module.CurrentShopProductId);
            this.rptShopProductCommentsList.DataBind();
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


        private void rptShopProductImagesList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ShopProduct fProduct = e.Item.DataItem as ShopProduct;
            }
        }


		private void rptShopProductCommentsList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
		
		}

		public string GetPublishedDate(object o)
		{
            ShopComment tComment = o as ShopComment;
            return TimeZoneUtil.AdjustDateToUserTimeZone(tComment.DateCreated, this.Page.User.Identity).ToLongDateString() + " " + TimeZoneUtil.AdjustDateToUserTimeZone(tComment.DateCreated, this.Page.User.Identity).ToLongTimeString();
		}
		public string GetMessage(object o)
		{
            ShopComment tComment = o as ShopComment;
            return tComment.Message;
		}

		public string GetUserProfileLink(object o)
		{
            ShopComment tComment = o as ShopComment;
            if (tComment.UserId != 0)
			{
                return String.Format("<a href=\"{0}/ShopViewProfile/{1}\" class=\"shop\">{2}</a>", UrlHelper.GetUrlFromSection(this._module.Section), tComment.UserId, tComment.UserName);
			}
			else
			{
                return String.Format("<a href=\"#\" class=\"shop\">{0}</a>", tComment.UserName);
			}
		}
        public string GetRating(object o)
        {
            ShopComment tComment = o as ShopComment;
            return tComment.Rating.ToString();
        }

        public string GetImageURL(object o)
		{
			ShopImage tImage = o as ShopImage;

            string sUpDir = "Modules//Shop//Attach//";
            string filename = tImage.OrigImageName;
            string sImageOutputWidth = "200";

            string sReturn = UrlHelper.GetSiteUrl() + "/Modules/Shop/Imager.aspx?Image=" + String.Format("{0}{1}.{2}.{3}&ImageOutputWidth={4}", sUpDir, this._shopProduct.ShopId, this._shopProduct.Id, filename, sImageOutputWidth);

            return sReturn;
		}

        protected void lbtnBuy_Click(object sender, EventArgs e)
        {
            
            if (this._module.CurrentShopOrder == null)
            {
                ShopOrder order = new ShopOrder();
                Cuyahoga.Core.Domain.User currentUser = Context.User.Identity as Cuyahoga.Core.Domain.User;
                order.Owner = currentUser;
                order.OrderState = this._module.GetOrderState(1);
                this._module.SaveOrder(order);
                this._module.CurrentShopOrder = order;
            }
            this._shopProduct = this._module.GetShopProductById(this._module.CurrentShopProductId);
            ShopOrderLine orderline = new ShopOrderLine();
            orderline.Product = this._shopProduct;
            orderline.ShopOrder = this._module.CurrentShopOrder;
            this._module.CurrentShopOrder.OrderLines.Add(orderline);
            this._module.SaveOrder(this._module.CurrentShopOrder);
        }	
	}
}
