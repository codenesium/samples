using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public abstract class AbstractCityRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCityRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<City>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<City> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<City> Create(City item)
                {
                        this.Context.Set<City>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(City item)
                {
                        var entity = this.Context.Set<City>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<City>().Attach(item);
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
                        City record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<City>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<City>> GetProvinceId(int provinceId)
                {
                        var records = await this.SearchLinqEF(x => x.ProvinceId == provinceId);

                        return records;
                }

                protected async Task<List<City>> Where(Expression<Func<City, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<City> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<City>> SearchLinqEF(Expression<Func<City, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(City.Id)} ASC";
                        }

                        return await this.Context.Set<City>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<City>();
                }

                private async Task<List<City>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(City.Id)} ASC";
                        }

                        return await this.Context.Set<City>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<City>();
                }

                private async Task<City> GetById(int id)
                {
                        List<City> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Event>> Events(int cityId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Event>().Where(x => x.CityId == cityId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Event>();
                }
        }
}

/*<Codenesium>
    <Hash>2b1bc5cedaa226f194008b33c4d0c1b6</Hash>
</Codenesium>*/