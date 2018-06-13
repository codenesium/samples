using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public abstract class AbstractTeamRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTeamRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Team>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Team> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Team> Create(Team item)
                {
                        this.Context.Set<Team>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Team item)
                {
                        var entity = this.Context.Set<Team>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Team>().Attach(item);
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
                        Team record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Team>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Team>> Where(Expression<Func<Team, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Team> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Team>> SearchLinqEF(Expression<Func<Team, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Team.Id)} ASC";
                        }

                        return await this.Context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Team>();
                }

                private async Task<List<Team>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Team.Id)} ASC";
                        }

                        return await this.Context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Team>();
                }

                private async Task<Team> GetById(int id)
                {
                        List<Team> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Chain>> Chains(int teamId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Chain>().Where(x => x.TeamId == teamId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Chain>();
                }
                public async virtual Task<List<MachineRefTeam>> MachineRefTeams(int teamId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<MachineRefTeam>().Where(x => x.TeamId == teamId).AsQueryable().Skip(offset).Take(limit).ToListAsync<MachineRefTeam>();
                }
        }
}

/*<Codenesium>
    <Hash>c745a421dc3bec665e317d0dd389d246</Hash>
</Codenesium>*/