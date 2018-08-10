using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLConfigurationMapper
	{
		BOConfiguration MapModelToBO(
			string id,
			ApiConfigurationRequestModel model);

		ApiConfigurationResponseModel MapBOToModel(
			BOConfiguration boConfiguration);

		List<ApiConfigurationResponseModel> MapBOToModel(
			List<BOConfiguration> items);
	}
}

/*<Codenesium>
    <Hash>223c095c8b1bff517dd33ed61f4c06f7</Hash>
</Codenesium>*/