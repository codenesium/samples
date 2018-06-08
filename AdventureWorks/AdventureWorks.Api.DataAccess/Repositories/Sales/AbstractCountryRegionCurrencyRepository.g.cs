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
        public abstract class AbstractCountryRegionCurrencyRepository: AbstractRepository
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

                public virtual Task<List<CountryRegionCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                public async Task<List<CountryRegionCurrency>> GetCurrencyCode(string currencyCode)
                {
                        var records = await this.SearchLinqEF(x => x.CurrencyCode == currencyCode);

                        return records;
                }

                protected async Task<List<CountryRegionCurrency>> Where(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<CountryRegionCurrency> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<CountryRegionCurrency>> SearchLinqEF(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(CountryRegionCurrency.CountryRegionCode)} ASC";
                        }

                        return await this.Context.Set<CountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CountryRegionCurrency>();
                }

                private async Task<List<CountryRegionCurrency>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(CountryRegionCurrency.CountryRegionCode)} ASC";
                        }

                        return await this.Context.Set<CountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CountryRegionCurrency>();
                }

                private async Task<CountryRegionCurrency> GetById(string countryRegionCode)
                {
                        List<CountryRegionCurrency> records = await this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>6bb1a2a32e6663019eacd69fdbdc3138</Hash>
</Codenesium>*/