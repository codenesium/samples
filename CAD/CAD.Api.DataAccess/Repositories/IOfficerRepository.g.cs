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

		Task<List<OfficerRefCapability>> OfficerRefCapabilitiesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<List<UnitOfficer>> UnitOfficersByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<List<VehicleOfficer>> VehicleOfficersByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fc377ecd0f9e8e3a27f48b137182ecdb</Hash>
</Codenesium>*/