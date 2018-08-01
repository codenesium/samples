using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLApiKeyMapper
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
    <Hash>a65c5dd3df40505f06fbec12c1209e08</Hash>
</Codenesium>*/