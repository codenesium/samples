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

                public virtual Task<List<TransactionStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                protected async Task<List<TransactionStatus>> Where(Expression<Func<TransactionStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<TransactionStatus> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<TransactionStatus>> SearchLinqEF(Expression<Func<TransactionStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TransactionStatus.Id)} ASC";
                        }

                        return await this.Context.Set<TransactionStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TransactionStatus>();
                }

                private async Task<List<TransactionStatus>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TransactionStatus.Id)} ASC";
                        }

                        return await this.Context.Set<TransactionStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TransactionStatus>();
                }

                private async Task<TransactionStatus> GetById(int id)
                {
                        List<TransactionStatus> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>a62da1d491e95b04c61ffd8b4850f6ef</Hash>
</Codenesium>*/