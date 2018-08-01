using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLInterruptionMapper
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
    <Hash>f40a7c01143a9349390613238ebe365d</Hash>
</Codenesium>*/