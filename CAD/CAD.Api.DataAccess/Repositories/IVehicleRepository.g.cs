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

		Task<List<VehicleCapabilitty>> VehicleCapabilitiesByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);

		Task<List<Vehicle>> ByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<VehicleOfficer> CreateVehicleOfficer(VehicleOfficer item);

		Task DeleteVehicleOfficer(VehicleOfficer item);
	}
}

/*<Codenesium>
    <Hash>d7cca3cb5207ae87288fdd9766ddbea4</Hash>
</Codenesium>*/