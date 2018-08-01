using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLWorkerTaskLeaseMapper
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
    <Hash>5c65cf44cfdd1b3adef3616ed6c175aa</Hash>
</Codenesium>*/