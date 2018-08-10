using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLApiKeyMapper
	{
		BOApiKey MapModelToBO(
			string id,
			ApiApiKeyRequestModel model);

		ApiApiKeyResponseModel MapBOToModel(
			BOApiKey boApiKey);

		List<ApiApiKeyResponseModel> MapBOToModel(
			List<BOApiKey> items);
	}
}

/*<Codenesium>
    <Hash>954ea458674dc743e4b5997c352c7506</Hash>
</Codenesium>*/