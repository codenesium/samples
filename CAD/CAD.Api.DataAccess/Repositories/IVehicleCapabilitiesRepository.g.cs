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

		Task Delete(int vehicleId);

		Task<VehicleCapabilities> Get(int vehicleId);

		Task<List<VehicleCapabilities>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Vehicle> VehicleByVehicleId(int vehicleId);
	}
}

/*<Codenesium>
    <Hash>b617af15b5351d42a226c0cacaca9ccc</Hash>
</Codenesium>*/