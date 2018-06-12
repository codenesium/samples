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

                public virtual Task<List<Event>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Event> Get(string id)
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
                        string id)
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

                public async Task<List<Event>> GetAutoId(long autoId)
                {
                        var records = await this.SearchLinqEF(x => x.AutoId == autoId);

                        return records;
                }
                public async Task<List<Event>> GetIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTime occurred, string category, long autoId)
                {
                        var records = await this.SearchLinqEF(x => x.Id == id && x.RelatedDocumentIds == relatedDocumentIds && x.Occurred == occurred && x.Category == category && x.AutoId == autoId);

                        return records;
                }
                public async Task<List<Event>> GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTime occurred, string tenantId)
                {
                        var records = await this.SearchLinqEF(x => x.Id == id && x.RelatedDocumentIds == relatedDocumentIds && x.ProjectId == projectId && x.EnvironmentId == environmentId && x.Category == category && x.UserId == userId && x.Occurred == occurred && x.TenantId == tenantId);

                        return records;
                }
                public async Task<List<Event>> GetIdOccurred(string id, DateTime occurred)
                {
                        var records = await this.SearchLinqEF(x => x.Id == id && x.Occurred == occurred);

                        return records;
                }

                protected async Task<List<Event>> Where(Expression<Func<Event, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Event> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Event>> SearchLinqEF(Expression<Func<Event, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Event.Id)} ASC";
                        }

                        return await this.Context.Set<Event>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Event>();
                }

                private async Task<List<Event>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Event.Id)} ASC";
                        }

                        return await this.Context.Set<Event>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Event>();
                }

                private async Task<Event> GetById(string id)
                {
                        List<Event> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>b5239f0cecf4e0e1fc5d6f6832761099</Hash>
</Codenesium>*/