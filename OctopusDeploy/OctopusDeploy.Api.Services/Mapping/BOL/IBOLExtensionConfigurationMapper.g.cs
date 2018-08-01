using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLExtensionConfigurationMapper
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
    <Hash>786268567d7e16872f9e90b3dfab9d29</Hash>
</Codenesium>*/