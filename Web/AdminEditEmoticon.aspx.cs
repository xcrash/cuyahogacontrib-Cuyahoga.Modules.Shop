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
using Cuyahoga.Modules.Shop;
using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Web.UI;

namespace Cuyahoga.Modules.Shop
{
	/// <summary>
	/// Summary description for Edit shop emoticon.
	/// </summary>
	public class AdminEditEmoticon : ModuleAdminBasePage
	{
		private ShopEmoticon	_shopemoticon;
		private ShopModule		_module;

		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnCancel;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateOnline;
		protected System.Web.UI.WebControls.TextBox txtTextVersion;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvTextVersion;
		protected System.Web.UI.WebControls.TextBox txtImageName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvImageName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateOffline;

		private void Page_Load(object sender, System.EventArgs e)
		{
			this._module = base.Module as ShopModule;
			this.btnCancel.Attributes.Add("onClick", String.Format("document.location.href='AdminShop.aspx{0}'", base.GetBaseQueryString()));
			if (! this.IsPostBack)
			{
			}

			if (Request.QueryString["EmoticonId"] != null)
			{
				int emoticonId = Int32.Parse(Request.QueryString["EmoticonId"]);
				if (emoticonId > 0)
				{
					this._shopemoticon = this._module.GetEmoticonById(emoticonId);
					if (! this.IsPostBack)
					{
						BindEmoticon();
					}
					this.btnDelete.Visible = true;
					this.btnDelete.Attributes.Add("onClick", "return confirm('Are you sure?');");
				}
			}
		}

		private void BindEmoticon()
		{
			this.txtImageName.Text		= this._shopemoticon.ImageName;
			this.txtTextVersion.Text	= this._shopemoticon.TextVersion;
		}

		private void SaveEmoticon()
		{
			try
			{
				this._shopemoticon.ImageName		= this.txtImageName.Text;
				this._shopemoticon.TextVersion		= this.txtTextVersion.Text;
				this._shopemoticon.DateModified	= DateTime.Now;
				this._module.SaveEmoticon(this._shopemoticon);
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
				if (this._shopemoticon == null)
				{
					this._shopemoticon = new ShopEmoticon();
				}
				this.SaveEmoticon();
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if (this._shopemoticon != null)
			{
				try
				{
					this._module.DeleteEmoticon(this._shopemoticon);
					Response.Redirect(String.Format("AdminShop.aspx{0}", base.GetBaseQueryString()));
				}
				catch (Exception ex)
				{
					ShowError(ex.Message);
				}
			}
			else
			{
				ShowError("No emoticon found to delete");
			}
		}
	}
}
