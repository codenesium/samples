using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IDeploymentProcessService
	{
		Task<CreateResponse<ApiDeploymentProcessResponseModel>> Create(
			ApiDeploymentProcessRequestModel model);

		Task<UpdateResponse<ApiDeploymentProcessResponseModel>> Update(string id,
		                                                                ApiDeploymentProcessRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiDeploymentProcessResponseModel> Get(string id);

		Task<List<ApiDeploymentProcessResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f13184f1270b7d8fbceec37376538600</Hash>
</Codenesium>*/