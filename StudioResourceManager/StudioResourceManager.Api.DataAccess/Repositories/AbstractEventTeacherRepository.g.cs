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
	public abstract class AbstractEventTeacherRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractEventTeacherRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<EventTeacher>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<EventTeacher> Get(int eventId)
		{
			return await this.GetById(eventId);
		}

		public async virtual Task<EventTeacher> Create(EventTeacher item)
		{
			this.Context.Set<EventTeacher>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(EventTeacher item)
		{
			var entity = this.Context.Set<EventTeacher>().Local.FirstOrDefault(x => x.EventId == item.EventId);
			if (entity == null)
			{
				this.Context.Set<EventTeacher>().Attach(item);
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
			EventTeacher record = await this.GetById(eventId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EventTeacher>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Event> EventByEventId(int eventId)
		{
			return await this.Context.Set<Event>().SingleOrDefaultAsync(x => x.Id == eventId);
		}

		public async virtual Task<Teacher> TeacherByTeacherId(int teacherId)
		{
			return await this.Context.Set<Teacher>().SingleOrDefaultAsync(x => x.Id == teacherId);
		}

		protected async Task<List<EventTeacher>> Where(
			Expression<Func<EventTeacher, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<EventTeacher, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.EventId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<EventTeacher>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<EventTeacher>();
			}
			else
			{
				return await this.Context.Set<EventTeacher>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<EventTeacher>();
			}
		}

		private async Task<EventTeacher> GetById(int eventId)
		{
			List<EventTeacher> records = await this.Where(x => x.EventId == eventId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b9586dc735fd3f53b00faee579c509f6</Hash>
</Codenesium>*/