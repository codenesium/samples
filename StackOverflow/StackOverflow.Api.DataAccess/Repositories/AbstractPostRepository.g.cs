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

		// Non-unique constraint IX_Posts_LastEditorUserId.
		public async virtual Task<List<Post>> ByLastEditorUserId(int? lastEditorUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.LastEditorUserId == lastEditorUserId, limit, offset);
		}

		// Non-unique constraint IX_Posts_PostTypeId.
		public async virtual Task<List<Post>> ByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.PostTypeId == postTypeId, limit, offset);
		}

		// Non-unique constraint IX_Posts_ParentId.
		public async virtual Task<List<Post>> ByParentId(int? parentId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ParentId == parentId, limit, offset);
		}

		// Foreign key reference to this table Comment via postId.
		public async virtual Task<List<Comment>> CommentsByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Comment>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.PostId == postId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Comment>();
		}

		// Foreign key reference to this table Post via parentId.
		public async virtual Task<List<Post>> PostsByParentId(int parentId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Post>()
			       .Include(x => x.LastEditorUserIdNavigation)
			       .Include(x => x.OwnerUserIdNavigation)
			       .Include(x => x.ParentIdNavigation)
			       .Include(x => x.PostTypeIdNavigation)

			       .Where(x => x.ParentId == parentId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Post>();
		}

		// Foreign key reference to this table Tag via excerptPostId.
		public async virtual Task<List<Tag>> TagsByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Tag>()
			       .Include(x => x.ExcerptPostIdNavigation)
			       .Include(x => x.WikiPostIdNavigation)

			       .Where(x => x.ExcerptPostId == excerptPostId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Tag>();
		}

		// Foreign key reference to this table Tag via wikiPostId.
		public async virtual Task<List<Tag>> TagsByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Tag>()
			       .Include(x => x.ExcerptPostIdNavigation)
			       .Include(x => x.WikiPostIdNavigation)

			       .Where(x => x.WikiPostId == wikiPostId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Tag>();
		}

		// Foreign key reference to this table Vote via postId.
		public async virtual Task<List<Vote>> VotesByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Vote>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)
			       .Include(x => x.VoteTypeIdNavigation)

			       .Where(x => x.PostId == postId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Vote>();
		}

		// Foreign key reference to this table PostHistory via postId.
		public async virtual Task<List<PostHistory>> PostHistoriesByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostHistory>()
			       .Include(x => x.PostHistoryTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.PostId == postId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostHistory>();
		}

		// Foreign key reference to this table PostLink via postId.
		public async virtual Task<List<PostLink>> PostLinksByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostLink>()
			       .Include(x => x.LinkTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.RelatedPostIdNavigation)

			       .Where(x => x.PostId == postId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostLink>();
		}

		// Foreign key reference to this table PostLink via relatedPostId.
		public async virtual Task<List<PostLink>> PostLinksByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostLink>()
			       .Include(x => x.LinkTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.RelatedPostIdNavigation)

			       .Where(x => x.RelatedPostId == relatedPostId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostLink>();
		}

		// Foreign key reference to table User via lastEditorUserId.
		public async virtual Task<User> UserByLastEditorUserId(int? lastEditorUserId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.Id == lastEditorUserId);
		}

		// Foreign key reference to table User via ownerUserId.
		public async virtual Task<User> UserByOwnerUserId(int? ownerUserId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.Id == ownerUserId);
		}

		// Foreign key reference to table Post via parentId.
		public async virtual Task<Post> PostByParentId(int? parentId)
		{
			return await this.Context.Set<Post>()
			       .SingleOrDefaultAsync(x => x.Id == parentId);
		}

		// Foreign key reference to table PostType via postTypeId.
		public async virtual Task<PostType> PostTypeByPostTypeId(int postTypeId)
		{
			return await this.Context.Set<PostType>()
			       .SingleOrDefaultAsync(x => x.Id == postTypeId);
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
			       .Include(x => x.LastEditorUserIdNavigation)
			       .Include(x => x.OwnerUserIdNavigation)
			       .Include(x => x.ParentIdNavigation)
			       .Include(x => x.PostTypeIdNavigation)

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
    <Hash>afc0e19bd2748e368705e6a9cf5b8d40</Hash>
</Codenesium>*/