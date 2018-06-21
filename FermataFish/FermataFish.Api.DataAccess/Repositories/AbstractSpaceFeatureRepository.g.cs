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

namespace FermataFishNS.Api.DataAccess
{
        public abstract class AbstractSpaceFeatureRepository : AbstractRepository
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

                public virtual Task<List<SpaceFeature>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                public async virtual Task<List<SpaceXSpaceFeature>> SpaceXSpaceFeatures(int spaceFeatureId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SpaceXSpaceFeature>().Where(x => x.SpaceFeatureId == spaceFeatureId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceXSpaceFeature>();
                }

                public async virtual Task<Studio> GetStudio(int studioId)
                {
                        return await this.Context.Set<Studio>().SingleOrDefaultAsync(x => x.Id == studioId);
                }

                protected async Task<List<SpaceFeature>> Where(
                        Expression<Func<SpaceFeature, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<SpaceFeature, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<SpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SpaceFeature>();
                        }
                        else
                        {
                                return await this.Context.Set<SpaceFeature>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SpaceFeature>();
                        }
                }

                private async Task<SpaceFeature> GetById(int id)
                {
                        List<SpaceFeature> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>56d073a1da7c28a8ad9d2219a4f66e09</Hash>
</Codenesium>*/