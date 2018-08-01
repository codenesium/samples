using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLMachinePolicyMapper
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
    <Hash>a8db77a3011283fba241f7e565a392ad</Hash>
</Codenesium>*/