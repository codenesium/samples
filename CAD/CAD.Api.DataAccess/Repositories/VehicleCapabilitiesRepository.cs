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
	public class VehicleCapabilitiesRepository : AbstractRepository, IVehicleCapabilitiesRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public VehicleCapabilitiesRepository(
			ILogger<IVehicleCapabilitiesRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VehicleCapabilities>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.VehicleCapabilityIdNavigation == null || x.VehicleCapabilityIdNavigation.Name == null?false : x.VehicleCapabilityIdNavigation.Name.StartsWith(query)) ||
				                  (x.VehicleIdNavigation == null || x.VehicleIdNavigation.Name == null?false : x.VehicleIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<VehicleCapabilities> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<VehicleCapabilities> Create(VehicleCapabilities item)
		{
			this.Context.Set<VehicleCapabilities>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VehicleCapabilities item)
		{
			var entity = this.Context.Set<VehicleCapabilities>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<VehicleCapabilities>().Attach(item);
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
			VehicleCapabilities record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VehicleCapabilities>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table VehCapability via vehicleCapabilityId.
		public async virtual Task<VehCapability> VehCapabilityByVehicleCapabilityId(int vehicleCapabilityId)
		{
			return await this.Context.Set<VehCapability>()
			       .SingleOrDefaultAsync(x => x.Id == vehicleCapabilityId);
		}

		// Foreign key reference to table Vehicle via vehicleId.
		public async virtual Task<Vehicle> VehicleByVehicleId(int vehicleId)
		{
			return await this.Context.Set<Vehicle>()
			       .SingleOrDefaultAsync(x => x.Id == vehicleId);
		}

		protected async Task<List<VehicleCapabilities>> Where(
			Expression<Func<VehicleCapabilities, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VehicleCapabilities, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<VehicleCapabilities>()
			       .Include(x => x.VehicleCapabilityIdNavigation)
			       .Include(x => x.VehicleIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VehicleCapabilities>();
		}

		private async Task<VehicleCapabilities> GetById(int id)
		{
			List<VehicleCapabilities> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3be5956d16534ca55da70ffd45ca63d5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/