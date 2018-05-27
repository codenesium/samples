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
		Task<CreateResponse<ApiChainResponseModel>> Create(
			ApiChainRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiChainRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiChainResponseModel> Get(int id);

		Task<List<ApiChainResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiChainResponseModel> GetExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>99a216d2e74e6daa189d07d1c8567f6d</Hash>
</Codenesium>*/