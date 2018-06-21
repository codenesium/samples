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

namespace FermataFishNS.Api.DataAccess
{
        public abstract class AbstractTeacherXTeacherSkillRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTeacherXTeacherSkillRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TeacherXTeacherSkill>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<TeacherXTeacherSkill> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<TeacherXTeacherSkill> Create(TeacherXTeacherSkill item)
                {
                        this.Context.Set<TeacherXTeacherSkill>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(TeacherXTeacherSkill item)
                {
                        var entity = this.Context.Set<TeacherXTeacherSkill>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<TeacherXTeacherSkill>().Attach(item);
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
                        TeacherXTeacherSkill record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<TeacherXTeacherSkill>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async virtual Task<Teacher> GetTeacher(int teacherId)
                {
                        return await this.Context.Set<Teacher>().SingleOrDefaultAsync(x => x.Id == teacherId);
                }

                public async virtual Task<TeacherSkill> GetTeacherSkill(int teacherSkillId)
                {
                        return await this.Context.Set<TeacherSkill>().SingleOrDefaultAsync(x => x.Id == teacherSkillId);
                }

                protected async Task<List<TeacherXTeacherSkill>> Where(
                        Expression<Func<TeacherXTeacherSkill, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<TeacherXTeacherSkill, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<TeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TeacherXTeacherSkill>();
                        }
                        else
                        {
                                return await this.Context.Set<TeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<TeacherXTeacherSkill>();
                        }
                }

                private async Task<TeacherXTeacherSkill> GetById(int id)
                {
                        List<TeacherXTeacherSkill> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>43a3b6fd3eb8a6937e43a51723745d8e</Hash>
</Codenesium>*/