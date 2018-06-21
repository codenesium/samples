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
        public abstract class AbstractCountryRegionCurrencyRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCountryRegionCurrencyRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<CountryRegionCurrency>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<CountryRegionCurrency> Get(string countryRegionCode)
                {
                        return await this.GetById(countryRegionCode);
                }

                public async virtual Task<CountryRegionCurrency> Create(CountryRegionCurrency item)
                {
                        this.Context.Set<CountryRegionCurrency>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(CountryRegionCurrency item)
                {
                        var entity = this.Context.Set<CountryRegionCurrency>().Local.FirstOrDefault(x => x.CountryRegionCode == item.CountryRegionCode);
                        if (entity == null)
                        {
                                this.Context.Set<CountryRegionCurrency>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string countryRegionCode)
                {
                        CountryRegionCurrency record = await this.GetById(countryRegionCode);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<CountryRegionCurrency>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<CountryRegionCurrency>> ByCurrencyCode(string currencyCode)
                {
                        var records = await this.Where(x => x.CurrencyCode == currencyCode);

                        return records;
                }

                public async virtual Task<Currency> GetCurrency(string currencyCode)
                {
                        return await this.Context.Set<Currency>().SingleOrDefaultAsync(x => x.CurrencyCode == currencyCode);
                }

                protected async Task<List<CountryRegionCurrency>> Where(
                        Expression<Func<CountryRegionCurrency, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<CountryRegionCurrency, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.CountryRegionCode;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<CountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CountryRegionCurrency>();
                        }
                        else
                        {
                                return await this.Context.Set<CountryRegionCurrency>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<CountryRegionCurrency>();
                        }
                }

                private async Task<CountryRegionCurrency> GetById(string countryRegionCode)
                {
                        List<CountryRegionCurrency> records = await this.Where(x => x.CountryRegionCode == countryRegionCode);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>594cc95f84848313d9844f882c2f9f55</Hash>
</Codenesium>*/