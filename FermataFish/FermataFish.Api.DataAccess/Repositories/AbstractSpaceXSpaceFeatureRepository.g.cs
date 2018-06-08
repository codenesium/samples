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

                public virtual Task<List<SpaceXSpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                protected async Task<List<SpaceXSpaceFeature>> Where(Expression<Func<SpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<SpaceXSpaceFeature> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<SpaceXSpaceFeature>> SearchLinqEF(Expression<Func<SpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SpaceXSpaceFeature.Id)} ASC";
                        }

                        return await this.Context.Set<SpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpaceXSpaceFeature>();
                }

                private async Task<List<SpaceXSpaceFeature>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SpaceXSpaceFeature.Id)} ASC";
                        }

                        return await this.Context.Set<SpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpaceXSpaceFeature>();
                }

                private async Task<SpaceXSpaceFeature> GetById(int id)
                {
                        List<SpaceXSpaceFeature> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>b39c13e5015d757fae6d6ea6b3b12b9f</Hash>
</Codenesium>*/