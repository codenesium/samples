using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IVehicleCapabilityRepository
	{
		Task<VehicleCapability> Create(VehicleCapability item);

		Task Update(VehicleCapability item);

		Task Delete(int id);

		Task<VehicleCapability> Get(int id);

		Task<List<VehicleCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<VehicleRefCapability>> VehicleRefCapabilitiesByVehicleCapabilityId(int vehicleCapabilityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3987a1898b030b9859d981624585f323</Hash>
</Codenesium>*/