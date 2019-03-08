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
	public abstract class AbstractTagsRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTagsRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Tags>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<Tags> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Tags> Create(Tags item)
		{
			this.Context.Set<Tags>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Tags item)
		{
			var entity = this.Context.Set<Tags>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Tags>().Attach(item);
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
			Tags record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Tags>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Tags_ExcerptPostId.
		public async virtual Task<List<Tags>> ByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ExcerptPostId == excerptPostId, limit, offset);
		}

		// Non-unique constraint IX_Tags_WikiPostId.
		public async virtual Task<List<Tags>> ByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.WikiPostId == wikiPostId, limit, offset);
		}

		// Foreign key reference to table Posts via excerptPostId.
		public async virtual Task<Posts> PostsByExcerptPostId(int excerptPostId)
		{
			return await this.Context.Set<Posts>()
			       .SingleOrDefaultAsync(x => x.Id == excerptPostId);
		}

		// Foreign key reference to table Posts via wikiPostId.
		public async virtual Task<Posts> PostsByWikiPostId(int wikiPostId)
		{
			return await this.Context.Set<Posts>()
			       .SingleOrDefaultAsync(x => x.Id == wikiPostId);
		}

		protected async Task<List<Tags>> Where(
			Expression<Func<Tags, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Tags, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Tags>()
			       .Include(x => x.ExcerptPostIdNavigation)
			       .Include(x => x.WikiPostIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Tags>();
		}

		private async Task<Tags> GetById(int id)
		{
			List<Tags> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e55d00f0e9b12b83981b606be28cf03a</Hash>
</Codenesium>*/