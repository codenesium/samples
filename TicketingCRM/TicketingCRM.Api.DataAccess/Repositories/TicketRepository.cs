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
	public class TicketRepository : AbstractRepository, ITicketRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public TicketRepository(
			ILogger<ITicketRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Ticket>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.PublicId == null?false : x.PublicId.StartsWith(query)) ||
				                  (x.TicketStatusIdNavigation == null || x.TicketStatusIdNavigation.Name == null?false : x.TicketStatusIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Ticket> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Ticket> Create(Ticket item)
		{
			this.Context.Set<Ticket>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Ticket item)
		{
			var entity = this.Context.Set<Ticket>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Ticket>().Attach(item);
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
			Ticket record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Ticket>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_ticket_ticketStatusId.
		public async virtual Task<List<Ticket>> ByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TicketStatusId == ticketStatusId, limit, offset);
		}

		// Foreign key reference to this table SaleTickets via ticketId.
		public async virtual Task<List<SaleTickets>> SaleTicketsByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SaleTickets>()
			       .Include(x => x.SaleIdNavigation)
			       .Include(x => x.TicketIdNavigation)

			       .Where(x => x.TicketId == ticketId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SaleTickets>();
		}

		// Foreign key reference to table TicketStatus via ticketStatusId.
		public async virtual Task<TicketStatus> TicketStatusByTicketStatusId(int ticketStatusId)
		{
			return await this.Context.Set<TicketStatus>()
			       .SingleOrDefaultAsync(x => x.Id == ticketStatusId);
		}

		protected async Task<List<Ticket>> Where(
			Expression<Func<Ticket, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Ticket, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Ticket>()
			       .Include(x => x.TicketStatusIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Ticket>();
		}

		private async Task<Ticket> GetById(int id)
		{
			List<Ticket> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>edf5dbd651e519c559684044758dff26</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/