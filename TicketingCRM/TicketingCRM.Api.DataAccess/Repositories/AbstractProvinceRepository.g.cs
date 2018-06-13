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
        public abstract class AbstractProvinceRepository: AbstractRepository
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

                public virtual Task<List<Province>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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
                        var records = await this.SearchLinqEF(x => x.CountryId == countryId);

                        return records;
                }

                protected async Task<List<Province>> Where(Expression<Func<Province, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Province> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Province>> SearchLinqEF(Expression<Func<Province, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Province.Id)} ASC";
                        }

                        return await this.Context.Set<Province>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Province>();
                }

                private async Task<List<Province>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Province.Id)} ASC";
                        }

                        return await this.Context.Set<Province>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Province>();
                }

                private async Task<Province> GetById(int id)
                {
                        List<Province> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<City>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<City>().Where(x => x.ProvinceId == provinceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<City>();
                }
                public async virtual Task<List<Venue>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Venue>().Where(x => x.ProvinceId == provinceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Venue>();
                }
        }
}

/*<Codenesium>
    <Hash>cb4d7b9af1a6cb402bad853e5f8bf4b1</Hash>
</Codenesium>*/