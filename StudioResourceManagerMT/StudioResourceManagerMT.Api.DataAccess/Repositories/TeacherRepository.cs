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
	public class TeacherRepository : AbstractRepository, ITeacherRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public TeacherRepository(
			ILogger<ITeacherRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Teacher>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Birthday == query.ToDateTime() ||
				                  (x.Email == null?false : x.Email.StartsWith(query)) ||
				                  (x.FirstName == null?false : x.FirstName.StartsWith(query)) ||
				                  (x.LastName == null?false : x.LastName.StartsWith(query)) ||
				                  (x.Phone == null?false : x.Phone.StartsWith(query)) ||
				                  (x.UserIdNavigation == null || x.UserIdNavigation.Username == null?false : x.UserIdNavigation.Username.StartsWith(query)),
				                  limit,
				                  offset);
			}
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

		// Foreign key reference to this table EventTeacher via teacherId.
		public async virtual Task<List<EventTeacher>> EventTeachersByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventTeacher>()
			       .Include(x => x.EventIdNavigation)
			       .Include(x => x.TeacherIdNavigation)

			       .Where(x => x.TeacherId == teacherId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventTeacher>();
		}

		// Foreign key reference to this table Rate via teacherId.
		public async virtual Task<List<Rate>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Rate>()
			       .Include(x => x.TeacherIdNavigation)
			       .Include(x => x.TeacherSkillIdNavigation)

			       .Where(x => x.TeacherId == teacherId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Rate>();
		}

		// Foreign key reference to this table TeacherTeacherSkill via teacherId.
		public async virtual Task<List<TeacherTeacherSkill>> TeacherTeacherSkillsByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<TeacherTeacherSkill>()
			       .Include(x => x.TeacherIdNavigation)
			       .Include(x => x.TeacherSkillIdNavigation)

			       .Where(x => x.TeacherId == teacherId).AsQueryable().Skip(offset).Take(limit).ToListAsync<TeacherTeacherSkill>();
		}

		// Foreign key reference to table User via userId.
		public async virtual Task<User> UserByUserId(int userId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.Id == userId);
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

			return await this.Context.Set<Teacher>()
			       .Include(x => x.UserIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Teacher>();
		}

		private async Task<Teacher> GetById(int id)
		{
			List<Teacher> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4a643f6611d112ecb9eb57d825c9d20e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/