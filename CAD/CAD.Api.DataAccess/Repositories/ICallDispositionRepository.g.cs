using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface ICallDispositionRepository
	{
		Task<CallDisposition> Create(CallDisposition item);

		Task Update(CallDisposition item);

		Task Delete(int id);

		Task<CallDisposition> Get(int id);

		Task<List<CallDisposition>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Call>> CallsByCallDispositionId(int callDispositionId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ecb4a80ba48dbf4dcaf90076f9103de2</Hash>
</Codenesium>*/