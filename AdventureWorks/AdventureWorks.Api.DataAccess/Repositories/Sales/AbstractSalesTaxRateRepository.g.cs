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
        public abstract class AbstractSalesTaxRateRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSalesTaxRateRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SalesTaxRate>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<SalesTaxRate> Get(int salesTaxRateID)
                {
                        return await this.GetById(salesTaxRateID);
                }

                public async virtual Task<SalesTaxRate> Create(SalesTaxRate item)
                {
                        this.Context.Set<SalesTaxRate>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SalesTaxRate item)
                {
                        var entity = this.Context.Set<SalesTaxRate>().Local.FirstOrDefault(x => x.SalesTaxRateID == item.SalesTaxRateID);
                        if (entity == null)
                        {
                                this.Context.Set<SalesTaxRate>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int salesTaxRateID)
                {
                        SalesTaxRate record = await this.GetById(salesTaxRateID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SalesTaxRate>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<SalesTaxRate> GetStateProvinceIDTaxType(int stateProvinceID, int taxType)
                {
                        var records = await this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID && x.TaxType == taxType);

                        return records.FirstOrDefault();
                }

                protected async Task<List<SalesTaxRate>> Where(Expression<Func<SalesTaxRate, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<SalesTaxRate> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<SalesTaxRate>> SearchLinqEF(Expression<Func<SalesTaxRate, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesTaxRate.SalesTaxRateID)} ASC";
                        }

                        return await this.Context.Set<SalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SalesTaxRate>();
                }

                private async Task<List<SalesTaxRate>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SalesTaxRate.SalesTaxRateID)} ASC";
                        }

                        return await this.Context.Set<SalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SalesTaxRate>();
                }

                private async Task<SalesTaxRate> GetById(int salesTaxRateID)
                {
                        List<SalesTaxRate> records = await this.SearchLinqEF(x => x.SalesTaxRateID == salesTaxRateID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>55ecdc2515569d30713126d2556d19a2</Hash>
</Codenesium>*/