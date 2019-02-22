using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface ICallStatuRepository
	{
		Task<CallStatu> Create(CallStatu item);

		Task Update(CallStatu item);

		Task Delete(int id);

		Task<CallStatu> Get(int id);

		Task<List<CallStatu>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Call>> CallsByCallStatusId(int callStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e3276afdc6d8aeaea916a2ee6b57fb21</Hash>
</Codenesium>*/