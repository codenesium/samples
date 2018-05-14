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
			ChainStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ChainStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOChainStatus Get(int id);

		List<POCOChainStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOChainStatus Name(string name);
	}
}

/*<Codenesium>
    <Hash>9217845c77628c5b3d55401ff2177f8a</Hash>
</Codenesium>*/