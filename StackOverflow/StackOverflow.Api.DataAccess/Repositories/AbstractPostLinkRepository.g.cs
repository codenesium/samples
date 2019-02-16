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
				                  x.Id == query.ToInt() ||
				                  x.LinkTypeId == query.ToInt() ||
				                  x.PostId == query.ToInt() ||
				                  x.RelatedPostId == query.ToInt(),
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
    <Hash>a74131c4b0fc477bd43e650422538d98</Hash>
</Codenesium>*/