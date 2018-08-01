using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLCommunityActionTemplateMapper
	{
		BOCommunityActionTemplate MapModelToBO(
			string id,
			ApiCommunityActionTemplateRequestModel model);

		ApiCommunityActionTemplateResponseModel MapBOToModel(
			BOCommunityActionTemplate boCommunityActionTemplate);

		List<ApiCommunityActionTemplateResponseModel> MapBOToModel(
			List<BOCommunityActionTemplate> items);
	}
}

/*<Codenesium>
    <Hash>38537389a19e5b593395e4ffbdd7e09a</Hash>
</Codenesium>*/