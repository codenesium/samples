using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractNuGetPackageRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractNuGetPackageRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<NuGetPackage>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<NuGetPackage> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<NuGetPackage> Create(NuGetPackage item)
                {
                        this.Context.Set<NuGetPackage>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(NuGetPackage item)
                {
                        var entity = this.Context.Set<NuGetPackage>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<NuGetPackage>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string id)
                {
                        NuGetPackage record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<NuGetPackage>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<NuGetPackage>> Where(Expression<Func<NuGetPackage, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<NuGetPackage> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<NuGetPackage>> SearchLinqEF(Expression<Func<NuGetPackage, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(NuGetPackage.Id)} ASC";
                        }

                        return await this.Context.Set<NuGetPackage>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<NuGetPackage>();
                }

                private async Task<List<NuGetPackage>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(NuGetPackage.Id)} ASC";
                        }

                        return await this.Context.Set<NuGetPackage>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<NuGetPackage>();
                }

                private async Task<NuGetPackage> GetById(string id)
                {
                        List<NuGetPackage> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>9a26ed50cc13525f649573e82e0ef413</Hash>
</Codenesium>*/