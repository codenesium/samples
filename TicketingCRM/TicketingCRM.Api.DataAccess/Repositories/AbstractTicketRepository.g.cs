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
        public abstract class AbstractTicketRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTicketRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Ticket>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Ticket> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Ticket> Create(Ticket item)
                {
                        this.Context.Set<Ticket>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Ticket item)
                {
                        var entity = this.Context.Set<Ticket>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Ticket>().Attach(item);
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
                        Ticket record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Ticket>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<Ticket>> GetTicketStatusId(int ticketStatusId)
                {
                        var records = await this.SearchLinqEF(x => x.TicketStatusId == ticketStatusId);

                        return records;
                }

                protected async Task<List<Ticket>> Where(Expression<Func<Ticket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Ticket> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Ticket>> SearchLinqEF(Expression<Func<Ticket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Ticket.Id)} ASC";
                        }

                        return await this.Context.Set<Ticket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Ticket>();
                }

                private async Task<List<Ticket>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Ticket.Id)} ASC";
                        }

                        return await this.Context.Set<Ticket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Ticket>();
                }

                private async Task<Ticket> GetById(int id)
                {
                        List<Ticket> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>fb81d6997df0ea95a1eec9e135a45823</Hash>
</Codenesium>*/