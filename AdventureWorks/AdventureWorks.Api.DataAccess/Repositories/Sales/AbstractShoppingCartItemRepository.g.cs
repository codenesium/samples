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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractShoppingCartItemRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ShoppingCartItemModel model)
		{
			EFShoppingCartItem record = new EFShoppingCartItem();

			this.Mapper.ShoppingCartItemMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFShoppingCartItem>().Add(record);
			this.Context.SaveChanges();
			return record.ShoppingCartItemID;
		}

		public virtual void Update(
			int shoppingCartItemID,
			ShoppingCartItemModel model)
		{
			EFShoppingCartItem record = this.SearchLinqEF(x => x.ShoppingCartItemID == shoppingCartItemID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{shoppingCartItemID}");
			}
			else
			{
				this.Mapper.ShoppingCartItemMapModelToEF(
					shoppingCartItemID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int shoppingCartItemID)
		{
			EFShoppingCartItem record = this.SearchLinqEF(x => x.ShoppingCartItemID == shoppingCartItemID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFShoppingCartItem>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int shoppingCartItemID)
		{
			return this.SearchLinqPOCO(x => x.ShoppingCartItemID == shoppingCartItemID);
		}

		public virtual POCOShoppingCartItem GetByIdDirect(int shoppingCartItemID)
		{
			return this.SearchLinqPOCO(x => x.ShoppingCartItemID == shoppingCartItemID).ShoppingCartItems.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOShoppingCartItem> GetWhereDirect(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ShoppingCartItems;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFShoppingCartItem> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ShoppingCartItemMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFShoppingCartItem> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ShoppingCartItemMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFShoppingCartItem> SearchLinqEF(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFShoppingCartItem> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>3c7f0d16321398a5cc1f185044ecccf2</Hash>
</Codenesium>*/