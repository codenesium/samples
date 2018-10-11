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
	public abstract class AbstractTeacherTeacherSkillRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTeacherTeacherSkillRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TeacherTeacherSkill>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<TeacherTeacherSkill> Get(int teacherId)
		{
			return await this.GetById(teacherId);
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
			var entity = this.Context.Set<TeacherTeacherSkill>().Local.FirstOrDefault(x => x.TeacherId == item.TeacherId);
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
			int teacherId)
		{
			TeacherTeacherSkill record = await this.GetById(teacherId);

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

		public async virtual Task<Teacher> TeacherByTeacherId(int teacherId)
		{
			return await this.Context.Set<Teacher>().SingleOrDefaultAsync(x => x.Id == teacherId);
		}

		public async virtual Task<TeacherSkill> TeacherSkillByTeacherSkillId(int teacherSkillId)
		{
			return await this.Context.Set<TeacherSkill>().SingleOrDefaultAsync(x => x.Id == teacherSkillId);
		}

		protected async Task<List<TeacherTeacherSkill>> Where(
			Expression<Func<TeacherTeacherSkill, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TeacherTeacherSkill, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.TeacherId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<TeacherTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TeacherTeacherSkill>();
			}
			else
			{
				return await this.Context.Set<TeacherTeacherSkill>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<TeacherTeacherSkill>();
			}
		}

		private async Task<TeacherTeacherSkill> GetById(int teacherId)
		{
			List<TeacherTeacherSkill> records = await this.Where(x => x.TeacherId == teacherId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b60fe5881fde067055181e3d9bccd554</Hash>
</Codenesium>*/