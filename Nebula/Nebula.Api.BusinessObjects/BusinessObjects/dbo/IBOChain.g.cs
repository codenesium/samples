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

		Task<POCOChain> GetExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>5d9ee4fb816eff85c3c253da770c3f8e</Hash>
</Codenesium>*/