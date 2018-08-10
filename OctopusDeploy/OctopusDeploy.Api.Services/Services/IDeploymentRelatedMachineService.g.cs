using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDeploymentRelatedMachineService
	{
		Task<CreateResponse<ApiDeploymentRelatedMachineResponseModel>> Create(
			ApiDeploymentRelatedMachineRequestModel model);

		Task<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>> Update(int id,
		                                                                       ApiDeploymentRelatedMachineRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDeploymentRelatedMachineResponseModel> Get(int id);

		Task<List<ApiDeploymentRelatedMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDeploymentRelatedMachineResponseModel>> ByDeploymentId(string deploymentId);

		Task<List<ApiDeploymentRelatedMachineResponseModel>> ByMachineId(string machineId);
	}
}

/*<Codenesium>
    <Hash>8ac0dbf3af9a7371418bd40c499dc102</Hash>
</Codenesium>*/