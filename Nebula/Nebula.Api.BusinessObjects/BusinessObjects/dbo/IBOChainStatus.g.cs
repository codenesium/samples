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
		Task<CreateResponse<int>> Create(
			ChainStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ChainStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOChainStatus Get(int id);

		List<POCOChainStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d7b5361fe767cc9865324e09d1417704</Hash>
</Codenesium>*/