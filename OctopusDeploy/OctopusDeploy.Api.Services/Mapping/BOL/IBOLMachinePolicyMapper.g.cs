using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLMachinePolicyMapper
	{
		BOMachinePolicy MapModelToBO(
			string id,
			ApiMachinePolicyRequestModel model);

		ApiMachinePolicyResponseModel MapBOToModel(
			BOMachinePolicy boMachinePolicy);

		List<ApiMachinePolicyResponseModel> MapBOToModel(
			List<BOMachinePolicy> items);
	}
}

/*<Codenesium>
    <Hash>f951bec705d72e5bedb06ba46dba6ebf</Hash>
</Codenesium>*/