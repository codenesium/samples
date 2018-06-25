using Codenesium.DataConversionExtensions;
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
        public abstract class AbstractSalesPersonRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSalesPersonRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SalesPerson>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<SalesPerson> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<SalesPerson> Create(SalesPerson item)
                {
                        this.Context.Set<SalesPerson>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SalesPerson item)
                {
                        var entity = this.Context.Set<SalesPerson>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<SalesPerson>().Attach(item);
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
                        SalesPerson record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SalesPerson>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async virtual Task<List<SalesOrderHeader>> SalesOrderHeaders(int salesPersonID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SalesOrderHeader>().Where(x => x.SalesPersonID == salesPersonID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
                }

                public async virtual Task<List<SalesPersonQuotaHistory>> SalesPersonQuotaHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SalesPersonQuotaHistory>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesPersonQuotaHistory>();
                }

                public async virtual Task<List<SalesTerritoryHistory>> SalesTerritoryHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SalesTerritoryHistory>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesTerritoryHistory>();
                }

                public async virtual Task<List<Store>> Stores(int salesPersonID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Store>().Where(x => x.SalesPersonID == salesPersonID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Store>();
                }

                public async virtual Task<SalesTerritory> GetSalesTerritory(int? territoryID)
                {
                        return await this.Context.Set<SalesTerritory>().SingleOrDefaultAsync(x => x.TerritoryID == territoryID);
                }

                protected async Task<List<SalesPerson>> Where(
                        Expression<Func<SalesPerson, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<SalesPerson, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.BusinessEntityID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<SalesPerson>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesPerson>();
                        }
                        else
                        {
                                return await this.Context.Set<SalesPerson>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SalesPerson>();
                        }
                }

                private async Task<SalesPerson> GetById(int businessEntityID)
                {
                        List<SalesPerson> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>524a5f9f8c71f6862b8ffa95b0869ec9</Hash>
</Codenesium>*/