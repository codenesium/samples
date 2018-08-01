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
	public abstract class AbstractTransactionHistoryRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTransactionHistoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TransactionHistory>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async Task<List<TransactionHistory>> ByProductID(int productID)
		{
			var records = await this.Where(x => x.ProductID == productID);

			return records;
		}

		public async Task<List<TransactionHistory>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
		{
			var records = await this.Where(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID);

			return records;
		}

		protected async Task<List<TransactionHistory>> Where(
			Expression<Func<TransactionHistory, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TransactionHistory, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.TransactionID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<TransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TransactionHistory>();
			}
			else
			{
				return await this.Context.Set<TransactionHistory>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<TransactionHistory>();
			}
		}

		private async Task<TransactionHistory> GetById(int transactionID)
		{
			List<TransactionHistory> records = await this.Where(x => x.TransactionID == transactionID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a7e1cc08c46c557285d68527f55b743c</Hash>
</Codenesium>*/