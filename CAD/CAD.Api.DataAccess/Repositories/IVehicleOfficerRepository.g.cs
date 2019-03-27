using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IVehicleOfficerRepository
	{
		Task<VehicleOfficer> Create(VehicleOfficer item);

		Task Update(VehicleOfficer item);

		Task Delete(int id);

		Task<VehicleOfficer> Get(int id);

		Task<List<VehicleOfficer>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<VehicleOfficer>> ByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<Officer> OfficerByOfficerId(int officerId);

		Task<Vehicle> VehicleByVehicleId(int vehicleId);
	}
}

/*<Codenesium>
    <Hash>4955b64734658ef78ce2ec3bbe163a54</Hash>
</Codenesium>*/