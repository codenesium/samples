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
        public abstract class AbstractLessonRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractLessonRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Lesson>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Lesson> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Lesson> Create(Lesson item)
                {
                        this.Context.Set<Lesson>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Lesson item)
                {
                        var entity = this.Context.Set<Lesson>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Lesson>().Attach(item);
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
                        Lesson record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Lesson>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Lesson>> Where(Expression<Func<Lesson, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Lesson> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Lesson>> SearchLinqEF(Expression<Func<Lesson, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Lesson.Id)} ASC";
                        }

                        return await this.Context.Set<Lesson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Lesson>();
                }

                private async Task<List<Lesson>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Lesson.Id)} ASC";
                        }

                        return await this.Context.Set<Lesson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Lesson>();
                }

                private async Task<Lesson> GetById(int id)
                {
                        List<Lesson> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<LessonXStudent>> LessonXStudents(int lessonId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<LessonXStudent>().Where(x => x.LessonId == lessonId).AsQueryable().Skip(offset).Take(limit).ToListAsync<LessonXStudent>();
                }
                public async virtual Task<List<LessonXTeacher>> LessonXTeachers(int lessonId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<LessonXTeacher>().Where(x => x.LessonId == lessonId).AsQueryable().Skip(offset).Take(limit).ToListAsync<LessonXTeacher>();
                }
        }
}

/*<Codenesium>
    <Hash>db8067adf2089f27596e5f338f6fcafd</Hash>
</Codenesium>*/