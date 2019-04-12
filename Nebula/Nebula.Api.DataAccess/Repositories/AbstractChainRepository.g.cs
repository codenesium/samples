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
	public abstract class AbstractChainRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractChainRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Chain>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.ChainStatusIdNavigation == null || x.ChainStatusIdNavigation.Name == null?false : x.ChainStatusIdNavigation.Name.StartsWith(query)) ||
				                  x.ExternalId == query.ToGuid() ||
				                  x.Name.StartsWith(query) ||
				                  (x.TeamIdNavigation == null || x.TeamIdNavigation.Name == null?false : x.TeamIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Chain> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Chain> Create(Chain item)
		{
			this.Context.Set<Chain>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Chain item)
		{
			var entity = this.Context.Set<Chain>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Chain>().Attach(item);
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
			Chain record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Chain>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AX_Chain_ExternalId.
		public async virtual Task<Chain> ByExternalId(Guid externalId)
		{
			return await this.Context.Set<Chain>()
			       .Include(x => x.ChainStatusIdNavigation)
			       .Include(x => x.TeamIdNavigation)

			       .FirstOrDefaultAsync(x => x.ExternalId == externalId);
		}

		// Foreign key reference to this table Clasp via nextChainId.
		public async virtual Task<List<Clasp>> ClaspsByNextChainId(int nextChainId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Clasp>()
			       .Include(x => x.NextChainIdNavigation)
			       .Include(x => x.PreviousChainIdNavigation)

			       .Where(x => x.NextChainId == nextChainId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Clasp>();
		}

		// Foreign key reference to this table Clasp via previousChainId.
		public async virtual Task<List<Clasp>> ClaspsByPreviousChainId(int previousChainId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Clasp>()
			       .Include(x => x.NextChainIdNavigation)
			       .Include(x => x.PreviousChainIdNavigation)

			       .Where(x => x.PreviousChainId == previousChainId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Clasp>();
		}

		// Foreign key reference to this table Link via chainId.
		public async virtual Task<List<Link>> LinksByChainId(int chainId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Link>()
			       .Include(x => x.AssignedMachineIdNavigation)
			       .Include(x => x.ChainIdNavigation)
			       .Include(x => x.LinkStatusIdNavigation)

			       .Where(x => x.ChainId == chainId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Link>();
		}

		// Foreign key reference to table ChainStatus via chainStatusId.
		public async virtual Task<ChainStatus> ChainStatusByChainStatusId(int chainStatusId)
		{
			return await this.Context.Set<ChainStatus>()
			       .SingleOrDefaultAsync(x => x.Id == chainStatusId);
		}

		// Foreign key reference to table Team via teamId.
		public async virtual Task<Team> TeamByTeamId(int teamId)
		{
			return await this.Context.Set<Team>()
			       .SingleOrDefaultAsync(x => x.Id == teamId);
		}

		protected async Task<List<Chain>> Where(
			Expression<Func<Chain, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Chain, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Chain>()
			       .Include(x => x.ChainStatusIdNavigation)
			       .Include(x => x.TeamIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Chain>();
		}

		private async Task<Chain> GetById(int id)
		{
			List<Chain> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>613d797ad6acb208956a3bd98fdf27c8</Hash>
</Codenesium>*/