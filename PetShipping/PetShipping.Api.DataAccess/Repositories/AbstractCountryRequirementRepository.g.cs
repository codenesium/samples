using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public abstract class AbstractCountryRequirementRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCountryRequirementRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<CountryRequirement>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<CountryRequirement> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<CountryRequirement> Create(CountryRequirement item)
                {
                        this.Context.Set<CountryRequirement>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(CountryRequirement item)
                {
                        var entity = this.Context.Set<CountryRequirement>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<CountryRequirement>().Attach(item);
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
                        CountryRequirement record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<CountryRequirement>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<CountryRequirement>> Where(Expression<Func<CountryRequirement, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<CountryRequirement> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<CountryRequirement>> SearchLinqEF(Expression<Func<CountryRequirement, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(CountryRequirement.Id)} ASC";
                        }

                        return await this.Context.Set<CountryRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<CountryRequirement>();
                }

                private async Task<List<CountryRequirement>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(CountryRequirement.Id)} ASC";
                        }

                        return await this.Context.Set<CountryRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<CountryRequirement>();
                }

                private async Task<CountryRequirement> GetById(int id)
                {
                        List<CountryRequirement> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>03c2b98429d972f3d3cd36f6b96e0a1a</Hash>
</Codenesium>*/