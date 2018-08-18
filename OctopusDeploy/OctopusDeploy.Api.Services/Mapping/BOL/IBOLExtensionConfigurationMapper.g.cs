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
    <Hash>edb350bb7d7b498775bd54c060b448c4</Hash>
</Codenesium>*/