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
    <Hash>f2148b790d56294674c0c0c172ed53b3</Hash>
</Codenesium>*/