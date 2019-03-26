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
	public abstract class AbstractPostHistoryTypesRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPostHistoryTypesRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PostHistoryTypes>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<PostHistoryTypes> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PostHistoryTypes> Create(PostHistoryTypes item)
		{
			this.Context.Set<PostHistoryTypes>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PostHistoryTypes item)
		{
			var entity = this.Context.Set<PostHistoryTypes>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PostHistoryTypes>().Attach(item);
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
			PostHistoryTypes record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PostHistoryTypes>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table PostHistory via postHistoryTypeId.
		public async virtual Task<List<PostHistory>> PostHistoryByPostHistoryTypeId(int postHistoryTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostHistory>()
			       .Include(x => x.PostHistoryTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.PostHistoryTypeId == postHistoryTypeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostHistory>();
		}

		protected async Task<List<PostHistoryTypes>> Where(
			Expression<Func<PostHistoryTypes, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PostHistoryTypes, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PostHistoryTypes>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PostHistoryTypes>();
		}

		private async Task<PostHistoryTypes> GetById(int id)
		{
			List<PostHistoryTypes> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3a7d071d7e569db719b4cd51105850ab</Hash>
</Codenesium>*/