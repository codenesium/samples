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
	public abstract class AbstractProductCostHistoryRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductCostHistoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductCostHistory>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ProductCostHistory> Get(int productID)
		{
			return await this.GetById(productID);
		}

		public async virtual Task<ProductCostHistory> Create(ProductCostHistory item)
		{
			this.Context.Set<ProductCostHistory>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductCostHistory item)
		{
			var entity = this.Context.Set<ProductCostHistory>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
			if (entity == null)
			{
				this.Context.Set<ProductCostHistory>().Attach(item);
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
			ProductCostHistory record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductCostHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<ProductCostHistory>> Where(
			Expression<Func<ProductCostHistory, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductCostHistory, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ProductCostHistory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductCostHistory>();
			}
			else
			{
				return await this.Context.Set<ProductCostHistory>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProductCostHistory>();
			}
		}

		private async Task<ProductCostHistory> GetById(int productID)
		{
			List<ProductCostHistory> records = await this.Where(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>58aaeec4e1c3e4c7d30b9a75b9e11ee7</Hash>
</Codenesium>*/