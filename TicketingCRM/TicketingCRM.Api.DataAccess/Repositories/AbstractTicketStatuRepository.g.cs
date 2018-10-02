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
	public abstract class AbstractTicketStatuRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTicketStatuRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TicketStatu>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<TicketStatu> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<TicketStatu> Create(TicketStatu item)
		{
			this.Context.Set<TicketStatu>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(TicketStatu item)
		{
			var entity = this.Context.Set<TicketStatu>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<TicketStatu>().Attach(item);
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
			TicketStatu record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TicketStatu>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<Ticket>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Ticket>().Where(x => x.TicketStatusId == ticketStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Ticket>();
		}

		protected async Task<List<TicketStatu>> Where(
			Expression<Func<TicketStatu, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TicketStatu, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<TicketStatu>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TicketStatu>();
			}
			else
			{
				return await this.Context.Set<TicketStatu>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<TicketStatu>();
			}
		}

		private async Task<TicketStatu> GetById(int id)
		{
			List<TicketStatu> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c79db379e652421fe5ef49dfc3f42567</Hash>
</Codenesium>*/