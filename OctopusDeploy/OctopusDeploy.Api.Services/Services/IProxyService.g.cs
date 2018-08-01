using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IProxyService
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
    <Hash>cc3cd0ac990d59a5be5eebf5bd17d72e</Hash>
</Codenesium>*/