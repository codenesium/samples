using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

                public virtual Task<List<Transaction>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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
                        var records = await this.Where(x => x.TransactionStatusId == transactionStatusId);

                        return records;
                }

                protected async Task<List<Transaction>> Where(
                        Expression<Func<Transaction, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Transaction, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Transaction>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Transaction>();
                        }
                        else
                        {
                                return await this.Context.Set<Transaction>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Transaction>();
                        }
                }

                private async Task<Transaction> GetById(int id)
                {
                        List<Transaction> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Sale>> Sales(int transactionId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Sale>().Where(x => x.TransactionId == transactionId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Sale>();
                }

                public async virtual Task<TransactionStatus> GetTransactionStatus(int transactionStatusId)
                {
                        return await this.Context.Set<TransactionStatus>().SingleOrDefaultAsync(x => x.Id == transactionStatusId);
                }
        }
}

/*<Codenesium>
    <Hash>75b0f56cf2e58ffde2480d6c091d8e1b</Hash>
</Codenesium>*/