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

		public virtual Task<List<Student>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Birthday == query.ToDateTime() ||
				                  x.Email.StartsWith(query) ||
				                  x.EmailRemindersEnabled == query.ToBoolean() ||
				                  x.FamilyId == query.ToInt() ||
				                  x.FirstName.StartsWith(query) ||
				                  x.IsAdult == query.ToBoolean() ||
				                  x.LastName.StartsWith(query) ||
				                  x.Phone.StartsWith(query) ||
				                  x.SmsRemindersEnabled == query.ToBoolean() ||
				                  x.UserId == query.ToInt(),
				                  limit,
				                  offset);
			}
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

		// Non-unique constraint IX_Student_familyId.
		public async virtual Task<List<Student>> ByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.FamilyId == familyId, limit, offset);
		}

		// Non-unique constraint IX_Student_userId.
		public async virtual Task<List<Student>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserId == userId, limit, offset);
		}

		// Foreign key reference to this table EventStudent via studentId.
		public async virtual Task<List<EventStudent>> EventStudentsByStudentId(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventStudent>()
			       .Include(x => x.EventIdNavigation)
			       .Include(x => x.StudentIdNavigation)

			       .Where(x => x.StudentId == studentId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventStudent>();
		}

		// Foreign key reference to table Family via familyId.
		public async virtual Task<Family> FamilyByFamilyId(int familyId)
		{
			return await this.Context.Set<Family>()
			       .SingleOrDefaultAsync(x => x.Id == familyId);
		}

		// Foreign key reference to table User via userId.
		public async virtual Task<User> UserByUserId(int userId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.Id == userId);
		}

		protected async Task<List<Student>> Where(
			Expression<Func<Student, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Student, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Student>()
			       .Include(x => x.FamilyIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Student>();
		}

		private async Task<Student> GetById(int id)
		{
			List<Student> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b1c917e00c19cc19365170e813e46869</Hash>
</Codenesium>*/