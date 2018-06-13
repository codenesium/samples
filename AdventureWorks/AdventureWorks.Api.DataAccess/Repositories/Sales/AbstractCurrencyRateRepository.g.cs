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
        public abstract class AbstractCurrencyRateRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCurrencyRateRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<CurrencyRate>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<CurrencyRate> Get(int currencyRateID)
                {
                        return await this.GetById(currencyRateID);
                }

                public async virtual Task<CurrencyRate> Create(CurrencyRate item)
                {
                        this.Context.Set<CurrencyRate>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(CurrencyRate item)
                {
                        var entity = this.Context.Set<CurrencyRate>().Local.FirstOrDefault(x => x.CurrencyRateID == item.CurrencyRateID);
                        if (entity == null)
                        {
                                this.Context.Set<CurrencyRate>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int currencyRateID)
                {
                        CurrencyRate record = await this.GetById(currencyRateID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<CurrencyRate>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<CurrencyRate> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode)
                {
                        var records = await this.SearchLinqEF(x => x.CurrencyRateDate == currencyRateDate && x.FromCurrencyCode == fromCurrencyCode && x.ToCurrencyCode == toCurrencyCode);

                        return records.FirstOrDefault();
                }

                protected async Task<List<CurrencyRate>> Where(Expression<Func<CurrencyRate, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<CurrencyRate> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<CurrencyRate>> SearchLinqEF(Expression<Func<CurrencyRate, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(CurrencyRate.CurrencyRateID)} ASC";
                        }

                        return await this.Context.Set<CurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<CurrencyRate>();
                }

                private async Task<List<CurrencyRate>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(CurrencyRate.CurrencyRateID)} ASC";
                        }

                        return await this.Context.Set<CurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<CurrencyRate>();
                }

                private async Task<CurrencyRate> GetById(int currencyRateID)
                {
                        List<CurrencyRate> records = await this.SearchLinqEF(x => x.CurrencyRateID == currencyRateID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<SalesOrderHeader>> SalesOrderHeaders(int currencyRateID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SalesOrderHeader>().Where(x => x.CurrencyRateID == currencyRateID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
                }
        }
}

/*<Codenesium>
    <Hash>018653705d3e2db4038c5b41a15bd536</Hash>
</Codenesium>*/