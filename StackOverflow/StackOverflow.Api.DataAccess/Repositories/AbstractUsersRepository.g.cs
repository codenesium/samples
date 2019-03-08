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
	public abstract class AbstractUsersRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractUsersRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Users>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<Users> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Users> Create(Users item)
		{
			this.Context.Set<Users>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Users item)
		{
			var entity = this.Context.Set<Users>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Users>().Attach(item);
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
			Users record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Users>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Badges via userId.
		public async virtual Task<List<Badges>> BadgesByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Badges>()
			       .Include(x => x.UserIdNavigation)
			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Badges>();
		}

		// Foreign key reference to this table Comments via userId.
		public async virtual Task<List<Comments>> CommentsByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Comments>()
			       .Include(x => x.UserIdNavigation)
			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Comments>();
		}

		// Foreign key reference to this table Posts via lastEditorUserId.
		public async virtual Task<List<Posts>> PostsByLastEditorUserId(int lastEditorUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Posts>()
			       .Include(x => x.LastEditorUserIdNavigation)
			       .Where(x => x.LastEditorUserId == lastEditorUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Posts>();
		}

		// Foreign key reference to this table Posts via ownerUserId.
		public async virtual Task<List<Posts>> PostsByOwnerUserId(int ownerUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Posts>()
			       .Include(x => x.OwnerUserIdNavigation)
			       .Where(x => x.OwnerUserId == ownerUserId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Posts>();
		}

		// Foreign key reference to this table Votes via userId.
		public async virtual Task<List<Votes>> VotesByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Votes>()
			       .Include(x => x.UserIdNavigation)
			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Votes>();
		}

		// Foreign key reference to this table PostHistory via userId.
		public async virtual Task<List<PostHistory>> PostHistoryByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostHistory>()
			       .Include(x => x.UserIdNavigation)
			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostHistory>();
		}

		protected async Task<List<Users>> Where(
			Expression<Func<Users, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Users, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Users>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Users>();
		}

		private async Task<Users> GetById(int id)
		{
			List<Users> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a2368d0d9dd273e3693e6a656ba972e9</Hash>
</Codenesium>*/