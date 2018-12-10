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
	public abstract class AbstractEventRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractEventRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Event>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Event> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Event> Create(Event item)
		{
			this.Context.Set<Event>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Event item)
		{
			var entity = this.Context.Set<Event>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Event>().Attach(item);
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
			Event record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Event>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Event_eventStatusId.
		public async virtual Task<List<Event>> ByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.EventStatusId == eventStatusId, limit, offset);
		}

		// Foreign key reference to table EventStatu via eventStatusId.
		public async virtual Task<EventStatu> EventStatuByEventStatusId(int eventStatusId)
		{
			return await this.Context.Set<EventStatu>().SingleOrDefaultAsync(x => x.Id == eventStatusId);
		}

		// Foreign key reference pass-though. Pass-thru table EventStudent. Foreign Table Event.
		public async virtual Task<List<Event>> ByStudentId(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.EventStudents
			              join events in this.Context.Events on
			              refTable.EventId equals events.Id
			              where refTable.StudentId == studentId
			              select events).Skip(offset).Take(limit).ToListAsync();
		}

		// Foreign key reference pass-though. Pass-thru table EventStudent. Foreign Table Event.
		public async virtual Task<EventStudent> CreateEventStudent(EventStudent item)
		{
			this.Context.Set<EventStudent>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		// Foreign key reference pass-though. Pass-thru table EventStudent. Foreign Table Event.
		public async virtual Task DeleteEventStudent(EventStudent item)
		{
			this.Context.Set<EventStudent>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		// Foreign key reference pass-though. Pass-thru table EventTeacher. Foreign Table Event.
		public async virtual Task<List<Event>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.EventTeachers
			              join events in this.Context.Events on
			              refTable.EventId equals events.Id
			              where refTable.TeacherId == teacherId
			              select events).Skip(offset).Take(limit).ToListAsync();
		}

		// Foreign key reference pass-though. Pass-thru table EventTeacher. Foreign Table Event.
		public async virtual Task<EventTeacher> CreateEventTeacher(EventTeacher item)
		{
			this.Context.Set<EventTeacher>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		// Foreign key reference pass-though. Pass-thru table EventTeacher. Foreign Table Event.
		public async virtual Task DeleteEventTeacher(EventTeacher item)
		{
			this.Context.Set<EventTeacher>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		protected async Task<List<Event>> Where(
			Expression<Func<Event, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Event, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Event>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Event>();
		}

		private async Task<Event> GetById(int id)
		{
			List<Event> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3967151de0b82df1aae6a79f591025d5</Hash>
</Codenesium>*/