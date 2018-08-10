using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLLifecycleMapper
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
    <Hash>a1b6bd9f96477ce5350753c6bdd11172</Hash>
</Codenesium>*/