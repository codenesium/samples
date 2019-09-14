using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface ICallTypeRepository
	{
		Task<CallType> Create(CallType item);

		Task Update(CallType item);

		Task Delete(int id);

		Task<CallType> Get(int id);

		Task<List<CallType>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Call>> CallsByCallTypeId(int callTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>72ff76b0d4773cd74c9797c52482f190</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/