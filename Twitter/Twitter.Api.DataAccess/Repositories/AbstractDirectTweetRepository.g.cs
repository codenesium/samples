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
	public abstract class AbstractDirectTweetRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractDirectTweetRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DirectTweet>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Content.StartsWith(query) ||
				                  x.Date == query.ToDateTime() ||
				                  (x.TaggedUserIdNavigation == null || x.TaggedUserIdNavigation.Username == null?false : x.TaggedUserIdNavigation.Username.StartsWith(query)) ||
				                  x.Time == query.ToTimespan(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<DirectTweet> Get(int tweetId)
		{
			return await this.GetById(tweetId);
		}

		public async virtual Task<DirectTweet> Create(DirectTweet item)
		{
			this.Context.Set<DirectTweet>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(DirectTweet item)
		{
			var entity = this.Context.Set<DirectTweet>().Local.FirstOrDefault(x => x.TweetId == item.TweetId);
			if (entity == null)
			{
				this.Context.Set<DirectTweet>().Attach(item);
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
			DirectTweet record = await this.GetById(tweetId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<DirectTweet>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Direct_Tweets_tagged_user_id.
		public async virtual Task<List<DirectTweet>> ByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TaggedUserId == taggedUserId, limit, offset);
		}

		// Foreign key reference to table User via taggedUserId.
		public async virtual Task<User> UserByTaggedUserId(int taggedUserId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.UserId == taggedUserId);
		}

		protected async Task<List<DirectTweet>> Where(
			Expression<Func<DirectTweet, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<DirectTweet, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.TweetId;
			}

			return await this.Context.Set<DirectTweet>()
			       .Include(x => x.TaggedUserIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<DirectTweet>();
		}

		private async Task<DirectTweet> GetById(int tweetId)
		{
			List<DirectTweet> records = await this.Where(x => x.TweetId == tweetId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>846899e9cb4307e26fb60b8fd9abab3f</Hash>
</Codenesium>*/