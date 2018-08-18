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

		Task<List<ApiDeploymentRelatedMachineResponseModel>> ByDeploymentId(string deploymentId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDeploymentRelatedMachineResponseModel>> ByMachineId(string machineId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c3273086067ba150cd1e6f65adf1b5b3</Hash>
</Codenesium>*/