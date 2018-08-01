using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLLifecycleMapper
	{
		BOLifecycle MapModelToBO(
			string id,
			ApiLifecycleRequestModel model);

		ApiLifecycleResponseModel MapBOToModel(
			BOLifecycle boLifecycle);

		List<ApiLifecycleResponseModel> MapBOToModel(
			List<BOLifecycle> items);
	}
}

/*<Codenesium>
    <Hash>ea9588d5a645ffe50b1b2868f58ae0b5</Hash>
</Codenesium>*/