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
	public abstract class AbstractTagRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTagRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Tag>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Count == query.ToInt() ||
				                  x.ExcerptPostId == query.ToInt() ||
				                  x.Id == query.ToInt() ||
				                  x.TagName.StartsWith(query) ||
				                  x.WikiPostId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Tag> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Tag> Create(Tag item)
		{
			this.Context.Set<Tag>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Tag item)
		{
			var entity = this.Context.Set<Tag>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Tag>().Attach(item);
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
			Tag record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Tag>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Tags_ExcerptPostId.
		public async virtual Task<List<Tag>> ByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ExcerptPostId == excerptPostId, limit, offset);
		}

		// Non-unique constraint IX_Tags_WikiPostId.
		public async virtual Task<List<Tag>> ByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.WikiPostId == wikiPostId, limit, offset);
		}

		// Foreign key reference to table Post via excerptPostId.
		public async virtual Task<Post> PostByExcerptPostId(int excerptPostId)
		{
			return await this.Context.Set<Post>()
			       .SingleOrDefaultAsync(x => x.Id == excerptPostId);
		}

		// Foreign key reference to table Post via wikiPostId.
		public async virtual Task<Post> PostByWikiPostId(int wikiPostId)
		{
			return await this.Context.Set<Post>()
			       .SingleOrDefaultAsync(x => x.Id == wikiPostId);
		}

		protected async Task<List<Tag>> Where(
			Expression<Func<Tag, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Tag, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Tag>()
			       .Include(x => x.ExcerptPostIdNavigation)
			       .Include(x => x.WikiPostIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Tag>();
		}

		private async Task<Tag> GetById(int id)
		{
			List<Tag> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>dd4aed5c2c86e1888a3e79a06ab87c69</Hash>
</Codenesium>*/