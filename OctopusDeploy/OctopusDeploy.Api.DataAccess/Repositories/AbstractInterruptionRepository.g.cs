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
	public abstract class AbstractInterruptionRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractInterruptionRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Interruption>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Interruption> Get(string id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Interruption> Create(Interruption item)
		{
			this.Context.Set<Interruption>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Interruption item)
		{
			var entity = this.Context.Set<Interruption>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Interruption>().Attach(item);
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
			Interruption record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Interruption>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<Interruption>> ByTenantId(string tenantId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.TenantId == tenantId, limit, offset);

			return records;
		}

		protected async Task<List<Interruption>> Where(
			Expression<Func<Interruption, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Interruption, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Interruption>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Interruption>();
			}
			else
			{
				return await this.Context.Set<Interruption>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Interruption>();
			}
		}

		private async Task<Interruption> GetById(string id)
		{
			List<Interruption> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fa76546d9daf3c47da7e32ee00defda0</Hash>
</Codenesium>*/