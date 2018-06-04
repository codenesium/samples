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
	public abstract class AbstractSalesOrderHeaderSalesReasonRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractSalesOrderHeaderSalesReasonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SalesOrderHeaderSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<SalesOrderHeaderSalesReason> Get(int salesOrderID)
		{
			return await this.GetById(salesOrderID);
		}

		public async virtual Task<SalesOrderHeaderSalesReason> Create(SalesOrderHeaderSalesReason item)
		{
			this.Context.Set<SalesOrderHeaderSalesReason>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SalesOrderHeaderSalesReason item)
		{
			var entity = this.Context.Set<SalesOrderHeaderSalesReason>().Local.FirstOrDefault(x => x.SalesOrderID == item.SalesOrderID);
			if (entity == null)
			{
				this.Context.Set<SalesOrderHeaderSalesReason>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int salesOrderID)
		{
			SalesOrderHeaderSalesReason record = await this.GetById(salesOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderHeaderSalesReason>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<SalesOrderHeaderSalesReason>> Where(Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<SalesOrderHeaderSalesReason> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<SalesOrderHeaderSalesReason>> SearchLinqEF(Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeaderSalesReason.SalesOrderID)} ASC";
			}
			return await this.Context.Set<SalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderHeaderSalesReason>();
		}

		private async Task<List<SalesOrderHeaderSalesReason>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeaderSalesReason.SalesOrderID)} ASC";
			}

			return await this.Context.Set<SalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderHeaderSalesReason>();
		}

		private async Task<SalesOrderHeaderSalesReason> GetById(int salesOrderID)
		{
			List<SalesOrderHeaderSalesReason> records = await this.SearchLinqEF(x => x.SalesOrderID == salesOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a8342390ffef3701fbc19309ef5bcab5</Hash>
</Codenesium>*/