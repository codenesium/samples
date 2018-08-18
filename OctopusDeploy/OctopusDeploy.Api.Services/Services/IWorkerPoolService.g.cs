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
    <Hash>6016c9ceaa61373299ad7e314ce1904f</Hash>
</Codenesium>*/