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
	public abstract class AbstractOfficerCapabilityRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractOfficerCapabilityRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<OfficerCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<OfficerCapability> Get(int capabilityId)
		{
			return await this.GetById(capabilityId);
		}

		public async virtual Task<OfficerCapability> Create(OfficerCapability item)
		{
			this.Context.Set<OfficerCapability>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(OfficerCapability item)
		{
			var entity = this.Context.Set<OfficerCapability>().Local.FirstOrDefault(x => x.CapabilityId == item.CapabilityId);
			if (entity == null)
			{
				this.Context.Set<OfficerCapability>().Attach(item);
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
			OfficerCapability record = await this.GetById(capabilityId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<OfficerCapability>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table OfficerCapability via capabilityId.
		public async virtual Task<OfficerCapability> OfficerCapabilityByCapabilityId(int capabilityId)
		{
			return await this.Context.Set<OfficerCapability>()
			       .SingleOrDefaultAsync(x => x.CapabilityId == capabilityId);
		}

		// Foreign key reference to table Officer via officerId.
		public async virtual Task<Officer> OfficerByOfficerId(int officerId)
		{
			return await this.Context.Set<Officer>()
			       .SingleOrDefaultAsync(x => x.Id == officerId);
		}

		// Foreign key reference pass-though. Pass-thru table OfficerCapability. Foreign Table OfficerCapability.
		public async virtual Task<List<OfficerCapability>> ByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.OfficerCapabilities
			              join officerCapabilities in this.Context.OfficerCapabilities on
			              refTable.CapabilityId equals officerCapabilities.Id
			              where refTable.OfficerId == officerId
			              select officerCapabilities).Skip(offset).Take(limit).ToListAsync();
		}

		// Foreign key reference pass-though. Pass-thru table OfficerCapability. Foreign Table OfficerCapability.
		public async virtual Task<OfficerCapability> CreateOfficerCapability(OfficerCapability item)
		{
			this.Context.Set<OfficerCapability>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		// Foreign key reference pass-though. Pass-thru table OfficerCapability. Foreign Table OfficerCapability.
		public async virtual Task DeleteOfficerCapability(OfficerCapability item)
		{
			this.Context.Set<OfficerCapability>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		protected async Task<List<OfficerCapability>> Where(
			Expression<Func<OfficerCapability, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<OfficerCapability, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.CapabilityId;
			}

			return await this.Context.Set<OfficerCapability>()
			       .Include(x => x.CapabilityIdNavigation)
			       .Include(x => x.OfficerIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<OfficerCapability>();
		}

		private async Task<OfficerCapability> GetById(int capabilityId)
		{
			List<OfficerCapability> records = await this.Where(x => x.CapabilityId == capabilityId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>df624863538819f198e8900aa351b401</Hash>
</Codenesium>*/