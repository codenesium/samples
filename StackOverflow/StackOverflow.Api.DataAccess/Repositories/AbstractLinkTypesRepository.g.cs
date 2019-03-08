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
	public abstract class AbstractLinkTypesRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLinkTypesRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<LinkTypes>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<LinkTypes> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<LinkTypes> Create(LinkTypes item)
		{
			this.Context.Set<LinkTypes>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(LinkTypes item)
		{
			var entity = this.Context.Set<LinkTypes>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<LinkTypes>().Attach(item);
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
			LinkTypes record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LinkTypes>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table PostLinks via linkTypeId.
		public async virtual Task<List<PostLinks>> PostLinksByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostLinks>()
			       .Include(x => x.LinkTypeIdNavigation)
			       .Where(x => x.LinkTypeId == linkTypeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostLinks>();
		}

		protected async Task<List<LinkTypes>> Where(
			Expression<Func<LinkTypes, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<LinkTypes, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<LinkTypes>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<LinkTypes>();
		}

		private async Task<LinkTypes> GetById(int id)
		{
			List<LinkTypes> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0261d6b2f1e8750f51daf231531f7a10</Hash>
</Codenesium>*/