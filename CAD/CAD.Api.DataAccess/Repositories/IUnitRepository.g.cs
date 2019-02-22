using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IUnitRepository
	{
		Task<Unit> Create(Unit item);

		Task Update(Unit item);

		Task Delete(int id);

		Task<Unit> Get(int id);

		Task<List<Unit>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<UnitOfficer>> UnitOfficersByUnitId(int unitId, int limit = int.MaxValue, int offset = 0);

		Task<List<CallAssignment>> CallAssignmentsByUnitId(int unitId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>488edf8e5304de0689636a942fa28e1b</Hash>
</Codenesium>*/