using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IDeploymentRelatedMachineService
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
    <Hash>01b4c2e8885d717587aec5b0c25c923d</Hash>
</Codenesium>*/