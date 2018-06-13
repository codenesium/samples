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
        public abstract class AbstractCurrencyRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCurrencyRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Currency>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Currency> Get(string currencyCode)
                {
                        return await this.GetById(currencyCode);
                }

                public async virtual Task<Currency> Create(Currency item)
                {
                        this.Context.Set<Currency>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Currency item)
                {
                        var entity = this.Context.Set<Currency>().Local.FirstOrDefault(x => x.CurrencyCode == item.CurrencyCode);
                        if (entity == null)
                        {
                                this.Context.Set<Currency>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string currencyCode)
                {
                        Currency record = await this.GetById(currencyCode);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Currency>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Currency> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<Currency>> Where(Expression<Func<Currency, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Currency> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Currency>> SearchLinqEF(Expression<Func<Currency, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Currency.CurrencyCode)} ASC";
                        }

                        return await this.Context.Set<Currency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Currency>();
                }

                private async Task<List<Currency>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Currency.CurrencyCode)} ASC";
                        }

                        return await this.Context.Set<Currency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Currency>();
                }

                private async Task<Currency> GetById(string currencyCode)
                {
                        List<Currency> records = await this.SearchLinqEF(x => x.CurrencyCode == currencyCode);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<CountryRegionCurrency>> CountryRegionCurrencies(string currencyCode, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<CountryRegionCurrency>().Where(x => x.CurrencyCode == currencyCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<CountryRegionCurrency>();
                }
                public async virtual Task<List<CurrencyRate>> CurrencyRates(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<CurrencyRate>().Where(x => x.FromCurrencyCode == fromCurrencyCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<CurrencyRate>();
                }
        }
}

/*<Codenesium>
    <Hash>9f596ecfbae6026405abb42bedb1cc88</Hash>
</Codenesium>*/