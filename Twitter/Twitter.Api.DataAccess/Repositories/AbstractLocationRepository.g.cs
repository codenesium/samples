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

namespace TwitterNS.Api.DataAccess
{
	public abstract class AbstractLocationRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLocationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Location>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Location> Get(int locationId)
		{
			return await this.GetById(locationId);
		}

		public async virtual Task<Location> Create(Location item)
		{
			this.Context.Set<Location>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Location item)
		{
			var entity = this.Context.Set<Location>().Local.FirstOrDefault(x => x.LocationId == item.LocationId);
			if (entity == null)
			{
				this.Context.Set<Location>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int locationId)
		{
			Location record = await this.GetById(locationId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Location>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Tweet via locationId.
		public async virtual Task<List<Tweet>> TweetsByLocationId(int locationId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Tweet>().Where(x => x.LocationId == locationId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Tweet>();
		}

		// Foreign key reference to this table User via locationLocationId.
		public async virtual Task<List<User>> UsersByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<User>().Where(x => x.LocationLocationId == locationLocationId).AsQueryable().Skip(offset).Take(limit).ToListAsync<User>();
		}

		// Foreign key reference pass-though. Pass-thru table Tweet. Foreign Table Location.
		public async virtual Task<List<Location>> ByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.Tweets
			              join locations in this.Context.Locations on
			              refTable.LocationId equals locations.LocationId
			              where refTable.UserUserId == userUserId
			              select locations).Skip(offset).Take(limit).ToListAsync();
		}

		public async virtual Task<Tweet> CreateTweet(Tweet item)
		{
			this.Context.Set<Tweet>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task DeleteTweet(Tweet item)
		{
			this.Context.Set<Tweet>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		protected async Task<List<Location>> Where(
			Expression<Func<Location, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Location, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.LocationId;
			}

			return await this.Context.Set<Location>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Location>();
		}

		private async Task<Location> GetById(int locationId)
		{
			List<Location> records = await this.Where(x => x.LocationId == locationId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9107ece31ad24573bc6f5cd804112189</Hash>
</Codenesium>*/