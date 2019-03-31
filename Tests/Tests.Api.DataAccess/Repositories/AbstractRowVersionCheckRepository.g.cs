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

namespace TestsNS.Api.DataAccess
{
	public abstract class AbstractRowVersionCheckRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractRowVersionCheckRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<RowVersionCheck>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Name.StartsWith(query) ||
				                  x.RowVersion == query.ToGuid(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<RowVersionCheck> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<RowVersionCheck> Create(RowVersionCheck item)
		{
			this.Context.Set<RowVersionCheck>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(RowVersionCheck item)
		{
			var entity = this.Context.Set<RowVersionCheck>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<RowVersionCheck>().Attach(item);
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
			RowVersionCheck record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<RowVersionCheck>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<RowVersionCheck>> Where(
			Expression<Func<RowVersionCheck, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<RowVersionCheck, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<RowVersionCheck>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<RowVersionCheck>();
		}

		private async Task<RowVersionCheck> GetById(int id)
		{
			List<RowVersionCheck> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>83220eae6859efb3b75b557b1df0f614</Hash>
</Codenesium>*/