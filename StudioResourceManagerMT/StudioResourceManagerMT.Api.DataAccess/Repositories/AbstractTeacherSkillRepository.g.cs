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
	public abstract class AbstractTeacherSkillRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTeacherSkillRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TeacherSkill>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async virtual Task<List<Rate>> RatesByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Rate>().Where(x => x.TeacherSkillId == teacherSkillId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Rate>();
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

			return await this.Context.Set<TeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TeacherSkill>();
		}

		private async Task<TeacherSkill> GetById(int id)
		{
			List<TeacherSkill> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e2007821e38fd621193010d6a76e26ae</Hash>
</Codenesium>*/