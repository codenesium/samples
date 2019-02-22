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
	public abstract class AbstractVehicleOfficerRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVehicleOfficerRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VehicleOfficer>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.OfficerId == query.ToInt() ||
				                  x.VehicleId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<VehicleOfficer> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<VehicleOfficer> Create(VehicleOfficer item)
		{
			this.Context.Set<VehicleOfficer>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VehicleOfficer item)
		{
			var entity = this.Context.Set<VehicleOfficer>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<VehicleOfficer>().Attach(item);
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
			VehicleOfficer record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VehicleOfficer>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Officer via officerId.
		public async virtual Task<Officer> OfficerByOfficerId(int officerId)
		{
			return await this.Context.Set<Officer>()
			       .SingleOrDefaultAsync(x => x.Id == officerId);
		}

		// Foreign key reference to table Vehicle via vehicleId.
		public async virtual Task<Vehicle> VehicleByVehicleId(int vehicleId)
		{
			return await this.Context.Set<Vehicle>()
			       .SingleOrDefaultAsync(x => x.Id == vehicleId);
		}

		protected async Task<List<VehicleOfficer>> Where(
			Expression<Func<VehicleOfficer, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VehicleOfficer, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<VehicleOfficer>()
			       .Include(x => x.OfficerIdNavigation)
			       .Include(x => x.VehicleIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VehicleOfficer>();
		}

		private async Task<VehicleOfficer> GetById(int id)
		{
			List<VehicleOfficer> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>45972485be6b78a1687a7306fed2878d</Hash>
</Codenesium>*/