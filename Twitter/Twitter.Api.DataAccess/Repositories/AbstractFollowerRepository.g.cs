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
	public abstract class AbstractFollowerRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractFollowerRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Follower>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async virtual Task<List<Follower>> ByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.FollowedUserId == followedUserId, limit, offset);
		}

		public async virtual Task<List<Follower>> ByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.FollowingUserId == followingUserId, limit, offset);
		}

		public async virtual Task<User> UserByFollowedUserId(int followedUserId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.UserId == followedUserId);
		}

		public async virtual Task<User> UserByFollowingUserId(int followingUserId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.UserId == followingUserId);
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

			return await this.Context.Set<Follower>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Follower>();
		}

		private async Task<Follower> GetById(int id)
		{
			List<Follower> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>380619d92a2a6b3d25bc2a153086c1b2</Hash>
</Codenesium>*/