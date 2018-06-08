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
        public abstract class AbstractBusinessEntityContactRepository: AbstractRepository
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

                public virtual Task<List<BusinessEntityContact>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                public async Task<List<BusinessEntityContact>> GetContactTypeID(int contactTypeID)
                {
                        var records = await this.SearchLinqEF(x => x.ContactTypeID == contactTypeID);

                        return records;
                }
                public async Task<List<BusinessEntityContact>> GetPersonID(int personID)
                {
                        var records = await this.SearchLinqEF(x => x.PersonID == personID);

                        return records;
                }

                protected async Task<List<BusinessEntityContact>> Where(Expression<Func<BusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<BusinessEntityContact> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<BusinessEntityContact>> SearchLinqEF(Expression<Func<BusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(BusinessEntityContact.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<BusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntityContact>();
                }

                private async Task<List<BusinessEntityContact>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(BusinessEntityContact.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<BusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntityContact>();
                }

                private async Task<BusinessEntityContact> GetById(int businessEntityID)
                {
                        List<BusinessEntityContact> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>bcd76d2c237e371133d7be79ac60baa5</Hash>
</Codenesium>*/