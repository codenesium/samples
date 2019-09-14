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
	public class FollowerRepository : AbstractRepository, IFollowerRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public FollowerRepository(
			ILogger<IFollowerRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Follower>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Blocked == null?false : x.Blocked.StartsWith(query)) ||
				                  x.DateFollowed == query.ToDateTime() ||
				                  (x.FollowRequestStatu == null?false : x.FollowRequestStatu.StartsWith(query)) ||
				                  (x.FollowedUserIdNavigation == null || x.FollowedUserIdNavigation.Username == null?false : x.FollowedUserIdNavigation.Username.StartsWith(query)) ||
				                  (x.FollowingUserIdNavigation == null || x.FollowingUserIdNavigation.Username == null?false : x.FollowingUserIdNavigation.Username.StartsWith(query)) ||
				                  (x.Muted == null?false : x.Muted.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Follower> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Follower> Create(Follower item)
		{
			this.Context.Set<Follower>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Follower item)
		{
			var entity = this.Context.Set<Follower>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Follower>().Attach(item);
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
			Follower record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Follower>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Follower_followed_user_id.
		public async virtual Task<List<Follower>> ByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.FollowedUserId == followedUserId, limit, offset);
		}

		// Non-unique constraint IX_Follower_following_user_id.
		public async virtual Task<List<Follower>> ByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.FollowingUserId == followingUserId, limit, offset);
		}

		// Foreign key reference to table User via followedUserId.
		public async virtual Task<User> UserByFollowedUserId(int followedUserId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.UserId == followedUserId);
		}

		// Foreign key reference to table User via followingUserId.
		public async virtual Task<User> UserByFollowingUserId(int followingUserId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.UserId == followingUserId);
		}

		protected async Task<List<Follower>> Where(
			Expression<Func<Follower, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Follower, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Follower>()
			       .Include(x => x.FollowedUserIdNavigation)
			       .Include(x => x.FollowingUserIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Follower>();
		}

		private async Task<Follower> GetById(int id)
		{
			List<Follower> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fc4f1d30c25684294a5c1c7d9693f104</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/