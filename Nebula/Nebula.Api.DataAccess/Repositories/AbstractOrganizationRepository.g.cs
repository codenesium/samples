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
	public abstract class AbstractOrganizationRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractOrganizationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Organization>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Organization> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Organization> Create(Organization item)
		{
			this.Context.Set<Organization>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Organization item)
		{
			var entity = this.Context.Set<Organization>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Organization>().Attach(item);
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
			Organization record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Organization>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AX_organization_Name.
		public async virtual Task<Organization> ByName(string name)
		{
			return await this.Context.Set<Organization>()

			       .FirstOrDefaultAsync(x => x.Name == name);
		}

		// Foreign key reference to this table Team via organizationId.
		public async virtual Task<List<Team>> TeamsByOrganizationId(int organizationId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Team>()
			       .Include(x => x.OrganizationIdNavigation)

			       .Where(x => x.OrganizationId == organizationId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Team>();
		}

		protected async Task<List<Organization>> Where(
			Expression<Func<Organization, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Organization, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Organization>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Organization>();
		}

		private async Task<Organization> GetById(int id)
		{
			List<Organization> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>82da276c71bd1f6a540d2ebbd09a04a8</Hash>
</Codenesium>*/