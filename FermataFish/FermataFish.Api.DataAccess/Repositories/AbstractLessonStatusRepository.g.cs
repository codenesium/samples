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
        public abstract class AbstractLessonStatusRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractLessonStatusRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<LessonStatus>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<LessonStatus> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<LessonStatus> Create(LessonStatus item)
                {
                        this.Context.Set<LessonStatus>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(LessonStatus item)
                {
                        var entity = this.Context.Set<LessonStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<LessonStatus>().Attach(item);
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
                        LessonStatus record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<LessonStatus>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<LessonStatus>> Where(Expression<Func<LessonStatus, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<LessonStatus> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<LessonStatus>> SearchLinqEF(Expression<Func<LessonStatus, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(LessonStatus.Id)} ASC";
                        }

                        return await this.Context.Set<LessonStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<LessonStatus>();
                }

                private async Task<List<LessonStatus>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(LessonStatus.Id)} ASC";
                        }

                        return await this.Context.Set<LessonStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<LessonStatus>();
                }

                private async Task<LessonStatus> GetById(int id)
                {
                        List<LessonStatus> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Lesson>> Lessons(int lessonStatusId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Lesson>().Where(x => x.LessonStatusId == lessonStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Lesson>();
                }
        }
}

/*<Codenesium>
    <Hash>acdbd55ca644283dea9f5832d274a097</Hash>
</Codenesium>*/