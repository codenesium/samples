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
	public abstract class AbstractPostTypeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPostTypeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PostType>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.RwType.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<PostType> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PostType> Create(PostType item)
		{
			this.Context.Set<PostType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PostType item)
		{
			var entity = this.Context.Set<PostType>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PostType>().Attach(item);
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
			PostType record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PostType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Post via postTypeId.
		public async virtual Task<List<Post>> PostsByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Post>()
			       .Include(x => x.LastEditorUserIdNavigation)
			       .Include(x => x.OwnerUserIdNavigation)
			       .Include(x => x.ParentIdNavigation)
			       .Include(x => x.PostTypeIdNavigation)

			       .Where(x => x.PostTypeId == postTypeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Post>();
		}

		protected async Task<List<PostType>> Where(
			Expression<Func<PostType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PostType, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PostType>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PostType>();
		}

		private async Task<PostType> GetById(int id)
		{
			List<PostType> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3579c20975e987050562b9438b1f8378</Hash>
</Codenesium>*/