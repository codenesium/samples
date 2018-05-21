using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLink
	{
		Task<CreateResponse<POCOLink>> Create(
			ApiLinkModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLinkModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOLink> Get(int id);

		Task<List<POCOLink>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOLink>> ChainId(int chainId);
		Task<POCOLink> ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>890a44a47c8ab993e58afd96a3a5fdf9</Hash>
</Codenesium>*/