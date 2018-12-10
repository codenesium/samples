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
	public abstract class AbstractTeacherRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTeacherRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Teacher>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Teacher> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Teacher> Create(Teacher item)
		{
			this.Context.Set<Teacher>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Teacher item)
		{
			var entity = this.Context.Set<Teacher>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Teacher>().Attach(item);
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
			Teacher record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Teacher>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Teacher_userId.
		public async virtual Task<List<Teacher>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserId == userId, limit, offset);
		}

		// Foreign key reference to this table Rate via teacherId.
		public async virtual Task<List<Rate>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Rate>().Where(x => x.TeacherId == teacherId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Rate>();
		}

		// Foreign key reference to table User via userId.
		public async virtual Task<User> UserByUserId(int userId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.Id == userId);
		}

		// Foreign key reference pass-though. Pass-thru table EventTeacher. Foreign Table Teacher.
		public async virtual Task<List<Teacher>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.EventTeachers
			              join teachers in this.Context.Teachers on
			              refTable.TeacherId equals teachers.Id
			              where refTable.EventId == eventId
			              select teachers).Skip(offset).Take(limit).ToListAsync();
		}

		// Foreign key reference pass-though. Pass-thru table EventTeacher. Foreign Table Teacher.
		public async virtual Task<EventTeacher> CreateEventTeacher(EventTeacher item)
		{
			this.Context.Set<EventTeacher>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		// Foreign key reference pass-though. Pass-thru table EventTeacher. Foreign Table Teacher.
		public async virtual Task DeleteEventTeacher(EventTeacher item)
		{
			this.Context.Set<EventTeacher>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		protected async Task<List<Teacher>> Where(
			Expression<Func<Teacher, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Teacher, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Teacher>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Teacher>();
		}

		private async Task<Teacher> GetById(int id)
		{
			List<Teacher> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ac95ddc8b819819948088cba5aef0177</Hash>
</Codenesium>*/