using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IExtensionConfigurationService
	{
		Task<CreateResponse<ApiExtensionConfigurationResponseModel>> Create(
			ApiExtensionConfigurationRequestModel model);

		Task<UpdateResponse<ApiExtensionConfigurationResponseModel>> Update(string id,
		                                                                     ApiExtensionConfigurationRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiExtensionConfigurationResponseModel> Get(string id);

		Task<List<ApiExtensionConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>acb0a8940ba6512554fa5846a83fae28</Hash>
</Codenesium>*/