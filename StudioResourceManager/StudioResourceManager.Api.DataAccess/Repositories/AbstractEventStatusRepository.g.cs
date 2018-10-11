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

namespace StudioResourceManagerNS.Api.DataAccess
{
	public abstract class AbstractEventStatusRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractEventStatusRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<EventStatus>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<EventStatus> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<EventStatus> Create(EventStatus item)
		{
			this.Context.Set<EventStatus>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(EventStatus item)
		{
			var entity = this.Context.Set<EventStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<EventStatus>().Attach(item);
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
			EventStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EventStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<Event>> Events(int eventStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Event>().Where(x => x.EventStatusId == eventStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Event>();
		}

		protected async Task<List<EventStatus>> Where(
			Expression<Func<EventStatus, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<EventStatus, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<EventStatus>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<EventStatus>();
			}
			else
			{
				return await this.Context.Set<EventStatus>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<EventStatus>();
			}
		}

		private async Task<EventStatus> GetById(int id)
		{
			List<EventStatus> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e023374dff5bbe50a9418993597ff2ab</Hash>
</Codenesium>*/