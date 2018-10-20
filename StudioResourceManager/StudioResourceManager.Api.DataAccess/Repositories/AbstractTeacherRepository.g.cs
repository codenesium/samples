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

		public async virtual Task<List<EventTeacher>> EventTeachersByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventTeacher>().Where(x => x.TeacherId == teacherId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventTeacher>();
		}

		public async virtual Task<List<Rate>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Rate>().Where(x => x.TeacherId == teacherId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Rate>();
		}

		public async virtual Task<List<TeacherTeacherSkill>> TeacherTeacherSkillsByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<TeacherTeacherSkill>().Where(x => x.TeacherId == teacherId).AsQueryable().Skip(offset).Take(limit).ToListAsync<TeacherTeacherSkill>();
		}

		public async virtual Task<User> UserByUserId(int userId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.Id == userId);
		}

		protected async Task<List<Teacher>> Where(
			Expression<Func<Teacher, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Teacher, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Teacher>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Teacher>();
			}
			else
			{
				return await this.Context.Set<Teacher>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Teacher>();
			}
		}

		private async Task<Teacher> GetById(int id)
		{
			List<Teacher> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2f55c025ae015b0ac3855532bfb17f17</Hash>
</Codenesium>*/