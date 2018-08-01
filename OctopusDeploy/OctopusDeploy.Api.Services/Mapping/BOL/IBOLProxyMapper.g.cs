using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLProxyMapper
	{
		BOProxy MapModelToBO(
			string id,
			ApiProxyRequestModel model);

		ApiProxyResponseModel MapBOToModel(
			BOProxy boProxy);

		List<ApiProxyResponseModel> MapBOToModel(
			List<BOProxy> items);
	}
}

/*<Codenesium>
    <Hash>742752cd94552ebd7a55669b33e4d0b7</Hash>
</Codenesium>*/