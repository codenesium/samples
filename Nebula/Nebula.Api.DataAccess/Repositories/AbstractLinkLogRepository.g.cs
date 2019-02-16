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

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractLinkLogRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLinkLogRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<LinkLog>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.DateEntered == query.ToDateTime() ||
				                  x.Id == query.ToInt() ||
				                  x.LinkId == query.ToInt() ||
				                  x.Log.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<LinkLog> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<LinkLog> Create(LinkLog item)
		{
			this.Context.Set<LinkLog>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(LinkLog item)
		{
			var entity = this.Context.Set<LinkLog>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<LinkLog>().Attach(item);
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
			LinkLog record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LinkLog>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Link via linkId.
		public async virtual Task<Link> LinkByLinkId(int linkId)
		{
			return await this.Context.Set<Link>()
			       .SingleOrDefaultAsync(x => x.Id == linkId);
		}

		protected async Task<List<LinkLog>> Where(
			Expression<Func<LinkLog, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<LinkLog, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<LinkLog>()
			       .Include(x => x.LinkIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<LinkLog>();
		}

		private async Task<LinkLog> GetById(int id)
		{
			List<LinkLog> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2c1b7f7e4423088889281e6de88a30f5</Hash>
</Codenesium>*/