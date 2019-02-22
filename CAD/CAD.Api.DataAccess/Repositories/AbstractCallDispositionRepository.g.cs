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
	public abstract class AbstractCallDispositionRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCallDispositionRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CallDisposition>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<CallDisposition> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<CallDisposition> Create(CallDisposition item)
		{
			this.Context.Set<CallDisposition>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CallDisposition item)
		{
			var entity = this.Context.Set<CallDisposition>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<CallDisposition>().Attach(item);
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
			CallDisposition record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CallDisposition>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Call via callDispositionId.
		public async virtual Task<List<Call>> CallsByCallDispositionId(int callDispositionId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Call>()
			       .Include(x => x.CallDispositionIdNavigation)
			       .Where(x => x.CallDispositionId == callDispositionId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Call>();
		}

		protected async Task<List<CallDisposition>> Where(
			Expression<Func<CallDisposition, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CallDisposition, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<CallDisposition>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CallDisposition>();
		}

		private async Task<CallDisposition> GetById(int id)
		{
			List<CallDisposition> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>abfb66a8c0ac2249fcfa6385f0836fce</Hash>
</Codenesium>*/