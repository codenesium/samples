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
	public abstract class AbstractLinkRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLinkRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Link>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Link> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Link> Create(Link item)
		{
			this.Context.Set<Link>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Link item)
		{
			var entity = this.Context.Set<Link>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Link>().Attach(item);
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
			Link record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Link>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<Link> ByExternalId(Guid externalId)
		{
			var records = await this.Where(x => x.ExternalId == externalId);

			return records.FirstOrDefault();
		}

		public async Task<List<Link>> ByChainId(int chainId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.ChainId == chainId, limit, offset);

			return records;
		}

		public async virtual Task<List<LinkLog>> LinkLogs(int linkId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<LinkLog>().Where(x => x.LinkId == linkId).AsQueryable().Skip(offset).Take(limit).ToListAsync<LinkLog>();
		}

		public async virtual Task<Machine> GetMachine(int? assignedMachineId)
		{
			return await this.Context.Set<Machine>().SingleOrDefaultAsync(x => x.Id == assignedMachineId);
		}

		public async virtual Task<Chain> GetChain(int chainId)
		{
			return await this.Context.Set<Chain>().SingleOrDefaultAsync(x => x.Id == chainId);
		}

		public async virtual Task<LinkStatu> GetLinkStatu(int linkStatusId)
		{
			return await this.Context.Set<LinkStatu>().SingleOrDefaultAsync(x => x.Id == linkStatusId);
		}

		protected async Task<List<Link>> Where(
			Expression<Func<Link, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Link, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Link>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Link>();
			}
			else
			{
				return await this.Context.Set<Link>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Link>();
			}
		}

		private async Task<Link> GetById(int id)
		{
			List<Link> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e3e8019f2730f2b9bf1be126533ce30f</Hash>
</Codenesium>*/