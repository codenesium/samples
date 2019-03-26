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

		public virtual Task<List<EventStudent>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.EventId == query.ToInt() ||
				                  x.Id == query.ToInt() ||
				                  x.StudentId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<EventStudent> Get(int id)
		{
			return await this.GetById(id);
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
			var entity = this.Context.Set<EventStudent>().Local.FirstOrDefault(x => x.Id == item.Id);
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
			int id)
		{
			EventStudent record = await this.GetById(id);

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

		// Non-unique constraint IX_EventStudent_eventId.
		public async virtual Task<List<EventStudent>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.EventId == eventId, limit, offset);
		}

		// Non-unique constraint IX_EventStudent_studentId.
		public async virtual Task<List<EventStudent>> ByStudentId(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.StudentId == studentId, limit, offset);
		}

		// Foreign key reference to table Event via eventId.
		public async virtual Task<Event> EventByEventId(int eventId)
		{
			return await this.Context.Set<Event>()
			       .SingleOrDefaultAsync(x => x.Id == eventId);
		}

		// Foreign key reference to table Student via studentId.
		public async virtual Task<Student> StudentByStudentId(int studentId)
		{
			return await this.Context.Set<Student>()
			       .SingleOrDefaultAsync(x => x.Id == studentId);
		}

		protected async Task<List<EventStudent>> Where(
			Expression<Func<EventStudent, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<EventStudent, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<EventStudent>()
			       .Include(x => x.EventIdNavigation)
			       .Include(x => x.StudentIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<EventStudent>();
		}

		private async Task<EventStudent> GetById(int id)
		{
			List<EventStudent> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4ea19673e9f655af26d337170a0dc6f3</Hash>
</Codenesium>*/