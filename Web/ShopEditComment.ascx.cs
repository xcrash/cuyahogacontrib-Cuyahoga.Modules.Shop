using System;
using System.Collections;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Cuyahoga.Core.Util;
using Cuyahoga.Core.Domain;
using Cuyahoga.Web.UI;
using Cuyahoga.Web.Util;
using Cuyahoga.Modules.Shop;
using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Modules.Shop.Utils;

namespace Cuyahoga.Modules.Shop
{
	/// <summary>
	///		Summary description.
	/// </summary>
	public class ShopEditComment : BaseModuleControl
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl Welcome;
		protected System.Web.UI.WebControls.Button btnPreview;
		protected System.Web.UI.WebControls.Button btnPublish;
        protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtMessage;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvMessage;
		protected System.Web.UI.WebControls.Panel pnlShopNewComment;
		protected System.Web.UI.WebControls.PlaceHolder phTop;
		protected System.Web.UI.WebControls.PlaceHolder phFooter;
		protected System.Web.UI.WebControls.PlaceHolder phShopTop;
		protected System.Web.UI.WebControls.PlaceHolder phShopFooter;
		protected System.Web.UI.WebControls.Literal ltOrigProduct;
		protected System.Web.UI.WebControls.Panel pnlPreview;
		protected System.Web.UI.WebControls.Literal ltPreviewProduct;
		protected System.Web.UI.WebControls.Label lblPreview;
		protected System.Web.UI.WebControls.Panel pnlOrigProduct;
		protected System.Web.UI.WebControls.Label lblOrigTitle;
		protected System.Web.UI.WebControls.Repeater rptSmily;
		protected System.Web.UI.WebControls.Panel pnlSmily;
		protected System.Web.UI.WebControls.Literal ltJsInject;
		protected System.Web.UI.HtmlControls.HtmlInputFile txtAttachment;
        protected System.Web.UI.WebControls.DropDownList ddnRating;
		
		#region Private vars
		private ShopModule _module;
        private ShopShop _shopShop;
		protected System.Web.UI.WebControls.Literal ltlUploadError;
		protected System.Web.UI.WebControls.Panel pnlUploadError;
		private ShopProduct	_origProduct;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			this._module = base.Module as ShopModule;
			// Add the CSS
			string cssfile = String.Format("{0}Modules/Shop/Images/Standard/shop.css",UrlHelper.GetApplicationPath());
			this.RegisterStylesheet("shopcss",cssfile);

			this._origProduct		= this._module.GetShopProductById(this._module.CurrentShopProductId);
			this._shopShop	= this._module.GetShopById(this._module.CurrentShopId);
			this._module.CurrentShopCategoryId	= this._shopShop.CategoryId;

            this.BindTopFooter();
            base.LocalizeControls();
            this.ltOrigProduct.Text = this._origProduct.Message;
			this.BindJS();
			this.BindEmoticon();

			if(!this.IsPostBack)
			{
				if(this._module.QuoteProduct == 1)
				{
					this.txtMessage.Text = "[quote]" + TextParser.HtmlToShopCode(this._origProduct.Message,this._module) + "[/quote]";
				}
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

		private void BindJS()
		{
			string m = String.Format("{0}",this.txtMessage.ClientID);
			Page.RegisterClientScriptBlock("shopscripts", String.Format("<script language=\"JavaScript\" src=\"{0}/Modules/Shop/shop.js\"></script>\n",UrlHelper.GetSiteUrl()));
		}

		private void BindEmoticon()
		{
			this.rptSmily.DataSource = this._module.GetAllEmoticons();
			this.rptSmily.DataBind();
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
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPreview_Click(object sender, System.EventArgs e)
		{
			this.pnlPreview.Visible = true;
			this.ltPreviewProduct.Visible = true;
			this.lblPreview.Visible	= true;
			this.ltPreviewProduct.Text	= TextParser.ShopCodeToHtml(this.txtMessage.Text,this._module);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            Response.Redirect(String.Format("{0}/ShopViewProduct/{1}/ProductId/{2}", UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId, this._module.CurrentShopProductId));
        }


		private void btnPublish_Click(object sender, System.EventArgs e)
		{
			if(this.Page.IsValid)
			{
				Cuyahoga.Core.Domain.User tUser = this.Page.User.Identity as User;

                ShopComment tShopComment = new ShopComment();
                tShopComment.DateCreated = DateTime.Now;
                tShopComment.DateModified = DateTime.Now;
                tShopComment.Message = TextParser.ShopCodeToHtml(this.txtMessage.Text, this._module);
                tShopComment.Title = this._origProduct.Title;
                tShopComment.ProductId = this._module.CurrentShopProductId;
                tShopComment.Rating = int.Parse(this.ddnRating.SelectedValue);

				if(tUser != null)
				{
                    tShopComment.UserId = tUser.Id;
                    tShopComment.UserName = tUser.UserName;
				}
				else
				{
                    tShopComment.UserId = 0;
                    tShopComment.UserName = "Guest";
				}

                this._module.SaveShopComment(tShopComment);

				// Update the original post
				this._origProduct.Comments++;
				this._module.SaveShopProduct(this._origProduct);
                Response.Redirect(String.Format("{0}/ShopViewProduct/{1}/ProductId/{2}", UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId, this._module.CurrentShopProductId));
			}
		}
		
		public string GetEmoticonIcon(object o)
		{
            ShopEmoticon ei = (ShopEmoticon)o;
            string imagepath = String.Format("{0}/Images/Standard/", this.TemplateSourceDirectory);
            // HARD CODEDE - CHANGEME!!
            string sResult = String.Format("<a href=\"javascript:InsertEmoticon('{0}','{1}');\"><img src=\"{2}{3}\" border=0 alt=\"\"></a>", this.txtMessage.ClientID, ei.TextVersion, imagepath, ei.ImageName);
            return sResult;
        }
	}
}
