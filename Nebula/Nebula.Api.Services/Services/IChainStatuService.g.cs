using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IChainStatuService
	{
		Task<CreateResponse<ApiChainStatuResponseModel>> Create(
			ApiChainStatuRequestModel model);

		Task<UpdateResponse<ApiChainStatuResponseModel>> Update(int id,
		                                                         ApiChainStatuRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiChainStatuResponseModel> Get(int id);

		Task<List<ApiChainStatuResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiChainStatuResponseModel> ByName(string name);

		Task<List<ApiChainResponseModel>> Chains(int chainStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>eb106a940eb5833f5093c66ed24a3e9a</Hash>
</Codenesium>*/