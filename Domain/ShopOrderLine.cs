using System;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Caching;

namespace Cuyahoga.Modules.Shop.Domain
{
	public class ShopOrderLine
	{
        private int     _shoporderlineid;
        private ShopOrder _shoporder;
        private ShopProduct _shopproduct;

		#region Properties
        public int Id
		{
            get { return this._shoporderlineid; }
            set { this._shoporderlineid = value; }
		}


        public ShopOrder ShopOrder
        {
            get { return this._shoporder; }
            set { this._shoporder = value; }
        }

        public ShopProduct Product
        {
            get { return this._shopproduct; }
            set { this._shopproduct = value; }
        }

		#endregion

        public ShopOrderLine()
		{
            this._shoporderlineid = -1;
		}

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
	}
}
