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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractShoppingCartItemRepository(ILogger logger,
		                                          ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFShoppingCartItem>().Add(record);
			this.context.SaveChanges();
			return record.ShoppingCartItemID;
		}

		public virtual void Update(int shoppingCartItemID, string shoppingCartID,
		                           int quantity,
		                           int productID,
		                           DateTime dateCreated,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ShoppingCartItemID == shoppingCartItemID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",shoppingCartItemID);
			}
			else
			{
				MapPOCOToEF(shoppingCartItemID,  shoppingCartID,
				            quantity,
				            productID,
				            dateCreated,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int shoppingCartItemID)
		{
			var record = this.SearchLinqEF(x => x.ShoppingCartItemID == shoppingCartItemID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFShoppingCartItem>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int shoppingCartItemID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ShoppingCartItemID == shoppingCartItemID,response);
			return response;
		}

		public virtual POCOShoppingCartItem GetByIdDirect(int shoppingCartItemID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ShoppingCartItemID == shoppingCartItemID,response);
			return response.ShoppingCartItems.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOShoppingCartItem> GetWhereDirect(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ShoppingCartItems;
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

		protected virtual List<EFShoppingCartItem> SearchLinqEF(Expression<Func<EFShoppingCartItem, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFShoppingCartItem> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int shoppingCartItemID, string shoppingCartID,
		                               int quantity,
		                               int productID,
		                               DateTime dateCreated,
		                               DateTime modifiedDate, EFShoppingCartItem   efShoppingCartItem)
		{
			efShoppingCartItem.ShoppingCartItemID = shoppingCartItemID;
			efShoppingCartItem.ShoppingCartID = shoppingCartID;
			efShoppingCartItem.Quantity = quantity;
			efShoppingCartItem.ProductID = productID;
			efShoppingCartItem.DateCreated = dateCreated;
			efShoppingCartItem.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFShoppingCartItem efShoppingCartItem,Response response)
		{
			if(efShoppingCartItem == null)
			{
				return;
			}
			response.AddShoppingCartItem(new POCOShoppingCartItem()
			{
				ShoppingCartItemID = efShoppingCartItem.ShoppingCartItemID.ToInt(),
				ShoppingCartID = efShoppingCartItem.ShoppingCartID,
				Quantity = efShoppingCartItem.Quantity.ToInt(),
				DateCreated = efShoppingCartItem.DateCreated.ToDateTime(),
				ModifiedDate = efShoppingCartItem.ModifiedDate.ToDateTime(),

				ProductID = new ReferenceEntity<int>(efShoppingCartItem.ProductID,
				                                     "Products"),
			});

			ProductRepository.MapEFToPOCO(efShoppingCartItem.Product, response);
		}
	}
}

/*<Codenesium>
    <Hash>a4c44ea2465aa7de0fa829117ef40767</Hash>
</Codenesium>*/