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
	public abstract class AbstractPostRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPostRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Post>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.AcceptedAnswerId == query.ToNullableInt() ||
				                  x.AnswerCount == query.ToNullableInt() ||
				                  x.Body.StartsWith(query) ||
				                  x.ClosedDate == query.ToNullableDateTime() ||
				                  x.CommentCount == query.ToNullableInt() ||
				                  x.CommunityOwnedDate == query.ToNullableDateTime() ||
				                  x.CreationDate == query.ToDateTime() ||
				                  x.FavoriteCount == query.ToNullableInt() ||
				                  x.Id == query.ToInt() ||
				                  x.LastActivityDate == query.ToDateTime() ||
				                  x.LastEditDate == query.ToNullableDateTime() ||
				                  x.LastEditorDisplayName.StartsWith(query) ||
				                  x.LastEditorUserId == query.ToNullableInt() ||
				                  x.OwnerUserId == query.ToNullableInt() ||
				                  x.ParentId == query.ToNullableInt() ||
				                  x.PostTypeId == query.ToInt() ||
				                  x.Score == query.ToInt() ||
				                  x.Tag.StartsWith(query) ||
				                  x.Title.StartsWith(query) ||
				                  x.ViewCount == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Post> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Post> Create(Post item)
		{
			this.Context.Set<Post>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Post item)
		{
			var entity = this.Context.Set<Post>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Post>().Attach(item);
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
			Post record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Post>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint NonClusteredIndex-20180824-123547.
		public async virtual Task<List<Post>> ByOwnerUserId(int? ownerUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.OwnerUserId == ownerUserId, limit, offset);
		}

		protected async Task<List<Post>> Where(
			Expression<Func<Post, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Post, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Post>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Post>();
		}

		private async Task<Post> GetById(int id)
		{
			List<Post> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4c41f52a488438094ae5dc9e63cac551</Hash>
</Codenesium>*/