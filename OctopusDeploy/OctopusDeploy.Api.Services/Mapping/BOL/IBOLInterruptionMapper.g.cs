using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLInterruptionMapper
	{
		BOInterruption MapModelToBO(
			string id,
			ApiInterruptionRequestModel model);

		ApiInterruptionResponseModel MapBOToModel(
			BOInterruption boInterruption);

		List<ApiInterruptionResponseModel> MapBOToModel(
			List<BOInterruption> items);
	}
}

/*<Codenesium>
    <Hash>4cc81053d5f73a84debdf8db7cb204da</Hash>
</Codenesium>*/