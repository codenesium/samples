using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IVehicleRefCapabilityRepository
	{
		Task<VehicleRefCapability> Create(VehicleRefCapability item);

		Task Update(VehicleRefCapability item);

		Task Delete(int id);

		Task<VehicleRefCapability> Get(int id);

		Task<List<VehicleRefCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<VehicleCapability> VehicleCapabilityByVehicleCapabilityId(int vehicleCapabilityId);

		Task<Vehicle> VehicleByVehicleId(int vehicleId);
	}
}

/*<Codenesium>
    <Hash>e1dfca2e4452551279ba438e4c03b3ed</Hash>
</Codenesium>*/