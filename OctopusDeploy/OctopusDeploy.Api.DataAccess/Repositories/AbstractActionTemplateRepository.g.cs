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
	public abstract class AbstractActionTemplateRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractActionTemplateRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ActionTemplate>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ActionTemplate> Get(string id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<ActionTemplate> Create(ActionTemplate item)
		{
			this.Context.Set<ActionTemplate>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ActionTemplate item)
		{
			var entity = this.Context.Set<ActionTemplate>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<ActionTemplate>().Attach(item);
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
			ActionTemplate record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ActionTemplate>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<ActionTemplate> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<ActionTemplate>> Where(
			Expression<Func<ActionTemplate, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ActionTemplate, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ActionTemplate>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ActionTemplate>();
			}
			else
			{
				return await this.Context.Set<ActionTemplate>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ActionTemplate>();
			}
		}

		private async Task<ActionTemplate> GetById(string id)
		{
			List<ActionTemplate> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>295965c76df833a259ce00d7efd75162</Hash>
</Codenesium>*/