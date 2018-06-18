using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractSalesTerritoryHistoryRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSalesTerritoryHistoryRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SalesTerritoryHistory>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<SalesTerritoryHistory> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<SalesTerritoryHistory> Create(SalesTerritoryHistory item)
                {
                        this.Context.Set<SalesTerritoryHistory>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SalesTerritoryHistory item)
                {
                        var entity = this.Context.Set<SalesTerritoryHistory>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<SalesTerritoryHistory>().Attach(item);
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
                        SalesTerritoryHistory record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SalesTerritoryHistory>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<SalesTerritoryHistory>> Where(
                        Expression<Func<SalesTerritoryHistory, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<SalesTerritoryHistory, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.BusinessEntityID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<SalesTerritoryHistory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesTerritoryHistory>();
                        }
                        else
                        {
                                return await this.Context.Set<SalesTerritoryHistory>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SalesTerritoryHistory>();
                        }
                }

                private async Task<SalesTerritoryHistory> GetById(int businessEntityID)
                {
                        List<SalesTerritoryHistory> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<SalesPerson> GetSalesPerson(int businessEntityID)
                {
                        return await this.Context.Set<SalesPerson>().SingleOrDefaultAsync(x => x.BusinessEntityID == businessEntityID);
                }
                public async virtual Task<SalesTerritory> GetSalesTerritory(int territoryID)
                {
                        return await this.Context.Set<SalesTerritory>().SingleOrDefaultAsync(x => x.TerritoryID == territoryID);
                }
        }
}

/*<Codenesium>
    <Hash>7d4c6872f818b9a6f6554d6373199dde</Hash>
</Codenesium>*/