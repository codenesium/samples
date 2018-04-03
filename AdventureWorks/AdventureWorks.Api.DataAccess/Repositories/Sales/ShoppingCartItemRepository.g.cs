using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShoppingCartItemRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractShoppingCartItemRepository(ILogger logger,
		                                          ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string shoppingCartID,
		                          int quantity,
		                          int productID,
		                          DateTime dateCreated,
		                          DateTime modifiedDate)
		{
			var record = new EFShoppingCartItem ();

			MapPOCOToEF(0, shoppingCartID,
			            quantity,
			            productID,
			            dateCreated,
			            modifiedDate, record);

			this._context.Set<EFShoppingCartItem>().Add(record);
			this._context.SaveChanges();
			return record.shoppingCartItemID;
		}

		public virtual void Update(int shoppingCartItemID, string shoppingCartID,
		                           int quantity,
		                           int productID,
		                           DateTime dateCreated,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.shoppingCartItemID == shoppingCartItemID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",shoppingCartItemID);
			}
			else
			{
				MapPOCOToEF(shoppingCartItemID,  shoppingCartID,
				            quantity,
				            productID,
				            dateCreated,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int shoppingCartItemID)
		{
			var record = this.SearchLinqEF(x => x.shoppingCartItemID == shoppingCartItemID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFShoppingCartItem>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int shoppingCartItemID, Response response)
		{
			this.SearchLinqPOCO(x => x.shoppingCartItemID == shoppingCartItemID,response);
		}

		protected virtual List<EFShoppingCartItem> SearchLinqEF(Expression<Func<EFShoppingCartItem, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFShoppingCartItem> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFShoppingCartItem, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFShoppingCartItem, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFShoppingCartItem> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFShoppingCartItem> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int shoppingCartItemID, string shoppingCartID,
		                               int quantity,
		                               int productID,
		                               DateTime dateCreated,
		                               DateTime modifiedDate, EFShoppingCartItem   efShoppingCartItem)
		{
			efShoppingCartItem.shoppingCartItemID = shoppingCartItemID;
			efShoppingCartItem.shoppingCartID = shoppingCartID;
			efShoppingCartItem.quantity = quantity;
			efShoppingCartItem.productID = productID;
			efShoppingCartItem.dateCreated = dateCreated;
			efShoppingCartItem.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFShoppingCartItem efShoppingCartItem,Response response)
		{
			if(efShoppingCartItem == null)
			{
				return;
			}
			response.AddShoppingCartItem(new POCOShoppingCartItem()
			{
				ShoppingCartItemID = efShoppingCartItem.shoppingCartItemID.ToInt(),
				ShoppingCartID = efShoppingCartItem.shoppingCartID,
				Quantity = efShoppingCartItem.quantity.ToInt(),
				ProductID = efShoppingCartItem.productID.ToInt(),
				DateCreated = efShoppingCartItem.dateCreated.ToDateTime(),
				ModifiedDate = efShoppingCartItem.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>679da0ecce76b0cae2221cecf625e66d</Hash>
</Codenesium>*/