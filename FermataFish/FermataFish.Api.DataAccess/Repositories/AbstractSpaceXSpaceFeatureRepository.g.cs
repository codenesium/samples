using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public abstract class AbstractSpaceXSpaceFeatureRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSpaceXSpaceFeatureRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SpaceXSpaceFeature>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<SpaceXSpaceFeature> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<SpaceXSpaceFeature> Create(SpaceXSpaceFeature item)
                {
                        this.Context.Set<SpaceXSpaceFeature>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SpaceXSpaceFeature item)
                {
                        var entity = this.Context.Set<SpaceXSpaceFeature>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<SpaceXSpaceFeature>().Attach(item);
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
                        SpaceXSpaceFeature record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SpaceXSpaceFeature>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<SpaceXSpaceFeature>> Where(Expression<Func<SpaceXSpaceFeature, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<SpaceXSpaceFeature> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<SpaceXSpaceFeature>> SearchLinqEF(Expression<Func<SpaceXSpaceFeature, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SpaceXSpaceFeature.Id)} ASC";
                        }

                        return await this.Context.Set<SpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SpaceXSpaceFeature>();
                }

                private async Task<List<SpaceXSpaceFeature>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SpaceXSpaceFeature.Id)} ASC";
                        }

                        return await this.Context.Set<SpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SpaceXSpaceFeature>();
                }

                private async Task<SpaceXSpaceFeature> GetById(int id)
                {
                        List<SpaceXSpaceFeature> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>82ce070ba3739b1d673e10000684bcf4</Hash>
</Codenesium>*/