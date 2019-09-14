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
	public class UserRepository : AbstractRepository, IUserRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public UserRepository(
			ILogger<IUserRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<User>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.BioImgUrl == null?false : x.BioImgUrl.StartsWith(query)) ||
				                  x.Birthday == query.ToNullableDateTime() ||
				                  (x.ContentDescription == null?false : x.ContentDescription.StartsWith(query)) ||
				                  (x.Email == null?false : x.Email.StartsWith(query)) ||
				                  (x.FullName == null?false : x.FullName.StartsWith(query)) ||
				                  (x.HeaderImgUrl == null?false : x.HeaderImgUrl.StartsWith(query)) ||
				                  (x.Interest == null?false : x.Interest.StartsWith(query)) ||
				                  (x.LocationLocationIdNavigation == null || x.LocationLocationIdNavigation.LocationName == null?false : x.LocationLocationIdNavigation.LocationName.StartsWith(query)) ||
				                  (x.Password == null?false : x.Password.StartsWith(query)) ||
				                  (x.PhoneNumber == null?false : x.PhoneNumber.StartsWith(query)) ||
				                  (x.Privacy == null?false : x.Privacy.StartsWith(query)) ||
				                  (x.Username == null?false : x.Username.StartsWith(query)) ||
				                  (x.Website == null?false : x.Website.StartsWith(query)),
				                  limit,
				                  offset);
			}
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
			return await this.Context.Set<DirectTweet>()
			       .Include(x => x.TaggedUserIdNavigation)

			       .Where(x => x.TaggedUserId == taggedUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<DirectTweet>();
		}

		// Foreign key reference to this table Follower via followedUserId.
		public async virtual Task<List<Follower>> FollowersByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Follower>()
			       .Include(x => x.FollowedUserIdNavigation)
			       .Include(x => x.FollowingUserIdNavigation)

			       .Where(x => x.FollowedUserId == followedUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Follower>();
		}

		// Foreign key reference to this table Follower via followingUserId.
		public async virtual Task<List<Follower>> FollowersByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Follower>()
			       .Include(x => x.FollowedUserIdNavigation)
			       .Include(x => x.FollowingUserIdNavigation)

			       .Where(x => x.FollowingUserId == followingUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Follower>();
		}

		// Foreign key reference to this table Message via senderUserId.
		public async virtual Task<List<Message>> MessagesBySenderUserId(int senderUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Message>()
			       .Include(x => x.SenderUserIdNavigation)

			       .Where(x => x.SenderUserId == senderUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Message>();
		}

		// Foreign key reference to this table Messenger via toUserId.
		public async virtual Task<List<Messenger>> MessengersByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Messenger>()
			       .Include(x => x.MessageIdNavigation)
			       .Include(x => x.ToUserIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.ToUserId == toUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Messenger>();
		}

		// Foreign key reference to this table Messenger via userId.
		public async virtual Task<List<Messenger>> MessengersByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Messenger>()
			       .Include(x => x.MessageIdNavigation)
			       .Include(x => x.ToUserIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Messenger>();
		}

		// Foreign key reference to this table QuoteTweet via retweeterUserId.
		public async virtual Task<List<QuoteTweet>> QuoteTweetsByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<QuoteTweet>()
			       .Include(x => x.RetweeterUserIdNavigation)
			       .Include(x => x.SourceTweetIdNavigation)

			       .Where(x => x.RetweeterUserId == retweeterUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<QuoteTweet>();
		}

		// Foreign key reference to this table Reply via replierUserId.
		public async virtual Task<List<Reply>> RepliesByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Reply>()
			       .Include(x => x.ReplierUserIdNavigation)

			       .Where(x => x.ReplierUserId == replierUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Reply>();
		}

		// Foreign key reference to this table Retweet via retwitterUserId.
		public async virtual Task<List<Retweet>> RetweetsByRetwitterUserId(int retwitterUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Retweet>()
			       .Include(x => x.RetwitterUserIdNavigation)
			       .Include(x => x.TweetTweetIdNavigation)

			       .Where(x => x.RetwitterUserId == retwitterUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Retweet>();
		}

		// Foreign key reference to this table Tweet via userUserId.
		public async virtual Task<List<Tweet>> TweetsByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Tweet>()
			       .Include(x => x.LocationIdNavigation)
			       .Include(x => x.UserUserIdNavigation)

			       .Where(x => x.UserUserId == userUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Tweet>();
		}

		// Foreign key reference to table Location via locationLocationId.
		public async virtual Task<Location> LocationByLocationLocationId(int locationLocationId)
		{
			return await this.Context.Set<Location>()
			       .SingleOrDefaultAsync(x => x.LocationId == locationLocationId);
		}

		// Foreign key reference pass-though. Pass-thru table Like. Foreign Table User.
		public async virtual Task<List<User>> ByTweetId(int tweetId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.Likes
			              join users in this.Context.Users on
			              refTable.LikerUserId equals users.UserId
			              where refTable.TweetId == tweetId
			              select users).Skip(offset).Take(limit).ToListAsync();
		}

		// Foreign key reference pass-though. Pass-thru table Like. Foreign Table User.
		public async virtual Task<Like> CreateLike(Like item)
		{
			this.Context.Set<Like>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		// Foreign key reference pass-though. Pass-thru table Like. Foreign Table User.
		public async virtual Task DeleteLike(Like item)
		{
			this.Context.Set<Like>().Remove(item);
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

			return await this.Context.Set<User>()
			       .Include(x => x.LocationLocationIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<User>();
		}

		private async Task<User> GetById(int userId)
		{
			List<User> records = await this.Where(x => x.UserId == userId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a4cc5ee44da468643b40de055fa3c78c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/