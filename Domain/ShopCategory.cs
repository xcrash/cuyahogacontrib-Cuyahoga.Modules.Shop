using System;

namespace Cuyahoga.Modules.Shop.Domain
{
	/// <summary>
	/// Summary description for ShopCategory.
	/// </summary>
	public class ShopCategory
	{
        private int _categoryid;
		private int _siteid;
		private string _name;
		private int _sortorder;
		private DateTime	_dateCreated;
		private DateTime	_dateModified;

		#region Properties
		public int Id
		{
            get { return this._categoryid; }
            set { this._categoryid = value; }
		}

		public int SiteId
		{
			get { return this._siteid; }
			set { this._siteid = value; }
		}

		public string Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

		public int SortOrder
		{
			get { return this._sortorder; }
			set { this._sortorder = value; }
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
		public ShopCategory()
		{
			//
			// TODO: Add constructor logic here
			//
            this._categoryid = -1;
			this._dateCreated = DateTime.Now;
			this._dateModified = DateTime.Now;
		}
	}
}

