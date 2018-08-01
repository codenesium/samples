using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface ILifecycleService
	{
		Task<CreateResponse<ApiLifecycleResponseModel>> Create(
			ApiLifecycleRequestModel model);

		Task<UpdateResponse<ApiLifecycleResponseModel>> Update(string id,
		                                                        ApiLifecycleRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiLifecycleResponseModel> Get(string id);

		Task<List<ApiLifecycleResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiLifecycleResponseModel> ByName(string name);

		Task<List<ApiLifecycleResponseModel>> ByDataVersion(byte[] dataVersion);
	}
}

/*<Codenesium>
    <Hash>09ba944d4ecf7692d2d128bba817ed70</Hash>
</Codenesium>*/