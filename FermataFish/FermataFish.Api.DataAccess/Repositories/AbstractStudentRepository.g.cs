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
        public abstract class AbstractStudentRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractStudentRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Student>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Student> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Student> Create(Student item)
                {
                        this.Context.Set<Student>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Student item)
                {
                        var entity = this.Context.Set<Student>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Student>().Attach(item);
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
                        Student record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Student>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Student>> Where(Expression<Func<Student, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Student> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Student>> SearchLinqEF(Expression<Func<Student, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Student.Id)} ASC";
                        }

                        return await this.Context.Set<Student>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Student>();
                }

                private async Task<List<Student>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Student.Id)} ASC";
                        }

                        return await this.Context.Set<Student>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Student>();
                }

                private async Task<Student> GetById(int id)
                {
                        List<Student> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<LessonXStudent>> LessonXStudents(int studentId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<LessonXStudent>().Where(x => x.StudentId == studentId).AsQueryable().Skip(offset).Take(limit).ToListAsync<LessonXStudent>();
                }
                public async virtual Task<List<LessonXTeacher>> LessonXTeachers(int studentId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<LessonXTeacher>().Where(x => x.StudentId == studentId).AsQueryable().Skip(offset).Take(limit).ToListAsync<LessonXTeacher>();
                }
                public async virtual Task<List<StudentXFamily>> StudentXFamilies(int studentId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<StudentXFamily>().Where(x => x.StudentId == studentId).AsQueryable().Skip(offset).Take(limit).ToListAsync<StudentXFamily>();
                }
        }
}

/*<Codenesium>
    <Hash>13676ca6592cb016b5c882395de562cb</Hash>
</Codenesium>*/