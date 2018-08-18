using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IInterruptionService
	{
		Task<CreateResponse<ApiInterruptionResponseModel>> Create(
			ApiInterruptionRequestModel model);

		Task<UpdateResponse<ApiInterruptionResponseModel>> Update(string id,
		                                                           ApiInterruptionRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiInterruptionResponseModel> Get(string id);

		Task<List<ApiInterruptionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiInterruptionResponseModel>> ByTenantId(string tenantId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dabfee9c54a54e5635a248c7b2372047</Hash>
</Codenesium>*/