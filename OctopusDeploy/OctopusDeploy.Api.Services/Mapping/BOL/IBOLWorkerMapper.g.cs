using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLWorkerMapper
	{
		BOWorker MapModelToBO(
			string id,
			ApiWorkerRequestModel model);

		ApiWorkerResponseModel MapBOToModel(
			BOWorker boWorker);

		List<ApiWorkerResponseModel> MapBOToModel(
			List<BOWorker> items);
	}
}

/*<Codenesium>
    <Hash>dc6beb23ebc8fa25eb74b4c980fe4acc</Hash>
</Codenesium>*/