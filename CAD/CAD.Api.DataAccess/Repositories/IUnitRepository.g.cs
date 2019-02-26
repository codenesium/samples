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

		Task<List<Unit>> ByCallId(int callId, int limit = int.MaxValue, int offset = 0);

		Task<CallAssignment> CreateCallAssignment(CallAssignment item);

		Task DeleteCallAssignment(CallAssignment item);
	}
}

/*<Codenesium>
    <Hash>ba1201b620647aeae8356f7040094183</Hash>
</Codenesium>*/