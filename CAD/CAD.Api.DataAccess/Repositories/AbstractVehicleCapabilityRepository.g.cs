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
	public abstract class AbstractVehicleCapabilityRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVehicleCapabilityRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VehicleCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<VehicleCapability> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<VehicleCapability> Create(VehicleCapability item)
		{
			this.Context.Set<VehicleCapability>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VehicleCapability item)
		{
			var entity = this.Context.Set<VehicleCapability>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<VehicleCapability>().Attach(item);
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
			VehicleCapability record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VehicleCapability>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table VehicleRefCapability via vehicleCapabilityId.
		public async virtual Task<List<VehicleRefCapability>> VehicleRefCapabilitiesByVehicleCapabilityId(int vehicleCapabilityId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<VehicleRefCapability>()
			       .Include(x => x.VehicleCapabilityIdNavigation)
			       .Where(x => x.VehicleCapabilityId == vehicleCapabilityId).AsQueryable().Skip(offset).Take(limit).ToListAsync<VehicleRefCapability>();
		}

		protected async Task<List<VehicleCapability>> Where(
			Expression<Func<VehicleCapability, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VehicleCapability, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<VehicleCapability>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VehicleCapability>();
		}

		private async Task<VehicleCapability> GetById(int id)
		{
			List<VehicleCapability> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3c55581ed26702d38bf2f2959f5c1ce9</Hash>
</Codenesium>*/