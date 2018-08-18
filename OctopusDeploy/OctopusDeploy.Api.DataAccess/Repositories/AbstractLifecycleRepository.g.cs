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
	public abstract class AbstractLifecycleRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLifecycleRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Lifecycle>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Lifecycle> Get(string id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Lifecycle> Create(Lifecycle item)
		{
			this.Context.Set<Lifecycle>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Lifecycle item)
		{
			var entity = this.Context.Set<Lifecycle>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Lifecycle>().Attach(item);
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
			Lifecycle record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Lifecycle>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<Lifecycle> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		public async Task<List<Lifecycle>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.DataVersion == dataVersion, limit, offset);

			return records;
		}

		protected async Task<List<Lifecycle>> Where(
			Expression<Func<Lifecycle, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Lifecycle, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Lifecycle>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Lifecycle>();
			}
			else
			{
				return await this.Context.Set<Lifecycle>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Lifecycle>();
			}
		}

		private async Task<Lifecycle> GetById(string id)
		{
			List<Lifecycle> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0692c9918aebc1a356449bb9f380ef35</Hash>
</Codenesium>*/