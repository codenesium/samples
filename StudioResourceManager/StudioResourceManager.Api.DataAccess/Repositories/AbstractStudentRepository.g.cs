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
	public abstract class AbstractStudentRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractStudentRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Student>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Student> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Student> Create(Student item)
		{
			this.Context.Set<Student>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Student item)
		{
			var entity = this.Context.Set<Student>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Student>().Attach(item);
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
			Student record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Student>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<EventStudent>> EventStudents(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventStudent>().Where(x => x.StudentId == studentId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventStudent>();
		}

		public async virtual Task<Family> FamilyByFamilyId(int familyId)
		{
			return await this.Context.Set<Family>().SingleOrDefaultAsync(x => x.Id == familyId);
		}

		public async virtual Task<User> UserByUserId(int userId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.Id == userId);
		}

		// Reference foreign key. Reference Table=EventStudent. First table=students. Second table=events
		public async virtual Task<List<Student>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.EventStudents
			              join students in this.Context.Students on
			              refTable.StudentId equals students.Id
			              where refTable.EventId == eventId
			              select students).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<Student>> Where(
			Expression<Func<Student, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Student, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Student>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Student>();
			}
			else
			{
				return await this.Context.Set<Student>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Student>();
			}
		}

		private async Task<Student> GetById(int id)
		{
			List<Student> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8b887b0c44c31dffa8b6d08de2c01921</Hash>
</Codenesium>*/