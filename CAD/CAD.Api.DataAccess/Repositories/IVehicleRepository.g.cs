using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IVehicleRepository
	{
		Task<Vehicle> Create(Vehicle item);

		Task Update(Vehicle item);

		Task Delete(int id);

		Task<Vehicle> Get(int id);

		Task<List<Vehicle>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<VehicleOfficer>> VehicleOfficersByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);

		Task<List<VehicleRefCapability>> VehicleRefCapabilitiesByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c1600afdf01dc0239c5f39162bdab979</Hash>
</Codenesium>*/