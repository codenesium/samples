using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IMachineService
	{
		Task<CreateResponse<ApiMachineResponseModel>> Create(
			ApiMachineRequestModel model);

		Task<UpdateResponse<ApiMachineResponseModel>> Update(string id,
		                                                      ApiMachineRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiMachineResponseModel> Get(string id);

		Task<List<ApiMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiMachineResponseModel> ByName(string name);

		Task<List<ApiMachineResponseModel>> ByMachinePolicyId(string machinePolicyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>aa20421217095a2fa50784c25ff7bc14</Hash>
</Codenesium>*/