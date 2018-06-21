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

namespace TicketingCRMNS.Api.DataAccess
{
        public abstract class AbstractProvinceRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProvinceRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Province>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Province> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Province> Create(Province item)
                {
                        this.Context.Set<Province>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Province item)
                {
                        var entity = this.Context.Set<Province>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Province>().Attach(item);
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
                        Province record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Province>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<Province>> GetCountryId(int countryId)
                {
                        var records = await this.Where(x => x.CountryId == countryId);

                        return records;
                }

                public async virtual Task<List<City>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<City>().Where(x => x.ProvinceId == provinceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<City>();
                }

                public async virtual Task<List<Venue>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Venue>().Where(x => x.ProvinceId == provinceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Venue>();
                }

                public async virtual Task<Country> GetCountry(int countryId)
                {
                        return await this.Context.Set<Country>().SingleOrDefaultAsync(x => x.Id == countryId);
                }

                protected async Task<List<Province>> Where(
                        Expression<Func<Province, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Province, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Province>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Province>();
                        }
                        else
                        {
                                return await this.Context.Set<Province>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Province>();
                        }
                }

                private async Task<Province> GetById(int id)
                {
                        List<Province> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>78e30b88338baf95aa2e53a45ee11f93</Hash>
</Codenesium>*/