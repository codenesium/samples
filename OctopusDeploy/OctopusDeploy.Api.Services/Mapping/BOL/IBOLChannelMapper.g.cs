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
    <Hash>28503c81a2944cc6db3f2fd3e05da138</Hash>
</Codenesium>*/