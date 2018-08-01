using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLFeedMapper
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
    <Hash>02124a898b02723137748ef2d293398d</Hash>
</Codenesium>*/