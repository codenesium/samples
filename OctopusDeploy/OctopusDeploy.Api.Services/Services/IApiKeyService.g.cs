using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiKeyService
	{
		Task<CreateResponse<ApiApiKeyResponseModel>> Create(
			ApiApiKeyRequestModel model);

		Task<UpdateResponse<ApiApiKeyResponseModel>> Update(string id,
		                                                     ApiApiKeyRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiApiKeyResponseModel> Get(string id);

		Task<List<ApiApiKeyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiApiKeyResponseModel> ByApiKeyHashed(string apiKeyHashed);
	}
}

/*<Codenesium>
    <Hash>f0d6c4c12adc52d127478c80962b8381</Hash>
</Codenesium>*/