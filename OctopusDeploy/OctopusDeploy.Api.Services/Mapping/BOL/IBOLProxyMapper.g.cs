using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLProxyMapper
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
    <Hash>c26a63201b22a8b5b645870f94c12daf</Hash>
</Codenesium>*/