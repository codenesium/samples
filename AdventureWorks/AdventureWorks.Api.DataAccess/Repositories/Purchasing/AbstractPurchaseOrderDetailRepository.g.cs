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
        public abstract class AbstractPurchaseOrderDetailRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPurchaseOrderDetailRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PurchaseOrderDetail>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<PurchaseOrderDetail> Get(int purchaseOrderID)
                {
                        return await this.GetById(purchaseOrderID);
                }

                public async virtual Task<PurchaseOrderDetail> Create(PurchaseOrderDetail item)
                {
                        this.Context.Set<PurchaseOrderDetail>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(PurchaseOrderDetail item)
                {
                        var entity = this.Context.Set<PurchaseOrderDetail>().Local.FirstOrDefault(x => x.PurchaseOrderID == item.PurchaseOrderID);
                        if (entity == null)
                        {
                                this.Context.Set<PurchaseOrderDetail>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int purchaseOrderID)
                {
                        PurchaseOrderDetail record = await this.GetById(purchaseOrderID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<PurchaseOrderDetail>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<PurchaseOrderDetail>> GetProductID(int productID)
                {
                        var records = await this.SearchLinqEF(x => x.ProductID == productID);

                        return records;
                }

                protected async Task<List<PurchaseOrderDetail>> Where(Expression<Func<PurchaseOrderDetail, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<PurchaseOrderDetail> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<PurchaseOrderDetail>> SearchLinqEF(Expression<Func<PurchaseOrderDetail, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PurchaseOrderDetail.PurchaseOrderID)} ASC";
                        }

                        return await this.Context.Set<PurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PurchaseOrderDetail>();
                }

                private async Task<List<PurchaseOrderDetail>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PurchaseOrderDetail.PurchaseOrderID)} ASC";
                        }

                        return await this.Context.Set<PurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PurchaseOrderDetail>();
                }

                private async Task<PurchaseOrderDetail> GetById(int purchaseOrderID)
                {
                        List<PurchaseOrderDetail> records = await this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>d566ae998b1aeb654526814f0800169c</Hash>
</Codenesium>*/