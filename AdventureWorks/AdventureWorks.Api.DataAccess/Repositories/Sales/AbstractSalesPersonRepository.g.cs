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
        public abstract class AbstractSalesPersonRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSalesPersonRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SalesPerson>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<SalesPerson>> Where(Expression<Func<SalesPerson, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<SalesPerson> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<SalesPerson>> SearchLinqEF(Expression<Func<SalesPerson, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesPerson.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<SalesPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SalesPerson>();
                }

                private async Task<List<SalesPerson>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesPerson.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<SalesPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SalesPerson>();
                }

                private async Task<SalesPerson> GetById(int businessEntityID)
                {
                        List<SalesPerson> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
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
        }
}

/*<Codenesium>
    <Hash>91e4dd6825cd03ecd8730f1028131e85</Hash>
</Codenesium>*/