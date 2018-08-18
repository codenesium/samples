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
    <Hash>fa5cdc00ade17ed6006ed7177008286b</Hash>
</Codenesium>*/