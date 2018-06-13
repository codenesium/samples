using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractScrapReasonRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractScrapReasonRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ScrapReason>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ScrapReason> Get(short scrapReasonID)
                {
                        return await this.GetById(scrapReasonID);
                }

                public async virtual Task<ScrapReason> Create(ScrapReason item)
                {
                        this.Context.Set<ScrapReason>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ScrapReason item)
                {
                        var entity = this.Context.Set<ScrapReason>().Local.FirstOrDefault(x => x.ScrapReasonID == item.ScrapReasonID);
                        if (entity == null)
                        {
                                this.Context.Set<ScrapReason>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        short scrapReasonID)
                {
                        ScrapReason record = await this.GetById(scrapReasonID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ScrapReason>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<ScrapReason> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<ScrapReason>> Where(Expression<Func<ScrapReason, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ScrapReason> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ScrapReason>> SearchLinqEF(Expression<Func<ScrapReason, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ScrapReason.ScrapReasonID)} ASC";
                        }

                        return await this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ScrapReason>();
                }

                private async Task<List<ScrapReason>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ScrapReason.ScrapReasonID)} ASC";
                        }

                        return await this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ScrapReason>();
                }

                private async Task<ScrapReason> GetById(short scrapReasonID)
                {
                        List<ScrapReason> records = await this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<WorkOrder>> WorkOrders(short scrapReasonID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<WorkOrder>().Where(x => x.ScrapReasonID == scrapReasonID).AsQueryable().Skip(offset).Take(limit).ToListAsync<WorkOrder>();
                }
        }
}

/*<Codenesium>
    <Hash>0fd01d099a99f0dddafe54d41f53b932</Hash>
</Codenesium>*/