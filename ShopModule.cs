using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

using NHibernate;
using NHibernate.Expression;
using NHibernate.Type;

using Castle.Services.Transaction;
using Castle.Facilities.NHibernateIntegration;

using Cuyahoga.Core;
using Cuyahoga.Core.Domain;
using Cuyahoga.Core.Communication;

using Cuyahoga.Core.Service;
using Cuyahoga.Web.Util;
using Cuyahoga.Modules.Shop.Domain;

namespace Cuyahoga.Modules.Shop 
{
	/// <summary>
	/// Summary description for ShopModule.
	/// </summary>
    public class ShopModule : ModuleBase, INHibernateModule
	{

		private ShopModuleAction _currentAction;

		private CategorySortBy	_categorySortBy;

        private bool _categorySortASC;

		private ShopSortBy		_shopSortBy;

        private bool _shopSortASC;

		private ShopProductSortBy	_shopProductSortBy;

        private bool _productSortASC;

        private ShopOrder _currentshoporder;


		private int				_currentShopId;
		private int				_currentShopCategoryId;
		private int				_currentShopProductId;
		private int				_currentUserId;
		private int				_quoteProduct;
		private int				_origShopProductId;
		private int				_downloadId;

		private string			_shopthemepath;
        private ISessionManager _sessionManager;
		
		#region Properties
        
        public int CurrentUserId
		{
			get { return this._currentUserId; }
			set { this._currentUserId = value; }
		}

		public int CurrentShopId
		{
			get { return this._currentShopId; }
			set { this._currentShopId = value; }
		}

		public int CurrentShopCategoryId
		{
			get { return this._currentShopCategoryId; }
			set { this._currentShopCategoryId = value; }
		}

		public int CurrentShopProductId
		{
			get { return this._currentShopProductId; }
			set { this._currentShopProductId = value; }
		}

		public int QuoteProduct
		{
			get { return this._quoteProduct; }
			set { this._quoteProduct = value; }
		}

		public string ThemePath
		{
			get { return this._shopthemepath; }
			set { this._shopthemepath = value; }
		}

		public int OrigShopProductId
		{
			get { return this._origShopProductId; }
			set { this._origShopProductId = value; }
		}

		public ShopOrder CurrentShopOrder
		{
			get { return this._currentshoporder; }
            set { this._currentshoporder = value; }
		}

		public ShopModuleAction ModuleAction
		{
			get { return this._currentAction; }
		}
		#endregion

        public ShopModule(ISessionManager sessionManager)
		{
            _sessionManager = sessionManager;

            ISession session = this._sessionManager.OpenSession();

            this._currentAction = ShopModuleAction.ShopList;

			_categorySortBy			= CategorySortBy.Name;
            _categorySortASC = true;
			_shopSortBy			= ShopSortBy.Name;
            _shopSortASC = true;
			_shopProductSortBy		= ShopProductSortBy.DateCreated;
            _productSortASC = true;

			this._shopthemepath = UrlHelper.GetApplicationPath() + "Modules/Shop/Images/Standard/";
		}

		/// <summary>
		/// Override ParsePathInfo to determine action and optional parameters.
		/// </summary>
		protected override void ParsePathInfo()
		{
			base.ParsePathInfo();
			if (base.ModuleParams.Length > 0)
			{
				// First pathinfo parameter is the module action.
				try
				{
					this._currentAction = (ShopModuleAction)Enum.Parse(typeof(ShopModuleAction), base.ModuleParams[0], true);

					switch(this._currentAction)
					{
						case ShopModuleAction.ShopCategoryList:
							this.CurrentShopCategoryId = Int32.Parse(base.ModuleParams[1]);
							break;

						case ShopModuleAction.ShopView:
							this.CurrentShopId = Int32.Parse(base.ModuleParams[1]);
							break;

						case ShopModuleAction.ShopNewProduct:
							this.CurrentShopId = Int32.Parse(base.ModuleParams[1]);
							break;

						case ShopModuleAction.ShopViewProduct:
							this.CurrentShopId		= Int32.Parse(base.ModuleParams[1]);
							this.CurrentShopProductId	= Int32.Parse(base.ModuleParams[3]);					
							
							break;

						case ShopModuleAction.ShopNewComment:
							this.CurrentShopId		= Int32.Parse(base.ModuleParams[1]);
							this.CurrentShopProductId	= Int32.Parse(base.ModuleParams[3]);
							this.OrigShopProductId	= Int32.Parse(base.ModuleParams[3]);
							this.QuoteProduct = 0;
							break;

						case ShopModuleAction.ShopNewCommentQuote:
							this.CurrentShopId		= Int32.Parse(base.ModuleParams[1]);
							this.CurrentShopProductId	= Int32.Parse(base.ModuleParams[3]);
							this.OrigShopProductId	= Int32.Parse(base.ModuleParams[5]);
							this.QuoteProduct = 1;
							this._currentAction = ShopModuleAction.ShopNewComment;
							break;

						case ShopModuleAction.ShopProfile:
						case ShopModuleAction.ShopViewProfile:
							this.CurrentUserId	= Int32.Parse(base.ModuleParams[1]);
							break;
					}
				}
				catch (ArgumentException ex)
				{
					throw new Exception("Error when parsing module action: " + base.ModuleParams[0], ex);
				}
				catch (Exception ex)
				{
					throw new Exception("Error when parsing module parameters: " + base.ModulePathInfo, ex);
				}
			}
		}

        public override void DeleteModuleContent()
		{
			// Delete all the files that users have uploaded
			
			string sUpDir = HttpContext.Current.Request.PhysicalApplicationPath + "Modules/Shop/Attach/";
			if(System.IO.Directory.Exists(sUpDir))
			{
				System.IO.Directory.Delete(sUpDir,true);
			}
		}

		/// <summary>
		/// The current view user control based on the action that was set while parsing the pathinfo.
		/// </summary>
		public override string CurrentViewControlPath
		{
			get
			{
				string basePath = "Modules/Shop/";
				return basePath + this._currentAction.ToString() + ".ascx";
			}
		}

		#region Shop
		/// <summary>
		/// 
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public IList GetShopsByCategoryId(int categoryid)
        {
            ISession session = this._sessionManager.OpenSession();

			try
			{
                ICriteria shops = session.CreateCriteria(typeof(ShopShop)).Add(NHibernate.Expression.Expression.Eq("CategoryId", categoryid));
                shops.AddOrder(new Order(this._categorySortBy.ToString(), this._categorySortASC));

                IList Shops = shops.List();

                return Shops;
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get shop by category" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
        public ShopShop GetShopById(int shopId)
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                return (ShopShop)session.Load(typeof(ShopShop), shopId);
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get shop by id" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}


        [Transaction(TransactionMode.RequiresNew)]
        public virtual void SaveShop(ShopShop shop)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
			{
                session.SaveOrUpdate(shop);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to save Shop " + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		/// <summary>
		/// Delete the meta-information of a file
		/// </summary>
        [Transaction(TransactionMode.RequiresNew)]
        public virtual void DeleteShop(ShopShop shop)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
			{
                session.Delete(shop);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
				tx.Rollback();
                throw new Exception("Unable to delete Shop" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public IList GetAllShops()
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                ICriteria shops = session.CreateCriteria(typeof(ShopShop)).AddOrder(new Order(this._shopSortBy.ToString(),this._shopSortASC));
              
                return shops.List();
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get shop " + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		/// <summary>
		/// The property to sort the links by.
		/// </summary>
		public enum ShopSortBy
		{
			/// <summary>
			/// Sort by Name.
			/// </summary>
			Name,
			/// <summary>
			/// Sort by the user who created the article.
			/// </summary>
			CreatedBy,
			/// <summary>
			/// Sort by the user who modified the article most recently.
			/// </summary>
			ModifiedBy,
			/// <summary>
			/// Don't sort the articles.
			/// </summary>
			None
		}

		#endregion

		#region Category

		//
		/// <summary>
		/// 
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public IList GetAllCategories()
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                ICriteria shops = session.CreateCriteria(typeof(ShopCategory)).AddOrder(new Order(this._categorySortBy.ToString(), this._categorySortASC));

                return shops.List();
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get shop categories " + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}


		/// <summary>
		/// Get the meta-information of a single file.
		/// </summary>
		/// <param name="fileId"></param>
		/// <returns></returns>
		public ShopCategory GetShopCategoryById(int id)
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                return (ShopCategory)session.Load(typeof(ShopCategory), id);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to get Shop category identifier: " + id.ToString(), ex);
			}
		}

        [Transaction(TransactionMode.RequiresNew)]
        public virtual void SaveShopCategory(ShopCategory shopcategory)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(shopcategory);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to save Shop category" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		/// <summary>
		/// Delete the meta-information of a file
		/// </summary>
        [Transaction(TransactionMode.RequiresNew)]
        public virtual void DeleteShopCategory(ShopCategory shopcategory)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.Delete(shopcategory);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to delete Shop category" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		/// <summary>
		/// The property to sort the links by.
		/// </summary>
		public enum CategorySortBy
		{
			/// <summary>
			/// Sort by Name.
			/// </summary>
			Name,
			/// <summary>
			/// Sort by the user who created the article.
			/// </summary>
			CreatedBy,
			/// <summary>
			/// Sort by the user who modified the article most recently.
			/// </summary>
			ModifiedBy,
			/// <summary>
			/// Don't sort the articles.
			/// </summary>
			None
		}

		#endregion

		#region Products
		/// <summary>
		/// 
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public IList GetAllShopProducts(int shopid)
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                ICriteria shopproducts = session.CreateCriteria(typeof(ShopProduct)).Add(NHibernate.Expression.Expression.Eq("ShopId", shopid));
                shopproducts.AddOrder(new Order(this._shopProductSortBy.ToString(), this._productSortASC));

                return shopproducts.List();
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get shop products", ex);
			}
		}

        [Transaction(TransactionMode.RequiresNew)]
        public virtual void SaveShopProduct(ShopProduct shopproduct)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(shopproduct);
                tx.Commit();
                session.Close(); 
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to save Shop product" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}


        [Transaction(TransactionMode.RequiresNew)]
        public virtual void SaveShopComment(ShopComment shopcomment)
        {
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(shopcomment);
                tx.Commit();
                session.Close();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw new Exception("Unable to save Shop comment" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
            }
        }

		/// <summary>
		/// Get the meta-information of a single file.
		/// </summary>
		/// <param name="fileId"></param>
		/// <returns></returns>
		public ShopProduct GetShopProductById(int id)
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                return (ShopProduct)session.Load(typeof(ShopProduct), id);
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get Shop product identifier: " + id.ToString(), ex);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public IList GetAllShopProductComments(int productid)
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                ICriteria shopcomments = session.CreateCriteria(typeof(ShopComment)).Add(NHibernate.Expression.Expression.Eq("ProductId", productid));
                shopcomments.AddOrder(new Order(this._shopProductSortBy.ToString(), this._productSortASC));

                return shopcomments.List();
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get shop product comments" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

        [Transaction(TransactionMode.RequiresNew)]
        public virtual void DeleteShopProduct(ShopProduct product)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.Delete(product);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to delete Shop product" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		public IList SearchShopProducts(string searchString)
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                string hql;
				hql = "from ShopProduct f where f.Message like :sv order by f.DateCreated ";
                IQuery q = session.CreateQuery(hql);
				q.SetString("sv", "%" + searchString + "%");
				return q.List();
			}
			catch(Exception ex)
			{
				throw new Exception("Unable to search!",ex);
			}
		}

		public enum ShopProductSortBy
		{
			Title,
			DateCreated,
			DateModified,
			UserName,
			None
		}

		#endregion

		#region Emoticons
		public ShopEmoticon GetEmoticonById(int eId)
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                return (ShopEmoticon)session.Load(typeof(ShopEmoticon), eId);
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get emoticon by id" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		public IList GetAllEmoticons()
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                IList emoticons = session.CreateCriteria(typeof(ShopEmoticon)).List();
                return emoticons;
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get emoticons " + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}


        [Transaction(TransactionMode.RequiresNew)]
        public void SaveEmoticon(ShopEmoticon emoticon)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(emoticon);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to save Emoticon " + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		/// <summary>
		/// Delete the meta-information of a file
		/// </summary>
        [Transaction(TransactionMode.RequiresNew)]
        public void DeleteEmoticon(ShopEmoticon emoticon)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.Delete(emoticon);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to delete Emoticon" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		#endregion

		#region Tag
		public ShopTag GetTagById(int tId)
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                return (ShopTag)session.Load(typeof(ShopTag), tId);
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get tag by id" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		public IList GetAllTags()
		{
            ISession session = this._sessionManager.OpenSession();
            try
			{
                IList tags = session.CreateCriteria(typeof(ShopTag)).List();
                return tags;			
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get tags " + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}


        [Transaction(TransactionMode.RequiresNew)]
        public void SaveTag(ShopTag tag)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(tag);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to save Tag " + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

        [Transaction(TransactionMode.RequiresNew)]
        public void DeleteTag(ShopTag tag)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.Delete(tag);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to delete Tag" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		#endregion

		#region Shop user address

        public IList GetShopUserAddress(Cuyahoga.Core.Domain.User user)
		{
            IList addressList;
            ISession session = this._sessionManager.OpenSession();
            try
            {

                ICriteria criteria = session.CreateCriteria(typeof(ShopUserAddress)).Add(Expression.Eq("User", user));
                addressList = criteria.List();


                return addressList;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get address for user " + user.Name, ex);
            }
		}


        /// <summary>
        /// Get the meta-information for user address.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public ShopUserAddress GetShopUserAddress(int id)
        {
            ISession session = this._sessionManager.OpenSession();
            try
            {
                return (ShopUserAddress)session.Load(typeof(ShopUserAddress), id);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Shop user address for identifier: " + id.ToString(), ex);
            }
        }

        [Transaction(TransactionMode.RequiresNew)]
        public void SaveShopUserAddress(ShopUserAddress address)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(address);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to save address " + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

        [Transaction(TransactionMode.RequiresNew)]
        public void DeleteShopUserAddress(ShopUserAddress address)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.Delete(address);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to delete address" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		#endregion


        #region Orders


        [Transaction(TransactionMode.RequiresNew)]
        public virtual void SaveOrder(ShopOrder order)
        {
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(order);
                tx.Commit();
                session.Close();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw new Exception("Unable to save order", ex);
            }
        }


        private IList GetOrders(int userid)
        {
            IList orders;
            ISession session = this._sessionManager.OpenSession();
            try
            {
                ICriteria criteria = session.CreateCriteria(typeof(ShopOrder)).Add(NHibernate.Expression.Expression.Eq("userid", userid));
                orders = criteria.List();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get orders for user " + userid, ex);
            }
            return orders;
        }

        private IList GetOrders(int userid, ShopOrderState state)
        {
            IList orders;
            ISession session = this._sessionManager.OpenSession();
            try
            {

                ICriteria criteria = session.CreateCriteria(typeof(ShopOrder)).Add(Expression.Eq("userid", userid));
                criteria.Add(Expression.Eq("OrderState", state));
                orders = criteria.List();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get orders for user " + userid + " and state " + state.Name, ex);
            }
            return orders;
        }


        public void SetCurrentOrder(Cuyahoga.Core.Domain.User owner)
        {
            IList orders;
            ISession session = this._sessionManager.OpenSession();
            try
            {

                ICriteria criteria = session.CreateCriteria(typeof(ShopOrder)).Add(Expression.Eq("Owner", owner));
                criteria.Add(Expression.Eq("OrderState", this.GetOrderState(1)));
                orders = criteria.List();
                if (orders.Count > 0)
                {
                    this.CurrentShopOrder = (ShopOrder)orders[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get orders for user " + owner.Id, ex);
            }
        }


        #endregion

        #region OrderLines


        /// <summary>
        /// Get the meta-information for one ShopOrderLine.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public ShopOrderLine GetShopOrderLine(int id)
        {
            ISession session = this._sessionManager.OpenSession();
            try
            {
                return (ShopOrderLine)session.Load(typeof(ShopOrderLine), id);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get ShopOrderLine by identifier: " + id.ToString(), ex);
            }
        }


        #endregion

        #region OrderState


        /// <summary>
        /// Get the meta-information for one orderstate.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public ShopOrderState GetOrderState(int id)
        {
            ISession session = this._sessionManager.OpenSession();
            try
            {
                return (ShopOrderState)session.Load(typeof(ShopOrderState), id);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Shop order state by identifier: " + id.ToString(), ex);
            }
        }


        #endregion

		#region Shop images
        [Transaction(TransactionMode.RequiresNew)]
        public virtual void SaveShopImage(ShopImage shopimage)
		{
            ISession session = this._sessionManager.OpenSession();
            NHibernate.ITransaction tx = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(shopimage);
                tx.Commit();
                session.Close();
			}
			catch (Exception ex)
			{
                tx.Rollback();
                throw new Exception("Unable to save Shop file" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

		public ShopImage GetShopImageById(int id)
		{
            ISession session = this._sessionManager.OpenSession();

			try
			{
                return (ShopImage)session.Load(typeof(ShopImage), id);
			}
			catch (Exception ex)
			{
                throw new Exception("Unable to get form file by id" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IList GetAllShopProductImages(int productid)
        {
            ISession session = this._sessionManager.OpenSession();
            try
            {
                ICriteria shopImages = session.CreateCriteria(typeof(ShopImage)).Add(NHibernate.Expression.Expression.Eq("ProductId", productid));

                return shopImages.List();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get shop product images" + "<br>" + ex.Message + "<br>" + ex.InnerException, ex);
            }
        }



		#endregion



        public enum SortDirection
		{
			DESC,
			ASC
		}
	}


	/// <summary>
	/// 
	/// </summary>
	public enum ShopModuleAction
	{
		/// <summary>
		/// 
		/// </summary>
		ShopList,
		/// <summary>
		/// 
		/// </summary>
		ShopCategoryList,
		/// <summary>
		/// 
		/// </summary>
		ShopView,
		/// <summary>
		/// 
		/// </summary>
		ShopNewProduct,
		ShopViewProduct,
		ShopNewComment,
		ShopNewCommentQuote,
		ShopSearch,
		ShopProfile,
		ShopViewProfile,
        ShopCaddy
	}

    /// <summary>
    /// The display mode of the module.
    /// </summary>
    public enum CheckoutType
    {
        Email,
        PayPal
    }

}
