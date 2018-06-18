using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public abstract class AbstractEventRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractEventRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Event>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Event> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Event> Create(Event item)
                {
                        this.Context.Set<Event>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Event item)
                {
                        var entity = this.Context.Set<Event>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Event>().Attach(item);
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
                        Event record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Event>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<Event>> GetCityId(int cityId)
                {
                        var records = await this.Where(x => x.CityId == cityId);

                        return records;
                }

                protected async Task<List<Event>> Where(
                        Expression<Func<Event, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Event, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Event>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Event>();
                        }
                        else
                        {
                                return await this.Context.Set<Event>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Event>();
                        }
                }

                private async Task<Event> GetById(int id)
                {
                        List<Event> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<City> GetCity(int cityId)
                {
                        return await this.Context.Set<City>().SingleOrDefaultAsync(x => x.Id == cityId);
                }
        }
}

/*<Codenesium>
    <Hash>ddbb18c8bf0710064d0536dcb9d2436c</Hash>
</Codenesium>*/