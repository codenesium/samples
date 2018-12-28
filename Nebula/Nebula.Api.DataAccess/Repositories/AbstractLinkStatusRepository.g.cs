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
	public abstract class AbstractLinkStatusRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLinkStatusRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<LinkStatus>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<LinkStatus> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<LinkStatus> Create(LinkStatus item)
		{
			this.Context.Set<LinkStatus>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(LinkStatus item)
		{
			var entity = this.Context.Set<LinkStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<LinkStatus>().Attach(item);
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
			LinkStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LinkStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AX_LinkStatus_Name.
		public async virtual Task<LinkStatus> ByName(string name)
		{
			return await this.Context.Set<LinkStatus>().FirstOrDefaultAsync(x => x.Name == name);
		}

		// Foreign key reference to this table Link via linkStatusId.
		public async virtual Task<List<Link>> LinksByLinkStatusId(int linkStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Link>().Where(x => x.LinkStatusId == linkStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Link>();
		}

		protected async Task<List<LinkStatus>> Where(
			Expression<Func<LinkStatus, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<LinkStatus, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<LinkStatus>();
		}

		private async Task<LinkStatus> GetById(int id)
		{
			List<LinkStatus> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>28eac1d9dcfcab807bfc7a0e9af153f9</Hash>
</Codenesium>*/