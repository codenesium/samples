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
	public abstract class AbstractQuoteTweetRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractQuoteTweetRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<QuoteTweet>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async Task<List<QuoteTweet>> ByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.RetweeterUserId == retweeterUserId, limit, offset);
		}

		public async Task<List<QuoteTweet>> BySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.SourceTweetId == sourceTweetId, limit, offset);
		}

		public async virtual Task<User> UserByRetweeterUserId(int retweeterUserId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.UserId == retweeterUserId);
		}

		public async virtual Task<Tweet> TweetBySourceTweetId(int sourceTweetId)
		{
			return await this.Context.Set<Tweet>().SingleOrDefaultAsync(x => x.TweetId == sourceTweetId);
		}

		protected async Task<List<QuoteTweet>> Where(
			Expression<Func<QuoteTweet, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<QuoteTweet, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.QuoteTweetId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<QuoteTweet>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<QuoteTweet>();
			}
			else
			{
				return await this.Context.Set<QuoteTweet>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<QuoteTweet>();
			}
		}

		private async Task<QuoteTweet> GetById(int quoteTweetId)
		{
			List<QuoteTweet> records = await this.Where(x => x.QuoteTweetId == quoteTweetId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8edb974abd1fd81d428233af8f8e1af2</Hash>
</Codenesium>*/