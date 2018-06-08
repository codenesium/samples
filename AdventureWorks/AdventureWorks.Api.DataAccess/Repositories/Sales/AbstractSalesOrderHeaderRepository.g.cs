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

                public virtual Task<List<SalesOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                protected async Task<List<SalesOrderHeader>> Where(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<SalesOrderHeader> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<SalesOrderHeader>> SearchLinqEF(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesOrderHeader.SalesOrderID)} ASC";
                        }

                        return await this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderHeader>();
                }

                private async Task<List<SalesOrderHeader>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesOrderHeader.SalesOrderID)} ASC";
                        }

                        return await this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderHeader>();
                }

                private async Task<SalesOrderHeader> GetById(int salesOrderID)
                {
                        List<SalesOrderHeader> records = await this.SearchLinqEF(x => x.SalesOrderID == salesOrderID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>b18b5e940c32b247adfda54ca7b10947</Hash>
</Codenesium>*/