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

                public virtual Task<List<Chain>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<Chain>> Where(Expression<Func<Chain, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Chain> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Chain>> SearchLinqEF(Expression<Func<Chain, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Chain.Id)} ASC";
                        }

                        return await this.Context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Chain>();
                }

                private async Task<List<Chain>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Chain.Id)} ASC";
                        }

                        return await this.Context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Chain>();
                }

                private async Task<Chain> GetById(int id)
                {
                        List<Chain> records = await this.SearchLinqEF(x => x.Id == id);

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
        }
}

/*<Codenesium>
    <Hash>0eabdd529cde2bd7a72570d6879bdb9c</Hash>
</Codenesium>*/