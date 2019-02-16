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
	public abstract class AbstractDatabaseLogRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractDatabaseLogRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DatabaseLog>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.DatabaseLogID == query.ToInt() ||
				                  x.DatabaseUser.StartsWith(query) ||
				                  x.PostTime == query.ToDateTime() ||
				                  x.Schema.StartsWith(query) ||
				                  x.Tsql.StartsWith(query) ||
				                  x.XmlEvent.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<DatabaseLog> Get(int databaseLogID)
		{
			return await this.GetById(databaseLogID);
		}

		public async virtual Task<DatabaseLog> Create(DatabaseLog item)
		{
			this.Context.Set<DatabaseLog>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(DatabaseLog item)
		{
			var entity = this.Context.Set<DatabaseLog>().Local.FirstOrDefault(x => x.DatabaseLogID == item.DatabaseLogID);
			if (entity == null)
			{
				this.Context.Set<DatabaseLog>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int databaseLogID)
		{
			DatabaseLog record = await this.GetById(databaseLogID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<DatabaseLog>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DatabaseLog>> Where(
			Expression<Func<DatabaseLog, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<DatabaseLog, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.DatabaseLogID;
			}

			return await this.Context.Set<DatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<DatabaseLog>();
		}

		private async Task<DatabaseLog> GetById(int databaseLogID)
		{
			List<DatabaseLog> records = await this.Where(x => x.DatabaseLogID == databaseLogID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>bf193af4b114a9727ebdfc8472742e24</Hash>
</Codenesium>*/