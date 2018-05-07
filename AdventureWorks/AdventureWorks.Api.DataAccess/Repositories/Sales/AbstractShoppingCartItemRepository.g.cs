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

		public virtual POCOShoppingCartItem Get(int shoppingCartItemID)
		{
			return this.SearchLinqPOCO(x => x.ShoppingCartItemID == shoppingCartItemID).FirstOrDefault();
		}

		public virtual List<POCOShoppingCartItem> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOShoppingCartItem> Where(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOShoppingCartItem> SearchLinqPOCO(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShoppingCartItem> response = new List<POCOShoppingCartItem>();
			List<EFShoppingCartItem> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ShoppingCartItemMapEFToPOCO(x)));
			return response;
		}

		private List<EFShoppingCartItem> SearchLinqEF(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy("ShoppingCartItemID ASC").Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
			else
			{
				return this.Context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
		}

		private List<EFShoppingCartItem> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy("ShoppingCartItemID ASC").Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
			else
			{
				return this.Context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>56b3014af6ee6b1caa2b57558b580d2a</Hash>
</Codenesium>*/