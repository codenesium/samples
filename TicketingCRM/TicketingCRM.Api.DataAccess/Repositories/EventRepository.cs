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
	public class EventRepository : AbstractRepository, IEventRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public EventRepository(
			ILogger<IEventRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Event>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Address1 == null?false : x.Address1.StartsWith(query)) ||
				                  (x.Address2 == null?false : x.Address2.StartsWith(query)) ||
				                  (x.CityIdNavigation == null || x.CityIdNavigation.Name == null?false : x.CityIdNavigation.Name.StartsWith(query)) ||
				                  x.Date == query.ToDateTime() ||
				                  (x.Description == null?false : x.Description.StartsWith(query)) ||
				                  x.EndDate == query.ToDateTime() ||
				                  (x.Facebook == null?false : x.Facebook.StartsWith(query)) ||
				                  (x.Name == null?false : x.Name.StartsWith(query)) ||
				                  x.StartDate == query.ToDateTime() ||
				                  (x.Website == null?false : x.Website.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Event> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Event> Create(Event item)
		{
			this.Context.Set<Event>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Event item)
		{
			var entity = this.Context.Set<Event>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Event>().Attach(item);
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
			Event record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Event>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_event_cityId.
		public async virtual Task<List<Event>> ByCityId(int cityId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.CityId == cityId, limit, offset);
		}

		// Foreign key reference to table City via cityId.
		public async virtual Task<City> CityByCityId(int cityId)
		{
			return await this.Context.Set<City>()
			       .SingleOrDefaultAsync(x => x.Id == cityId);
		}

		protected async Task<List<Event>> Where(
			Expression<Func<Event, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Event, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Event>()
			       .Include(x => x.CityIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Event>();
		}

		private async Task<Event> GetById(int id)
		{
			List<Event> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b5b39ea7f542557fcf367a5c13a6d1ec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/