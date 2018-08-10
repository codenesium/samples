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
    <Hash>141178b36fd74b56a3c58b37939d0d7f</Hash>
</Codenesium>*/