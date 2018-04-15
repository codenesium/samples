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
		protected IObjectMapper mapper;

		public AbstractShoppingCartItemRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ShoppingCartItemModel model)
		{
			var record = new EFShoppingCartItem();

			this.mapper.ShoppingCartItemMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFShoppingCartItem>().Add(record);
			this.context.SaveChanges();
			return record.ShoppingCartItemID;
		}

		public virtual void Update(
			int shoppingCartItemID,
			ShoppingCartItemModel model)
		{
			var record = this.SearchLinqEF(x => x.ShoppingCartItemID == shoppingCartItemID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{shoppingCartItemID}");
			}
			else
			{
				this.mapper.ShoppingCartItemMapModelToEF(
					shoppingCartItemID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int shoppingCartItemID)
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

		public virtual ApiResponse GetById(int shoppingCartItemID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ShoppingCartItemID == shoppingCartItemID, response);
			return response;
		}

		public virtual POCOShoppingCartItem GetByIdDirect(int shoppingCartItemID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ShoppingCartItemID == shoppingCartItemID, response);
			return response.ShoppingCartItems.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOShoppingCartItem> GetWhereDirect(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ShoppingCartItems;
		}

		private void SearchLinqPOCO(Expression<Func<EFShoppingCartItem, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFShoppingCartItem> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ShoppingCartItemMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFShoppingCartItem> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ShoppingCartItemMapEFToPOCO(x, response));
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
    <Hash>04e2f378de7fc4fa6e8e25132d82685c</Hash>
</Codenesium>*/