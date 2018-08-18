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
	public abstract class AbstractDashboardConfigurationRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractDashboardConfigurationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DashboardConfiguration>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<DashboardConfiguration> Get(string id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<DashboardConfiguration> Create(DashboardConfiguration item)
		{
			this.Context.Set<DashboardConfiguration>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(DashboardConfiguration item)
		{
			var entity = this.Context.Set<DashboardConfiguration>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<DashboardConfiguration>().Attach(item);
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
			DashboardConfiguration record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<DashboardConfiguration>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DashboardConfiguration>> Where(
			Expression<Func<DashboardConfiguration, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<DashboardConfiguration, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<DashboardConfiguration>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<DashboardConfiguration>();
			}
			else
			{
				return await this.Context.Set<DashboardConfiguration>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<DashboardConfiguration>();
			}
		}

		private async Task<DashboardConfiguration> GetById(string id)
		{
			List<DashboardConfiguration> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>55c660572e91fa6fef26642f4834fe40</Hash>
</Codenesium>*/