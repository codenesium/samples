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
	public abstract class AbstractTicketStatusRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTicketStatusRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TicketStatus>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<TicketStatus> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<TicketStatus> Create(TicketStatus item)
		{
			this.Context.Set<TicketStatus>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(TicketStatus item)
		{
			var entity = this.Context.Set<TicketStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<TicketStatus>().Attach(item);
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
			TicketStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TicketStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<Ticket>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Ticket>().Where(x => x.TicketStatusId == ticketStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Ticket>();
		}

		protected async Task<List<TicketStatus>> Where(
			Expression<Func<TicketStatus, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TicketStatus, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<TicketStatus>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TicketStatus>();
			}
			else
			{
				return await this.Context.Set<TicketStatus>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<TicketStatus>();
			}
		}

		private async Task<TicketStatus> GetById(int id)
		{
			List<TicketStatus> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>70bc04cec4e982a509bcaf857742f655</Hash>
</Codenesium>*/