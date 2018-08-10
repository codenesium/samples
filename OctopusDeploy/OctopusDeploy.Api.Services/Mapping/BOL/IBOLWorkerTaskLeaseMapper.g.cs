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
    <Hash>38932f67daffaea5a5e16953d63871a3</Hash>
</Codenesium>*/