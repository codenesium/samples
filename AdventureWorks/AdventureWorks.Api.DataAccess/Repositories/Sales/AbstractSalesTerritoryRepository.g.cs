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
        public abstract class AbstractSalesTerritoryRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSalesTerritoryRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SalesTerritory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<SalesTerritory> Get(int territoryID)
                {
                        return await this.GetById(territoryID);
                }

                public async virtual Task<SalesTerritory> Create(SalesTerritory item)
                {
                        this.Context.Set<SalesTerritory>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SalesTerritory item)
                {
                        var entity = this.Context.Set<SalesTerritory>().Local.FirstOrDefault(x => x.TerritoryID == item.TerritoryID);
                        if (entity == null)
                        {
                                this.Context.Set<SalesTerritory>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int territoryID)
                {
                        SalesTerritory record = await this.GetById(territoryID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SalesTerritory>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<SalesTerritory> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<SalesTerritory>> Where(Expression<Func<SalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<SalesTerritory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<SalesTerritory>> SearchLinqEF(Expression<Func<SalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesTerritory.TerritoryID)} ASC";
                        }

                        return await this.Context.Set<SalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesTerritory>();
                }

                private async Task<List<SalesTerritory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesTerritory.TerritoryID)} ASC";
                        }

                        return await this.Context.Set<SalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesTerritory>();
                }

                private async Task<SalesTerritory> GetById(int territoryID)
                {
                        List<SalesTerritory> records = await this.SearchLinqEF(x => x.TerritoryID == territoryID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>8fc86ab1ecacdf37d15a0ad545b1b94b</Hash>
</Codenesium>*/