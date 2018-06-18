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

namespace FermataFishNS.Api.DataAccess
{
        public abstract class AbstractStateRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractStateRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<State>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<State> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<State> Create(State item)
                {
                        this.Context.Set<State>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(State item)
                {
                        var entity = this.Context.Set<State>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<State>().Attach(item);
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
                        State record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<State>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<State>> Where(
                        Expression<Func<State, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<State, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<State>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<State>();
                        }
                        else
                        {
                                return await this.Context.Set<State>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<State>();
                        }
                }

                private async Task<State> GetById(int id)
                {
                        List<State> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Studio>> Studios(int stateId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Studio>().Where(x => x.StateId == stateId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Studio>();
                }
        }
}

/*<Codenesium>
    <Hash>ff85ba8df125d11b7b52be375f27e621</Hash>
</Codenesium>*/