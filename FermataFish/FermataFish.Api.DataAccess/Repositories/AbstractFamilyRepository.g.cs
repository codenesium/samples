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
        public abstract class AbstractFamilyRepository: AbstractRepository
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

                public virtual Task<List<Family>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<Family>> Where(Expression<Func<Family, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Family> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Family>> SearchLinqEF(Expression<Func<Family, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Family.Id)} ASC";
                        }

                        return await this.Context.Set<Family>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Family>();
                }

                private async Task<List<Family>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Family.Id)} ASC";
                        }

                        return await this.Context.Set<Family>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Family>();
                }

                private async Task<Family> GetById(int id)
                {
                        List<Family> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Student>> Students(int familyId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Student>().Where(x => x.FamilyId == familyId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Student>();
                }
                public async virtual Task<List<StudentXFamily>> StudentXFamilies(int familyId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<StudentXFamily>().Where(x => x.FamilyId == familyId).AsQueryable().Skip(offset).Take(limit).ToListAsync<StudentXFamily>();
                }
        }
}

/*<Codenesium>
    <Hash>1060de65420484a76ff97dde6a32d0eb</Hash>
</Codenesium>*/