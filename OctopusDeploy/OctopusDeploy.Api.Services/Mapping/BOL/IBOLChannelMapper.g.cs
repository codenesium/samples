using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLChannelMapper
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
    <Hash>397b31ee58518ff18ea96ce84d353a0a</Hash>
</Codenesium>*/