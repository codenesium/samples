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
    <Hash>21aa0b60b2e399b94344ef97aba3e56e</Hash>
</Codenesium>*/