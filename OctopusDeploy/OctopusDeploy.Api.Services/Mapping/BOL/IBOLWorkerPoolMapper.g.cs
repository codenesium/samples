using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLWorkerPoolMapper
	{
		BOWorkerPool MapModelToBO(
			string id,
			ApiWorkerPoolRequestModel model);

		ApiWorkerPoolResponseModel MapBOToModel(
			BOWorkerPool boWorkerPool);

		List<ApiWorkerPoolResponseModel> MapBOToModel(
			List<BOWorkerPool> items);
	}
}

/*<Codenesium>
    <Hash>e54edb09d600d5f6c8fa090d21bf653d</Hash>
</Codenesium>*/