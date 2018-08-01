using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLWorkerMapper
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
    <Hash>ac3ce720c59907d92ee42a8aea0f7fd9</Hash>
</Codenesium>*/