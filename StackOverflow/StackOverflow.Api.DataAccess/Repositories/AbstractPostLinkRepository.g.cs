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
	public abstract class AbstractPostLinkRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPostLinkRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PostLink>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.CreationDate == query.ToDateTime() ||
				                  (x.LinkTypeIdNavigation == null || x.LinkTypeIdNavigation.RwType == null?false : x.LinkTypeIdNavigation.RwType.StartsWith(query)) ||
				                  (x.PostIdNavigation == null || x.PostIdNavigation.Id == null?false : x.PostIdNavigation.Id == query.ToInt()) ||
				                  (x.RelatedPostIdNavigation == null || x.RelatedPostIdNavigation.Id == null?false : x.RelatedPostIdNavigation.Id == query.ToInt()),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<PostLink> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PostLink> Create(PostLink item)
		{
			this.Context.Set<PostLink>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PostLink item)
		{
			var entity = this.Context.Set<PostLink>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PostLink>().Attach(item);
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
			PostLink record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PostLink>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_PostLinks_LinkTypeId.
		public async virtual Task<List<PostLink>> ByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.LinkTypeId == linkTypeId, limit, offset);
		}

		// Non-unique constraint IX_PostLinks_PostId.
		public async virtual Task<List<PostLink>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.PostId == postId, limit, offset);
		}

		// Non-unique constraint IX_PostLinks_RelatedPostId.
		public async virtual Task<List<PostLink>> ByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.RelatedPostId == relatedPostId, limit, offset);
		}

		// Foreign key reference to table LinkType via linkTypeId.
		public async virtual Task<LinkType> LinkTypeByLinkTypeId(int linkTypeId)
		{
			return await this.Context.Set<LinkType>()
			       .SingleOrDefaultAsync(x => x.Id == linkTypeId);
		}

		// Foreign key reference to table Post via postId.
		public async virtual Task<Post> PostByPostId(int postId)
		{
			return await this.Context.Set<Post>()
			       .SingleOrDefaultAsync(x => x.Id == postId);
		}

		// Foreign key reference to table Post via relatedPostId.
		public async virtual Task<Post> PostByRelatedPostId(int relatedPostId)
		{
			return await this.Context.Set<Post>()
			       .SingleOrDefaultAsync(x => x.Id == relatedPostId);
		}

		protected async Task<List<PostLink>> Where(
			Expression<Func<PostLink, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PostLink, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PostLink>()
			       .Include(x => x.LinkTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.RelatedPostIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PostLink>();
		}

		private async Task<PostLink> GetById(int id)
		{
			List<PostLink> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6b2e7aa1ab39fd434dc848c2b3ae9e27</Hash>
</Codenesium>*/