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
	public abstract class AbstractDeploymentHistoryRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractDeploymentHistoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DeploymentHistory>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<DeploymentHistory> Get(string deploymentId)
		{
			return await this.GetById(deploymentId);
		}

		public async virtual Task<DeploymentHistory> Create(DeploymentHistory item)
		{
			this.Context.Set<DeploymentHistory>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(DeploymentHistory item)
		{
			var entity = this.Context.Set<DeploymentHistory>().Local.FirstOrDefault(x => x.DeploymentId == item.DeploymentId);
			if (entity == null)
			{
				this.Context.Set<DeploymentHistory>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			string deploymentId)
		{
			DeploymentHistory record = await this.GetById(deploymentId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<DeploymentHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DeploymentHistory>> ByCreated(DateTimeOffset created, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.Created == created, limit, offset);

			return records;
		}

		protected async Task<List<DeploymentHistory>> Where(
			Expression<Func<DeploymentHistory, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<DeploymentHistory, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.DeploymentId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<DeploymentHistory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<DeploymentHistory>();
			}
			else
			{
				return await this.Context.Set<DeploymentHistory>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<DeploymentHistory>();
			}
		}

		private async Task<DeploymentHistory> GetById(string deploymentId)
		{
			List<DeploymentHistory> records = await this.Where(x => x.DeploymentId == deploymentId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6e5d0dcfa9acf3c771308c9a85d5a07b</Hash>
</Codenesium>*/