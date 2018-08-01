using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IWorkerTaskLeaseService
	{
		Task<CreateResponse<ApiWorkerTaskLeaseResponseModel>> Create(
			ApiWorkerTaskLeaseRequestModel model);

		Task<UpdateResponse<ApiWorkerTaskLeaseResponseModel>> Update(string id,
		                                                              ApiWorkerTaskLeaseRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiWorkerTaskLeaseResponseModel> Get(string id);

		Task<List<ApiWorkerTaskLeaseResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>84cdc0d70339170e9b858c0178d41dda</Hash>
</Codenesium>*/