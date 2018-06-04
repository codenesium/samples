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
	public abstract class AbstractSalesReasonRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractSalesReasonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<SalesReason> Get(int salesReasonID)
		{
			return await this.GetById(salesReasonID);
		}

		public async virtual Task<SalesReason> Create(SalesReason item)
		{
			this.Context.Set<SalesReason>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SalesReason item)
		{
			var entity = this.Context.Set<SalesReason>().Local.FirstOrDefault(x => x.SalesReasonID == item.SalesReasonID);
			if (entity == null)
			{
				this.Context.Set<SalesReason>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int salesReasonID)
		{
			SalesReason record = await this.GetById(salesReasonID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesReason>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<SalesReason>> Where(Expression<Func<SalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<SalesReason> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<SalesReason>> SearchLinqEF(Expression<Func<SalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesReason.SalesReasonID)} ASC";
			}
			return await this.Context.Set<SalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesReason>();
		}

		private async Task<List<SalesReason>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesReason.SalesReasonID)} ASC";
			}

			return await this.Context.Set<SalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesReason>();
		}

		private async Task<SalesReason> GetById(int salesReasonID)
		{
			List<SalesReason> records = await this.SearchLinqEF(x => x.SalesReasonID == salesReasonID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d5dbe1612d38112fa2251f71224be8a7</Hash>
</Codenesium>*/