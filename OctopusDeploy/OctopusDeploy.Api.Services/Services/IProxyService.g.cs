using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IProxyService
	{
		Task<CreateResponse<ApiProxyResponseModel>> Create(
			ApiProxyRequestModel model);

		Task<UpdateResponse<ApiProxyResponseModel>> Update(string id,
		                                                    ApiProxyRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiProxyResponseModel> Get(string id);

		Task<List<ApiProxyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProxyResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>584b97e2ddb9eeb13cca9989ea4cfa67</Hash>
</Codenesium>*/