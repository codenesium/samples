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
	public class TeacherTeacherSkillRepository : AbstractRepository, ITeacherTeacherSkillRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public TeacherTeacherSkillRepository(
			ILogger<ITeacherTeacherSkillRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TeacherTeacherSkill>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.TeacherIdNavigation == null || x.TeacherIdNavigation.LastName == null?false : x.TeacherIdNavigation.LastName.StartsWith(query)) ||
				                  (x.TeacherSkillIdNavigation == null || x.TeacherSkillIdNavigation.Name == null?false : x.TeacherSkillIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<TeacherTeacherSkill> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<TeacherTeacherSkill> Create(TeacherTeacherSkill item)
		{
			this.Context.Set<TeacherTeacherSkill>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(TeacherTeacherSkill item)
		{
			var entity = this.Context.Set<TeacherTeacherSkill>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<TeacherTeacherSkill>().Attach(item);
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
			TeacherTeacherSkill record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TeacherTeacherSkill>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_TeacherTeacherSkill_teacherId.
		public async virtual Task<List<TeacherTeacherSkill>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TeacherId == teacherId, limit, offset);
		}

		// Non-unique constraint IX_TeacherTeacherSkill_teacherSkillId.
		public async virtual Task<List<TeacherTeacherSkill>> ByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TeacherSkillId == teacherSkillId, limit, offset);
		}

		// Foreign key reference to table Teacher via teacherId.
		public async virtual Task<Teacher> TeacherByTeacherId(int teacherId)
		{
			return await this.Context.Set<Teacher>()
			       .SingleOrDefaultAsync(x => x.Id == teacherId);
		}

		// Foreign key reference to table TeacherSkill via teacherSkillId.
		public async virtual Task<TeacherSkill> TeacherSkillByTeacherSkillId(int teacherSkillId)
		{
			return await this.Context.Set<TeacherSkill>()
			       .SingleOrDefaultAsync(x => x.Id == teacherSkillId);
		}

		protected async Task<List<TeacherTeacherSkill>> Where(
			Expression<Func<TeacherTeacherSkill, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TeacherTeacherSkill, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<TeacherTeacherSkill>()
			       .Include(x => x.TeacherIdNavigation)
			       .Include(x => x.TeacherSkillIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TeacherTeacherSkill>();
		}

		private async Task<TeacherTeacherSkill> GetById(int id)
		{
			List<TeacherTeacherSkill> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ed63d54dad02752955959ca27a303c8c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/