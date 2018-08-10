using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IMutexService
	{
		Task<CreateResponse<ApiMutexResponseModel>> Create(
			ApiMutexRequestModel model);

		Task<UpdateResponse<ApiMutexResponseModel>> Update(string id,
		                                                    ApiMutexRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiMutexResponseModel> Get(string id);

		Task<List<ApiMutexResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d451e27a88d4199e6bf438b74ce3c547</Hash>
</Codenesium>*/