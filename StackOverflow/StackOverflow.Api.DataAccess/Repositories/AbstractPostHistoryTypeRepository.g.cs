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
	public abstract class AbstractPostHistoryTypeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPostHistoryTypeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PostHistoryType>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<PostHistoryType> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PostHistoryType> Create(PostHistoryType item)
		{
			this.Context.Set<PostHistoryType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PostHistoryType item)
		{
			var entity = this.Context.Set<PostHistoryType>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PostHistoryType>().Attach(item);
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
			PostHistoryType record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PostHistoryType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<PostHistoryType>> Where(
			Expression<Func<PostHistoryType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PostHistoryType, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<PostHistoryType>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PostHistoryType>();
			}
			else
			{
				return await this.Context.Set<PostHistoryType>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<PostHistoryType>();
			}
		}

		private async Task<PostHistoryType> GetById(int id)
		{
			List<PostHistoryType> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>bde502c3334e8a1963f3f78eac60ef54</Hash>
</Codenesium>*/