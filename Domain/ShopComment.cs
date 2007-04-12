using System;

namespace Cuyahoga.Modules.Shop.Domain
{
	public class ShopComment
	{
		private int			_id;
		private DateTime	_dateCreated;
		private DateTime	_dateModified;
		private string 		_title;
		private int			_userid;
		private string		_username;
		private string		_ip;
		private string		_message;
		private int			_productid;
		private int			_views;
		private int			_rating;

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

		public int ProductId
		{
			get { return this._productid; }
			set { this._productid = value; }
		}

		public int Views
		{
			get { return this._views; }
			set { this._views = value; }
		}

        public int Rating
		{
            get { return this._rating; }
            set { this._rating = value; }
		}

		#endregion

        public ShopComment()
		{
			this._id			= -1;
			this._dateCreated	= DateTime.Now;
			this._dateModified	= DateTime.Now;
		}
	}
}
