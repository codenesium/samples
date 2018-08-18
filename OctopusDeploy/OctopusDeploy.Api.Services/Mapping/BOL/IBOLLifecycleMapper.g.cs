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
    <Hash>c12f5be46c3f4e00b3a3669d41af09e8</Hash>
</Codenesium>*/