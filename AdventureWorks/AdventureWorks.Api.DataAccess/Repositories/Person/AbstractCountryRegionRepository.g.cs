using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

                public virtual Task<List<CountryRegion>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                public async Task<CountryRegion> ByName(string name)
                {
                        var records = await this.Where(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<CountryRegion>> Where(
                        Expression<Func<CountryRegion, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<CountryRegion, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.CountryRegionCode;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<CountryRegion>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CountryRegion>();
                        }
                        else
                        {
                                return await this.Context.Set<CountryRegion>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<CountryRegion>();
                        }
                }

                private async Task<CountryRegion> GetById(string countryRegionCode)
                {
                        List<CountryRegion> records = await this.Where(x => x.CountryRegionCode == countryRegionCode);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<StateProvince>> StateProvinces(string countryRegionCode, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<StateProvince>().Where(x => x.CountryRegionCode == countryRegionCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<StateProvince>();
                }
        }
}

/*<Codenesium>
    <Hash>56965bc1a78f61873f45958b32424150</Hash>
</Codenesium>*/