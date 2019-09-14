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
	public class TeacherSkillRepository : AbstractRepository, ITeacherSkillRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public TeacherSkillRepository(
			ILogger<ITeacherSkillRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TeacherSkill>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Name == null?false : x.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<TeacherSkill> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<TeacherSkill> Create(TeacherSkill item)
		{
			this.Context.Set<TeacherSkill>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(TeacherSkill item)
		{
			var entity = this.Context.Set<TeacherSkill>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<TeacherSkill>().Attach(item);
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
			TeacherSkill record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TeacherSkill>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Rate via teacherSkillId.
		public async virtual Task<List<Rate>> RatesByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Rate>()
			       .Include(x => x.TeacherIdNavigation)
			       .Include(x => x.TeacherSkillIdNavigation)

			       .Where(x => x.TeacherSkillId == teacherSkillId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Rate>();
		}

		// Foreign key reference to this table TeacherTeacherSkill via teacherSkillId.
		public async virtual Task<List<TeacherTeacherSkill>> TeacherTeacherSkillsByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<TeacherTeacherSkill>()
			       .Include(x => x.TeacherIdNavigation)
			       .Include(x => x.TeacherSkillIdNavigation)

			       .Where(x => x.TeacherSkillId == teacherSkillId).AsQueryable().Skip(offset).Take(limit).ToListAsync<TeacherTeacherSkill>();
		}

		protected async Task<List<TeacherSkill>> Where(
			Expression<Func<TeacherSkill, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TeacherSkill, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<TeacherSkill>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TeacherSkill>();
		}

		private async Task<TeacherSkill> GetById(int id)
		{
			List<TeacherSkill> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4fbf77fc519e019e17c566e739149668</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/