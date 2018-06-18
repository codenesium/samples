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
        public abstract class AbstractBusinessEntityAddressRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractBusinessEntityAddressRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<BusinessEntityAddress>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<BusinessEntityAddress> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<BusinessEntityAddress> Create(BusinessEntityAddress item)
                {
                        this.Context.Set<BusinessEntityAddress>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(BusinessEntityAddress item)
                {
                        var entity = this.Context.Set<BusinessEntityAddress>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<BusinessEntityAddress>().Attach(item);
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
                        BusinessEntityAddress record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<BusinessEntityAddress>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<BusinessEntityAddress>> ByAddressID(int addressID)
                {
                        var records = await this.Where(x => x.AddressID == addressID);

                        return records;
                }
                public async Task<List<BusinessEntityAddress>> ByAddressTypeID(int addressTypeID)
                {
                        var records = await this.Where(x => x.AddressTypeID == addressTypeID);

                        return records;
                }

                protected async Task<List<BusinessEntityAddress>> Where(
                        Expression<Func<BusinessEntityAddress, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<BusinessEntityAddress, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.BusinessEntityID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<BusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<BusinessEntityAddress>();
                        }
                        else
                        {
                                return await this.Context.Set<BusinessEntityAddress>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<BusinessEntityAddress>();
                        }
                }

                private async Task<BusinessEntityAddress> GetById(int businessEntityID)
                {
                        List<BusinessEntityAddress> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>ecb60467a7f94ec9945fa80b3bd029c9</Hash>
</Codenesium>*/