using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractFamilyRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractFamilyRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Family>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Family> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Family> Create(Family item)
                {
                        this.Context.Set<Family>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Family item)
                {
                        var entity = this.Context.Set<Family>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Family>().Attach(item);
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
                        Family record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Family>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async virtual Task<List<Student>> Students(int familyId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Student>().Where(x => x.FamilyId == familyId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Student>();
                }

                public async virtual Task<List<StudentXFamily>> StudentXFamilies(int familyId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<StudentXFamily>().Where(x => x.FamilyId == familyId).AsQueryable().Skip(offset).Take(limit).ToListAsync<StudentXFamily>();
                }

                public async virtual Task<Studio> GetStudio(int id)
                {
                        return await this.Context.Set<Studio>().SingleOrDefaultAsync(x => x.Id == id);
                }

                protected async Task<List<Family>> Where(
                        Expression<Func<Family, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Family, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Family>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Family>();
                        }
                        else
                        {
                                return await this.Context.Set<Family>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Family>();
                        }
                }

                private async Task<Family> GetById(int id)
                {
                        List<Family> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>f8e4976114e792c1694a3b5525c11e5e</Hash>
</Codenesium>*/