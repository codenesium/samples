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
        public abstract class AbstractSalesOrderDetailRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSalesOrderDetailRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SalesOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<SalesOrderDetail> Get(int salesOrderID)
                {
                        return await this.GetById(salesOrderID);
                }

                public async virtual Task<SalesOrderDetail> Create(SalesOrderDetail item)
                {
                        this.Context.Set<SalesOrderDetail>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SalesOrderDetail item)
                {
                        var entity = this.Context.Set<SalesOrderDetail>().Local.FirstOrDefault(x => x.SalesOrderID == item.SalesOrderID);
                        if (entity == null)
                        {
                                this.Context.Set<SalesOrderDetail>().Attach(item);
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
                        SalesOrderDetail record = await this.GetById(salesOrderID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SalesOrderDetail>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<SalesOrderDetail>> GetProductID(int productID)
                {
                        var records = await this.SearchLinqEF(x => x.ProductID == productID);

                        return records;
                }

                protected async Task<List<SalesOrderDetail>> Where(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<SalesOrderDetail> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<SalesOrderDetail>> SearchLinqEF(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesOrderDetail.SalesOrderID)} ASC";
                        }

                        return await this.Context.Set<SalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderDetail>();
                }

                private async Task<List<SalesOrderDetail>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesOrderDetail.SalesOrderID)} ASC";
                        }

                        return await this.Context.Set<SalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderDetail>();
                }

                private async Task<SalesOrderDetail> GetById(int salesOrderID)
                {
                        List<SalesOrderDetail> records = await this.SearchLinqEF(x => x.SalesOrderID == salesOrderID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>0fd0aac5652ca9fe8921c0c4a5be68da</Hash>
</Codenesium>*/