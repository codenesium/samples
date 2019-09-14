using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface ICallAssignmentRepository
	{
		Task<CallAssignment> Create(CallAssignment item);

		Task Update(CallAssignment item);

		Task Delete(int id);

		Task<CallAssignment> Get(int id);

		Task<List<CallAssignment>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<CallAssignment>> ByCallId(int callId, int limit = int.MaxValue, int offset = 0);

		Task<List<CallAssignment>> ByUnitId(int unitId, int limit = int.MaxValue, int offset = 0);

		Task<Call> CallByCallId(int callId);

		Task<Unit> UnitByUnitId(int unitId);
	}
}

/*<Codenesium>
    <Hash>b989da2e9e12c08e0ce22d8025b7a4b0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/