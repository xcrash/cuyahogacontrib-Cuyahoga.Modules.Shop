using System;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Caching;

namespace Cuyahoga.Modules.Shop.Domain
{
	public class ShopUser
	{
		private int			_id;
		private DateTime	_dateCreated;
		private DateTime	_dateModified;
		private int			_userId;

		#region Properties
		public int Id
		{
			get { return this._id; }
			set	{ this._id =  value; }
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

		public int UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

	 		
		#endregion

		public ShopUser()
		{
			this._id				= -1;
			this._dateCreated		= DateTime.Now;
			this._dateModified		= DateTime.Now;
		}
	}
}
