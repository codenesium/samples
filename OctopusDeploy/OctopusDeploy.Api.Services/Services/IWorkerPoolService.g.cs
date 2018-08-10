using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IWorkerPoolService
	{
		Task<CreateResponse<ApiWorkerPoolResponseModel>> Create(
			ApiWorkerPoolRequestModel model);

		Task<UpdateResponse<ApiWorkerPoolResponseModel>> Update(string id,
		                                                         ApiWorkerPoolRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiWorkerPoolResponseModel> Get(string id);

		Task<List<ApiWorkerPoolResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiWorkerPoolResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>cc0e4ccf1a1ef3fdec897dbf779280f2</Hash>
</Codenesium>*/