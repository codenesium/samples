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

		Task<Officer> OfficerByOfficerId(int officerId);

		Task<Vehicle> VehicleByVehicleId(int vehicleId);
	}
}

/*<Codenesium>
    <Hash>2b8e861f99ede243fd32b2afc6d14437</Hash>
</Codenesium>*/