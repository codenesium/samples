using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOChain
	{
		Task<CreateResponse<POCOChain>> Create(
			ApiChainModel model);

		Task<ActionResponse> Update(int id,
		                            ApiChainModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOChain> Get(int id);

		Task<List<POCOChain>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOChain> ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>0265568a3dd09844f820feb7b4db53a7</Hash>
</Codenesium>*/