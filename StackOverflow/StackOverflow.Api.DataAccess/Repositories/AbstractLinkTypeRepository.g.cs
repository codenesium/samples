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
	public abstract class AbstractLinkTypeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLinkTypeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<LinkType>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<LinkType> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<LinkType> Create(LinkType item)
		{
			this.Context.Set<LinkType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(LinkType item)
		{
			var entity = this.Context.Set<LinkType>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<LinkType>().Attach(item);
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
			LinkType record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LinkType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table PostLink via linkTypeId.
		public async virtual Task<List<PostLink>> PostLinksByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PostLink>()
			       .Include(x => x.LinkTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.RelatedPostIdNavigation)

			       .Where(x => x.LinkTypeId == linkTypeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PostLink>();
		}

		protected async Task<List<LinkType>> Where(
			Expression<Func<LinkType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<LinkType, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<LinkType>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<LinkType>();
		}

		private async Task<LinkType> GetById(int id)
		{
			List<LinkType> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>831a5e0e5949be828f870634f1d82fc9</Hash>
</Codenesium>*/