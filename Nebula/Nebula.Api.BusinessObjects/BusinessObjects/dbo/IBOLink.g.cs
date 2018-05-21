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

		Task<POCOLink> GetExternalId(Guid externalId);
		Task<List<POCOLink>> GetChainId(int chainId);
	}
}

/*<Codenesium>
    <Hash>d6cc605257c053dc6b813ccf24106f60</Hash>
</Codenesium>*/