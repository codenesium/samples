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
	public abstract class AbstractVehCapabilityRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVehCapabilityRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VehCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<VehCapability> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<VehCapability> Create(VehCapability item)
		{
			this.Context.Set<VehCapability>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VehCapability item)
		{
			var entity = this.Context.Set<VehCapability>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<VehCapability>().Attach(item);
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
			VehCapability record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VehCapability>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table VehicleCapabilities via vehicleCapabilityId.
		public async virtual Task<List<VehicleCapabilities>> VehicleCapabilitiesByVehicleCapabilityId(int vehicleCapabilityId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<VehicleCapabilities>()
			       .Include(x => x.VehicleCapabilityIdNavigation)
			       .Include(x => x.VehicleIdNavigation)

			       .Where(x => x.VehicleCapabilityId == vehicleCapabilityId).AsQueryable().Skip(offset).Take(limit).ToListAsync<VehicleCapabilities>();
		}

		protected async Task<List<VehCapability>> Where(
			Expression<Func<VehCapability, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VehCapability, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<VehCapability>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VehCapability>();
		}

		private async Task<VehCapability> GetById(int id)
		{
			List<VehCapability> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8e99d677a04a06d12a35c6a9a156c0e1</Hash>
</Codenesium>*/