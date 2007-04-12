using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Cuyahoga.Core.Domain;
using Cuyahoga.Core.Util;
using Cuyahoga.Web.UI;
using Cuyahoga.Modules.Shop;
using Cuyahoga.Modules.Shop.Domain;

namespace Cuyahoga.Modules.Shop
{
	/// <summary>
	/// Summary description for Edit shop category.
	/// </summary>
	public class AdminEditShop : ModuleAdminBasePage
	{
        private ShopShop _shop;
		private ShopModule		_module;

		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnCancel;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateOnline;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvTitle;
		protected System.Web.UI.WebControls.DropDownList lstCategories;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDescription;
		protected System.Web.UI.WebControls.CheckBox ckbAllowGuestProduct;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateOffline;

		private void Page_Load(object sender, System.EventArgs e)
		{
			this._module = base.Module as ShopModule;
			this.btnCancel.Attributes.Add("onClick", String.Format("document.location.href='AdminShop.aspx{0}'", base.GetBaseQueryString()));
			if (! this.IsPostBack)
			{
				this.lstCategories.Items.Add(new ListItem("none", "0"));
				IList categories = this._module.GetAllCategories();
				foreach (ShopCategory category in categories)
				{
					this.lstCategories.Items.Add(new ListItem(category.Name, category.Id.ToString()));
				}
			}

			if (Request.QueryString["ShopId"] != null)
			{
				int shopId = Int32.Parse(Request.QueryString["ShopId"]);
				if (shopId > 0)
				{
					this._shop = this._module.GetShopById(shopId);
					if (! this.IsPostBack)
					{
						BindShop();
					}
					this.btnDelete.Visible = true;
					this.btnDelete.Attributes.Add("onClick", "return confirm('Are you sure?');");
				}
			}
		}

		private void BindShop()
		{
			if(this._shop != null)
			{
				this.txtName.Text			= this._shop.Name;
				this.txtDescription.Text	= this._shop.Description;

				if (this._shop.CategoryId	!= 0)
				{
					ListItem li = this.lstCategories.Items.FindByValue(this._shop.CategoryId.ToString());
					if (li != null)
					{
						li.Selected = true;
					}
				}

				if(this._shop.AllowGuestPublish == 1)
				{
					this.ckbAllowGuestProduct.Checked = true;
				}
			}
		}

		private void SaveShop()
		{
			try
			{
				this._shop.Name			= this.txtName.Text;
				this._shop.Description		= this.txtDescription.Text;
				this._shop.DateModified	= DateTime.Now;
				if (this.lstCategories.SelectedIndex > 0)
				{
					
					this._shop.CategoryId = Int32.Parse(this.lstCategories.SelectedValue);
				}
				if(this.ckbAllowGuestProduct.Checked)
				{
					this._shop.AllowGuestPublish = 1;
				}
				else
				{
					this._shop.AllowGuestPublish = 0;
				}
				this._module.SaveShop(this._shop);
				Response.Redirect(String.Format("AdminShop.aspx{0}", base.GetBaseQueryString()));
			}
			catch (Exception ex)
			{
				ShowError(ex.Message);
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (this.IsValid)
			{
				if (this._shop == null)
				{
					this._shop = new ShopShop();
				}
				
				this.SaveShop();
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if (this._shop != null)
			{
				try
				{
					this._module.DeleteShop(this._shop);
					Response.Redirect(String.Format("AdminShop.aspx{0}", base.GetBaseQueryString()));
				}
				catch (Exception ex)
				{
					ShowError(ex.Message);
				}
			}
			else
			{
				ShowError("No shop found to delete");
			}
		}
	}
}
