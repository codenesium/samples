using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IDeploymentHistoryService
	{
		Task<CreateResponse<ApiDeploymentHistoryResponseModel>> Create(
			ApiDeploymentHistoryRequestModel model);

		Task<UpdateResponse<ApiDeploymentHistoryResponseModel>> Update(string deploymentId,
		                                                                ApiDeploymentHistoryRequestModel model);

		Task<ActionResponse> Delete(string deploymentId);

		Task<ApiDeploymentHistoryResponseModel> Get(string deploymentId);

		Task<List<ApiDeploymentHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDeploymentHistoryResponseModel>> ByCreated(DateTimeOffset created);
	}
}

/*<Codenesium>
    <Hash>0bbe0888dd1a507379082684da80c65b</Hash>
</Codenesium>*/