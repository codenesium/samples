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

                public virtual Task<List<TransactionHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                protected async Task<List<TransactionHistory>> Where(Expression<Func<TransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<TransactionHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<TransactionHistory>> SearchLinqEF(Expression<Func<TransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TransactionHistory.TransactionID)} ASC";
                        }

                        return await this.Context.Set<TransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TransactionHistory>();
                }

                private async Task<List<TransactionHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TransactionHistory.TransactionID)} ASC";
                        }

                        return await this.Context.Set<TransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TransactionHistory>();
                }

                private async Task<TransactionHistory> GetById(int transactionID)
                {
                        List<TransactionHistory> records = await this.SearchLinqEF(x => x.TransactionID == transactionID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>c0d6a0d59858840cde32b1bf27b04569</Hash>
</Codenesium>*/