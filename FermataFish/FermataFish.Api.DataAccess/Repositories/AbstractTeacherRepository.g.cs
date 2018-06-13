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
        public abstract class AbstractTeacherRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTeacherRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Teacher>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<Teacher>> Where(Expression<Func<Teacher, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Teacher> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Teacher>> SearchLinqEF(Expression<Func<Teacher, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Teacher.Id)} ASC";
                        }

                        return await this.Context.Set<Teacher>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Teacher>();
                }

                private async Task<List<Teacher>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Teacher.Id)} ASC";
                        }

                        return await this.Context.Set<Teacher>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Teacher>();
                }

                private async Task<Teacher> GetById(int id)
                {
                        List<Teacher> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Rate>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Rate>().Where(x => x.TeacherId == teacherId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Rate>();
                }
                public async virtual Task<List<TeacherXTeacherSkill>> TeacherXTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<TeacherXTeacherSkill>().Where(x => x.TeacherId == teacherId).AsQueryable().Skip(offset).Take(limit).ToListAsync<TeacherXTeacherSkill>();
                }
        }
}

/*<Codenesium>
    <Hash>24366fc7d26489e251641c3d104b31f6</Hash>
</Codenesium>*/