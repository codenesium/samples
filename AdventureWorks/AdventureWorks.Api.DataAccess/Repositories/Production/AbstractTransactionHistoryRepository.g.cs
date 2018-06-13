using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractTransactionHistoryRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTransactionHistoryRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TransactionHistory>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<TransactionHistory> Get(int transactionID)
                {
                        return await this.GetById(transactionID);
                }

                public async virtual Task<TransactionHistory> Create(TransactionHistory item)
                {
                        this.Context.Set<TransactionHistory>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(TransactionHistory item)
                {
                        var entity = this.Context.Set<TransactionHistory>().Local.FirstOrDefault(x => x.TransactionID == item.TransactionID);
                        if (entity == null)
                        {
                                this.Context.Set<TransactionHistory>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int transactionID)
                {
                        TransactionHistory record = await this.GetById(transactionID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<TransactionHistory>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<TransactionHistory>> GetProductID(int productID)
                {
                        var records = await this.SearchLinqEF(x => x.ProductID == productID);

                        return records;
                }
                public async Task<List<TransactionHistory>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        var records = await this.SearchLinqEF(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID);

                        return records;
                }

                protected async Task<List<TransactionHistory>> Where(Expression<Func<TransactionHistory, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<TransactionHistory> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<TransactionHistory>> SearchLinqEF(Expression<Func<TransactionHistory, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TransactionHistory.TransactionID)} ASC";
                        }

                        return await this.Context.Set<TransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<TransactionHistory>();
                }

                private async Task<List<TransactionHistory>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TransactionHistory.TransactionID)} ASC";
                        }

                        return await this.Context.Set<TransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<TransactionHistory>();
                }

                private async Task<TransactionHistory> GetById(int transactionID)
                {
                        List<TransactionHistory> records = await this.SearchLinqEF(x => x.TransactionID == transactionID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>9a756dd61a8eb9a1087b2afa7468eaa8</Hash>
</Codenesium>*/