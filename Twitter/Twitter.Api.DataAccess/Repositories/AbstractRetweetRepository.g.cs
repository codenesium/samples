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
	public abstract class AbstractRetweetRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractRetweetRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Retweet>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Retweet> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Retweet> Create(Retweet item)
		{
			this.Context.Set<Retweet>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Retweet item)
		{
			var entity = this.Context.Set<Retweet>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Retweet>().Attach(item);
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
			Retweet record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Retweet>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<Retweet>> ByRetwitterUserId(int? retwitterUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.RetwitterUserId == retwitterUserId, limit, offset);
		}

		public async Task<List<Retweet>> ByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TweetTweetId == tweetTweetId, limit, offset);
		}

		public async virtual Task<User> UserByRetwitterUserId(int? retwitterUserId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.UserId == retwitterUserId);
		}

		public async virtual Task<Tweet> TweetByTweetTweetId(int tweetTweetId)
		{
			return await this.Context.Set<Tweet>().SingleOrDefaultAsync(x => x.TweetId == tweetTweetId);
		}

		protected async Task<List<Retweet>> Where(
			Expression<Func<Retweet, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Retweet, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Retweet>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Retweet>();
			}
			else
			{
				return await this.Context.Set<Retweet>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Retweet>();
			}
		}

		private async Task<Retweet> GetById(int id)
		{
			List<Retweet> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>34a746a58e924fa5ca42d036a3bce633</Hash>
</Codenesium>*/