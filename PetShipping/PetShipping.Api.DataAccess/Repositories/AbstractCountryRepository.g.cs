using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public abstract class AbstractCountryRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCountryRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Country>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Country> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Country> Create(Country item)
                {
                        this.Context.Set<Country>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Country item)
                {
                        var entity = this.Context.Set<Country>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Country>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int id)
                {
                        Country record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Country>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Country>> Where(Expression<Func<Country, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Country> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Country>> SearchLinqEF(Expression<Func<Country, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Country.Id)} ASC";
                        }

                        return await this.Context.Set<Country>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Country>();
                }

                private async Task<List<Country>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Country.Id)} ASC";
                        }

                        return await this.Context.Set<Country>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Country>();
                }

                private async Task<Country> GetById(int id)
                {
                        List<Country> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<CountryRequirement>> CountryRequirements(int countryId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<CountryRequirement>().Where(x => x.CountryId == countryId).AsQueryable().Skip(offset).Take(limit).ToListAsync<CountryRequirement>();
                }
                public async virtual Task<List<Destination>> Destinations(int countryId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Destination>().Where(x => x.CountryId == countryId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Destination>();
                }
        }
}

/*<Codenesium>
    <Hash>6d0ce4ee407cb041464209273b2314dd</Hash>
</Codenesium>*/