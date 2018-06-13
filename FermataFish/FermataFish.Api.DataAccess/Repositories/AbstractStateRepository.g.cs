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

                public virtual Task<List<State>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<State>> Where(Expression<Func<State, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<State> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<State>> SearchLinqEF(Expression<Func<State, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(State.Id)} ASC";
                        }

                        return await this.Context.Set<State>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<State>();
                }

                private async Task<List<State>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(State.Id)} ASC";
                        }

                        return await this.Context.Set<State>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<State>();
                }

                private async Task<State> GetById(int id)
                {
                        List<State> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Studio>> Studios(int stateId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Studio>().Where(x => x.StateId == stateId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Studio>();
                }
        }
}

/*<Codenesium>
    <Hash>e0e1c65c5cd8572c8692d30dcdf39bb5</Hash>
</Codenesium>*/