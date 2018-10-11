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

		public async Task<Team> ByName(string name)
		{
			return await this.Context.Set<Team>().SingleOrDefaultAsync(x => x.Name == name);
		}

		public async virtual Task<List<Chain>> Chains(int teamId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Chain>().Where(x => x.TeamId == teamId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Chain>();
		}

		public async virtual Task<Organization> OrganizationByOrganizationId(int organizationId)
		{
			return await this.Context.Set<Organization>().SingleOrDefaultAsync(x => x.Id == organizationId);
		}

		public async virtual Task<List<Team>> ByMachineId(int machineId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.MachineRefTeams
			              join teams in this.Context.Teams on
			              refTable.TeamId equals teams.Id
			              where refTable.MachineId == machineId
			              select teams).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<Team>> Where(
			Expression<Func<Team, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Team, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Team>();
			}
			else
			{
				return await this.Context.Set<Team>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Team>();
			}
		}

		private async Task<Team> GetById(int id)
		{
			List<Team> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>21ebe6766f966774b004b4955e228a4d</Hash>
</Codenesium>*/