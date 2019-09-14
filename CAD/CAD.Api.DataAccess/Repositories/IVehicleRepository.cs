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

		Task<List<VehicleOfficer>> VehicleOfficersByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8847289689ad686cfba98dbd93260019</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/