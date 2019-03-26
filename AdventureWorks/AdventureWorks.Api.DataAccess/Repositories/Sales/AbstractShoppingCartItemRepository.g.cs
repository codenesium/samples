using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShoppingCartItemRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractShoppingCartItemRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ShoppingCartItem>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.DateCreated == query.ToDateTime() ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.ProductID == query.ToInt() ||
				                  x.Quantity == query.ToInt() ||
				                  x.ShoppingCartID.StartsWith(query) ||
				                  x.ShoppingCartItemID == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<ShoppingCartItem> Get(int shoppingCartItemID)
		{
			return await this.GetById(shoppingCartItemID);
		}

		public async virtual Task<ShoppingCartItem> Create(ShoppingCartItem item)
		{
			this.Context.Set<ShoppingCartItem>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ShoppingCartItem item)
		{
			var entity = this.Context.Set<ShoppingCartItem>().Local.FirstOrDefault(x => x.ShoppingCartItemID == item.ShoppingCartItemID);
			if (entity == null)
			{
				this.Context.Set<ShoppingCartItem>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int shoppingCartItemID)
		{
			ShoppingCartItem record = await this.GetById(shoppingCartItemID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ShoppingCartItem>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_ShoppingCartItem_ShoppingCartID_ProductID.
		public async virtual Task<List<ShoppingCartItem>> ByShoppingCartIDProductID(string shoppingCartID, int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ShoppingCartID == shoppingCartID && x.ProductID == productID, limit, offset);
		}

		protected async Task<List<ShoppingCartItem>> Where(
			Expression<Func<ShoppingCartItem, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ShoppingCartItem, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ShoppingCartItemID;
			}

			return await this.Context.Set<ShoppingCartItem>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ShoppingCartItem>();
		}

		private async Task<ShoppingCartItem> GetById(int shoppingCartItemID)
		{
			List<ShoppingCartItem> records = await this.Where(x => x.ShoppingCartItemID == shoppingCartItemID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d766276214a67829e12270bd49981167</Hash>
</Codenesium>*/