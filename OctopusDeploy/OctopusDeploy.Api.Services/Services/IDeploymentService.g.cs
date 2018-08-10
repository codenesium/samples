using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDeploymentService
	{
		Task<CreateResponse<ApiDeploymentResponseModel>> Create(
			ApiDeploymentRequestModel model);

		Task<UpdateResponse<ApiDeploymentResponseModel>> Update(string id,
		                                                         ApiDeploymentRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiDeploymentResponseModel> Get(string id);

		Task<List<ApiDeploymentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDeploymentResponseModel>> ByChannelId(string channelId);

		Task<List<ApiDeploymentResponseModel>> ByIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId);

		Task<List<ApiDeploymentResponseModel>> ByTenantId(string tenantId);

		Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachines(string deploymentId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>662b413748d7a86c13b42612adc8d9be</Hash>
</Codenesium>*/