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
    <Hash>6a96a42bb7af613760b4a66344696b47</Hash>
</Codenesium>*/