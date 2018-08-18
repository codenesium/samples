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
    <Hash>1d2ebe5ecadfa5dfa3dc2d1167a06c8d</Hash>
</Codenesium>*/