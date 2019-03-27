using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IVehicleCapabilitiesRepository
	{
		Task<VehicleCapabilities> Create(VehicleCapabilities item);

		Task Update(VehicleCapabilities item);

		Task Delete(int id);

		Task<VehicleCapabilities> Get(int id);

		Task<List<VehicleCapabilities>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<VehCapability> VehCapabilityByVehicleCapabilityId(int vehicleCapabilityId);

		Task<Vehicle> VehicleByVehicleId(int vehicleId);
	}
}

/*<Codenesium>
    <Hash>0fcce3bd438a6e5a2d8f8b708d745e9e</Hash>
</Codenesium>*/