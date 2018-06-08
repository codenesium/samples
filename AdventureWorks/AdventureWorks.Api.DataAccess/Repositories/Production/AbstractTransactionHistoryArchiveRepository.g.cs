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
        public abstract class AbstractTransactionHistoryArchiveRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTransactionHistoryArchiveRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TransactionHistoryArchive>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<TransactionHistoryArchive> Get(int transactionID)
                {
                        return await this.GetById(transactionID);
                }

                public async virtual Task<TransactionHistoryArchive> Create(TransactionHistoryArchive item)
                {
                        this.Context.Set<TransactionHistoryArchive>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(TransactionHistoryArchive item)
                {
                        var entity = this.Context.Set<TransactionHistoryArchive>().Local.FirstOrDefault(x => x.TransactionID == item.TransactionID);
                        if (entity == null)
                        {
                                this.Context.Set<TransactionHistoryArchive>().Attach(item);
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
                        TransactionHistoryArchive record = await this.GetById(transactionID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<TransactionHistoryArchive>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<TransactionHistoryArchive>> GetProductID(int productID)
                {
                        var records = await this.SearchLinqEF(x => x.ProductID == productID);

                        return records;
                }
                public async Task<List<TransactionHistoryArchive>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        var records = await this.SearchLinqEF(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID);

                        return records;
                }

                protected async Task<List<TransactionHistoryArchive>> Where(Expression<Func<TransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<TransactionHistoryArchive> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<TransactionHistoryArchive>> SearchLinqEF(Expression<Func<TransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TransactionHistoryArchive.TransactionID)} ASC";
                        }

                        return await this.Context.Set<TransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TransactionHistoryArchive>();
                }

                private async Task<List<TransactionHistoryArchive>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TransactionHistoryArchive.TransactionID)} ASC";
                        }

                        return await this.Context.Set<TransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TransactionHistoryArchive>();
                }

                private async Task<TransactionHistoryArchive> GetById(int transactionID)
                {
                        List<TransactionHistoryArchive> records = await this.SearchLinqEF(x => x.TransactionID == transactionID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>c24079cddd55ff50bc0d8ddd822b03ce</Hash>
</Codenesium>*/