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
	public abstract class AbstractSaleRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSaleRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.IpAddress.StartsWith(query) ||
				                  x.Notes.StartsWith(query) ||
				                  x.SaleDate == query.ToDateTime() ||
				                  (x.TransactionIdNavigation == null || x.TransactionIdNavigation.Id == null?false : x.TransactionIdNavigation.Id == query.ToInt()),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Sale> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Sale> Create(Sale item)
		{
			this.Context.Set<Sale>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Sale item)
		{
			var entity = this.Context.Set<Sale>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Sale>().Attach(item);
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
			Sale record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Sale>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_sale_transactionId.
		public async virtual Task<List<Sale>> ByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TransactionId == transactionId, limit, offset);
		}

		// Foreign key reference to this table SaleTickets via saleId.
		public async virtual Task<List<SaleTickets>> SaleTicketsBySaleId(int saleId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SaleTickets>()
			       .Include(x => x.SaleIdNavigation)
			       .Include(x => x.TicketIdNavigation)

			       .Where(x => x.SaleId == saleId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SaleTickets>();
		}

		// Foreign key reference to table Transaction via transactionId.
		public async virtual Task<Transaction> TransactionByTransactionId(int transactionId)
		{
			return await this.Context.Set<Transaction>()
			       .SingleOrDefaultAsync(x => x.Id == transactionId);
		}

		protected async Task<List<Sale>> Where(
			Expression<Func<Sale, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Sale, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Sale>()
			       .Include(x => x.TransactionIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Sale>();
		}

		private async Task<Sale> GetById(int id)
		{
			List<Sale> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9b91145ccf8f7d198f6d032468d5b486</Hash>
</Codenesium>*/