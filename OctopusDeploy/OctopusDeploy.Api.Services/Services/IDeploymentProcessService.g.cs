using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDeploymentProcessService
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
    <Hash>8fed52812193dfba2008162e6e6b432a</Hash>
</Codenesium>*/