using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLFeedMapper
	{
		BOFeed MapModelToBO(
			string id,
			ApiFeedRequestModel model);

		ApiFeedResponseModel MapBOToModel(
			BOFeed boFeed);

		List<ApiFeedResponseModel> MapBOToModel(
			List<BOFeed> items);
	}
}

/*<Codenesium>
    <Hash>acc621393d6f22576a155fe4986882ca</Hash>
</Codenesium>*/