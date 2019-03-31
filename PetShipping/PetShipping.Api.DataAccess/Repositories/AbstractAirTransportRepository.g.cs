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

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractAirTransportRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractAirTransportRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<AirTransport>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.AirlineId == query.ToInt() ||
				                  x.FlightNumber.StartsWith(query) ||
				                  x.HandlerId == query.ToInt() ||
				                  x.LandDate == query.ToDateTime() ||
				                  x.PipelineStepId == query.ToInt() ||
				                  x.TakeoffDate == query.ToDateTime(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<AirTransport> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<AirTransport> Create(AirTransport item)
		{
			this.Context.Set<AirTransport>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(AirTransport item)
		{
			var entity = this.Context.Set<AirTransport>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<AirTransport>().Attach(item);
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
			AirTransport record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<AirTransport>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Handler via handlerId.
		public async virtual Task<Handler> HandlerByHandlerId(int handlerId)
		{
			return await this.Context.Set<Handler>()
			       .SingleOrDefaultAsync(x => x.Id == handlerId);
		}

		protected async Task<List<AirTransport>> Where(
			Expression<Func<AirTransport, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<AirTransport, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<AirTransport>()
			       .Include(x => x.HandlerIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<AirTransport>();
		}

		private async Task<AirTransport> GetById(int id)
		{
			List<AirTransport> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>bd9df7481d902f7950f874193e62663e</Hash>
</Codenesium>*/