using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLExtensionConfigurationMapper
	{
		BOExtensionConfiguration MapModelToBO(
			string id,
			ApiExtensionConfigurationRequestModel model);

		ApiExtensionConfigurationResponseModel MapBOToModel(
			BOExtensionConfiguration boExtensionConfiguration);

		List<ApiExtensionConfigurationResponseModel> MapBOToModel(
			List<BOExtensionConfiguration> items);
	}
}

/*<Codenesium>
    <Hash>4bcd38a84b92e453240d93a719eafd0f</Hash>
</Codenesium>*/