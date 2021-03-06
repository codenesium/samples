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
	public class QuoteTweetRepository : AbstractRepository, IQuoteTweetRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public QuoteTweetRepository(
			ILogger<IQuoteTweetRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<QuoteTweet>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Content == null?false : x.Content.StartsWith(query)) ||
				                  x.Date == query.ToDateTime() ||
				                  (x.RetweeterUserIdNavigation == null || x.RetweeterUserIdNavigation.Username == null?false : x.RetweeterUserIdNavigation.Username.StartsWith(query)) ||
				                  (x.SourceTweetIdNavigation == null || x.SourceTweetIdNavigation.TweetId == null?false : x.SourceTweetIdNavigation.TweetId == query.ToInt()) ||
				                  x.Time == query.ToTimespan(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<QuoteTweet> Get(int quoteTweetId)
		{
			return await this.GetById(quoteTweetId);
		}

		public async virtual Task<QuoteTweet> Create(QuoteTweet item)
		{
			this.Context.Set<QuoteTweet>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(QuoteTweet item)
		{
			var entity = this.Context.Set<QuoteTweet>().Local.FirstOrDefault(x => x.QuoteTweetId == item.QuoteTweetId);
			if (entity == null)
			{
				this.Context.Set<QuoteTweet>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int quoteTweetId)
		{
			QuoteTweet record = await this.GetById(quoteTweetId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<QuoteTweet>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Quote_Tweet_retweeter_user_id.
		public async virtual Task<List<QuoteTweet>> ByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.RetweeterUserId == retweeterUserId, limit, offset);
		}

		// Non-unique constraint IX_Quote_Tweet_source_tweet_id.
		public async virtual Task<List<QuoteTweet>> BySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.SourceTweetId == sourceTweetId, limit, offset);
		}

		// Foreign key reference to table User via retweeterUserId.
		public async virtual Task<User> UserByRetweeterUserId(int retweeterUserId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.UserId == retweeterUserId);
		}

		// Foreign key reference to table Tweet via sourceTweetId.
		public async virtual Task<Tweet> TweetBySourceTweetId(int sourceTweetId)
		{
			return await this.Context.Set<Tweet>()
			       .SingleOrDefaultAsync(x => x.TweetId == sourceTweetId);
		}

		protected async Task<List<QuoteTweet>> Where(
			Expression<Func<QuoteTweet, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<QuoteTweet, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.QuoteTweetId;
			}

			return await this.Context.Set<QuoteTweet>()
			       .Include(x => x.RetweeterUserIdNavigation)
			       .Include(x => x.SourceTweetIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<QuoteTweet>();
		}

		private async Task<QuoteTweet> GetById(int quoteTweetId)
		{
			List<QuoteTweet> records = await this.Where(x => x.QuoteTweetId == quoteTweetId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5671701c9cced522d1546c7dc0897f68</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/