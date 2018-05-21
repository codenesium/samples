using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOChainStatus
	{
		Task<CreateResponse<POCOChainStatus>> Create(
			ApiChainStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ApiChainStatusModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOChainStatus> Get(int id);

		Task<List<POCOChainStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOChainStatus> Name(string name);
	}
}

/*<Codenesium>
    <Hash>784a403cbe862b84b370c848ca05ddf5</Hash>
</Codenesium>*/