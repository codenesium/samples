using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public abstract class AbstractStudioRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractStudioRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Studio>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Studio> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Studio> Create(Studio item)
                {
                        this.Context.Set<Studio>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Studio item)
                {
                        var entity = this.Context.Set<Studio>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Studio>().Attach(item);
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
                        Studio record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Studio>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Studio>> Where(
                        Expression<Func<Studio, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Studio, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Studio>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Studio>();
                        }
                        else
                        {
                                return await this.Context.Set<Studio>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Studio>();
                        }
                }

                private async Task<Studio> GetById(int id)
                {
                        List<Studio> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Admin>> Admins(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Admin>().Where(x => x.StudioId == studioId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Admin>();
                }
                public async virtual Task<List<Family>> Families(int id, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Family>().Where(x => x.Id == id).AsQueryable().Skip(offset).Take(limit).ToListAsync<Family>();
                }
                public async virtual Task<List<Lesson>> Lessons(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Lesson>().Where(x => x.StudioId == studioId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Lesson>();
                }
                public async virtual Task<List<LessonStatus>> LessonStatus(int id, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<LessonStatus>().Where(x => x.Id == id).AsQueryable().Skip(offset).Take(limit).ToListAsync<LessonStatus>();
                }
                public async virtual Task<List<Space>> Spaces(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Space>().Where(x => x.StudioId == studioId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Space>();
                }
                public async virtual Task<List<SpaceFeature>> SpaceFeatures(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SpaceFeature>().Where(x => x.StudioId == studioId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceFeature>();
                }
                public async virtual Task<List<Student>> Students(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Student>().Where(x => x.StudioId == studioId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Student>();
                }
                public async virtual Task<List<Teacher>> Teachers(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Teacher>().Where(x => x.StudioId == studioId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Teacher>();
                }
                public async virtual Task<List<TeacherSkill>> TeacherSkills(int studioId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<TeacherSkill>().Where(x => x.StudioId == studioId).AsQueryable().Skip(offset).Take(limit).ToListAsync<TeacherSkill>();
                }

                public async virtual Task<State> GetState(int stateId)
                {
                        return await this.Context.Set<State>().SingleOrDefaultAsync(x => x.Id == stateId);
                }
        }
}

/*<Codenesium>
    <Hash>2be8be56c131fe4b636e4dd5e6864410</Hash>
</Codenesium>*/