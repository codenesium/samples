using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IChainStatusService
	{
		Task<CreateResponse<ApiChainStatusResponseModel>> Create(
			ApiChainStatusRequestModel model);

		Task<UpdateResponse<ApiChainStatusResponseModel>> Update(int id,
		                                                          ApiChainStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiChainStatusResponseModel> Get(int id);

		Task<List<ApiChainStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiChainResponseModel>> Chains(int chainStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e589d7ad7ebdd7c82d05578b1a35e758</Hash>
</Codenesium>*/