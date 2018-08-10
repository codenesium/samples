using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLChannelMapper
	{
		BOChannel MapModelToBO(
			string id,
			ApiChannelRequestModel model);

		ApiChannelResponseModel MapBOToModel(
			BOChannel boChannel);

		List<ApiChannelResponseModel> MapBOToModel(
			List<BOChannel> items);
	}
}

/*<Codenesium>
    <Hash>7cdc9717e6214edfa73e1baaa0b517cd</Hash>
</Codenesium>*/