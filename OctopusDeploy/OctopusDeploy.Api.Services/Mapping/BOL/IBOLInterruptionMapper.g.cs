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
    <Hash>02cee299522de7bb2abeadfe9f7a7cc7</Hash>
</Codenesium>*/