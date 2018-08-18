using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IWorkerService
	{
		Task<CreateResponse<ApiWorkerResponseModel>> Create(
			ApiWorkerRequestModel model);

		Task<UpdateResponse<ApiWorkerResponseModel>> Update(string id,
		                                                     ApiWorkerRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiWorkerResponseModel> Get(string id);

		Task<List<ApiWorkerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiWorkerResponseModel> ByName(string name);

		Task<List<ApiWorkerResponseModel>> ByMachinePolicyId(string machinePolicyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>614ddad69347604fc3e2410ac201fb72</Hash>
</Codenesium>*/