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

namespace CADNS.Api.DataAccess
{
	public abstract class AbstractOfficerCapabilitiesRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractOfficerCapabilitiesRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<OfficerCapabilities>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.CapabilityId == query.ToInt() ||
				                  x.OfficerId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<OfficerCapabilities> Get(int capabilityId)
		{
			return await this.GetById(capabilityId);
		}

		public async virtual Task<OfficerCapabilities> Create(OfficerCapabilities item)
		{
			this.Context.Set<OfficerCapabilities>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(OfficerCapabilities item)
		{
			var entity = this.Context.Set<OfficerCapabilities>().Local.FirstOrDefault(x => x.CapabilityId == item.CapabilityId);
			if (entity == null)
			{
				this.Context.Set<OfficerCapabilities>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int capabilityId)
		{
			OfficerCapabilities record = await this.GetById(capabilityId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<OfficerCapabilities>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Officer via officerId.
		public async virtual Task<Officer> OfficerByOfficerId(int officerId)
		{
			return await this.Context.Set<Officer>()
			       .SingleOrDefaultAsync(x => x.Id == officerId);
		}

		protected async Task<List<OfficerCapabilities>> Where(
			Expression<Func<OfficerCapabilities, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<OfficerCapabilities, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.CapabilityId;
			}

			return await this.Context.Set<OfficerCapabilities>()
			       .Include(x => x.OfficerIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<OfficerCapabilities>();
		}

		private async Task<OfficerCapabilities> GetById(int capabilityId)
		{
			List<OfficerCapabilities> records = await this.Where(x => x.CapabilityId == capabilityId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>765b57cdd59ecbd06848d0120bf82c85</Hash>
</Codenesium>*/