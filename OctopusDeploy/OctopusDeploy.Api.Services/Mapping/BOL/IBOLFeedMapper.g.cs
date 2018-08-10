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
    <Hash>d5828631eef71e65164a8a44d52a65a7</Hash>
</Codenesium>*/