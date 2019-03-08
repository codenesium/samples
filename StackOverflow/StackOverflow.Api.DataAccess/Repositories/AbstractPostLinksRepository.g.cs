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
	public abstract class AbstractPostLinksRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPostLinksRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PostLinks>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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
				                  x.LinkTypeId == query.ToInt() ||
				                  x.PostId == query.ToInt() ||
				                  x.RelatedPostId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<PostLinks> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PostLinks> Create(PostLinks item)
		{
			this.Context.Set<PostLinks>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PostLinks item)
		{
			var entity = this.Context.Set<PostLinks>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PostLinks>().Attach(item);
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
			PostLinks record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PostLinks>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_PostLinks_LinkTypeId.
		public async virtual Task<List<PostLinks>> ByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.LinkTypeId == linkTypeId, limit, offset);
		}

		// Non-unique constraint IX_PostLinks_PostId.
		public async virtual Task<List<PostLinks>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.PostId == postId, limit, offset);
		}

		// Non-unique constraint IX_PostLinks_RelatedPostId.
		public async virtual Task<List<PostLinks>> ByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.RelatedPostId == relatedPostId, limit, offset);
		}

		// Foreign key reference to table LinkTypes via linkTypeId.
		public async virtual Task<LinkTypes> LinkTypesByLinkTypeId(int linkTypeId)
		{
			return await this.Context.Set<LinkTypes>()
			       .SingleOrDefaultAsync(x => x.Id == linkTypeId);
		}

		// Foreign key reference to table Posts via postId.
		public async virtual Task<Posts> PostsByPostId(int postId)
		{
			return await this.Context.Set<Posts>()
			       .SingleOrDefaultAsync(x => x.Id == postId);
		}

		// Foreign key reference to table Posts via relatedPostId.
		public async virtual Task<Posts> PostsByRelatedPostId(int relatedPostId)
		{
			return await this.Context.Set<Posts>()
			       .SingleOrDefaultAsync(x => x.Id == relatedPostId);
		}

		protected async Task<List<PostLinks>> Where(
			Expression<Func<PostLinks, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PostLinks, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PostLinks>()
			       .Include(x => x.LinkTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.RelatedPostIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PostLinks>();
		}

		private async Task<PostLinks> GetById(int id)
		{
			List<PostLinks> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>250202cb355e6e5b186d6419e557a486</Hash>
</Codenesium>*/