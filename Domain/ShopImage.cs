using System;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Caching;

using Cuyahoga.Web.Util;
namespace Cuyahoga.Modules.Shop.Domain
{
	/// <summary>
	/// The Emoticon class matches the text representation of an icon (i.e., ":)" for a smile) with its file name.
	/// </summary>
	public class ShopImage
	{
		private int			_id;
		private string		_origimagename;
		private string		_shopimagename;
		private int			_imagesize;
		private int			_productid;
		private string		_contenttype;
		private DateTime	_dateCreated;
		private DateTime	_dateModified;
        private Byte[] _data;
        private int _isdefault;

		#region Properties
		/// <summary>
		/// Corresponds to the primary key value of EmoticonID in the Emoticons table.
		/// </summary>
		public int Id
		{
			get { return this._id; }
			set	{ this._id =  value; }
		}

		/// <summary>
		/// The text representation of the emoticon, i.e., ";)" for a wink.
		/// </summary>
		public string OrigImageName
		{
			get	{ return this._origimagename; }
			set { this._origimagename = value; }
		}

		/// <summary>
		/// The file name of the Emoticon.
		/// </summary>
		public string ShopImageName
		{
			get { return this._shopimagename; }
			set { this._shopimagename = value; }
		}

		public int ImageSize
		{
			get { return this._imagesize; }
			set { this._imagesize = value; }
		}

		public string ContentType
		{
			get { return this._contenttype; }
			set { this._contenttype = value; }
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
        
        public int ProductId
		{
            get { return this._productid; }
            set { this._productid = value; }
		}
        public Byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public int IsDefault
        {
            get { return this._isdefault; }
            set { this._isdefault = value; }
        }
        
		#endregion

		/// <summary>
		/// Creates a default Emoticon object.
		/// </summary>
		public ShopImage()
		{
			this._id				= -1;
			this._origimagename		= "";
			this._shopimagename		= "";
			this._imagesize			= 0;
			this._contenttype		= "";
			this._dateCreated		= DateTime.Now;
			this._dateModified		= DateTime.Now;
            this._productid = -1;
            this._isdefault = 0;
		}
	}
}
