using System;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Caching;

namespace Cuyahoga.Modules.Shop.Domain
{
	public class ShopTag
	{
		private int			_id;
		private string		_shopCodeStart;
		private string		_shopCodeEnd;
		private string		_htmlCodeStart;
		private string		_htmlCodeEnd;
		private DateTime	_dateCreated;
		private DateTime	_dateModified;

		#region Properties
		public int Id
		{
			get { return this._id; }
			set	{ this._id =  value; }
		}

		public string ShopCodeStart
		{
			get	{ return this._shopCodeStart; }
			set { this._shopCodeStart = value; }
		}

		public string ShopCodeEnd
		{
			get { return this._shopCodeEnd; }
			set { this._shopCodeEnd = value; }
		}

		public string HtmlCodeStart
		{
			get	{ return this._htmlCodeStart; }
			set { this._htmlCodeStart = value; }
		}

		public string HtmlCodeEnd
		{
			get { return this._htmlCodeEnd; }
			set { this._htmlCodeEnd = value; }
		}

		public DateTime DateModified
		{
			get { return this._dateModified; }
			set { this._dateModified = value; }
		}

		public DateTime DateCreated
		{
			get { return this._dateCreated; }
			set { this._dateCreated = value; }
		}
		
		#endregion

		public ShopTag()
		{
			this._id				= -1;
			this._shopCodeStart	= "";
			this._shopCodeEnd		= "";
			this._htmlCodeEnd		= "";
			this._htmlCodeStart		= "";
			this._dateCreated		= DateTime.Now;
			this._dateModified		= DateTime.Now;
		}
	}
}
