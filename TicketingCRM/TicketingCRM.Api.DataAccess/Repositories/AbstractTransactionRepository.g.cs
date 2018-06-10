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
        public abstract class AbstractTransactionRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTransactionRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Transaction>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Transaction> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Transaction> Create(Transaction item)
                {
                        this.Context.Set<Transaction>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Transaction item)
                {
                        var entity = this.Context.Set<Transaction>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Transaction>().Attach(item);
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
                        Transaction record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Transaction>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<Transaction>> GetTransactionStatusId(int transactionStatusId)
                {
                        var records = await this.SearchLinqEF(x => x.TransactionStatusId == transactionStatusId);

                        return records;
                }

                protected async Task<List<Transaction>> Where(Expression<Func<Transaction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Transaction> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Transaction>> SearchLinqEF(Expression<Func<Transaction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Transaction.Id)} ASC";
                        }

                        return await this.Context.Set<Transaction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Transaction>();
                }

                private async Task<List<Transaction>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Transaction.Id)} ASC";
                        }

                        return await this.Context.Set<Transaction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Transaction>();
                }

                private async Task<Transaction> GetById(int id)
                {
                        List<Transaction> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>e3826bc2e0000963c95cd111121a1c2f</Hash>
</Codenesium>*/