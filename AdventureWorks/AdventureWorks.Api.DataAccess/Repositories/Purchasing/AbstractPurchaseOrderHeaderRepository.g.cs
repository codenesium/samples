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
        public abstract class AbstractPurchaseOrderHeaderRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPurchaseOrderHeaderRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PurchaseOrderHeader>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<PurchaseOrderHeader> Get(int purchaseOrderID)
                {
                        return await this.GetById(purchaseOrderID);
                }

                public async virtual Task<PurchaseOrderHeader> Create(PurchaseOrderHeader item)
                {
                        this.Context.Set<PurchaseOrderHeader>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(PurchaseOrderHeader item)
                {
                        var entity = this.Context.Set<PurchaseOrderHeader>().Local.FirstOrDefault(x => x.PurchaseOrderID == item.PurchaseOrderID);
                        if (entity == null)
                        {
                                this.Context.Set<PurchaseOrderHeader>().Attach(item);
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
                        PurchaseOrderHeader record = await this.GetById(purchaseOrderID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<PurchaseOrderHeader>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<PurchaseOrderHeader>> GetEmployeeID(int employeeID)
                {
                        var records = await this.SearchLinqEF(x => x.EmployeeID == employeeID);

                        return records;
                }
                public async Task<List<PurchaseOrderHeader>> GetVendorID(int vendorID)
                {
                        var records = await this.SearchLinqEF(x => x.VendorID == vendorID);

                        return records;
                }

                protected async Task<List<PurchaseOrderHeader>> Where(Expression<Func<PurchaseOrderHeader, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<PurchaseOrderHeader> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<PurchaseOrderHeader>> SearchLinqEF(Expression<Func<PurchaseOrderHeader, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PurchaseOrderHeader.PurchaseOrderID)} ASC";
                        }

                        return await this.Context.Set<PurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PurchaseOrderHeader>();
                }

                private async Task<List<PurchaseOrderHeader>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PurchaseOrderHeader.PurchaseOrderID)} ASC";
                        }

                        return await this.Context.Set<PurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PurchaseOrderHeader>();
                }

                private async Task<PurchaseOrderHeader> GetById(int purchaseOrderID)
                {
                        List<PurchaseOrderHeader> records = await this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<PurchaseOrderDetail>> PurchaseOrderDetails(int purchaseOrderID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<PurchaseOrderDetail>().Where(x => x.PurchaseOrderID == purchaseOrderID).AsQueryable().Skip(offset).Take(limit).ToListAsync<PurchaseOrderDetail>();
                }
        }
}

/*<Codenesium>
    <Hash>fb136774c753528621221926019307e7</Hash>
</Codenesium>*/