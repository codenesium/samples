using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public abstract class AbstractTicketStatusRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTicketStatusRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TicketStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<TicketStatus> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<TicketStatus> Create(TicketStatus item)
                {
                        this.Context.Set<TicketStatus>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(TicketStatus item)
                {
                        var entity = this.Context.Set<TicketStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<TicketStatus>().Attach(item);
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
                        TicketStatus record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<TicketStatus>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<TicketStatus>> Where(Expression<Func<TicketStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<TicketStatus> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<TicketStatus>> SearchLinqEF(Expression<Func<TicketStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TicketStatus.Id)} ASC";
                        }

                        return await this.Context.Set<TicketStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TicketStatus>();
                }

                private async Task<List<TicketStatus>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TicketStatus.Id)} ASC";
                        }

                        return await this.Context.Set<TicketStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TicketStatus>();
                }

                private async Task<TicketStatus> GetById(int id)
                {
                        List<TicketStatus> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>acb91398e71b98aac9ca9164328f5742</Hash>
</Codenesium>*/