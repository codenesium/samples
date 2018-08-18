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
    <Hash>796700c21ebe594117110c0330bd8090</Hash>
</Codenesium>*/