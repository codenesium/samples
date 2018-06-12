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
        public abstract class AbstractEventRelatedDocumentRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractEventRelatedDocumentRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<EventRelatedDocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<EventRelatedDocument> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<EventRelatedDocument> Create(EventRelatedDocument item)
                {
                        this.Context.Set<EventRelatedDocument>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(EventRelatedDocument item)
                {
                        var entity = this.Context.Set<EventRelatedDocument>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<EventRelatedDocument>().Attach(item);
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
                        EventRelatedDocument record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<EventRelatedDocument>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<EventRelatedDocument>> GetEventId(string eventId)
                {
                        var records = await this.SearchLinqEF(x => x.EventId == eventId);

                        return records;
                }
                public async Task<List<EventRelatedDocument>> GetEventIdRelatedDocumentId(string eventId, string relatedDocumentId)
                {
                        var records = await this.SearchLinqEF(x => x.EventId == eventId && x.RelatedDocumentId == relatedDocumentId);

                        return records;
                }

                protected async Task<List<EventRelatedDocument>> Where(Expression<Func<EventRelatedDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<EventRelatedDocument> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<EventRelatedDocument>> SearchLinqEF(Expression<Func<EventRelatedDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(EventRelatedDocument.Id)} ASC";
                        }

                        return await this.Context.Set<EventRelatedDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EventRelatedDocument>();
                }

                private async Task<List<EventRelatedDocument>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(EventRelatedDocument.Id)} ASC";
                        }

                        return await this.Context.Set<EventRelatedDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EventRelatedDocument>();
                }

                private async Task<EventRelatedDocument> GetById(int id)
                {
                        List<EventRelatedDocument> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>d7d2908dbe3af40b4ef6bdb8b1983936</Hash>
</Codenesium>*/