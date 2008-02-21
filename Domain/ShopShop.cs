using System;

namespace Cuyahoga.Modules.Shop.Domain
{
	/// <summary>
	/// Summary description for Shop.
	/// </summary>
	public class ShopShop
	{
        private int _shopid;
		private DateTime	_dateCreated;
		private DateTime	_dateModified;
		private int			_categoryid;
		private string		_name;
		private string		_description;
        private DateTime    _lastpublished;
		private int			_lastproductid;
		private int			_sortorder;
		private int			_allowguestpublish;
		private string		_lastpublishusername;
		
		#region properties
		/// <summary>
		/// Property Id (int)
		/// </summary>
        public int Id
		{
            get { return this._shopid; }
            set { this._shopid = value; }
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

        public int CategoryId
		{
			get { return this._categoryid; }
			set { this._categoryid = value; }
		}

        public string Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

        public string Description
		{
			get { return this._description; }
			set { this._description = value; }
		}

        public int SortOrder
		{
			get { return this._sortorder; }
			set { this._sortorder = value; }
		}

        public DateTime LastPublished
		{
			get { return this._lastpublished; }
            set { this._lastpublished = value; }
		}

        public int LastProductId
		{
			get { return this._lastproductid; }
            set { this._lastproductid = value; }
		}

        public int AllowGuestPublish
		{
			get { return this._allowguestpublish; }
            set { this._allowguestpublish = value; }
		}

        public string LastPublishUserName
		{
			get { return this._lastpublishusername; }
			set { this._lastpublishusername = value; }
		}

		#endregion

		public ShopShop()
		{
			//
			// TODO: Add constructor logic here
			//
            this._shopid = -1;
			this._dateCreated		= DateTime.Now;
			this._dateModified		= DateTime.Now;
			this._lastpublished		= DateTime.Now;
			this._allowguestpublish	= 0;
		}
	}
}
