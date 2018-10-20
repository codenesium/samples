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

		public async Task<List<Tweet>> ByLocationId(int locationId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.LocationId == locationId, limit, offset);
		}

		public async Task<List<Tweet>> ByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserUserId == userUserId, limit, offset);
		}

		public async virtual Task<List<QuoteTweet>> QuoteTweetsBySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<QuoteTweet>().Where(x => x.SourceTweetId == sourceTweetId).AsQueryable().Skip(offset).Take(limit).ToListAsync<QuoteTweet>();
		}

		public async virtual Task<List<Retweet>> RetweetsByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Retweet>().Where(x => x.TweetTweetId == tweetTweetId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Retweet>();
		}

		public async virtual Task<Location> LocationByLocationId(int locationId)
		{
			return await this.Context.Set<Location>().SingleOrDefaultAsync(x => x.LocationId == locationId);
		}

		public async virtual Task<User> UserByUserUserId(int userUserId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.UserId == userUserId);
		}

		protected async Task<List<Tweet>> Where(
			Expression<Func<Tweet, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Tweet, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.TweetId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Tweet>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Tweet>();
			}
			else
			{
				return await this.Context.Set<Tweet>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Tweet>();
			}
		}

		private async Task<Tweet> GetById(int tweetId)
		{
			List<Tweet> records = await this.Where(x => x.TweetId == tweetId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8072c49d1534fe9b97d373093d4583de</Hash>
</Codenesium>*/