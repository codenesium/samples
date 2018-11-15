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
	public abstract class AbstractCompositePrimaryKeyRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCompositePrimaryKeyRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CompositePrimaryKey>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<CompositePrimaryKey> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<CompositePrimaryKey> Create(CompositePrimaryKey item)
		{
			this.Context.Set<CompositePrimaryKey>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CompositePrimaryKey item)
		{
			var entity = this.Context.Set<CompositePrimaryKey>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<CompositePrimaryKey>().Attach(item);
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
			CompositePrimaryKey record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CompositePrimaryKey>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<CompositePrimaryKey>> Where(
			Expression<Func<CompositePrimaryKey, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CompositePrimaryKey, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<CompositePrimaryKey>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CompositePrimaryKey>();
		}

		private async Task<CompositePrimaryKey> GetById(int id)
		{
			List<CompositePrimaryKey> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>750ff3b4f226b50d559ccdb71dcb5a9b</Hash>
</Codenesium>*/