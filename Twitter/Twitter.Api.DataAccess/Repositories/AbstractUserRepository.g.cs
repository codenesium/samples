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
	public abstract class AbstractUserRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractUserRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<User>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<User> Get(int userId)
		{
			return await this.GetById(userId);
		}

		public async virtual Task<User> Create(User item)
		{
			this.Context.Set<User>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(User item)
		{
			var entity = this.Context.Set<User>().Local.FirstOrDefault(x => x.UserId == item.UserId);
			if (entity == null)
			{
				this.Context.Set<User>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int userId)
		{
			User record = await this.GetById(userId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<User>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_User_location_location_id.
		public async virtual Task<List<User>> ByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.LocationLocationId == locationLocationId, limit, offset);
		}

		// Foreign key reference to this table DirectTweet via taggedUserId.
		public async virtual Task<List<DirectTweet>> DirectTweetsByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<DirectTweet>().Where(x => x.TaggedUserId == taggedUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<DirectTweet>();
		}

		// Foreign key reference to this table Follower via followedUserId.
		public async virtual Task<List<Follower>> FollowersByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Follower>().Where(x => x.FollowedUserId == followedUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Follower>();
		}

		// Foreign key reference to this table Follower via followingUserId.
		public async virtual Task<List<Follower>> FollowersByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Follower>().Where(x => x.FollowingUserId == followingUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Follower>();
		}

		// Foreign key reference to this table Message via senderUserId.
		public async virtual Task<List<Message>> MessagesBySenderUserId(int senderUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Message>().Where(x => x.SenderUserId == senderUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Message>();
		}

		// Foreign key reference to this table Messenger via toUserId.
		public async virtual Task<List<Messenger>> MessengersByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Messenger>().Where(x => x.ToUserId == toUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Messenger>();
		}

		// Foreign key reference to this table Messenger via userId.
		public async virtual Task<List<Messenger>> MessengersByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Messenger>().Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Messenger>();
		}

		// Foreign key reference to this table QuoteTweet via retweeterUserId.
		public async virtual Task<List<QuoteTweet>> QuoteTweetsByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<QuoteTweet>().Where(x => x.RetweeterUserId == retweeterUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<QuoteTweet>();
		}

		// Foreign key reference to this table Reply via replierUserId.
		public async virtual Task<List<Reply>> RepliesByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Reply>().Where(x => x.ReplierUserId == replierUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Reply>();
		}

		// Foreign key reference to this table Retweet via retwitterUserId.
		public async virtual Task<List<Retweet>> RetweetsByRetwitterUserId(int retwitterUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Retweet>().Where(x => x.RetwitterUserId == retwitterUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Retweet>();
		}

		// Foreign key reference to this table Tweet via userUserId.
		public async virtual Task<List<Tweet>> TweetsByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Tweet>().Where(x => x.UserUserId == userUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Tweet>();
		}

		// Foreign key reference to table Location via locationLocationId.
		public async virtual Task<Location> LocationByLocationLocationId(int locationLocationId)
		{
			return await this.Context.Set<Location>().SingleOrDefaultAsync(x => x.LocationId == locationLocationId);
		}

		// Foreign key reference pass-though. Pass-thru table Tweet. Foreign Table User.
		public async virtual Task<List<User>> ByLocationId(int locationId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.Tweets
			              join users in this.Context.Users on
			              refTable.UserUserId equals users.UserId
			              where refTable.LocationId == locationId
			              select users).Skip(offset).Take(limit).ToListAsync();
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

		// Foreign key reference pass-though. Pass-thru table QuoteTweet. Foreign Table User.
		public async virtual Task<List<User>> BySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.QuoteTweets
			              join users in this.Context.Users on
			              refTable.RetweeterUserId equals users.UserId
			              where refTable.SourceTweetId == sourceTweetId
			              select users).Skip(offset).Take(limit).ToListAsync();
		}

		public async virtual Task<QuoteTweet> CreateQuoteTweet(QuoteTweet item)
		{
			this.Context.Set<QuoteTweet>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task DeleteQuoteTweet(QuoteTweet item)
		{
			this.Context.Set<QuoteTweet>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		protected async Task<List<User>> Where(
			Expression<Func<User, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<User, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.UserId;
			}

			return await this.Context.Set<User>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<User>();
		}

		private async Task<User> GetById(int userId)
		{
			List<User> records = await this.Where(x => x.UserId == userId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5a0ae714cd2b9249346cc46534263d3d</Hash>
</Codenesium>*/