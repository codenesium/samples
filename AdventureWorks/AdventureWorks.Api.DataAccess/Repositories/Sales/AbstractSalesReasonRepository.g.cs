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
        public abstract class AbstractSalesReasonRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSalesReasonRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SalesReason>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<SalesReason> Get(int salesReasonID)
                {
                        return await this.GetById(salesReasonID);
                }

                public async virtual Task<SalesReason> Create(SalesReason item)
                {
                        this.Context.Set<SalesReason>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SalesReason item)
                {
                        var entity = this.Context.Set<SalesReason>().Local.FirstOrDefault(x => x.SalesReasonID == item.SalesReasonID);
                        if (entity == null)
                        {
                                this.Context.Set<SalesReason>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int salesReasonID)
                {
                        SalesReason record = await this.GetById(salesReasonID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SalesReason>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<SalesReason>> Where(Expression<Func<SalesReason, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<SalesReason> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<SalesReason>> SearchLinqEF(Expression<Func<SalesReason, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesReason.SalesReasonID)} ASC";
                        }

                        return await this.Context.Set<SalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SalesReason>();
                }

                private async Task<List<SalesReason>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesReason.SalesReasonID)} ASC";
                        }

                        return await this.Context.Set<SalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SalesReason>();
                }

                private async Task<SalesReason> GetById(int salesReasonID)
                {
                        List<SalesReason> records = await this.SearchLinqEF(x => x.SalesReasonID == salesReasonID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<SalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasons(int salesReasonID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SalesOrderHeaderSalesReason>().Where(x => x.SalesReasonID == salesReasonID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeaderSalesReason>();
                }
        }
}

/*<Codenesium>
    <Hash>f62e075f57304f664f4c8a5321cefe42</Hash>
</Codenesium>*/