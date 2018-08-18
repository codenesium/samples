using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IConfigurationService
	{
		Task<CreateResponse<ApiConfigurationResponseModel>> Create(
			ApiConfigurationRequestModel model);

		Task<UpdateResponse<ApiConfigurationResponseModel>> Update(string id,
		                                                            ApiConfigurationRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiConfigurationResponseModel> Get(string id);

		Task<List<ApiConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>cd18348090477cd9727265f328ca8000</Hash>
</Codenesium>*/