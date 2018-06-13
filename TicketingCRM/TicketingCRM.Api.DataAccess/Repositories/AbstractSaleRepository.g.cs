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
        public abstract class AbstractSaleRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSaleRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Sale> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Sale> Create(Sale item)
                {
                        this.Context.Set<Sale>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Sale item)
                {
                        var entity = this.Context.Set<Sale>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Sale>().Attach(item);
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
                        Sale record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Sale>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<Sale>> GetTransactionId(int transactionId)
                {
                        var records = await this.SearchLinqEF(x => x.TransactionId == transactionId);

                        return records;
                }

                protected async Task<List<Sale>> Where(Expression<Func<Sale, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Sale> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Sale>> SearchLinqEF(Expression<Func<Sale, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Sale.Id)} ASC";
                        }

                        return await this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Sale>();
                }

                private async Task<List<Sale>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Sale.Id)} ASC";
                        }

                        return await this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Sale>();
                }

                private async Task<Sale> GetById(int id)
                {
                        List<Sale> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<SaleTickets>> SaleTickets(int saleId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SaleTickets>().Where(x => x.SaleId == saleId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SaleTickets>();
                }
        }
}

/*<Codenesium>
    <Hash>7aa78815ced9a4c7171828e6ee745903</Hash>
</Codenesium>*/