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
	public abstract class AbstractProjectRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProjectRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Project>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Project> Get(string id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Project> Create(Project item)
		{
			this.Context.Set<Project>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Project item)
		{
			var entity = this.Context.Set<Project>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Project>().Attach(item);
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
			Project record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Project>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<Project> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		public async Task<Project> BySlug(string slug)
		{
			var records = await this.Where(x => x.Slug == slug);

			return records.FirstOrDefault();
		}

		public async Task<List<Project>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.DataVersion == dataVersion, limit, offset);

			return records;
		}

		public async Task<List<Project>> ByDiscreteChannelReleaseId(bool discreteChannelRelease, string id, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.DiscreteChannelRelease == discreteChannelRelease && x.Id == id, limit, offset);

			return records;
		}

		protected async Task<List<Project>> Where(
			Expression<Func<Project, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Project, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Project>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Project>();
			}
			else
			{
				return await this.Context.Set<Project>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Project>();
			}
		}

		private async Task<Project> GetById(string id)
		{
			List<Project> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2a587e45ecd491a107b8f66aea7ca716</Hash>
</Codenesium>*/