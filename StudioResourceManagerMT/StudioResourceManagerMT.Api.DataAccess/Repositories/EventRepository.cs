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

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public class EventRepository : AbstractRepository, IEventRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public EventRepository(
			ILogger<IEventRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Event>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.ActualEndDate == query.ToNullableDateTime() ||
				                  x.ActualStartDate == query.ToNullableDateTime() ||
				                  x.BillAmount.ToNullableDecimal() == query.ToNullableDecimal() ||
				                  (x.EventStatusIdNavigation == null || x.EventStatusIdNavigation.Name == null?false : x.EventStatusIdNavigation.Name.StartsWith(query)) ||
				                  x.ScheduledEndDate == query.ToNullableDateTime() ||
				                  x.ScheduledStartDate == query.ToNullableDateTime() ||
				                  (x.StudentNotes == null?false : x.StudentNotes.StartsWith(query)) ||
				                  (x.TeacherNotes == null?false : x.TeacherNotes.StartsWith(query)),
				                  limit,
				                  offset);
			}
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

		// Foreign key reference to this table EventStudent via eventId.
		public async virtual Task<List<EventStudent>> EventStudentsByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventStudent>()
			       .Include(x => x.EventIdNavigation)
			       .Include(x => x.StudentIdNavigation)

			       .Where(x => x.EventId == eventId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventStudent>();
		}

		// Foreign key reference to this table EventTeacher via eventId.
		public async virtual Task<List<EventTeacher>> EventTeachersByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventTeacher>()
			       .Include(x => x.EventIdNavigation)
			       .Include(x => x.TeacherIdNavigation)

			       .Where(x => x.EventId == eventId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventTeacher>();
		}

		// Foreign key reference to table EventStatus via eventStatusId.
		public async virtual Task<EventStatus> EventStatusByEventStatusId(int eventStatusId)
		{
			return await this.Context.Set<EventStatus>()
			       .SingleOrDefaultAsync(x => x.Id == eventStatusId);
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

			return await this.Context.Set<Event>()
			       .Include(x => x.EventStatusIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Event>();
		}

		private async Task<Event> GetById(int id)
		{
			List<Event> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>71d5d29d3e01bd9342ffa1e13134af6f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/