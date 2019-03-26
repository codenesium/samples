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

namespace StackOverflowNS.Api.DataAccess
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

		public virtual Task<List<User>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.AboutMe.StartsWith(query) ||
				                  x.AccountId == query.ToNullableInt() ||
				                  x.Age == query.ToNullableInt() ||
				                  x.CreationDate == query.ToDateTime() ||
				                  x.DisplayName.StartsWith(query) ||
				                  x.DownVote == query.ToInt() ||
				                  x.EmailHash.StartsWith(query) ||
				                  x.Id == query.ToInt() ||
				                  x.LastAccessDate == query.ToDateTime() ||
				                  x.Location.StartsWith(query) ||
				                  x.Reputation == query.ToInt() ||
				                  x.UpVote == query.ToInt() ||
				                  x.View == query.ToInt() ||
				                  x.WebsiteUrl.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<User> Get(int id)
		{
			return await this.GetById(id);
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
			var entity = this.Context.Set<User>().Local.FirstOrDefault(x => x.Id == item.Id);
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
			int id)
		{
			User record = await this.GetById(id);

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

		// Foreign key reference to this table Badge via userId.
		public async virtual Task<List<Badge>> BadgesByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Badge>()
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Badge>();
		}

		// Foreign key reference to this table Comment via userId.
		public async virtual Task<List<Comment>> CommentsByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Comment>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Comment>();
		}

		// Foreign key reference to this table Post via lastEditorUserId.
		public async virtual Task<List<Post>> PostsByLastEditorUserId(int lastEditorUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Post>()
			       .Include(x => x.LastEditorUserIdNavigation)
			       .Include(x => x.OwnerUserIdNavigation)
			       .Include(x => x.ParentIdNavigation)
			       .Include(x => x.PostTypeIdNavigation)

			       .Where(x => x.LastEditorUserId == lastEditorUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Post>();
		}

		// Foreign key reference to this table Post via ownerUserId.
		public async virtual Task<List<Post>> PostsByOwnerUserId(int ownerUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Post>()
			       .Include(x => x.LastEditorUserIdNavigation)
			       .Include(x => x.OwnerUserIdNavigation)
			       .Include(x => x.ParentIdNavigation)
			       .Include(x => x.PostTypeIdNavigation)

			       .Where(x => x.OwnerUserId == ownerUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Post>();
		}

		// Foreign key reference to this table Vote via userId.
		public async virtual Task<List<Vote>> VotesByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Vote>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)
			       .Include(x => x.VoteTypeIdNavigation)

			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Vote>();
		}

		// Foreign key reference to this table PostHistory via userId.
		public async virtual Task<List<PostHistory>> PostHistoriesByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostHistory>()
			       .Include(x => x.PostHistoryTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostHistory>();
		}

		protected async Task<List<User>> Where(
			Expression<Func<User, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<User, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<User>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<User>();
		}

		private async Task<User> GetById(int id)
		{
			List<User> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f1054f930afb9c206e03904bee5c71a0</Hash>
</Codenesium>*/