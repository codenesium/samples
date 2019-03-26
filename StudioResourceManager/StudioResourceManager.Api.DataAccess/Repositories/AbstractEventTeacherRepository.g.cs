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

		public virtual Task<List<EventTeacher>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.TeacherId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<EventTeacher> Get(int id)
		{
			return await this.GetById(id);
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
			var entity = this.Context.Set<EventTeacher>().Local.FirstOrDefault(x => x.Id == item.Id);
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
			int id)
		{
			EventTeacher record = await this.GetById(id);

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

		// Non-unique constraint IX_EventTeacher_eventId.
		public async virtual Task<List<EventTeacher>> ById(int id, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.Id == id, limit, offset);
		}

		// Non-unique constraint IX_EventTeacher_teacherId.
		public async virtual Task<List<EventTeacher>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TeacherId == teacherId, limit, offset);
		}

		// Foreign key reference to table Event via id.
		public async virtual Task<Event> EventById(int id)
		{
			return await this.Context.Set<Event>()
			       .SingleOrDefaultAsync(x => x.Id == id);
		}

		// Foreign key reference to table Teacher via teacherId.
		public async virtual Task<Teacher> TeacherByTeacherId(int teacherId)
		{
			return await this.Context.Set<Teacher>()
			       .SingleOrDefaultAsync(x => x.Id == teacherId);
		}

		protected async Task<List<EventTeacher>> Where(
			Expression<Func<EventTeacher, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<EventTeacher, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<EventTeacher>()
			       .Include(x => x.IdNavigation)
			       .Include(x => x.TeacherIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<EventTeacher>();
		}

		private async Task<EventTeacher> GetById(int id)
		{
			List<EventTeacher> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b012a698513a63c8dc245268962d4f93</Hash>
</Codenesium>*/