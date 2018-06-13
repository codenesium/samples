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
        public abstract class AbstractTransactionStatusRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTransactionStatusRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TransactionStatus>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<TransactionStatus> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<TransactionStatus> Create(TransactionStatus item)
                {
                        this.Context.Set<TransactionStatus>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(TransactionStatus item)
                {
                        var entity = this.Context.Set<TransactionStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<TransactionStatus>().Attach(item);
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
                        TransactionStatus record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<TransactionStatus>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<TransactionStatus>> Where(Expression<Func<TransactionStatus, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<TransactionStatus> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<TransactionStatus>> SearchLinqEF(Expression<Func<TransactionStatus, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TransactionStatus.Id)} ASC";
                        }

                        return await this.Context.Set<TransactionStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<TransactionStatus>();
                }

                private async Task<List<TransactionStatus>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TransactionStatus.Id)} ASC";
                        }

                        return await this.Context.Set<TransactionStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<TransactionStatus>();
                }

                private async Task<TransactionStatus> GetById(int id)
                {
                        List<TransactionStatus> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Transaction>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Transaction>().Where(x => x.TransactionStatusId == transactionStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Transaction>();
                }
        }
}

/*<Codenesium>
    <Hash>b0ee93e2cc35a7b5b624572fda4e8d7a</Hash>
</Codenesium>*/