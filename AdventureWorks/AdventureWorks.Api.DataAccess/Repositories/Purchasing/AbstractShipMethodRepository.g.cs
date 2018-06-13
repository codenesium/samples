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
        public abstract class AbstractShipMethodRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractShipMethodRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ShipMethod>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ShipMethod> Get(int shipMethodID)
                {
                        return await this.GetById(shipMethodID);
                }

                public async virtual Task<ShipMethod> Create(ShipMethod item)
                {
                        this.Context.Set<ShipMethod>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ShipMethod item)
                {
                        var entity = this.Context.Set<ShipMethod>().Local.FirstOrDefault(x => x.ShipMethodID == item.ShipMethodID);
                        if (entity == null)
                        {
                                this.Context.Set<ShipMethod>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int shipMethodID)
                {
                        ShipMethod record = await this.GetById(shipMethodID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ShipMethod>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<ShipMethod> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<ShipMethod>> Where(Expression<Func<ShipMethod, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ShipMethod> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ShipMethod>> SearchLinqEF(Expression<Func<ShipMethod, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ShipMethod.ShipMethodID)} ASC";
                        }

                        return await this.Context.Set<ShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ShipMethod>();
                }

                private async Task<List<ShipMethod>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ShipMethod.ShipMethodID)} ASC";
                        }

                        return await this.Context.Set<ShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ShipMethod>();
                }

                private async Task<ShipMethod> GetById(int shipMethodID)
                {
                        List<ShipMethod> records = await this.SearchLinqEF(x => x.ShipMethodID == shipMethodID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<PurchaseOrderHeader>> PurchaseOrderHeaders(int shipMethodID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<PurchaseOrderHeader>().Where(x => x.ShipMethodID == shipMethodID).AsQueryable().Skip(offset).Take(limit).ToListAsync<PurchaseOrderHeader>();
                }
        }
}

/*<Codenesium>
    <Hash>c814491d6515281716712c897ffe201a</Hash>
</Codenesium>*/