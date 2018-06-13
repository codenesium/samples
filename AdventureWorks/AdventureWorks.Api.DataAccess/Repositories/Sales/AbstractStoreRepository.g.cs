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
        public abstract class AbstractStoreRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractStoreRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Store>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Store> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<Store> Create(Store item)
                {
                        this.Context.Set<Store>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Store item)
                {
                        var entity = this.Context.Set<Store>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<Store>().Attach(item);
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
                        Store record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Store>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<Store>> GetSalesPersonID(Nullable<int> salesPersonID)
                {
                        var records = await this.SearchLinqEF(x => x.SalesPersonID == salesPersonID);

                        return records;
                }
                public async Task<List<Store>> GetDemographics(string demographics)
                {
                        var records = await this.SearchLinqEF(x => x.Demographics == demographics);

                        return records;
                }

                protected async Task<List<Store>> Where(Expression<Func<Store, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Store> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Store>> SearchLinqEF(Expression<Func<Store, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Store.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<Store>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Store>();
                }

                private async Task<List<Store>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Store.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<Store>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Store>();
                }

                private async Task<Store> GetById(int businessEntityID)
                {
                        List<Store> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Customer>> Customers(int storeID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Customer>().Where(x => x.StoreID == storeID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Customer>();
                }
        }
}

/*<Codenesium>
    <Hash>37ced400982375be84c2b81254544d03</Hash>
</Codenesium>*/