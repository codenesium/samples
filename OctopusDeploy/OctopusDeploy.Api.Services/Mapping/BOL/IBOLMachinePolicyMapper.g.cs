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
    <Hash>5135c617a575c7a0fabdb36a1deb0b2c</Hash>
</Codenesium>*/