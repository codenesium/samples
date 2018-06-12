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
        public abstract class AbstractApiKeyRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractApiKeyRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ApiKey>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<ApiKey> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<ApiKey> Create(ApiKey item)
                {
                        this.Context.Set<ApiKey>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ApiKey item)
                {
                        var entity = this.Context.Set<ApiKey>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<ApiKey>().Attach(item);
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
                        ApiKey record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ApiKey>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<ApiKey> GetApiKeyHashed(string apiKeyHashed)
                {
                        var records = await this.SearchLinqEF(x => x.ApiKeyHashed == apiKeyHashed);

                        return records.FirstOrDefault();
                }

                protected async Task<List<ApiKey>> Where(Expression<Func<ApiKey, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<ApiKey> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<ApiKey>> SearchLinqEF(Expression<Func<ApiKey, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ApiKey.Id)} ASC";
                        }

                        return await this.Context.Set<ApiKey>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ApiKey>();
                }

                private async Task<List<ApiKey>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ApiKey.Id)} ASC";
                        }

                        return await this.Context.Set<ApiKey>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ApiKey>();
                }

                private async Task<ApiKey> GetById(string id)
                {
                        List<ApiKey> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>a952fbadc77f13850ace035f3f816bf4</Hash>
</Codenesium>*/