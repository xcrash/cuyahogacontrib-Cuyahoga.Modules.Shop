using System;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Caching;

namespace Cuyahoga.Modules.Shop.Domain
{
	public class ShopOrderState
	{
		private int			_id;
        private String _name;

		#region Properties
		public int Id
		{
			get { return this._id; }
			set	{ this._id =  value; }
		}

        public String Name
		{
            get { return this._name; }
            set { this._name = value; }
		}
		
		#endregion

        public ShopOrderState()
		{
			this._id	= -1;
			this._name		= "";
		}
	}
}