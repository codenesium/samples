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

		POCOChain Get(int id);

		List<POCOChain> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOChain ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>7a1529c111dd8d38f4af0bfe378f9f74</Hash>
</Codenesium>*/