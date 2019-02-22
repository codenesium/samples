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
	public abstract class AbstractVehicleRefCapabilityRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVehicleRefCapabilityRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VehicleRefCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.VehicleCapabilityId == query.ToInt() ||
				                  x.VehicleId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<VehicleRefCapability> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<VehicleRefCapability> Create(VehicleRefCapability item)
		{
			this.Context.Set<VehicleRefCapability>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VehicleRefCapability item)
		{
			var entity = this.Context.Set<VehicleRefCapability>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<VehicleRefCapability>().Attach(item);
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
			VehicleRefCapability record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VehicleRefCapability>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table VehicleCapability via vehicleCapabilityId.
		public async virtual Task<VehicleCapability> VehicleCapabilityByVehicleCapabilityId(int vehicleCapabilityId)
		{
			return await this.Context.Set<VehicleCapability>()
			       .SingleOrDefaultAsync(x => x.Id == vehicleCapabilityId);
		}

		// Foreign key reference to table Vehicle via vehicleId.
		public async virtual Task<Vehicle> VehicleByVehicleId(int vehicleId)
		{
			return await this.Context.Set<Vehicle>()
			       .SingleOrDefaultAsync(x => x.Id == vehicleId);
		}

		protected async Task<List<VehicleRefCapability>> Where(
			Expression<Func<VehicleRefCapability, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VehicleRefCapability, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<VehicleRefCapability>()
			       .Include(x => x.VehicleCapabilityIdNavigation)
			       .Include(x => x.VehicleIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VehicleRefCapability>();
		}

		private async Task<VehicleRefCapability> GetById(int id)
		{
			List<VehicleRefCapability> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>be8e7f190283dd5e14bde3bbce17f45e</Hash>
</Codenesium>*/