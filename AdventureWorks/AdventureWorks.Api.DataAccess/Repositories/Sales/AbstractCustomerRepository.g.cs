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
        public abstract class AbstractCustomerRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCustomerRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Customer>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Customer> Get(int customerID)
                {
                        return await this.GetById(customerID);
                }

                public async virtual Task<Customer> Create(Customer item)
                {
                        this.Context.Set<Customer>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Customer item)
                {
                        var entity = this.Context.Set<Customer>().Local.FirstOrDefault(x => x.CustomerID == item.CustomerID);
                        if (entity == null)
                        {
                                this.Context.Set<Customer>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int customerID)
                {
                        Customer record = await this.GetById(customerID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Customer>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Customer> GetAccountNumber(string accountNumber)
                {
                        var records = await this.SearchLinqEF(x => x.AccountNumber == accountNumber);

                        return records.FirstOrDefault();
                }
                public async Task<List<Customer>> GetTerritoryID(Nullable<int> territoryID)
                {
                        var records = await this.SearchLinqEF(x => x.TerritoryID == territoryID);

                        return records;
                }

                protected async Task<List<Customer>> Where(Expression<Func<Customer, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Customer> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Customer>> SearchLinqEF(Expression<Func<Customer, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Customer.CustomerID)} ASC";
                        }

                        return await this.Context.Set<Customer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Customer>();
                }

                private async Task<List<Customer>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Customer.CustomerID)} ASC";
                        }

                        return await this.Context.Set<Customer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Customer>();
                }

                private async Task<Customer> GetById(int customerID)
                {
                        List<Customer> records = await this.SearchLinqEF(x => x.CustomerID == customerID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<SalesOrderHeader>> SalesOrderHeaders(int customerID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SalesOrderHeader>().Where(x => x.CustomerID == customerID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
                }
        }
}

/*<Codenesium>
    <Hash>acd6a3390b6a1553a82e30d28d25f250</Hash>
</Codenesium>*/