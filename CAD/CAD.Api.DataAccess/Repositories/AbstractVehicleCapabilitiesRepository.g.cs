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
	public abstract class AbstractVehicleCapabilitiesRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVehicleCapabilitiesRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
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
				                  x.VehicleCapabilityId == query.ToInt() ||
				                  x.VehicleId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<VehicleCapabilities> Get(int vehicleId)
		{
			return await this.GetById(vehicleId);
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
			var entity = this.Context.Set<VehicleCapabilities>().Local.FirstOrDefault(x => x.VehicleId == item.VehicleId);
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
			int vehicleId)
		{
			VehicleCapabilities record = await this.GetById(vehicleId);

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
				orderBy = x => x.VehicleId;
			}

			return await this.Context.Set<VehicleCapabilities>()
			       .Include(x => x.VehicleIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VehicleCapabilities>();
		}

		private async Task<VehicleCapabilities> GetById(int vehicleId)
		{
			List<VehicleCapabilities> records = await this.Where(x => x.VehicleId == vehicleId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>322f1cf5ffc68301f1caf20b463c378a</Hash>
</Codenesium>*/