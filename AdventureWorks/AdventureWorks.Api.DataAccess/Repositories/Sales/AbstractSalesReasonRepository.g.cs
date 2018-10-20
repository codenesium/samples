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
	public abstract class AbstractSalesReasonRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSalesReasonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SalesReason>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async virtual Task<List<SalesReason>> BySalesOrderID(int salesOrderID, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.SalesOrderHeaderSalesReasons
			              join salesReasons in this.Context.SalesReasons on
			              refTable.SalesReasonID equals salesReasons.SalesReasonID
			              where refTable.SalesOrderID == salesOrderID
			              select salesReasons).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<SalesReason>> Where(
			Expression<Func<SalesReason, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SalesReason, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.SalesReasonID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<SalesReason>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesReason>();
			}
			else
			{
				return await this.Context.Set<SalesReason>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SalesReason>();
			}
		}

		private async Task<SalesReason> GetById(int salesReasonID)
		{
			List<SalesReason> records = await this.Where(x => x.SalesReasonID == salesReasonID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>58f3f65525fd85c3a92ca1f5bd7c0103</Hash>
</Codenesium>*/