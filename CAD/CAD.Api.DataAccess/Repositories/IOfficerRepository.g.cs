using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IOfficerRepository
	{
		Task<Officer> Create(Officer item);

		Task Update(Officer item);

		Task Delete(int id);

		Task<Officer> Get(int id);

		Task<List<Officer>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Note>> NotesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<List<OfficerCapability>> OfficerCapabilitiesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<List<Officer>> ByCapabilityId(int capabilityId, int limit = int.MaxValue, int offset = 0);

		Task<OfficerCapability> CreateOfficerCapability(OfficerCapability item);

		Task DeleteOfficerCapability(OfficerCapability item);

		Task<List<Officer>> ByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0);

		Task<VehicleOfficer> CreateVehicleOfficer(VehicleOfficer item);

		Task DeleteVehicleOfficer(VehicleOfficer item);
	}
}

/*<Codenesium>
    <Hash>babd08c7a846729182caba4138985fea</Hash>
</Codenesium>*/