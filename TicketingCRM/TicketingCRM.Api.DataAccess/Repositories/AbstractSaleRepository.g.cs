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

		public virtual Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		// Foreign key reference to table Transaction via transactionId.
		public async virtual Task<Transaction> TransactionByTransactionId(int transactionId)
		{
			return await this.Context.Set<Transaction>().SingleOrDefaultAsync(x => x.Id == transactionId);
		}

		// Foreign key reference pass-though. Pass-thru table SaleTicket. Foreign Table Sale.
		public async virtual Task<List<Sale>> BySaleId(int saleId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.SaleTickets
			              join sales in this.Context.Sales on
			              refTable.SaleId equals sales.Id
			              where refTable.SaleId == saleId
			              select sales).Skip(offset).Take(limit).ToListAsync();
		}

		// Foreign key reference pass-though. Pass-thru table SaleTicket. Foreign Table Sale.
		public async virtual Task<SaleTicket> CreateSaleTicket(SaleTicket item)
		{
			this.Context.Set<SaleTicket>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		// Foreign key reference pass-though. Pass-thru table SaleTicket. Foreign Table Sale.
		public async virtual Task DeleteSaleTicket(SaleTicket item)
		{
			this.Context.Set<SaleTicket>().Remove(item);
			await this.Context.SaveChangesAsync();
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

			return await this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Sale>();
		}

		private async Task<Sale> GetById(int id)
		{
			List<Sale> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>941055cb13fd75243c40f97515f11eb0</Hash>
</Codenesium>*/