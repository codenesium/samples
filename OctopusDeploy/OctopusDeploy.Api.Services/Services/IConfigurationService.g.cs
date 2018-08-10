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
    <Hash>88255e3edfc3b928195a130aa20cb7e6</Hash>
</Codenesium>*/