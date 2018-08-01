using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLServerTaskMapper
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
    <Hash>132d3e5769f91c68052a9523b07b4067</Hash>
</Codenesium>*/