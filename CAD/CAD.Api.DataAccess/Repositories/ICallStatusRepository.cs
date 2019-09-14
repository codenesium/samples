using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface ICallStatusRepository
	{
		Task<CallStatus> Create(CallStatus item);

		Task Update(CallStatus item);

		Task Delete(int id);

		Task<CallStatus> Get(int id);

		Task<List<CallStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Call>> CallsByCallStatusId(int callStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>476f054a9ce794f3e00df1ef453d103c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/