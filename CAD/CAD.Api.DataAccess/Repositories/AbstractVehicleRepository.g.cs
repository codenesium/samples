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
	public abstract class AbstractVehicleRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVehicleRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Vehicle>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<Vehicle> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Vehicle> Create(Vehicle item)
		{
			this.Context.Set<Vehicle>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Vehicle item)
		{
			var entity = this.Context.Set<Vehicle>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Vehicle>().Attach(item);
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
			Vehicle record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Vehicle>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table VehicleOfficer via vehicleId.
		public async virtual Task<List<VehicleOfficer>> VehicleOfficersByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<VehicleOfficer>()
			       .Include(x => x.VehicleIdNavigation)
			       .Where(x => x.VehicleId == vehicleId).AsQueryable().Skip(offset).Take(limit).ToListAsync<VehicleOfficer>();
		}

		// Foreign key reference to this table VehicleRefCapability via vehicleId.
		public async virtual Task<List<VehicleRefCapability>> VehicleRefCapabilitiesByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<VehicleRefCapability>()
			       .Include(x => x.VehicleIdNavigation)
			       .Where(x => x.VehicleId == vehicleId).AsQueryable().Skip(offset).Take(limit).ToListAsync<VehicleRefCapability>();
		}

		protected async Task<List<Vehicle>> Where(
			Expression<Func<Vehicle, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Vehicle, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Vehicle>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Vehicle>();
		}

		private async Task<Vehicle> GetById(int id)
		{
			List<Vehicle> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4a084a07b2dc6e0e1795a27bfadb1688</Hash>
</Codenesium>*/