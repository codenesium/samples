using Codenesium.DataConversionExtensions;
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
        public abstract class AbstractSaleTicketsRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSaleTicketsRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SaleTickets>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<SaleTickets> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<SaleTickets> Create(SaleTickets item)
                {
                        this.Context.Set<SaleTickets>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SaleTickets item)
                {
                        var entity = this.Context.Set<SaleTickets>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<SaleTickets>().Attach(item);
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
                        SaleTickets record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SaleTickets>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<SaleTickets>> ByTicketId(int ticketId)
                {
                        var records = await this.Where(x => x.TicketId == ticketId);

                        return records;
                }

                public async virtual Task<Sale> GetSale(int saleId)
                {
                        return await this.Context.Set<Sale>().SingleOrDefaultAsync(x => x.Id == saleId);
                }

                public async virtual Task<Ticket> GetTicket(int ticketId)
                {
                        return await this.Context.Set<Ticket>().SingleOrDefaultAsync(x => x.Id == ticketId);
                }

                protected async Task<List<SaleTickets>> Where(
                        Expression<Func<SaleTickets, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<SaleTickets, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<SaleTickets>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SaleTickets>();
                        }
                        else
                        {
                                return await this.Context.Set<SaleTickets>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SaleTickets>();
                        }
                }

                private async Task<SaleTickets> GetById(int id)
                {
                        List<SaleTickets> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>576d5ee874e442d84df2e65f8289f80f</Hash>
</Codenesium>*/