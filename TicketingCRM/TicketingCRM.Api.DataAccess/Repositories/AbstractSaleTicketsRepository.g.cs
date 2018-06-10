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
        public abstract class AbstractSaleTicketsRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSaleTicketsRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SaleTickets>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                public async Task<List<SaleTickets>> GetTicketId(int ticketId)
                {
                        var records = await this.SearchLinqEF(x => x.TicketId == ticketId);

                        return records;
                }

                protected async Task<List<SaleTickets>> Where(Expression<Func<SaleTickets, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<SaleTickets> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<SaleTickets>> SearchLinqEF(Expression<Func<SaleTickets, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SaleTickets.Id)} ASC";
                        }

                        return await this.Context.Set<SaleTickets>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SaleTickets>();
                }

                private async Task<List<SaleTickets>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SaleTickets.Id)} ASC";
                        }

                        return await this.Context.Set<SaleTickets>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SaleTickets>();
                }

                private async Task<SaleTickets> GetById(int id)
                {
                        List<SaleTickets> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>f59a75a82c040b9782dfada9ff6931a4</Hash>
</Codenesium>*/