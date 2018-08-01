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

		public virtual Task<List<AirTransport>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<AirTransport> Get(int airlineId)
		{
			return await this.GetById(airlineId);
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
			var entity = this.Context.Set<AirTransport>().Local.FirstOrDefault(x => x.AirlineId == item.AirlineId);
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
			int airlineId)
		{
			AirTransport record = await this.GetById(airlineId);

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

		public async virtual Task<Handler> GetHandler(int handlerId)
		{
			return await this.Context.Set<Handler>().SingleOrDefaultAsync(x => x.Id == handlerId);
		}

		protected async Task<List<AirTransport>> Where(
			Expression<Func<AirTransport, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<AirTransport, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.AirlineId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<AirTransport>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<AirTransport>();
			}
			else
			{
				return await this.Context.Set<AirTransport>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<AirTransport>();
			}
		}

		private async Task<AirTransport> GetById(int airlineId)
		{
			List<AirTransport> records = await this.Where(x => x.AirlineId == airlineId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2a74b638b0d8b2549d7d0f0e43c0ded5</Hash>
</Codenesium>*/