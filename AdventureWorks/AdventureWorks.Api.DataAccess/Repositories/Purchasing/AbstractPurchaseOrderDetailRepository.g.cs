using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractPurchaseOrderDetailRepository : AbstractRepository
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

                public virtual Task<List<PurchaseOrderDetail>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                public async Task<List<PurchaseOrderDetail>> ByProductID(int productID)
                {
                        var records = await this.Where(x => x.ProductID == productID);

                        return records;
                }

                protected async Task<List<PurchaseOrderDetail>> Where(
                        Expression<Func<PurchaseOrderDetail, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<PurchaseOrderDetail, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.PurchaseOrderID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<PurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PurchaseOrderDetail>();
                        }
                        else
                        {
                                return await this.Context.Set<PurchaseOrderDetail>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<PurchaseOrderDetail>();
                        }
                }

                private async Task<PurchaseOrderDetail> GetById(int purchaseOrderID)
                {
                        List<PurchaseOrderDetail> records = await this.Where(x => x.PurchaseOrderID == purchaseOrderID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>abe448c5d7a8318a34612f3dbaa6b553</Hash>
</Codenesium>*/