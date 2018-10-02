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
	public abstract class AbstractSaleTicketRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSaleTicketRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SaleTicket>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SaleTicket> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<SaleTicket> Create(SaleTicket item)
		{
			this.Context.Set<SaleTicket>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SaleTicket item)
		{
			var entity = this.Context.Set<SaleTicket>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<SaleTicket>().Attach(item);
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
			SaleTicket record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SaleTicket>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<SaleTicket>> ByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.TicketId == ticketId, limit, offset);

			return records;
		}

		public async virtual Task<Sale> GetSale(int saleId)
		{
			return await this.Context.Set<Sale>().SingleOrDefaultAsync(x => x.Id == saleId);
		}

		public async virtual Task<Ticket> GetTicket(int ticketId)
		{
			return await this.Context.Set<Ticket>().SingleOrDefaultAsync(x => x.Id == ticketId);
		}

		protected async Task<List<SaleTicket>> Where(
			Expression<Func<SaleTicket, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SaleTicket, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<SaleTicket>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SaleTicket>();
			}
			else
			{
				return await this.Context.Set<SaleTicket>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SaleTicket>();
			}
		}

		private async Task<SaleTicket> GetById(int id)
		{
			List<SaleTicket> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2333fd557d65352ccae8975b1ad1e920</Hash>
</Codenesium>*/