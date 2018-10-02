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

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractSysdiagramRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSysdiagramRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Sysdiagram>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Sysdiagram> Get(int diagramId)
		{
			return await this.GetById(diagramId);
		}

		public async virtual Task<Sysdiagram> Create(Sysdiagram item)
		{
			this.Context.Set<Sysdiagram>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Sysdiagram item)
		{
			var entity = this.Context.Set<Sysdiagram>().Local.FirstOrDefault(x => x.DiagramId == item.DiagramId);
			if (entity == null)
			{
				this.Context.Set<Sysdiagram>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int diagramId)
		{
			Sysdiagram record = await this.GetById(diagramId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Sysdiagram>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<Sysdiagram> ByPrincipalIdName(int principalId, string name)
		{
			var records = await this.Where(x => x.PrincipalId == principalId && x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<Sysdiagram>> Where(
			Expression<Func<Sysdiagram, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Sysdiagram, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.DiagramId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Sysdiagram>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Sysdiagram>();
			}
			else
			{
				return await this.Context.Set<Sysdiagram>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Sysdiagram>();
			}
		}

		private async Task<Sysdiagram> GetById(int diagramId)
		{
			List<Sysdiagram> records = await this.Where(x => x.DiagramId == diagramId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>52ca2ab8678a4c0a8b2174d1a35d8800</Hash>
</Codenesium>*/