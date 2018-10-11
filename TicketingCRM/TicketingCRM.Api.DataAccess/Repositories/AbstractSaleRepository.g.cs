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

		public async Task<List<Sale>> ByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TransactionId == transactionId, limit, offset);
		}

		public async virtual Task<Transaction> TransactionByTransactionId(int transactionId)
		{
			return await this.Context.Set<Transaction>().SingleOrDefaultAsync(x => x.Id == transactionId);
		}

		// Reference foreign key. Reference Table=SaleTicket. First table=sales. Second table=sales
		public async virtual Task<List<Sale>> BySaleId(int saleId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.SaleTickets
			              join sales in this.Context.Sales on
			              refTable.SaleId equals sales.Id
			              where refTable.SaleId == saleId
			              select sales).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<Sale>> Where(
			Expression<Func<Sale, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Sale, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Sale>();
			}
			else
			{
				return await this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Sale>();
			}
		}

		private async Task<Sale> GetById(int id)
		{
			List<Sale> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1ad2ce18e041a2a6346a964d2ff0fc1f</Hash>
</Codenesium>*/