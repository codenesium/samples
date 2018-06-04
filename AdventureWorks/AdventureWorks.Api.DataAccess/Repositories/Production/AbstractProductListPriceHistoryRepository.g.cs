using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductListPriceHistoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractProductListPriceHistoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductListPriceHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<ProductListPriceHistory> Get(int productID)
		{
			return await this.GetById(productID);
		}

		public async virtual Task<ProductListPriceHistory> Create(ProductListPriceHistory item)
		{
			this.Context.Set<ProductListPriceHistory>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductListPriceHistory item)
		{
			var entity = this.Context.Set<ProductListPriceHistory>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
			if (entity == null)
			{
				this.Context.Set<ProductListPriceHistory>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productID)
		{
			ProductListPriceHistory record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductListPriceHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<ProductListPriceHistory>> Where(Expression<Func<ProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<ProductListPriceHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<ProductListPriceHistory>> SearchLinqEF(Expression<Func<ProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductListPriceHistory.ProductID)} ASC";
			}
			return await this.Context.Set<ProductListPriceHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductListPriceHistory>();
		}

		private async Task<List<ProductListPriceHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductListPriceHistory.ProductID)} ASC";
			}

			return await this.Context.Set<ProductListPriceHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductListPriceHistory>();
		}

		private async Task<ProductListPriceHistory> GetById(int productID)
		{
			List<ProductListPriceHistory> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5d4aa71f0d7b1e09653665f75c0e6dcc</Hash>
</Codenesium>*/