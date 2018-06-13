using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public abstract class AbstractTeacherSkillRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTeacherSkillRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TeacherSkill>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<TeacherSkill>> Where(Expression<Func<TeacherSkill, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<TeacherSkill> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<TeacherSkill>> SearchLinqEF(Expression<Func<TeacherSkill, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TeacherSkill.Id)} ASC";
                        }

                        return await this.Context.Set<TeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<TeacherSkill>();
                }

                private async Task<List<TeacherSkill>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TeacherSkill.Id)} ASC";
                        }

                        return await this.Context.Set<TeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<TeacherSkill>();
                }

                private async Task<TeacherSkill> GetById(int id)
                {
                        List<TeacherSkill> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Rate>> Rates(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Rate>().Where(x => x.TeacherSkillId == teacherSkillId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Rate>();
                }
                public async virtual Task<List<TeacherXTeacherSkill>> TeacherXTeacherSkills(int teacherSkillId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<TeacherXTeacherSkill>().Where(x => x.TeacherSkillId == teacherSkillId).AsQueryable().Skip(offset).Take(limit).ToListAsync<TeacherXTeacherSkill>();
                }
        }
}

/*<Codenesium>
    <Hash>e8f69fbd2e7011818f7461238fe6d0a1</Hash>
</Codenesium>*/