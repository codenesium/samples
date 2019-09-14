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

		Task<List<CallAssignment>> CallAssignmentsByUnitId(int unitId, int limit = int.MaxValue, int offset = 0);

		Task<List<UnitOfficer>> UnitOfficersByUnitId(int unitId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>721d87cd153a96f4f44bdfd1ffe6dc06</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/