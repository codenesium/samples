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
        public abstract class AbstractTeacherXTeacherSkillRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTeacherXTeacherSkillRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TeacherXTeacherSkill>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<TeacherXTeacherSkill>> Where(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<TeacherXTeacherSkill> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<TeacherXTeacherSkill>> SearchLinqEF(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TeacherXTeacherSkill.Id)} ASC";
                        }

                        return await this.Context.Set<TeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<TeacherXTeacherSkill>();
                }

                private async Task<List<TeacherXTeacherSkill>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TeacherXTeacherSkill.Id)} ASC";
                        }

                        return await this.Context.Set<TeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<TeacherXTeacherSkill>();
                }

                private async Task<TeacherXTeacherSkill> GetById(int id)
                {
                        List<TeacherXTeacherSkill> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>4efaaee26f5795fc6a00b0707fade290</Hash>
</Codenesium>*/