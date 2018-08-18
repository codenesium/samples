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
	public abstract class AbstractDeploymentRelatedMachineRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractDeploymentRelatedMachineRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DeploymentRelatedMachine>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<DeploymentRelatedMachine> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<DeploymentRelatedMachine> Create(DeploymentRelatedMachine item)
		{
			this.Context.Set<DeploymentRelatedMachine>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(DeploymentRelatedMachine item)
		{
			var entity = this.Context.Set<DeploymentRelatedMachine>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<DeploymentRelatedMachine>().Attach(item);
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
			DeploymentRelatedMachine record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<DeploymentRelatedMachine>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DeploymentRelatedMachine>> ByDeploymentId(string deploymentId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.DeploymentId == deploymentId, limit, offset);

			return records;
		}

		public async Task<List<DeploymentRelatedMachine>> ByMachineId(string machineId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.MachineId == machineId, limit, offset);

			return records;
		}

		public async virtual Task<Deployment> GetDeployment(string deploymentId)
		{
			return await this.Context.Set<Deployment>().SingleOrDefaultAsync(x => x.Id == deploymentId);
		}

		protected async Task<List<DeploymentRelatedMachine>> Where(
			Expression<Func<DeploymentRelatedMachine, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<DeploymentRelatedMachine, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<DeploymentRelatedMachine>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<DeploymentRelatedMachine>();
			}
			else
			{
				return await this.Context.Set<DeploymentRelatedMachine>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<DeploymentRelatedMachine>();
			}
		}

		private async Task<DeploymentRelatedMachine> GetById(int id)
		{
			List<DeploymentRelatedMachine> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f3b5bf1cf9060bb15e51960f00b4eedc</Hash>
</Codenesium>*/