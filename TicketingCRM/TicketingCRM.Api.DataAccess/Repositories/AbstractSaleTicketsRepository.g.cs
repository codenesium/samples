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
	public abstract class AbstractSaleTicketsRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSaleTicketsRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SaleTickets>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.SaleId == query.ToInt() ||
				                  x.TicketId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<SaleTickets> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<SaleTickets> Create(SaleTickets item)
		{
			this.Context.Set<SaleTickets>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SaleTickets item)
		{
			var entity = this.Context.Set<SaleTickets>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<SaleTickets>().Attach(item);
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
			SaleTickets record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SaleTickets>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_saleTickets_ticketId.
		public async virtual Task<List<SaleTickets>> ByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TicketId == ticketId, limit, offset);
		}

		// Foreign key reference to table Sale via saleId.
		public async virtual Task<Sale> SaleBySaleId(int saleId)
		{
			return await this.Context.Set<Sale>()
			       .SingleOrDefaultAsync(x => x.Id == saleId);
		}

		// Foreign key reference to table Ticket via ticketId.
		public async virtual Task<Ticket> TicketByTicketId(int ticketId)
		{
			return await this.Context.Set<Ticket>()
			       .SingleOrDefaultAsync(x => x.Id == ticketId);
		}

		protected async Task<List<SaleTickets>> Where(
			Expression<Func<SaleTickets, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SaleTickets, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<SaleTickets>()
			       .Include(x => x.SaleIdNavigation)
			       .Include(x => x.TicketIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SaleTickets>();
		}

		private async Task<SaleTickets> GetById(int id)
		{
			List<SaleTickets> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>bde46e7d1ede96ead68fc5aaf4120b39</Hash>
</Codenesium>*/