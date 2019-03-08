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
	public abstract class AbstractCommentsRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCommentsRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Comments>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.CreationDate == query.ToDateTime() ||
				                  x.Id == query.ToInt() ||
				                  x.PostId == query.ToInt() ||
				                  x.Score == query.ToNullableInt() ||
				                  x.Text.StartsWith(query) ||
				                  x.UserId == query.ToNullableInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Comments> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Comments> Create(Comments item)
		{
			this.Context.Set<Comments>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Comments item)
		{
			var entity = this.Context.Set<Comments>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Comments>().Attach(item);
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
			Comments record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Comments>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Comments_PostId.
		public async virtual Task<List<Comments>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.PostId == postId, limit, offset);
		}

		// Non-unique constraint IX_Comments_UserId.
		public async virtual Task<List<Comments>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserId == userId, limit, offset);
		}

		// Foreign key reference to table Posts via postId.
		public async virtual Task<Posts> PostsByPostId(int postId)
		{
			return await this.Context.Set<Posts>()
			       .SingleOrDefaultAsync(x => x.Id == postId);
		}

		// Foreign key reference to table Users via userId.
		public async virtual Task<Users> UsersByUserId(int? userId)
		{
			return await this.Context.Set<Users>()
			       .SingleOrDefaultAsync(x => x.Id == userId);
		}

		protected async Task<List<Comments>> Where(
			Expression<Func<Comments, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Comments, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Comments>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Comments>();
		}

		private async Task<Comments> GetById(int id)
		{
			List<Comments> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>051d892b572cf9ae1e03994bf2ab2191</Hash>
</Codenesium>*/