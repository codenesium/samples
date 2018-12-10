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
	public abstract class AbstractTweetRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTweetRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Tweet>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Tweet> Get(int tweetId)
		{
			return await this.GetById(tweetId);
		}

		public async virtual Task<Tweet> Create(Tweet item)
		{
			this.Context.Set<Tweet>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Tweet item)
		{
			var entity = this.Context.Set<Tweet>().Local.FirstOrDefault(x => x.TweetId == item.TweetId);
			if (entity == null)
			{
				this.Context.Set<Tweet>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int tweetId)
		{
			Tweet record = await this.GetById(tweetId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Tweet>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Tweet_location_id.
		public async virtual Task<List<Tweet>> ByLocationId(int locationId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.LocationId == locationId, limit, offset);
		}

		// Non-unique constraint IX_Tweet_user_user_id.
		public async virtual Task<List<Tweet>> ByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserUserId == userUserId, limit, offset);
		}

		// Foreign key reference to this table QuoteTweet via sourceTweetId.
		public async virtual Task<List<QuoteTweet>> QuoteTweetsBySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<QuoteTweet>().Where(x => x.SourceTweetId == sourceTweetId).AsQueryable().Skip(offset).Take(limit).ToListAsync<QuoteTweet>();
		}

		// Foreign key reference to this table Retweet via tweetTweetId.
		public async virtual Task<List<Retweet>> RetweetsByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Retweet>().Where(x => x.TweetTweetId == tweetTweetId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Retweet>();
		}

		// Foreign key reference to table Location via locationId.
		public async virtual Task<Location> LocationByLocationId(int locationId)
		{
			return await this.Context.Set<Location>().SingleOrDefaultAsync(x => x.LocationId == locationId);
		}

		// Foreign key reference to table User via userUserId.
		public async virtual Task<User> UserByUserUserId(int userUserId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.UserId == userUserId);
		}

		protected async Task<List<Tweet>> Where(
			Expression<Func<Tweet, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Tweet, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.TweetId;
			}

			return await this.Context.Set<Tweet>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Tweet>();
		}

		private async Task<Tweet> GetById(int tweetId)
		{
			List<Tweet> records = await this.Where(x => x.TweetId == tweetId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a6fe43f6d22f7845cacb18c3a32a10e7</Hash>
</Codenesium>*/