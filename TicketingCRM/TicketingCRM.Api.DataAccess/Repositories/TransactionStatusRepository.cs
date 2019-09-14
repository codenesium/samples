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
	public class TransactionStatusRepository : AbstractRepository, ITransactionStatusRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public TransactionStatusRepository(
			ILogger<ITransactionStatusRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TransactionStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Name == null?false : x.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
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

		// Foreign key reference to this table Transaction via transactionStatusId.
		public async virtual Task<List<Transaction>> TransactionsByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Transaction>()
			       .Include(x => x.TransactionStatusIdNavigation)

			       .Where(x => x.TransactionStatusId == transactionStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Transaction>();
		}

		protected async Task<List<TransactionStatus>> Where(
			Expression<Func<TransactionStatus, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TransactionStatus, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<TransactionStatus>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TransactionStatus>();
		}

		private async Task<TransactionStatus> GetById(int id)
		{
			List<TransactionStatus> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fa7d76110dcf6c2b85b9b5b04d2fb9bb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/