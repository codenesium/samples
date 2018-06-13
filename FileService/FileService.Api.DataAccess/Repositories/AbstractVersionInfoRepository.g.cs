using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
        public abstract class AbstractVersionInfoRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractVersionInfoRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<VersionInfo>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<VersionInfo> Get(long version)
                {
                        return await this.GetById(version);
                }

                public async virtual Task<VersionInfo> Create(VersionInfo item)
                {
                        this.Context.Set<VersionInfo>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(VersionInfo item)
                {
                        var entity = this.Context.Set<VersionInfo>().Local.FirstOrDefault(x => x.Version == item.Version);
                        if (entity == null)
                        {
                                this.Context.Set<VersionInfo>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        long version)
                {
                        VersionInfo record = await this.GetById(version);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<VersionInfo>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<VersionInfo> GetVersion(long version)
                {
                        var records = await this.SearchLinqEF(x => x.Version == version);

                        return records.FirstOrDefault();
                }

                protected async Task<List<VersionInfo>> Where(Expression<Func<VersionInfo, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<VersionInfo> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<VersionInfo>> SearchLinqEF(Expression<Func<VersionInfo, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(VersionInfo.Version)} ASC";
                        }

                        return await this.Context.Set<VersionInfo>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<VersionInfo>();
                }

                private async Task<List<VersionInfo>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(VersionInfo.Version)} ASC";
                        }

                        return await this.Context.Set<VersionInfo>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<VersionInfo>();
                }

                private async Task<VersionInfo> GetById(long version)
                {
                        List<VersionInfo> records = await this.SearchLinqEF(x => x.Version == version);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>2de82ca0b0c5e907b16bd297401cd4ba</Hash>
</Codenesium>*/