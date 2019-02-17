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

		public virtual Task<List<SalesReason>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.Name.StartsWith(query) ||
				                  x.ReasonType.StartsWith(query) ||
				                  x.SalesReasonID == query.ToInt(),
				                  limit,
				                  offset);
			}
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

		protected async Task<List<SalesReason>> Where(
			Expression<Func<SalesReason, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SalesReason, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.SalesReasonID;
			}

			return await this.Context.Set<SalesReason>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesReason>();
		}

		private async Task<SalesReason> GetById(int salesReasonID)
		{
			List<SalesReason> records = await this.Where(x => x.SalesReasonID == salesReasonID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0ab05eee34eec3455ac4ec24c7d0fa98</Hash>
</Codenesium>*/