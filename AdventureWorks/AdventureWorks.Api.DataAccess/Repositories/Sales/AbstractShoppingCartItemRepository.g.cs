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

		public virtual List<POCOShoppingCartItem> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOShoppingCartItem Get(int shoppingCartItemID)
		{
			return this.SearchLinqPOCO(x => x.ShoppingCartItemID == shoppingCartItemID).FirstOrDefault();
		}

		public virtual POCOShoppingCartItem Create(
			ApiShoppingCartItemModel model)
		{
			ShoppingCartItem record = new ShoppingCartItem();

			this.Mapper.ShoppingCartItemMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ShoppingCartItem>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ShoppingCartItemMapEFToPOCO(record);
		}

		public virtual void Update(
			int shoppingCartItemID,
			ApiShoppingCartItemModel model)
		{
			ShoppingCartItem record = this.SearchLinqEF(x => x.ShoppingCartItemID == shoppingCartItemID).FirstOrDefault();
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
			ShoppingCartItem record = this.SearchLinqEF(x => x.ShoppingCartItemID == shoppingCartItemID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ShoppingCartItem>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOShoppingCartItem> GetShoppingCartIDProductID(string shoppingCartID,int productID)
		{
			return this.SearchLinqPOCO(x => x.ShoppingCartID == shoppingCartID && x.ProductID == productID);
		}

		protected List<POCOShoppingCartItem> Where(Expression<Func<ShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOShoppingCartItem> SearchLinqPOCO(Expression<Func<ShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShoppingCartItem> response = new List<POCOShoppingCartItem>();
			List<ShoppingCartItem> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ShoppingCartItemMapEFToPOCO(x)));
			return response;
		}

		private List<ShoppingCartItem> SearchLinqEF(Expression<Func<ShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ShoppingCartItem.ShoppingCartItemID)} ASC";
			}
			return this.Context.Set<ShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ShoppingCartItem>();
		}

		private List<ShoppingCartItem> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ShoppingCartItem.ShoppingCartItemID)} ASC";
			}

			return this.Context.Set<ShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ShoppingCartItem>();
		}
	}
}

/*<Codenesium>
    <Hash>974ee0e811b124c2e58c9c68a3e1ca2b</Hash>
</Codenesium>*/