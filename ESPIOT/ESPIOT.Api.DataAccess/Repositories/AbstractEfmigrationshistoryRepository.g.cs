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

namespace ESPIOTNS.Api.DataAccess
{
	public abstract class AbstractEfmigrationshistoryRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractEfmigrationshistoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Efmigrationshistory>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Efmigrationshistory> Get(string migrationId)
		{
			return await this.GetById(migrationId);
		}

		public async virtual Task<Efmigrationshistory> Create(Efmigrationshistory item)
		{
			this.Context.Set<Efmigrationshistory>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Efmigrationshistory item)
		{
			var entity = this.Context.Set<Efmigrationshistory>().Local.FirstOrDefault(x => x.MigrationId == item.MigrationId);
			if (entity == null)
			{
				this.Context.Set<Efmigrationshistory>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			string migrationId)
		{
			Efmigrationshistory record = await this.GetById(migrationId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Efmigrationshistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Efmigrationshistory>> Where(
			Expression<Func<Efmigrationshistory, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Efmigrationshistory, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.MigrationId;
			}

			return await this.Context.Set<Efmigrationshistory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Efmigrationshistory>();
		}

		private async Task<Efmigrationshistory> GetById(string migrationId)
		{
			List<Efmigrationshistory> records = await this.Where(x => x.MigrationId == migrationId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d33c7da6c610f0c3c72514caf9d0fd0c</Hash>
</Codenesium>*/