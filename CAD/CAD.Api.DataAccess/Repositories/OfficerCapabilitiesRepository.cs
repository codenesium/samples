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
	public class OfficerCapabilitiesRepository : AbstractRepository, IOfficerCapabilitiesRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public OfficerCapabilitiesRepository(
			ILogger<IOfficerCapabilitiesRepository> logger,
			ApplicationDbContext context)
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
				                  (x.CapabilityIdNavigation == null || x.CapabilityIdNavigation.Name == null?false : x.CapabilityIdNavigation.Name.StartsWith(query)) ||
				                  (x.OfficerIdNavigation == null || x.OfficerIdNavigation.LastName == null?false : x.OfficerIdNavigation.LastName.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<OfficerCapabilities> Get(int id)
		{
			return await this.GetById(id);
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
			var entity = this.Context.Set<OfficerCapabilities>().Local.FirstOrDefault(x => x.Id == item.Id);
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
			int id)
		{
			OfficerCapabilities record = await this.GetById(id);

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

		// Foreign key reference to table OffCapability via capabilityId.
		public async virtual Task<OffCapability> OffCapabilityByCapabilityId(int capabilityId)
		{
			return await this.Context.Set<OffCapability>()
			       .SingleOrDefaultAsync(x => x.Id == capabilityId);
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
				orderBy = x => x.Id;
			}

			return await this.Context.Set<OfficerCapabilities>()
			       .Include(x => x.CapabilityIdNavigation)
			       .Include(x => x.OfficerIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<OfficerCapabilities>();
		}

		private async Task<OfficerCapabilities> GetById(int id)
		{
			List<OfficerCapabilities> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2e4c90e6a91ad0253c056ff54949e781</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/