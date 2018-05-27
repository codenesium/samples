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
		Task<CreateResponse<ApiLinkResponseModel>> Create(
			ApiLinkRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLinkRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkResponseModel> Get(int id);

		Task<List<ApiLinkResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiLinkResponseModel> GetExternalId(Guid externalId);
		Task<List<ApiLinkResponseModel>> GetChainId(int chainId);
	}
}

/*<Codenesium>
    <Hash>06ae65f91c09ad0c446266e4246ccb9e</Hash>
</Codenesium>*/