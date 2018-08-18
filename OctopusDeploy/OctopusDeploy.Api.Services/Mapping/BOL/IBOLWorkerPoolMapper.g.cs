using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLWorkerPoolMapper
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
    <Hash>5a95e4b2d57ed2f19a6068d5b8ea68a0</Hash>
</Codenesium>*/