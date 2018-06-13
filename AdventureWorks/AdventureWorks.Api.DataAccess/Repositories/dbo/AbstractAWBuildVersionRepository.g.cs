using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractAWBuildVersionRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractAWBuildVersionRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<AWBuildVersion>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<AWBuildVersion> Get(int systemInformationID)
                {
                        return await this.GetById(systemInformationID);
                }

                public async virtual Task<AWBuildVersion> Create(AWBuildVersion item)
                {
                        this.Context.Set<AWBuildVersion>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(AWBuildVersion item)
                {
                        var entity = this.Context.Set<AWBuildVersion>().Local.FirstOrDefault(x => x.SystemInformationID == item.SystemInformationID);
                        if (entity == null)
                        {
                                this.Context.Set<AWBuildVersion>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int systemInformationID)
                {
                        AWBuildVersion record = await this.GetById(systemInformationID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<AWBuildVersion>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<AWBuildVersion>> Where(Expression<Func<AWBuildVersion, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<AWBuildVersion> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<AWBuildVersion>> SearchLinqEF(Expression<Func<AWBuildVersion, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(AWBuildVersion.SystemInformationID)} ASC";
                        }

                        return await this.Context.Set<AWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<AWBuildVersion>();
                }

                private async Task<List<AWBuildVersion>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(AWBuildVersion.SystemInformationID)} ASC";
                        }

                        return await this.Context.Set<AWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<AWBuildVersion>();
                }

                private async Task<AWBuildVersion> GetById(int systemInformationID)
                {
                        List<AWBuildVersion> records = await this.SearchLinqEF(x => x.SystemInformationID == systemInformationID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>768044740489026f1a87f9e243956167</Hash>
</Codenesium>*/