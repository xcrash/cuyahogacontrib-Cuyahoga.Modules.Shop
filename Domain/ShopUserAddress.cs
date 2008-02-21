using System;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using Cuyahoga.Core.Domain;

namespace Cuyahoga.Modules.Shop.Domain
{
	public class ShopUserAddress
	{
        private int _addressid;
        private string _address1;
        private string _address2;
        private string _zip;
        private string _region;
        private string _city;
        private string _country;
        private string _telephone1;
        private string _telephone2;
        private string _mobile;
        private int _delivery;
        private User _user;

		#region Properties
		public int AddressId
		{
			get { return this._addressid; }
            set { this._addressid = value; }
		}

        public string Address1
        {
            get { return this._address1; }
            set { this._address1 = value; }
        }

        public string Address2
        {
            get { return this._address2; }
            set { this._address2 = value; }
        }

        public string Zip
        {
            get { return this._zip; }
            set { this._zip = value; }
        }

        public string Region
        {
            get { return this._region; }
            set { this._region = value; }
        }
        public string City
        {
            get { return this._city; }
            set { this._city = value; }
        }

        public string Country
        {
            get { return this._country; }
            set { this._country = value; }
        }

        public string Telephone1
        {
            get { return this._telephone1; }
            set { this._telephone1 = value; }
        }

        public string Telephone2
        {
            get { return this._telephone2; }
            set { this._telephone2 = value; }
        }

        public string Mobile
        {
            get { return this._mobile; }
            set { this._mobile = value; }
        }

        public int Delivery
        {
            get { return this._delivery; }
            set { this._delivery = value; }
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
	
		#endregion

        public ShopUserAddress()
		{
            this._addressid = -1;
		}
	}
}
