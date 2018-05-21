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

		Task<POCOChainStatus> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>89eac58e7a706520359a872045e46de4</Hash>
</Codenesium>*/