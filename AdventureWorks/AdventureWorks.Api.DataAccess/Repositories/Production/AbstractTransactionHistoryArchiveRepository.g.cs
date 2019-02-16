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

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractTransactionHistoryArchiveRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTransactionHistoryArchiveRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TransactionHistoryArchive>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.ActualCost.ToDecimal() == query.ToDecimal() ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.ProductID == query.ToInt() ||
				                  x.Quantity == query.ToInt() ||
				                  x.ReferenceOrderID == query.ToInt() ||
				                  x.ReferenceOrderLineID == query.ToInt() ||
				                  x.TransactionDate == query.ToDateTime() ||
				                  x.TransactionID == query.ToInt() ||
				                  x.TransactionType.StartsWith(query),
				                  limit,
				                  offset);
			}
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

		// Non-unique constraint IX_TransactionHistoryArchive_ProductID.
		public async virtual Task<List<TransactionHistoryArchive>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ProductID == productID, limit, offset);
		}

		// Non-unique constraint IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID.
		public async virtual Task<List<TransactionHistoryArchive>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID, limit, offset);
		}

		protected async Task<List<TransactionHistoryArchive>> Where(
			Expression<Func<TransactionHistoryArchive, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TransactionHistoryArchive, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.TransactionID;
			}

			return await this.Context.Set<TransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TransactionHistoryArchive>();
		}

		private async Task<TransactionHistoryArchive> GetById(int transactionID)
		{
			List<TransactionHistoryArchive> records = await this.Where(x => x.TransactionID == transactionID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a9200668b3d6d3da6492bee258e4cc96</Hash>
</Codenesium>*/