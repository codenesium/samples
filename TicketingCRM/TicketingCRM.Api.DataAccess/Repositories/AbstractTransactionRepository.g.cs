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

namespace TicketingCRMNS.Api.DataAccess
{
	public abstract class AbstractTransactionRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTransactionRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Transaction>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Amount.ToDecimal() == query.ToDecimal() ||
				                  x.GatewayConfirmationNumber.StartsWith(query) ||
				                  x.Id == query.ToInt() ||
				                  x.TransactionStatusId == query.ToInt(),
				                  limit,
				                  offset);
			}
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

		// Non-unique constraint IX_transaction_transactionStatusId.
		public async virtual Task<List<Transaction>> ByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TransactionStatusId == transactionStatusId, limit, offset);
		}

		// Foreign key reference to this table Sale via transactionId.
		public async virtual Task<List<Sale>> SalesByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Sale>()
			       .Include(x => x.TransactionIdNavigation)

			       .Where(x => x.TransactionId == transactionId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Sale>();
		}

		// Foreign key reference to table TransactionStatus via transactionStatusId.
		public async virtual Task<TransactionStatus> TransactionStatusByTransactionStatusId(int transactionStatusId)
		{
			return await this.Context.Set<TransactionStatus>()
			       .SingleOrDefaultAsync(x => x.Id == transactionStatusId);
		}

		protected async Task<List<Transaction>> Where(
			Expression<Func<Transaction, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Transaction, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Transaction>()
			       .Include(x => x.TransactionStatusIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Transaction>();
		}

		private async Task<Transaction> GetById(int id)
		{
			List<Transaction> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>37e1e0bdaff6b50f6256c9e1ca46dbb6</Hash>
</Codenesium>*/