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

namespace OctopusDeployNS.Api.DataAccess
{
	public abstract class AbstractWorkerPoolRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractWorkerPoolRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<WorkerPool>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<WorkerPool> Get(string id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<WorkerPool> Create(WorkerPool item)
		{
			this.Context.Set<WorkerPool>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(WorkerPool item)
		{
			var entity = this.Context.Set<WorkerPool>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<WorkerPool>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			string id)
		{
			WorkerPool record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<WorkerPool>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<WorkerPool> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<WorkerPool>> Where(
			Expression<Func<WorkerPool, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<WorkerPool, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<WorkerPool>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<WorkerPool>();
			}
			else
			{
				return await this.Context.Set<WorkerPool>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<WorkerPool>();
			}
		}

		private async Task<WorkerPool> GetById(string id)
		{
			List<WorkerPool> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ca6dac7b1147ca79e64c4306a688a9b5</Hash>
</Codenesium>*/