using System;
using System.Collections;
using System.Security.Principal;
using NHibernate.Collection;

namespace Cuyahoga.Modules.Shop.Domain
{
	public class ShopProduct
	{
		private int			_id;
		private DateTime	_dateCreated;
		private DateTime	_dateModified;
		private string 		_title;
		private int			_userid;
		private string		_username;
		private string		_ip;
		private string		_message;
		private int			_shopid;
		private int			_views;
		private int			_comments;
        private decimal _price;
        private IList _images;
        private IList _commentlist;
        private IList _orderLines;

		#region Properties
		public int Id
		{
			get { return this._id; }
			set { this._id = value; }
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

		public string Title
		{
			get { return this._title; }
            set { this._title = value; }
		}

		public int UserId
		{
			get { return this._userid; }
			set { this._userid = value; }
		}

		public string UserName
		{
			get { return this._username; }
			set { this._username = value; }
		}

		public string Ip
		{
			get { return this._ip; }
			set { this._ip = value; }
		}

		public string Message
		{
			get { return this._message; }
			set { this._message = value; }
		}

		public int ShopId
		{
			get { return this._shopid; }
			set { this._shopid = value; }
		}

		public int Views
		{
			get { return this._views; }
			set { this._views = value; }
		}

        public int Comments
		{
            get { return this._comments; }
            set { this._comments = value; }
		}

        public decimal Price
        {
            get { return this._price; }
            set { this._price = value; }
        }

        public IList Images
        {
            get { return _images; }
            set { _images = value; }
        }

        public IList CommentList
        {
            get { return _commentlist; }
            set { _commentlist = value; }
        }
        public IList OrderLines
        {
            get { return _orderLines; }
            set { _orderLines = value; }
        }

		#endregion

        public ShopProduct()
		{
			this._id			= -1;
			this._dateCreated	= DateTime.Now;
			this._dateModified	= DateTime.Now;
            this._images = new ArrayList();
            this._commentlist = new ArrayList();
            this._orderLines = new ArrayList();
        }
	}
}
