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
	public abstract class AbstractEventStudentRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractEventStudentRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<EventStudent>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<EventStudent> Get(int eventId)
		{
			return await this.GetById(eventId);
		}

		public async virtual Task<EventStudent> Create(EventStudent item)
		{
			this.Context.Set<EventStudent>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(EventStudent item)
		{
			var entity = this.Context.Set<EventStudent>().Local.FirstOrDefault(x => x.EventId == item.EventId);
			if (entity == null)
			{
				this.Context.Set<EventStudent>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int eventId)
		{
			EventStudent record = await this.GetById(eventId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EventStudent>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Event> EventByEventId(int eventId)
		{
			return await this.Context.Set<Event>().SingleOrDefaultAsync(x => x.Id == eventId);
		}

		public async virtual Task<Student> StudentByStudentId(int studentId)
		{
			return await this.Context.Set<Student>().SingleOrDefaultAsync(x => x.Id == studentId);
		}

		protected async Task<List<EventStudent>> Where(
			Expression<Func<EventStudent, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<EventStudent, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.EventId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<EventStudent>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<EventStudent>();
			}
			else
			{
				return await this.Context.Set<EventStudent>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<EventStudent>();
			}
		}

		private async Task<EventStudent> GetById(int eventId)
		{
			List<EventStudent> records = await this.Where(x => x.EventId == eventId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ddd3c9c48855bc42da3ab458ba6f3b19</Hash>
</Codenesium>*/