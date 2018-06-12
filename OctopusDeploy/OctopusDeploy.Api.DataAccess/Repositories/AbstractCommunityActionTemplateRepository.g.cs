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
        public abstract class AbstractCommunityActionTemplateRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCommunityActionTemplateRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<CommunityActionTemplate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<CommunityActionTemplate> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<CommunityActionTemplate> Create(CommunityActionTemplate item)
                {
                        this.Context.Set<CommunityActionTemplate>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(CommunityActionTemplate item)
                {
                        var entity = this.Context.Set<CommunityActionTemplate>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<CommunityActionTemplate>().Attach(item);
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
                        CommunityActionTemplate record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<CommunityActionTemplate>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<CommunityActionTemplate> GetExternalId(Guid externalId)
                {
                        var records = await this.SearchLinqEF(x => x.ExternalId == externalId);

                        return records.FirstOrDefault();
                }
                public async Task<CommunityActionTemplate> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<CommunityActionTemplate>> Where(Expression<Func<CommunityActionTemplate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<CommunityActionTemplate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<CommunityActionTemplate>> SearchLinqEF(Expression<Func<CommunityActionTemplate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(CommunityActionTemplate.Id)} ASC";
                        }

                        return await this.Context.Set<CommunityActionTemplate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CommunityActionTemplate>();
                }

                private async Task<List<CommunityActionTemplate>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(CommunityActionTemplate.Id)} ASC";
                        }

                        return await this.Context.Set<CommunityActionTemplate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CommunityActionTemplate>();
                }

                private async Task<CommunityActionTemplate> GetById(string id)
                {
                        List<CommunityActionTemplate> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>e4e405590f6a24c91b87b6084e807940</Hash>
</Codenesium>*/