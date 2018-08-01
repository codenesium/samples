using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IExtensionConfigurationService
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
    <Hash>452d84141bfee37c7de5bd697f3fd785</Hash>
</Codenesium>*/