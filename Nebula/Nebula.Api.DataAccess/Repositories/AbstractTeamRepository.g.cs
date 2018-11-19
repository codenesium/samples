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
	public abstract class AbstractTeamRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTeamRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Team>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Team> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Team> Create(Team item)
		{
			this.Context.Set<Team>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Team item)
		{
			var entity = this.Context.Set<Team>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Team>().Attach(item);
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
			Team record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Team>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AX_Team_Name.
		public async virtual Task<Team> ByName(string name)
		{
			return await this.Context.Set<Team>().SingleOrDefaultAsync(x => x.Name == name);
		}

		// Foreign key reference to table Organization via organizationId.
		public async virtual Task<Organization> OrganizationByOrganizationId(int organizationId)
		{
			return await this.Context.Set<Organization>().SingleOrDefaultAsync(x => x.Id == organizationId);
		}

		// Foreign key reference pass-though. Pass-thru table Chain. Foreign Table Team.
		public async virtual Task<List<Team>> ByChainStatusId(int chainStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.Chains
			              join teams in this.Context.Teams on
			              refTable.TeamId equals teams.Id
			              where refTable.ChainStatusId == chainStatusId
			              select teams).Skip(offset).Take(limit).ToListAsync();
		}

		public async virtual Task<Chain> CreateChain(Chain item)
		{
			this.Context.Set<Chain>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task DeleteChain(Chain item)
		{
			this.Context.Set<Chain>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		protected async Task<List<Team>> Where(
			Expression<Func<Team, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Team, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Team>();
		}

		private async Task<Team> GetById(int id)
		{
			List<Team> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1c213e86dd252168009f37dc96f7ae1b</Hash>
</Codenesium>*/