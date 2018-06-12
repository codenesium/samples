using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
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

                public virtual Task<List<Team>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Team> Get(string id)
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
                        string id)
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

                public async Task<Team> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<Team>> Where(Expression<Func<Team, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Team> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Team>> SearchLinqEF(Expression<Func<Team, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Team.Id)} ASC";
                        }

                        return await this.Context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Team>();
                }

                private async Task<List<Team>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Team.Id)} ASC";
                        }

                        return await this.Context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Team>();
                }

                private async Task<Team> GetById(string id)
                {
                        List<Team> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>0bc8e632fd645bb272d36b94bb19f1f0</Hash>
</Codenesium>*/