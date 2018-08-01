using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLConfigurationMapper
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
    <Hash>ddc89b3c4d8cdb4599d24b91147ade89</Hash>
</Codenesium>*/