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
        public abstract class AbstractStoreRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractStoreRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Store>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                public async Task<List<Store>> BySalesPersonID(int? salesPersonID)
                {
                        var records = await this.Where(x => x.SalesPersonID == salesPersonID);

                        return records;
                }

                public async Task<List<Store>> ByDemographic(string demographic)
                {
                        var records = await this.Where(x => x.Demographic == demographic);

                        return records;
                }

                public async virtual Task<List<Customer>> Customers(int storeID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Customer>().Where(x => x.StoreID == storeID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Customer>();
                }

                public async virtual Task<SalesPerson> GetSalesPerson(int? salesPersonID)
                {
                        return await this.Context.Set<SalesPerson>().SingleOrDefaultAsync(x => x.BusinessEntityID == salesPersonID);
                }

                protected async Task<List<Store>> Where(
                        Expression<Func<Store, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Store, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.BusinessEntityID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Store>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Store>();
                        }
                        else
                        {
                                return await this.Context.Set<Store>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Store>();
                        }
                }

                private async Task<Store> GetById(int businessEntityID)
                {
                        List<Store> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>4e94c5486df35035e6ae689b325f7dad</Hash>
</Codenesium>*/