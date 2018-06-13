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
        public abstract class AbstractCountryRegionRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCountryRegionRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<CountryRegion>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<CountryRegion> Get(string countryRegionCode)
                {
                        return await this.GetById(countryRegionCode);
                }

                public async virtual Task<CountryRegion> Create(CountryRegion item)
                {
                        this.Context.Set<CountryRegion>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(CountryRegion item)
                {
                        var entity = this.Context.Set<CountryRegion>().Local.FirstOrDefault(x => x.CountryRegionCode == item.CountryRegionCode);
                        if (entity == null)
                        {
                                this.Context.Set<CountryRegion>().Attach(item);
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
                        CountryRegion record = await this.GetById(countryRegionCode);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<CountryRegion>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<CountryRegion> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<CountryRegion>> Where(Expression<Func<CountryRegion, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<CountryRegion> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<CountryRegion>> SearchLinqEF(Expression<Func<CountryRegion, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(CountryRegion.CountryRegionCode)} ASC";
                        }

                        return await this.Context.Set<CountryRegion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<CountryRegion>();
                }

                private async Task<List<CountryRegion>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(CountryRegion.CountryRegionCode)} ASC";
                        }

                        return await this.Context.Set<CountryRegion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<CountryRegion>();
                }

                private async Task<CountryRegion> GetById(string countryRegionCode)
                {
                        List<CountryRegion> records = await this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<StateProvince>> StateProvinces(string countryRegionCode, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<StateProvince>().Where(x => x.CountryRegionCode == countryRegionCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<StateProvince>();
                }
        }
}

/*<Codenesium>
    <Hash>8324db2aa734e833cd07d6ba0296017c</Hash>
</Codenesium>*/