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

                public virtual Task<List<StateProvince>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                protected async Task<List<StateProvince>> Where(Expression<Func<StateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<StateProvince> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<StateProvince>> SearchLinqEF(Expression<Func<StateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(StateProvince.StateProvinceID)} ASC";
                        }

                        return await this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<StateProvince>();
                }

                private async Task<List<StateProvince>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(StateProvince.StateProvinceID)} ASC";
                        }

                        return await this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<StateProvince>();
                }

                private async Task<StateProvince> GetById(int stateProvinceID)
                {
                        List<StateProvince> records = await this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>ab4ff59a36ade8576237023debb79b41</Hash>
</Codenesium>*/