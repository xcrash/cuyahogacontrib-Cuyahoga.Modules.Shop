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
using System.IO;

using Cuyahoga.Core.Util;
using Cuyahoga.Core.Domain;
using Cuyahoga.Web.UI;
using Cuyahoga.Web.Util;
using Cuyahoga.Modules.Shop;
using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Modules.Shop.Utils;

using PAB.WebControls;

namespace Cuyahoga.Modules.Shop
{
	/// <summary>
	///		Summary description.
	/// </summary>
	public class ShopEditProduct : BaseModuleControl
	{
		protected System.Web.UI.WebControls.Panel pnlTop;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Welcome;
		protected System.Web.UI.WebControls.Button btnPreview;
        protected System.Web.UI.WebControls.Button btnPublish;
        protected System.Web.UI.WebControls.Button btnCancel;
        protected System.Web.UI.WebControls.Button btnDelete;
        protected System.Web.UI.WebControls.TextBox txtMessage;
        protected System.Web.UI.WebControls.TextBox txtPrice;
        protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvSubject;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvMessage;
		protected System.Web.UI.WebControls.PlaceHolder phShopTop;
		protected System.Web.UI.WebControls.PlaceHolder phShopFooter;
		protected System.Web.UI.WebControls.Literal ltPreviewProduct;
		protected System.Web.UI.WebControls.Panel pnlPreview;
		protected System.Web.UI.WebControls.Label lblPreview;
		protected System.Web.UI.WebControls.Literal ltJsInject;
		protected System.Web.UI.WebControls.Panel pnlSmily;
		protected System.Web.UI.WebControls.Repeater rptSmily;
        protected System.Web.UI.WebControls.FileUpload FileUploadDocument;
		protected System.Web.UI.WebControls.Panel pnlUploadError;
		protected System.Web.UI.WebControls.Literal ltlUploadError;
        protected ImageControl ImageControl1;

		private ShopModule _module;
        private ShopShop _shopShop;

		private void Page_Load(object sender, System.EventArgs e)
		{
			this._module = base.Module as ShopModule;

			// Add the CSS
			string cssfile = String.Format("{0}Modules/Shop/Images/Standard/shop.css",UrlHelper.GetApplicationPath());
			this.RegisterStylesheet("shopcss",cssfile);

			this._shopShop	= this._module.GetShopById(this._module.CurrentShopId);
			this._module.CurrentShopCategoryId	= this._shopShop.CategoryId;

            if (!IsPostBack)
            {
                ShopProduct product = this._module.GetShopProductById(this._module.CurrentShopProductId);
                if (product != null)
                {
                    this.txtMessage.Text = product.Message;
                    this.txtPrice.Text = product.Price.ToString();
                    this.txtSubject.Text = product.Title;
                    this.btnDelete.Visible = true;

                    if (product.Images.Count > 0)
                    {
                        MemoryStream ms = new MemoryStream();
                        ShopImage image = (ShopImage)product.Images[0];

                        if (image.Data != null)
                        {
                            this.ImageControl1.Bitmap = Utils.Utils.ImageResize(image.Data, this._module.ImageWidth); ;
                            this.ImageControl1.Visible = true;
                        }
                    }
                }
                this.BindTopFooter();
                base.LocalizeControls();
                this.BindJS();
                this.BindEmoticon();
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
			Page.RegisterClientScriptBlock("shopscripts", String.Format("<script language=\"JavaScript\" src=\"{0}/Modules/Shop/shop.js\"></script>\n",UrlHelper.GetSiteUrl()));
		}


		private void BindEmoticon()
		{
			this.rptSmily.DataSource = this._module.GetAllEmoticons();
			this.rptSmily.DataBind();
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
				uname = "Guest";
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


		private void CheckValidFile(FileUpload file) 
		{
			if(file.PostedFile==null || file.PostedFile.FileName.Trim().Length==0 || file.PostedFile.ContentLength==0)
				return;

			string filename = file.PostedFile.FileName;
			int pos = filename.LastIndexOfAny(new char[]{'/','\\'});
			if(pos>=0)
				filename = filename.Substring(pos+1);
			pos = filename.LastIndexOf('.');
			if(pos>=0) 
			{
				switch(filename.Substring(pos+1).ToLower()) 
				{
					default:
						break;
					case "asp":
					case "aspx":
					case "ascx":
					case "config":
					case "php":
					case "php3":
					case "js":
					case "vb":
					case "vbs":
						throw new Exception(String.Format(GetText("fileerror"),filename));
				}
			}
		}

		private ShopImage SaveAttachment(ShopProduct product, FileUpload file)
		{
			ShopImage imgProductImage = new ShopImage();
			if(file.PostedFile == null || file.PostedFile.FileName.Trim().Length==0 || file.PostedFile.ContentLength==0)
				return null;

			string filename = file.PostedFile.FileName;

            imgProductImage.OrigImageName = filename;
            imgProductImage.ShopImageName = filename;
            imgProductImage.ImageSize = file.PostedFile.ContentLength;
            imgProductImage.ContentType = file.PostedFile.ContentType;
            imgProductImage.ProductId = product.Id;
            imgProductImage.Data = file.FileBytes;

			try
			{
                this._module.SaveShopImage(imgProductImage);


			}
			catch(Exception ex)
			{
				throw new Exception("Unable to save image ",ex);
			}
            return imgProductImage;

		}
		public string GetEmoticonIcon(object o)
		{
			ShopEmoticon ei = (ShopEmoticon)o;
            string imagepath = String.Format("{0}/Images/Standard/", this.TemplateSourceDirectory);
			// HARD CODEDE - CHANGEME!!
            string sResult = String.Format("<a href=\"javascript:InsertEmoticon('{0}','{1}');\"><img src=\"{2}{3}\" border=0 alt=\"\"></a>", this.txtMessage.ClientID, ei.TextVersion, imagepath, ei.ImageName);
            return sResult;
		}


        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("{0}/ShopView/{1}", UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId));

        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                Cuyahoga.Core.Domain.User tUser = this.Page.User.Identity as User;
                FileUpload postedFile = this.FileUploadDocument;
                ShopImage fFile;

                ShopProduct tShopProduct = this._module.GetShopProductById(this._module.CurrentShopProductId);

                if (tShopProduct == null)
                {
                    tShopProduct = new ShopProduct();
                    tShopProduct.ShopId = this._module.CurrentShopId;
                    tShopProduct.DateCreated = DateTime.Now;
                    if (tUser != null)
                    {
                        tShopProduct.UserId = tUser.Id;
                        tShopProduct.UserName = tUser.UserName;
                    }
                    else
                    {
                        tShopProduct.UserId = 0;
                        tShopProduct.UserName = base.GetText("GUEST");
                    }
                }
                tShopProduct.DateModified = DateTime.Now;
                tShopProduct.Message = TextParser.ShopCodeToHtml(this.txtMessage.Text, this._module);
                tShopProduct.Title = this.txtSubject.Text;
                tShopProduct.Price = decimal.Parse(this.txtPrice.Text);

                this._module.SaveShopProduct(tShopProduct);

                // Save attachement
                if (postedFile.PostedFile.ContentLength > 0)
                {
                    try
                    {
                        //TODO: Manage Images
                        this.CheckValidFile(this.FileUploadDocument);
                        fFile = this.SaveAttachment(tShopProduct, this.FileUploadDocument);
                        //tShopProduct.AttachmentId = fFile.Id;
                        this._module.SaveShopProduct(tShopProduct);
                    }
                    catch (Exception ex)
                    {
                        this.pnlUploadError.Visible = true;
                        this.ltlUploadError.Text = ex.Message;
                        this._module.DeleteShopProduct(tShopProduct);
                        return;
                    }
                }
                // Update number of products and number of posts
                //TODO: Modify comments or product publishing
                ShopShop tShopShop = this._module.GetShopById(this._module.CurrentShopId);
                tShopShop.LastPublished = DateTime.Now;
                tShopShop.LastPublishUserName = tShopProduct.UserName;
                tShopShop.LastProductId = tShopProduct.Id;
                this._module.SaveShop(tShopShop);

                Response.Redirect(String.Format("{0}/ShopView/{1}", UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId));
            }
        }

        protected void ButtonPreview_Click1(object sender, EventArgs e)
        {
            this.pnlPreview.Visible = true;
            this.ltPreviewProduct.Visible = true;
            this.lblPreview.Visible = true;
            this.ltPreviewProduct.Text = TextParser.ShopCodeToHtml(this.txtMessage.Text, this._module);

        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            this._module.DeleteShopProduct(this._module.GetShopProductById(this._module.CurrentShopProductId));
            Response.Redirect(String.Format("{0}/ShopView/{1}", UrlHelper.GetUrlFromSection(this._module.Section), this._module.CurrentShopId));

        }
	}
}
