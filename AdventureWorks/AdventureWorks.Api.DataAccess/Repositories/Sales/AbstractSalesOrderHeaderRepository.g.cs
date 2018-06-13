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
        public abstract class AbstractSalesOrderHeaderRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSalesOrderHeaderRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SalesOrderHeader>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<SalesOrderHeader> Get(int salesOrderID)
                {
                        return await this.GetById(salesOrderID);
                }

                public async virtual Task<SalesOrderHeader> Create(SalesOrderHeader item)
                {
                        this.Context.Set<SalesOrderHeader>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SalesOrderHeader item)
                {
                        var entity = this.Context.Set<SalesOrderHeader>().Local.FirstOrDefault(x => x.SalesOrderID == item.SalesOrderID);
                        if (entity == null)
                        {
                                this.Context.Set<SalesOrderHeader>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int salesOrderID)
                {
                        SalesOrderHeader record = await this.GetById(salesOrderID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SalesOrderHeader>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<SalesOrderHeader> GetSalesOrderNumber(string salesOrderNumber)
                {
                        var records = await this.SearchLinqEF(x => x.SalesOrderNumber == salesOrderNumber);

                        return records.FirstOrDefault();
                }
                public async Task<List<SalesOrderHeader>> GetCustomerID(int customerID)
                {
                        var records = await this.SearchLinqEF(x => x.CustomerID == customerID);

                        return records;
                }
                public async Task<List<SalesOrderHeader>> GetSalesPersonID(Nullable<int> salesPersonID)
                {
                        var records = await this.SearchLinqEF(x => x.SalesPersonID == salesPersonID);

                        return records;
                }

                protected async Task<List<SalesOrderHeader>> Where(Expression<Func<SalesOrderHeader, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<SalesOrderHeader> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<SalesOrderHeader>> SearchLinqEF(Expression<Func<SalesOrderHeader, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesOrderHeader.SalesOrderID)} ASC";
                        }

                        return await this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
                }

                private async Task<List<SalesOrderHeader>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesOrderHeader.SalesOrderID)} ASC";
                        }

                        return await this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
                }

                private async Task<SalesOrderHeader> GetById(int salesOrderID)
                {
                        List<SalesOrderHeader> records = await this.SearchLinqEF(x => x.SalesOrderID == salesOrderID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<SalesOrderDetail>> SalesOrderDetails(int salesOrderID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SalesOrderDetail>().Where(x => x.SalesOrderID == salesOrderID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderDetail>();
                }
                public async virtual Task<List<SalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasons(int salesOrderID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SalesOrderHeaderSalesReason>().Where(x => x.SalesOrderID == salesOrderID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeaderSalesReason>();
                }
        }
}

/*<Codenesium>
    <Hash>4758130a62381f26ede22f7a27310186</Hash>
</Codenesium>*/