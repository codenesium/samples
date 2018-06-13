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
        public abstract class AbstractLessonXStudentRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractLessonXStudentRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<LessonXStudent>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<LessonXStudent> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<LessonXStudent> Create(LessonXStudent item)
                {
                        this.Context.Set<LessonXStudent>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(LessonXStudent item)
                {
                        var entity = this.Context.Set<LessonXStudent>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<LessonXStudent>().Attach(item);
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
                        LessonXStudent record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<LessonXStudent>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<LessonXStudent>> Where(Expression<Func<LessonXStudent, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<LessonXStudent> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<LessonXStudent>> SearchLinqEF(Expression<Func<LessonXStudent, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(LessonXStudent.Id)} ASC";
                        }

                        return await this.Context.Set<LessonXStudent>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<LessonXStudent>();
                }

                private async Task<List<LessonXStudent>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(LessonXStudent.Id)} ASC";
                        }

                        return await this.Context.Set<LessonXStudent>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<LessonXStudent>();
                }

                private async Task<LessonXStudent> GetById(int id)
                {
                        List<LessonXStudent> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>928812778f403330473b622928ba195f</Hash>
</Codenesium>*/