using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IVehicleCapabilittyRepository
	{
		Task<VehicleCapabilitty> Create(VehicleCapabilitty item);

		Task Update(VehicleCapabilitty item);

		Task Delete(int vehicleId);

		Task<VehicleCapabilitty> Get(int vehicleId);

		Task<List<VehicleCapabilitty>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Vehicle> VehicleByVehicleId(int vehicleId);
	}
}

/*<Codenesium>
    <Hash>cb8315dacafe554a3c3415abae575307</Hash>
</Codenesium>*/