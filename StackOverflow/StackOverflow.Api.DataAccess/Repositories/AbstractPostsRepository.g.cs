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
	public abstract class AbstractPostsRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPostsRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Posts>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<Posts> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Posts> Create(Posts item)
		{
			this.Context.Set<Posts>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Posts item)
		{
			var entity = this.Context.Set<Posts>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Posts>().Attach(item);
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
			Posts record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Posts>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint NonClusteredIndex-20180824-123547.
		public async virtual Task<List<Posts>> ByOwnerUserId(int? ownerUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.OwnerUserId == ownerUserId, limit, offset);
		}

		// Non-unique constraint IX_Posts_LastEditorUserId.
		public async virtual Task<List<Posts>> ByLastEditorUserId(int? lastEditorUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.LastEditorUserId == lastEditorUserId, limit, offset);
		}

		// Non-unique constraint IX_Posts_PostTypeId.
		public async virtual Task<List<Posts>> ByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.PostTypeId == postTypeId, limit, offset);
		}

		// Non-unique constraint IX_Posts_ParentId.
		public async virtual Task<List<Posts>> ByParentId(int? parentId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ParentId == parentId, limit, offset);
		}

		// Foreign key reference to this table Comments via postId.
		public async virtual Task<List<Comments>> CommentsByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Comments>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.PostId == postId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Comments>();
		}

		// Foreign key reference to this table Posts via parentId.
		public async virtual Task<List<Posts>> PostsByParentId(int parentId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Posts>()
			       .Include(x => x.LastEditorUserIdNavigation)
			       .Include(x => x.OwnerUserIdNavigation)
			       .Include(x => x.ParentIdNavigation)
			       .Include(x => x.PostTypeIdNavigation)

			       .Where(x => x.ParentId == parentId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Posts>();
		}

		// Foreign key reference to this table Tags via excerptPostId.
		public async virtual Task<List<Tags>> TagsByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Tags>()
			       .Include(x => x.ExcerptPostIdNavigation)
			       .Include(x => x.WikiPostIdNavigation)

			       .Where(x => x.ExcerptPostId == excerptPostId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Tags>();
		}

		// Foreign key reference to this table Tags via wikiPostId.
		public async virtual Task<List<Tags>> TagsByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Tags>()
			       .Include(x => x.ExcerptPostIdNavigation)
			       .Include(x => x.WikiPostIdNavigation)

			       .Where(x => x.WikiPostId == wikiPostId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Tags>();
		}

		// Foreign key reference to this table Votes via postId.
		public async virtual Task<List<Votes>> VotesByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Votes>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)
			       .Include(x => x.VoteTypeIdNavigation)

			       .Where(x => x.PostId == postId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Votes>();
		}

		// Foreign key reference to this table PostHistory via postId.
		public async virtual Task<List<PostHistory>> PostHistoryByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostHistory>()
			       .Include(x => x.PostHistoryTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.PostId == postId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostHistory>();
		}

		// Foreign key reference to this table PostLinks via postId.
		public async virtual Task<List<PostLinks>> PostLinksByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostLinks>()
			       .Include(x => x.LinkTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.RelatedPostIdNavigation)

			       .Where(x => x.PostId == postId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostLinks>();
		}

		// Foreign key reference to this table PostLinks via relatedPostId.
		public async virtual Task<List<PostLinks>> PostLinksByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostLinks>()
			       .Include(x => x.LinkTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.RelatedPostIdNavigation)

			       .Where(x => x.RelatedPostId == relatedPostId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostLinks>();
		}

		// Foreign key reference to table Users via lastEditorUserId.
		public async virtual Task<Users> UsersByLastEditorUserId(int? lastEditorUserId)
		{
			return await this.Context.Set<Users>()
			       .SingleOrDefaultAsync(x => x.Id == lastEditorUserId);
		}

		// Foreign key reference to table Users via ownerUserId.
		public async virtual Task<Users> UsersByOwnerUserId(int? ownerUserId)
		{
			return await this.Context.Set<Users>()
			       .SingleOrDefaultAsync(x => x.Id == ownerUserId);
		}

		// Foreign key reference to table Posts via parentId.
		public async virtual Task<Posts> PostsByParentId(int? parentId)
		{
			return await this.Context.Set<Posts>()
			       .SingleOrDefaultAsync(x => x.Id == parentId);
		}

		// Foreign key reference to table PostTypes via postTypeId.
		public async virtual Task<PostTypes> PostTypesByPostTypeId(int postTypeId)
		{
			return await this.Context.Set<PostTypes>()
			       .SingleOrDefaultAsync(x => x.Id == postTypeId);
		}

		protected async Task<List<Posts>> Where(
			Expression<Func<Posts, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Posts, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Posts>()
			       .Include(x => x.LastEditorUserIdNavigation)
			       .Include(x => x.OwnerUserIdNavigation)
			       .Include(x => x.ParentIdNavigation)
			       .Include(x => x.PostTypeIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Posts>();
		}

		private async Task<Posts> GetById(int id)
		{
			List<Posts> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0c2fb20154bbb40a9e33a07e83f2fbf9</Hash>
</Codenesium>*/