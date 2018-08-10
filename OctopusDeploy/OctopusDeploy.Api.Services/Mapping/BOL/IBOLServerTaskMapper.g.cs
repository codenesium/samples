using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLServerTaskMapper
	{
		BOServerTask MapModelToBO(
			string id,
			ApiServerTaskRequestModel model);

		ApiServerTaskResponseModel MapBOToModel(
			BOServerTask boServerTask);

		List<ApiServerTaskResponseModel> MapBOToModel(
			List<BOServerTask> items);
	}
}

/*<Codenesium>
    <Hash>8f6028f08f8b33abef495d14a75cf88c</Hash>
</Codenesium>*/