using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractBusinessEntityContactRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractBusinessEntityContactRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<BusinessEntityContact>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<BusinessEntityContact> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<BusinessEntityContact> Create(BusinessEntityContact item)
                {
                        this.Context.Set<BusinessEntityContact>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(BusinessEntityContact item)
                {
                        var entity = this.Context.Set<BusinessEntityContact>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<BusinessEntityContact>().Attach(item);
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
                        BusinessEntityContact record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<BusinessEntityContact>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<BusinessEntityContact>> ByContactTypeID(int contactTypeID)
                {
                        var records = await this.Where(x => x.ContactTypeID == contactTypeID);

                        return records;
                }

                public async Task<List<BusinessEntityContact>> ByPersonID(int personID)
                {
                        var records = await this.Where(x => x.PersonID == personID);

                        return records;
                }

                protected async Task<List<BusinessEntityContact>> Where(
                        Expression<Func<BusinessEntityContact, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<BusinessEntityContact, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.BusinessEntityID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<BusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<BusinessEntityContact>();
                        }
                        else
                        {
                                return await this.Context.Set<BusinessEntityContact>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<BusinessEntityContact>();
                        }
                }

                private async Task<BusinessEntityContact> GetById(int businessEntityID)
                {
                        List<BusinessEntityContact> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>5a85dda10c8c56b6ebd71a038b5256df</Hash>
</Codenesium>*/