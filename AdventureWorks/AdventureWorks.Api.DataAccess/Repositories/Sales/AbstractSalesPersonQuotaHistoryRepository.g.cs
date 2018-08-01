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
	public abstract class AbstractSalesPersonQuotaHistoryRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSalesPersonQuotaHistoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SalesPersonQuotaHistory>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SalesPersonQuotaHistory> Get(int businessEntityID)
		{
			return await this.GetById(businessEntityID);
		}

		public async virtual Task<SalesPersonQuotaHistory> Create(SalesPersonQuotaHistory item)
		{
			this.Context.Set<SalesPersonQuotaHistory>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SalesPersonQuotaHistory item)
		{
			var entity = this.Context.Set<SalesPersonQuotaHistory>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
			if (entity == null)
			{
				this.Context.Set<SalesPersonQuotaHistory>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			SalesPersonQuotaHistory record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesPersonQuotaHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<SalesPerson> GetSalesPerson(int businessEntityID)
		{
			return await this.Context.Set<SalesPerson>().SingleOrDefaultAsync(x => x.BusinessEntityID == businessEntityID);
		}

		protected async Task<List<SalesPersonQuotaHistory>> Where(
			Expression<Func<SalesPersonQuotaHistory, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SalesPersonQuotaHistory, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BusinessEntityID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<SalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesPersonQuotaHistory>();
			}
			else
			{
				return await this.Context.Set<SalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SalesPersonQuotaHistory>();
			}
		}

		private async Task<SalesPersonQuotaHistory> GetById(int businessEntityID)
		{
			List<SalesPersonQuotaHistory> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7257fbf11ab0718c14ad20e45d3fe8d0</Hash>
</Codenesium>*/