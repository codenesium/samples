using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDeploymentHistoryService
	{
		Task<CreateResponse<ApiDeploymentHistoryResponseModel>> Create(
			ApiDeploymentHistoryRequestModel model);

		Task<UpdateResponse<ApiDeploymentHistoryResponseModel>> Update(string deploymentId,
		                                                                ApiDeploymentHistoryRequestModel model);

		Task<ActionResponse> Delete(string deploymentId);

		Task<ApiDeploymentHistoryResponseModel> Get(string deploymentId);

		Task<List<ApiDeploymentHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDeploymentHistoryResponseModel>> ByCreated(DateTimeOffset created, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c09588f32e9131a2cd3652f96500a5f3</Hash>
</Codenesium>*/