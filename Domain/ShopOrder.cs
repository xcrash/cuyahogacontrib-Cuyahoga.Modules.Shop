using System;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using Cuyahoga.Core.Domain;

namespace Cuyahoga.Modules.Shop.Domain
{
	public class ShopOrder
	{
		private int			_id;
        private User _owner;
        private DateTime _dateCreated;
		private DateTime	_dateModified;
        private ShopOrderState _shoporderstate;
        private IList _orderlines;

		#region Properties
		public int Id
		{
			get { return this._id; }
			set	{ this._id =  value; }
		}

        public User Owner
        {
            get { return _owner; }
            set { _owner = value; }
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

        public ShopOrderState OrderState
        {
            get { return this._shoporderstate; }
            set { this._shoporderstate = value; }
        }
	
	    /// <summary>
        /// Property OrderLines (IList)
        /// </summary>
        public IList OrderLines
        {
            get { return this._orderlines; }
            set { this._orderlines = value; }
        }

		#endregion

        public ShopOrder()
		{
			this._id				= -1;
			this._dateCreated		= DateTime.Now;
			this._dateModified		= DateTime.Now;
            this._orderlines = new ArrayList();
        }
	}
}