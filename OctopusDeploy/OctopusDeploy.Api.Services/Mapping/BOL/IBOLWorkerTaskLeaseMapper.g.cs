using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLWorkerTaskLeaseMapper
	{
		BOWorkerTaskLease MapModelToBO(
			string id,
			ApiWorkerTaskLeaseRequestModel model);

		ApiWorkerTaskLeaseResponseModel MapBOToModel(
			BOWorkerTaskLease boWorkerTaskLease);

		List<ApiWorkerTaskLeaseResponseModel> MapBOToModel(
			List<BOWorkerTaskLease> items);
	}
}

/*<Codenesium>
    <Hash>aaf7bdc280ef8c61d2b9b5900e6086c8</Hash>
</Codenesium>*/