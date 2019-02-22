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

namespace CADNS.Api.DataAccess
{
	public abstract class AbstractCallStatuRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCallStatuRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CallStatu>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<CallStatu> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<CallStatu> Create(CallStatu item)
		{
			this.Context.Set<CallStatu>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CallStatu item)
		{
			var entity = this.Context.Set<CallStatu>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<CallStatu>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int id)
		{
			CallStatu record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CallStatu>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Call via callStatusId.
		public async virtual Task<List<Call>> CallsByCallStatusId(int callStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Call>()
			       .Include(x => x.CallStatusIdNavigation)
			       .Where(x => x.CallStatusId == callStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Call>();
		}

		protected async Task<List<CallStatu>> Where(
			Expression<Func<CallStatu, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CallStatu, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<CallStatu>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CallStatu>();
		}

		private async Task<CallStatu> GetById(int id)
		{
			List<CallStatu> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a3ea30e75ce65b544b97449e35d6f6f2</Hash>
</Codenesium>*/