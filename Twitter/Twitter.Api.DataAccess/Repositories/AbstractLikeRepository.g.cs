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
	public abstract class AbstractLikeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLikeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Like>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Like> Get(int likeId)
		{
			return await this.GetById(likeId);
		}

		public async virtual Task<Like> Create(Like item)
		{
			this.Context.Set<Like>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Like item)
		{
			var entity = this.Context.Set<Like>().Local.FirstOrDefault(x => x.LikeId == item.LikeId);
			if (entity == null)
			{
				this.Context.Set<Like>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int likeId)
		{
			Like record = await this.GetById(likeId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Like>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<Like>> ByLikerUserId(int likerUserId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.LikerUserId == likerUserId, limit, offset);

			return records;
		}

		public async Task<List<Like>> ByTweetId(int tweetId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.TweetId == tweetId, limit, offset);

			return records;
		}

		public async virtual Task<User> GetUser(int likerUserId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.UserId == likerUserId);
		}

		public async virtual Task<Tweet> GetTweet(int tweetId)
		{
			return await this.Context.Set<Tweet>().SingleOrDefaultAsync(x => x.TweetId == tweetId);
		}

		protected async Task<List<Like>> Where(
			Expression<Func<Like, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Like, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.LikeId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Like>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Like>();
			}
			else
			{
				return await this.Context.Set<Like>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Like>();
			}
		}

		private async Task<Like> GetById(int likeId)
		{
			List<Like> records = await this.Where(x => x.LikeId == likeId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>67d4e672228a464a4da5bdd930eeefc4</Hash>
</Codenesium>*/