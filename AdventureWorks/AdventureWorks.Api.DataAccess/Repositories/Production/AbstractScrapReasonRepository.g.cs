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

                public virtual Task<List<ScrapReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                protected async Task<List<ScrapReason>> Where(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<ScrapReason> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<ScrapReason>> SearchLinqEF(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ScrapReason.ScrapReasonID)} ASC";
                        }

                        return await this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ScrapReason>();
                }

                private async Task<List<ScrapReason>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ScrapReason.ScrapReasonID)} ASC";
                        }

                        return await this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ScrapReason>();
                }

                private async Task<ScrapReason> GetById(short scrapReasonID)
                {
                        List<ScrapReason> records = await this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>24552a7656a7d53431585fe50be94e20</Hash>
</Codenesium>*/