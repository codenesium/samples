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
        public abstract class AbstractLocationRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractLocationRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Location>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Location> Get(short locationID)
                {
                        return await this.GetById(locationID);
                }

                public async virtual Task<Location> Create(Location item)
                {
                        this.Context.Set<Location>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Location item)
                {
                        var entity = this.Context.Set<Location>().Local.FirstOrDefault(x => x.LocationID == item.LocationID);
                        if (entity == null)
                        {
                                this.Context.Set<Location>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        short locationID)
                {
                        Location record = await this.GetById(locationID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Location>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Location> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<Location>> Where(Expression<Func<Location, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Location> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Location>> SearchLinqEF(Expression<Func<Location, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Location.LocationID)} ASC";
                        }

                        return await this.Context.Set<Location>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Location>();
                }

                private async Task<List<Location>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Location.LocationID)} ASC";
                        }

                        return await this.Context.Set<Location>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Location>();
                }

                private async Task<Location> GetById(short locationID)
                {
                        List<Location> records = await this.SearchLinqEF(x => x.LocationID == locationID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>34b2990ba7c6eaeaa42a96ce7833fc6a</Hash>
</Codenesium>*/