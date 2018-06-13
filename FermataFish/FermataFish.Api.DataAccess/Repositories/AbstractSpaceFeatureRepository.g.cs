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
        public abstract class AbstractSpaceFeatureRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSpaceFeatureRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SpaceFeature>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<SpaceFeature> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<SpaceFeature> Create(SpaceFeature item)
                {
                        this.Context.Set<SpaceFeature>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SpaceFeature item)
                {
                        var entity = this.Context.Set<SpaceFeature>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<SpaceFeature>().Attach(item);
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
                        SpaceFeature record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SpaceFeature>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<SpaceFeature>> Where(Expression<Func<SpaceFeature, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<SpaceFeature> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<SpaceFeature>> SearchLinqEF(Expression<Func<SpaceFeature, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SpaceFeature.Id)} ASC";
                        }

                        return await this.Context.Set<SpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SpaceFeature>();
                }

                private async Task<List<SpaceFeature>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SpaceFeature.Id)} ASC";
                        }

                        return await this.Context.Set<SpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SpaceFeature>();
                }

                private async Task<SpaceFeature> GetById(int id)
                {
                        List<SpaceFeature> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<SpaceXSpaceFeature>> SpaceXSpaceFeatures(int spaceFeatureId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SpaceXSpaceFeature>().Where(x => x.SpaceFeatureId == spaceFeatureId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceXSpaceFeature>();
                }
        }
}

/*<Codenesium>
    <Hash>4fb5c3652dcca435c7ccccb00f8d8a84</Hash>
</Codenesium>*/