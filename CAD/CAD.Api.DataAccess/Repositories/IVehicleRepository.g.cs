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

		Task<List<VehicleCapabilities>> VehicleCapabilitiesByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);

		Task<List<Vehicle>> ByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<VehicleOfficer> CreateVehicleOfficer(VehicleOfficer item);

		Task DeleteVehicleOfficer(VehicleOfficer item);
	}
}

/*<Codenesium>
    <Hash>302caec2f84993d4aa3299d1fe31e5f1</Hash>
</Codenesium>*/