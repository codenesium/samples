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

namespace NebulaNS.Api.DataAccess
{
        public abstract class AbstractChainRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractChainRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Chain>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Chain> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Chain> Create(Chain item)
                {
                        this.Context.Set<Chain>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Chain item)
                {
                        var entity = this.Context.Set<Chain>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Chain>().Attach(item);
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
                        Chain record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Chain>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Chain>> Where(
                        Expression<Func<Chain, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Chain, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Chain>();
                        }
                        else
                        {
                                return await this.Context.Set<Chain>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Chain>();
                        }
                }

                private async Task<Chain> GetById(int id)
                {
                        List<Chain> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Clasp>> Clasps(int nextChainId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Clasp>().Where(x => x.NextChainId == nextChainId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Clasp>();
                }
                public async virtual Task<List<Link>> Links(int chainId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Link>().Where(x => x.ChainId == chainId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Link>();
                }

                public async virtual Task<ChainStatus> GetChainStatus(int chainStatusId)
                {
                        return await this.Context.Set<ChainStatus>().SingleOrDefaultAsync(x => x.Id == chainStatusId);
                }
                public async virtual Task<Team> GetTeam(int teamId)
                {
                        return await this.Context.Set<Team>().SingleOrDefaultAsync(x => x.Id == teamId);
                }
        }
}

/*<Codenesium>
    <Hash>3d8b814c13db98d133c4c27fe3607263</Hash>
</Codenesium>*/