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
        public abstract class AbstractStateProvinceRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractStateProvinceRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<StateProvince>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<StateProvince> Get(int stateProvinceID)
                {
                        return await this.GetById(stateProvinceID);
                }

                public async virtual Task<StateProvince> Create(StateProvince item)
                {
                        this.Context.Set<StateProvince>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(StateProvince item)
                {
                        var entity = this.Context.Set<StateProvince>().Local.FirstOrDefault(x => x.StateProvinceID == item.StateProvinceID);
                        if (entity == null)
                        {
                                this.Context.Set<StateProvince>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int stateProvinceID)
                {
                        StateProvince record = await this.GetById(stateProvinceID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<StateProvince>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<StateProvince> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }
                public async Task<StateProvince> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode)
                {
                        var records = await this.SearchLinqEF(x => x.StateProvinceCode == stateProvinceCode && x.CountryRegionCode == countryRegionCode);

                        return records.FirstOrDefault();
                }

                protected async Task<List<StateProvince>> Where(Expression<Func<StateProvince, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<StateProvince> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<StateProvince>> SearchLinqEF(Expression<Func<StateProvince, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(StateProvince.StateProvinceID)} ASC";
                        }

                        return await this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<StateProvince>();
                }

                private async Task<List<StateProvince>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(StateProvince.StateProvinceID)} ASC";
                        }

                        return await this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<StateProvince>();
                }

                private async Task<StateProvince> GetById(int stateProvinceID)
                {
                        List<StateProvince> records = await this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Address>> Addresses(int stateProvinceID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Address>().Where(x => x.StateProvinceID == stateProvinceID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Address>();
                }
        }
}

/*<Codenesium>
    <Hash>64f148867df968bff0c750824f83e228</Hash>
</Codenesium>*/