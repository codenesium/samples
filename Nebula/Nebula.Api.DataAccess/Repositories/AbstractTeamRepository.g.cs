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

		public virtual Task<List<Team>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Name.StartsWith(query) ||
				                  (x.OrganizationIdNavigation == null || x.OrganizationIdNavigation.Name == null?false : x.OrganizationIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
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
			return await this.Context.Set<Team>()
			       .Include(x => x.OrganizationIdNavigation)

			       .FirstOrDefaultAsync(x => x.Name == name);
		}

		// Foreign key reference to this table Chain via teamId.
		public async virtual Task<List<Chain>> ChainsByTeamId(int teamId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Chain>()
			       .Include(x => x.ChainStatusIdNavigation)
			       .Include(x => x.TeamIdNavigation)

			       .Where(x => x.TeamId == teamId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Chain>();
		}

		// Foreign key reference to table Organization via organizationId.
		public async virtual Task<Organization> OrganizationByOrganizationId(int organizationId)
		{
			return await this.Context.Set<Organization>()
			       .SingleOrDefaultAsync(x => x.Id == organizationId);
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

			return await this.Context.Set<Team>()
			       .Include(x => x.OrganizationIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Team>();
		}

		private async Task<Team> GetById(int id)
		{
			List<Team> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8052068e63a743a421887e6d4d912b4e</Hash>
</Codenesium>*/