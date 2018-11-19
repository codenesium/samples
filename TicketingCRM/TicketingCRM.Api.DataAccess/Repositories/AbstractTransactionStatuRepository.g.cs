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
	public abstract class AbstractTransactionStatuRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTransactionStatuRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TransactionStatu>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<TransactionStatu> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<TransactionStatu> Create(TransactionStatu item)
		{
			this.Context.Set<TransactionStatu>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(TransactionStatu item)
		{
			var entity = this.Context.Set<TransactionStatu>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<TransactionStatu>().Attach(item);
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
			TransactionStatu record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TransactionStatu>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Transaction via transactionStatusId.
		public async virtual Task<List<Transaction>> TransactionsByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Transaction>().Where(x => x.TransactionStatusId == transactionStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Transaction>();
		}

		protected async Task<List<TransactionStatu>> Where(
			Expression<Func<TransactionStatu, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TransactionStatu, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<TransactionStatu>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TransactionStatu>();
		}

		private async Task<TransactionStatu> GetById(int id)
		{
			List<TransactionStatu> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2641cbaacdfd2fbf076fafd0f17730a1</Hash>
</Codenesium>*/