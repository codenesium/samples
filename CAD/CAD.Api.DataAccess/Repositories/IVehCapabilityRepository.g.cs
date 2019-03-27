using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IVehCapabilityRepository
	{
		Task<VehCapability> Create(VehCapability item);

		Task Update(VehCapability item);

		Task Delete(int id);

		Task<VehCapability> Get(int id);

		Task<List<VehCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<VehicleCapabilities>> VehicleCapabilitiesByVehicleCapabilityId(int vehicleCapabilityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a619b8d8458face714471b2a3e2419cd</Hash>
</Codenesium>*/