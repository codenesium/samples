using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public abstract class AbstractTicketRepository : AbstractRepository
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

                public virtual Task<List<Ticket>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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
                        var records = await this.Where(x => x.TicketStatusId == ticketStatusId);

                        return records;
                }

                public async virtual Task<List<SaleTickets>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SaleTickets>().Where(x => x.TicketId == ticketId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SaleTickets>();
                }

                public async virtual Task<TicketStatus> GetTicketStatus(int ticketStatusId)
                {
                        return await this.Context.Set<TicketStatus>().SingleOrDefaultAsync(x => x.Id == ticketStatusId);
                }

                protected async Task<List<Ticket>> Where(
                        Expression<Func<Ticket, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Ticket, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Ticket>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Ticket>();
                        }
                        else
                        {
                                return await this.Context.Set<Ticket>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Ticket>();
                        }
                }

                private async Task<Ticket> GetById(int id)
                {
                        List<Ticket> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>04c7b7252e55bfa9083b3370e1ebe1e7</Hash>
</Codenesium>*/