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
    <Hash>ca4188bb1bbe9db191b4711d14f3163e</Hash>
</Codenesium>*/