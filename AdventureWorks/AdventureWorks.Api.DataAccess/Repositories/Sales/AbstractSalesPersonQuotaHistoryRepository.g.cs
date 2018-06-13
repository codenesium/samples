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
        public abstract class AbstractSalesPersonQuotaHistoryRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSalesPersonQuotaHistoryRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SalesPersonQuotaHistory>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<SalesPersonQuotaHistory> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<SalesPersonQuotaHistory> Create(SalesPersonQuotaHistory item)
                {
                        this.Context.Set<SalesPersonQuotaHistory>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SalesPersonQuotaHistory item)
                {
                        var entity = this.Context.Set<SalesPersonQuotaHistory>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<SalesPersonQuotaHistory>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int businessEntityID)
                {
                        SalesPersonQuotaHistory record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SalesPersonQuotaHistory>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<SalesPersonQuotaHistory>> Where(Expression<Func<SalesPersonQuotaHistory, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<SalesPersonQuotaHistory> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<SalesPersonQuotaHistory>> SearchLinqEF(Expression<Func<SalesPersonQuotaHistory, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesPersonQuotaHistory.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<SalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SalesPersonQuotaHistory>();
                }

                private async Task<List<SalesPersonQuotaHistory>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesPersonQuotaHistory.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<SalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SalesPersonQuotaHistory>();
                }

                private async Task<SalesPersonQuotaHistory> GetById(int businessEntityID)
                {
                        List<SalesPersonQuotaHistory> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>42f26290827910a4ef753c76f6629067</Hash>
</Codenesium>*/