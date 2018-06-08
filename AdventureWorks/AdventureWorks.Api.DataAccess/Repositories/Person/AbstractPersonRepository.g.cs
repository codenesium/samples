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
        public abstract class AbstractPersonRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPersonRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Person>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Person> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<Person> Create(Person item)
                {
                        this.Context.Set<Person>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Person item)
                {
                        var entity = this.Context.Set<Person>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<Person>().Attach(item);
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
                        Person record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Person>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<Person>> GetLastNameFirstNameMiddleName(string lastName, string firstName, string middleName)
                {
                        var records = await this.SearchLinqEF(x => x.LastName == lastName && x.FirstName == firstName && x.MiddleName == middleName);

                        return records;
                }
                public async Task<List<Person>> GetAdditionalContactInfo(string additionalContactInfo)
                {
                        var records = await this.SearchLinqEF(x => x.AdditionalContactInfo == additionalContactInfo);

                        return records;
                }
                public async Task<List<Person>> GetDemographics(string demographics)
                {
                        var records = await this.SearchLinqEF(x => x.Demographics == demographics);

                        return records;
                }

                protected async Task<List<Person>> Where(Expression<Func<Person, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Person> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Person>> SearchLinqEF(Expression<Func<Person, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Person.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<Person>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Person>();
                }

                private async Task<List<Person>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Person.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<Person>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Person>();
                }

                private async Task<Person> GetById(int businessEntityID)
                {
                        List<Person> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>c2d33ceb0afbb828a9a0bf3a65235af2</Hash>
</Codenesium>*/