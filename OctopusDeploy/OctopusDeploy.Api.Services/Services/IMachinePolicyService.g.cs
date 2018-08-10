using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IMachinePolicyService
	{
		Task<CreateResponse<ApiMachinePolicyResponseModel>> Create(
			ApiMachinePolicyRequestModel model);

		Task<UpdateResponse<ApiMachinePolicyResponseModel>> Update(string id,
		                                                            ApiMachinePolicyRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiMachinePolicyResponseModel> Get(string id);

		Task<List<ApiMachinePolicyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiMachinePolicyResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>45981b72141251f6c833b5bac228d3b6</Hash>
</Codenesium>*/